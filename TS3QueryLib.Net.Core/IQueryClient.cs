using System.Net;
using System.Threading.Tasks;

namespace TS3QueryLib.Net.Core
{
    public interface IQueryClient
    {
        bool Connected { get; }
        string Host { get; }
        int Port { get; }
        EndPoint RemoteEndPoint { get; }

        QueryClient.ConnectResponse Connect();
        Task<QueryClient.ConnectResponse> ConnectAsync();
        void Disconnect();
        string Send(string messageToSend);
        Task<string> SendAsync(string messageToSend);
    }
}