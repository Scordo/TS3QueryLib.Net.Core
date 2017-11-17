using System;
using System.Threading.Tasks;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core
{
    public interface IQueryClient : ICommandExecutor
    {
        bool Connected { get; }
        string Host { get; }
        int Port { get; }

        QueryClient.ConnectResponse Connect();
        Task<QueryClient.ConnectResponse> ConnectAsync();
        void Disconnect();
        string Send(string messageToSend);
        Task<string> SendAsync(string messageToSend);

        /// <summary>
        /// Raised when a ban was detected
        /// </summary>
        event EventHandler<EventArgs<ICommandResponse>> BanDetected;
        
        /// <summary>
        /// Raised when the connection to the server was closed
        /// </summary>
        event EventHandler<EventArgs<string>> ConnectionClosed;
    }
}