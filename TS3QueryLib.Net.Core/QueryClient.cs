using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Notification;
using TS3QueryLib.Net.Core.Common.Responses;
using TS3QueryLib.Net.Core.Server.Commands;

namespace TS3QueryLib.Net.Core
{
    public class QueryClient : IQueryClient
    {
        #region Events

        /// <summary>
        /// Raised when a ban was detected
        /// </summary>
        public event EventHandler<EventArgs<ICommandResponse>> BanDetected;

        /// <summary>
        /// Raised when the connection to the server was closed
        /// </summary>
        public event EventHandler<EventArgs<string>> ConnectionClosed;
        
        #endregion

        #region Properties

        public string Host { get; }
        public int Port { get; }
        protected INotificationHub NotificationHub { get; }
        protected TimeSpan? KeepAliveInterval { get; }
        public bool Connected { get; protected set; }
        public int? LastServerConnectionHandlerId { get; private set; }

        private List<string> ReceivedLines { get; } = new List<string>();
        private bool AtLeastOneResponseReceived { get; set; }
        private ConcurrentQueue<string> MessageResponses { get; } = new ConcurrentQueue<string>();
        private Task ReadLoopTask { get; set; }
        private Task KeepAliveTask { get; set; }

        private TcpClient Client { get; set; }
        private StreamReader ClientReader { get; set; }
        private StreamWriter ClientWriter { get; set; }
        private NetworkStream ClientStream { get; set; }
        private SemaphoreSlim SendLock { get; } = new SemaphoreSlim(1,1);
        private ICommunicationLog CommunicationLog { get; set; } = new VoidCommunicationLog();
        private string LastRawNotification { get; set; } = "";
        private DateTime LastNotificationTime { get; set; } = new DateTime(2000, 1, 1);

