using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Notification;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core
{
    public class QueryClient : IQueryClient
    {
        #region Constants

        protected const string CLIENT_GREETING_FIRST_LINE = "TS3 Client" + Util.QUERY_LINE_BREAK;
        protected const string SERVER_GREETING_FIRST_LINE = "TS3" + Util.QUERY_LINE_BREAK;

        #endregion

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
        protected Socket Socket { get; private set; }
        public EndPoint RemoteEndPoint { get; private set; }
        public bool Connected { get; protected set; }
        private StringBuilder ReceivedMessagesBuffer { get; } = new StringBuilder();
        private ConcurrentQueue<string> MessageResponses { get; } = new ConcurrentQueue<string>();
        private Task ReadLoopTask { get; set; }
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
        public QueryClient(string host = null, ushort? port = null, INotificationHub notificationHub = null)
        {
            Host = host ?? "localhost";
            Port = port ?? 10011;
            NotificationHub = notificationHub;
        }
        
        #endregion

        #region Public Methods

        public ConnectResponse Connect()
        {
            return AsyncHelper.RunSync(ConnectAsync);
        }

        public async Task<ConnectResponse> ConnectAsync()
        {
            if (Socket != null)
                return new ConnectResponse(message:"Already connected!");

            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) { ReceiveBufferSize = 4096 };

            IPAddress ipV4;
            RemoteEndPoint = IPAddress.TryParse(Host, out ipV4) ? new IPEndPoint(ipV4, Port) : (EndPoint)new DnsEndPoint(Host, Port);

            await Socket.ConnectAsync(RemoteEndPoint).ConfigureAwait(false);
            string message = await ReadMessageAsync().ConfigureAwait(false);

            QueryType queryType;

            if (message.StartsWith(SERVER_GREETING_FIRST_LINE, StringComparison.OrdinalIgnoreCase))
            {
                queryType = QueryType.Server;
            }
            else if (message.StartsWith(CLIENT_GREETING_FIRST_LINE, StringComparison.OrdinalIgnoreCase))
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
            return new ConnectResponse(message, queryType, true);
        }

        public string Send(string messageToSend)
        {
            return AsyncHelper.RunSync(() => SendAsync(messageToSend));
        }

        public async Task<string> SendAsync(string messageToSend)
        {
            await SendAsync(Socket, messageToSend + "\n").ConfigureAwait(false);

            do
            {
                string result;
                if (MessageResponses.TryDequeue(out result))
                    return result;

                await Task.Delay(TimeSpan.FromMilliseconds(10)).ConfigureAwait(false);
            } while (Connected);

            return null;
        }

        public void Disconnect()
        {
            DisconnectForced(null);
        }

        #endregion

        #region Non Public Methods

        protected async void ReadLoop()
        {
            while (Socket != null)
            {
                string message = await ReadMessageAsync(false).ConfigureAwait(false);

                if (message == null)
                {
                    DisconnectForced("Empty message received from server.");
                    return;
                }

                ReceivedMessagesBuffer.Append(message);

                while (true)
                {
                    Match notifyMatch = GetNotifyResponseMatch(ReceivedMessagesBuffer.ToString());

                    if (notifyMatch.Success)
                    {
                        NotificationHub?.HandleRawNotification(this, notifyMatch.Groups["eventname"].Value, notifyMatch.Value);
                        ReceivedMessagesBuffer.Remove(0, notifyMatch.Length);

                        if (ReceivedMessagesBuffer.Length == 0)
                            break;

                        continue;
                    }

                    Match statusLineMatch = GetStatusLineMatch(ReceivedMessagesBuffer.ToString());

                    if (statusLineMatch.Success)
                    {
                        string responseText = statusLineMatch.Value;

                        // happens when there is a notification between the body and statusline of a command response --> I think this is a bug of ts3
                        if (responseText.Contains("\n\rnotify"))
                        {
                            // extract the notification data and raise notification
                            notifyMatch = GetNotifyResponseMatchBetweenCommandResponse(responseText);
                            string eventName = notifyMatch.Groups["eventname"].Value;
                            NotificationHub?.HandleRawNotification(this, eventName, eventName + notifyMatch.Groups["eventdata"].Value);

                            // modify the response thext used for the command response
                            responseText = notifyMatch.Groups["part1"].Value + notifyMatch.Groups["part2"].Value;
                        }

                        MessageResponses.Enqueue(responseText);
                        ReceivedMessagesBuffer.Remove(0, statusLineMatch.Length);

                        CommandResponse commandResponse = new CommandResponse();
                        commandResponse.ApplyResponseText(responseText);

                        if (commandResponse.IsBanned)
                        {
                            BanDetected?.Invoke(this, new EventArgs<ICommandResponse>(commandResponse));
                            DisconnectForced("Banned!");
                            return;
                        }

                        if (ReceivedMessagesBuffer.Length > 0)
                            continue;
                    }

                    break;
                }
            }
        }

        protected async Task<string> ReadMessageAsync(bool throwOnEmptyMessage = true)
        {
            List<ArraySegment<byte>> buffer = new List<ArraySegment<byte>> { new ArraySegment<byte>(new byte[Socket.ReceiveBufferSize]) };
            int receivedBytes = await Socket.ReceiveAsync(buffer, SocketFlags.None).ConfigureAwait(false);

            if (receivedBytes != 0)
                return Encoding.UTF8.GetString(buffer[0].Array, 0, receivedBytes);

            DisconnectForced("Empty message received from server.");

            if (throwOnEmptyMessage)
                throw new InvalidOperationException("Received no message. Socket got disconnected.");
            
            return null;
        }

        protected static async Task SendAsync(Socket socket, string messageToSend)
        {
            ArraySegment<byte> messageBytes = new ArraySegment<byte>(Encoding.UTF8.GetBytes(messageToSend));
            int sendBytes = await socket.SendAsync(messageBytes, SocketFlags.None).ConfigureAwait(false);

            if (sendBytes != messageBytes.Count)
                throw new InvalidOperationException("Not all bytes were sent correctly!");
        }

        private static Match GetNotifyResponseMatch(string text)
        {
            const string PATTERN = @"^(?<eventname>notify[^\s]+)\s+.+?\x0A\x0D";

            return text.StartsWith("notify", StringComparison.OrdinalIgnoreCase) ? Regex.Match(text, PATTERN, RegexOptions.Singleline) : Match.Empty;
        }

        private static Match GetNotifyResponseMatchBetweenCommandResponse(string text)
        {
            const string PATTERN = @"^(?<part1>.*?\x0A\x0D)(?<eventname>notify[^\s]+)(?<eventdata>\s+.+?)\x0A\x0D(?<part2>.*)$";

            return Regex.Match(text, PATTERN, RegexOptions.Singleline);
        }

        protected static Match GetStatusLineMatch(string responseText)
        {
            const string PATTERN = "((^)|(.*?\\x0A\\x0D))error id=.+?\\x0A\\x0D";

            return responseText.IndexOf("error id=", StringComparison.OrdinalIgnoreCase) != -1 ? Regex.Match(responseText, PATTERN, RegexOptions.Singleline) : Match.Empty;
        }

        private void DisconnectForced(string reason)
        {
            Socket?.Shutdown(SocketShutdown.Both);
            Socket?.Dispose();
            Socket = null;
            Connected = false;
            ReadLoopTask = null;
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
