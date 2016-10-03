using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TS3QueryLib.Net.Core
{
    public class FileTransferClient
    {
        #region Constants

        private const int RECEIVE_BUFFER_SIZE = 4 * 1024; // 1 MB
        private const int SEND_BUFFER_SIZE = 4 * 1024; // 1 MB

        #endregion

        #region Properties

        public string Host { get; }
        public ushort Port { get; }
    
        #endregion

        #region Constructor

        public FileTransferClient(string host, ushort port)
        {
            if (host == null)
                throw new ArgumentNullException(nameof(host));

            Host = host;
            Port = port;
        }

        #endregion

        #region Public Methods

        public void DownloadFile(string fileTransferKey, ulong size, string targetFilePath)
        {
            AsyncHelper.RunSync(() => DownloadFileAsync(fileTransferKey, size, targetFilePath));
        }

        public async Task DownloadFileAsync(string fileTransferKey, ulong size, string targetFilePath)
        {
            using (FileStream fileStream = File.Create(targetFilePath))
            {
                await DownloadFileAsync(fileTransferKey, size, fileStream).ConfigureAwait(false);
            }
        }

        public void DownloadFile(string fileTransferKey, ulong size, Stream downloadStream)
        {
            AsyncHelper.RunSync(() => DownloadFileAsync(fileTransferKey, size, downloadStream));
        }

        public async Task DownloadFileAsync(string fileTransferKey, ulong size, Stream downloadStream)
        {
            if (fileTransferKey == null)
                throw new ArgumentNullException(nameof(fileTransferKey));

            if (fileTransferKey.Length != 32)
                throw new ArgumentOutOfRangeException(nameof(fileTransferKey), "fileTransferKey must have a length of 32 characters");
            
            if (downloadStream == null)
                throw new ArgumentNullException(nameof(downloadStream));

            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) {ReceiveBufferSize = RECEIVE_BUFFER_SIZE, SendBufferSize = SEND_BUFFER_SIZE})
            {
                IPAddress ipV4;
                EndPoint endPoint = IPAddress.TryParse(Host, out ipV4) ? new IPEndPoint(ipV4, Port) : (EndPoint) new DnsEndPoint(Host, Port);

                await socket.ConnectAsync(endPoint).ConfigureAwait(false);
                byte[] transferKeyBytes = Encoding.UTF8.GetBytes(fileTransferKey);

                int sentTransferKeyBytes = await SendAsync(socket, transferKeyBytes).ConfigureAwait(false);

                if (sentTransferKeyBytes != transferKeyBytes.Length)
                    throw new InvalidOperationException("Not all bytes were sent correctly!");

                uint processedBytesCount = 0;
                do
                {
                    byte[] bufferToWrite = await ReadMessageAsync(socket).ConfigureAwait(false);

                    if (bufferToWrite.Length == 0)
                        throw new InvalidOperationException($"File download failed and was aborted after reading ${processedBytesCount} of {size} bytes.");

                    processedBytesCount += (uint) bufferToWrite.Length;
                    await downloadStream.WriteAsync(bufferToWrite, 0, bufferToWrite.Length).ConfigureAwait(false);
                }
                while (processedBytesCount < size);

                if (processedBytesCount > size)
                    throw new InvalidOperationException($"File download failed and was aborted. Received too many bytes: ${processedBytesCount} of {size}.");
            }
        }
        
        #endregion
        
        #region Non Public Methods

        protected static async Task<int> SendAsync(Socket socket, byte[] bytesToSend)
        {
            ArraySegment<byte> messageBytes = new ArraySegment<byte>(bytesToSend);
            return await socket.SendAsync(messageBytes, SocketFlags.None).ConfigureAwait(false);       
        }

        protected async Task<byte[]> ReadMessageAsync(Socket socket)
        {
            List<ArraySegment<byte>> buffer = new List<ArraySegment<byte>> { new ArraySegment<byte>(new byte[socket.ReceiveBufferSize]) };
            int receivedBytes = await socket.ReceiveAsync(buffer, SocketFlags.None).ConfigureAwait(false);

            if (receivedBytes == 0)
                return new byte[0];

            byte[] resultBytes = new byte[receivedBytes];
            Array.Copy(buffer.First().Array, 0, resultBytes, 0, receivedBytes);
            
            return resultBytes;
        }

        #endregion
    }
}