        /// <summary>
        /// Gets or sets an optional predicate action which is executed before a command is sent. If the predicate action returns <value>true</value>, the command is sent, otherwise not.
        /// </summary>
        public Func<ICommand, IQueryClient, bool> SendCommandValidationPredicate { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of the current class
        /// </summary>
        /// <param name="host">The host to connect to</param>
        /// <param name="port">The port to connect to</param>
        /// <param name="notificationHub">An optional hub wich will handle notifications</param>
        /// <param name="keepAliveInterval">The keep alive interval used to send heart beats in a specific interval to the server to not get timed out (disconnected)</param>
        public QueryClient(string host = null, ushort? port = null, INotificationHub notificationHub = null, TimeSpan? keepAliveInterval = null)
        {
            Host = host ?? "localhost";
            Port = port ?? 10011;
            NotificationHub = notificationHub;
            KeepAliveInterval = keepAliveInterval;
        }

        #endregion

        #region Public Methods

        public ConnectResponse Connect()
        {
            return AsyncHelper.RunSync(ConnectAsync);
        }

        public async Task<ConnectResponse> ConnectAsync()
        {
            if (Client != null)
                return new ConnectResponse(message: "Already connected!");

            Client = new TcpClient();
            await Client.ConnectAsync(Host, Port).ConfigureAwait(false);

            if (!Client.Connected)
                throw new IOException($"Could not connect to {Host} on port {Port}.");

            ReceivedLines.Clear();
            AtLeastOneResponseReceived = false;
            ClientStream = Client.GetStream();
            ClientReader = new StreamReader(ClientStream);
            ClientWriter = new StreamWriter(ClientStream) { NewLine = "\n" };

            string message = await ReadLineAsync().ConfigureAwait(false);
            CommunicationLog.RawMessageReceived(message);

            QueryType queryType;

            if (message.StartsWith("TS3", StringComparison.OrdinalIgnoreCase))
            {
                queryType = QueryType.Server;
            }
            else if (message.StartsWith("TS3 Client", StringComparison.OrdinalIgnoreCase))
            {
                queryType = QueryType.Client;
            }
            else
            {
                string statusMessage = $"Invalid greeting received: {message}";
                DisconnectForced(statusMessage);
                return new ConnectResponse(statusMessage);
            }

            Connected = true;
            ReadLoopTask = Task.Factory.StartNew(ReadLoop, TaskCreationOptions.LongRunning);
            KeepAliveTask = Task.Factory.StartNew(KeepAliveLoop, TaskCreationOptions.LongRunning);
            return new ConnectResponse(message, queryType, true);
        }

        public string Send(string messageToSend)
        {
            return AsyncHelper.RunSync(() => SendAsync(messageToSend));
        }

        public async Task<string> SendAsync(string messageToSend)
        {
            await SendLock.WaitAsync();

            try
            {
                CommunicationLog.RawMessageSending(messageToSend);
                await SendAsync(ClientWriter, messageToSend);
                CommunicationLog.RawMessageSent(messageToSend);

                do
                {
                    if (MessageResponses.TryDequeue(out var result))
                        return result;

                    await Task.Delay(TimeSpan.FromMilliseconds(10)).ConfigureAwait(false);
                } while (Connected);

                return null;
            }
            finally
            {
                SendLock.Release();
            }
        }

        public void SetCommunicationLog(ICommunicationLog log)
        {
            CommunicationLog = log ?? new VoidCommunicationLog();
        }

        private static async Task SendAsync(StreamWriter writer, string messageToSend)
        {
            ConfiguredTaskAwaitable? writeLineAwaitable = writer?.WriteLineAsync(messageToSend).ConfigureAwait(false);

            if (writeLineAwaitable.HasValue)
                await writeLineAwaitable.Value;

            ConfiguredTaskAwaitable? flushAwaitable = writer?.FlushAsync().ConfigureAwait(false);
            if (flushAwaitable.HasValue)
                await flushAwaitable.Value;
        }

        public void Disconnect()
        {
            DisconnectForced(null);
        }

        #endregion

        #region Non Public Methods

        protected async void KeepAliveLoop()
        {
            while (Client != null && KeepAliveInterval.HasValue)
            {
                await Task.Delay(KeepAliveInterval.Value);
                await SendAsync("version");
            }
        }

        protected async void ReadLoop()
        {
            while (Client != null && Client.Connected)
            {
                string message = await ReadLineAsync(false).ConfigureAwait(false);
                CommunicationLog.RawMessageReceived(message);

                if (message == null)
                    continue;

                if (message.StartsWith("error", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!AtLeastOneResponseReceived)
                    {
                        AtLeastOneResponseReceived = true;
                        // Remove welcome messages after connect
                        ReceivedLines.Clear();
                    }

                    string responseText = string.Join(Util.QUERY_LINE_BREAK, ReceivedLines.Concat(new[] { message }));
                    MessageResponses.Enqueue(responseText);
                    ReceivedLines.Clear();

                    CommandResponse commandResponse = new CommandResponse();
                    commandResponse.ApplyResponseText(responseText);

                    if (commandResponse.IsBanned)
                    {
                        BanDetected?.Invoke(this, new EventArgs<ICommandResponse>(commandResponse));
                        DisconnectForced("Banned!");
                        return;
                    }
                }
                else if (message.StartsWith("notify", StringComparison.CurrentCultureIgnoreCase))
                {
                    // If 2 or more notifications are equal in a 200ms range, consider just one of them.
                    if (LastRawNotification == message && (DateTime.Now - LastNotificationTime).TotalMilliseconds < 200)
                        continue;
                        
                    LastRawNotification = message;
                    LastNotificationTime = DateTime.Now;

                    int indexOfFirstWhitespace = message.IndexOf(' ');
                    string notificationName = message.Substring(0, indexOfFirstWhitespace);

                    NotificationHub?.HandleRawNotification(this, notificationName, message);
                }
                else
                {
                    if (!AtLeastOneResponseReceived)
                    {
                        const string LastServerConnectionHandlerIdText = "selected schandlerid=";

                        if (message.StartsWith(LastServerConnectionHandlerIdText, StringComparison.CurrentCultureIgnoreCase) && int.TryParse(message.Substring(LastServerConnectionHandlerIdText.Length).Trim(), out int handlerId))
                            LastServerConnectionHandlerId = handlerId;
                    }

                    ReceivedLines.Add(message);
                }
            }
        }

        protected async Task<string> ReadLineAsync(bool throwOnEmptyMessage = true)
        {
            ConfiguredTaskAwaitable<string>? readLineAwaitable = ClientReader?.ReadLineAsync().ConfigureAwait(false);
            string message = readLineAwaitable.HasValue ? await readLineAwaitable.Value : null;

            if (message != null)
                return message;

            DisconnectForced("Empty message received from server.");

            if (throwOnEmptyMessage)
                throw new InvalidOperationException("Received no message. Socket got disconnected.");

            return null;
        }

        private void DisconnectForced(string reason)
        {
            bool clientWasConnected = Client?.Connected == true;
            ReceivedLines.Clear();
            Client?.Dispose();
            ClientStream?.Dispose();
            ClientReader?.Dispose();
            ClientWriter?.Dispose();

            Client = null;
            ClientStream = null;
            ClientReader = null;
            ClientWriter = null;

            Connected = false;
            ReadLoopTask = null;
            KeepAliveTask = null;

            if (clientWasConnected)
                ConnectionClosed?.Invoke(this, new EventArgs<string>(reason));
        }


        #endregion

        #region ICommandExecutor Implementation

        string ICommandExecutor.Execute(ICommand command)
        {
            return SendCommandValidationPredicate?.Invoke(command, this) == false ? @"error id=256 msg=command\snot\ssent" : Send(command?.ToString());
        }

        async Task<string> ICommandExecutor.ExecuteAsync(ICommand command)
        {
            return SendCommandValidationPredicate != null && !await Task.Run(() => SendCommandValidationPredicate(command, this)) ? @"error id=256 msg=command\snot\ssent" : await SendAsync(command?.ToString()).ConfigureAwait(false);
        }

        #endregion

        #region Embedded Types

        public enum QueryType { Server, Client }

        public class ConnectResponse
        {
            public string Greeting { get; }
            public QueryType? QueryType { get; }

            public bool Success { get; }
            public string Message { get; set; }

            public ConnectResponse(string greeting = null, QueryType? queryType = null, bool success = false, string message = null)
            {
                Greeting = greeting;
                QueryType = queryType;
                Success = success;
                Message = message;
            }
        }

        #endregion
    }
}
