using System;
using System.IO;
using System.Linq;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Server.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;
using TS3QueryLib.Net.Core.Server.Notification;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.TestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NotificationHub notifications = new NotificationHub();
            notifications.ClientJoined.Triggered += ClientJoined_Triggered;
            notifications.ClientLeft.Kicked += ClientLeft_Kicked;
            notifications.ClientLeft.Disconnected += ClientLeft_Disconnected;
            notifications.ClientLeft.ConnectionLost += ClientLeft_ConnectionLost;
            notifications.ClientLeft.Banned += ClientLeft_Banned;
            notifications.ClientMessage.ReceivedFromClient += ClientMessage_ReceivedFromClient;
            notifications.ClientMessage.ReceivedFromChannel += ClientMessage_ReceivedFromChannel;
            notifications.ClientMessage.ReceivedFromServer += ClientMessage_ReceivedFromServer;
            notifications.ClientMoved.JoiningChannel += ClientMoved_JoiningChannel;
            notifications.ClientMoved.CreatingTemporaryChannel += ClientMoved_CreatingTemporaryChannel;
            notifications.ClientMoved.JoiningChannelForced += ClientMoved_JoiningChannelForced;
            notifications.TokenUsed.Triggered += TokenUsed_Triggered;
            notifications.ChannelEdited.Triggered += ChannelEdited_Triggered;
            notifications.ChannelCreated.Triggered += ChannelCreated_Triggered;
            notifications.ChannelMoved.Triggered += ChannelMoved_Triggered;
            notifications.ChannelDeleted.Triggered += ChannelDeleted_Triggered;
            notifications.ChannelDescriptionChanged.Triggered += ChannelDescriptionChanged_Triggered;
            notifications.ChannelPasswordChanged.Triggered += ChannelPasswordChanged_Triggered;
            notifications.UnknownNotificationReceived.Triggered += UnknownNotificationReceived_Triggered;

            QueryClient client = new QueryClient(notificationHub: notifications);
            client.BanDetected += Client_BanDetected;
            client.ConnectionClosed += Client_ConnectionClosed;
            Connect(client);

            // username and password are random and only valid on my dev box. So dont bother
            Console.WriteLine("Admin login:" + !new LoginCommand("serveradmin", "RWkzzXu9").Execute(client).IsErroneous);
            Console.WriteLine("Switch to server with port 9987: " + !new UseCommand(9987).Execute(client).IsErroneous);

            Console.WriteLine("Register notify [Server]: "+ !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.Server).Execute(client).IsErroneous);
            Console.WriteLine("Register notify [Channel]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.Channel, 0).Execute(client).IsErroneous); // 0 = all channels
            Console.WriteLine("Register notify [Channel-Text]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.TextChannel, 1).Execute(client).IsErroneous);
            Console.WriteLine("Register notify [Server-Text]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.TextServer).Execute(client).IsErroneous);
            Console.WriteLine("Register notify [Private-Text]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.TextPrivate).Execute(client).IsErroneous);
            Console.WriteLine("Register notify [TokenUsed]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.TokenUsed).Execute(client).IsErroneous);

            Console.WriteLine("Type a command or press [ENTER] to quit");

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Command: ");
                Console.ResetColor();

                string commandText = Console.ReadLine();

                if (commandText.Length == 0)
                {
                    new LogoutCommand().Execute(client);
                    break;
                }

                string response = client.Send(commandText);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Response: ");
                Console.ResetColor();
                Console.WriteLine(response);
            }
            while (client.Connected);
            
            Console.WriteLine("Bye Bye!");
        }
        
        private static void Client_ConnectionClosed(object sender, EventArgs<string>  e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Connection lost: {e.Value}");
            Console.ResetColor();
        }

        private static void Client_BanDetected(object sender, EventArgs<Common.Responses.ICommandResponse> e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! BAN DETECTED !!!");
            Console.ResetColor();
        }

        private static void UnknownNotificationReceived_Triggered(object sender, Server.Notification.EventArgs.UnknownNotificationEventArgs e)
        {
            Console.WriteLine($"Unknown notification: [Name:{e.Name}] [ResponseText:{e.ResponseText}]");
        }

        private static void ChannelPasswordChanged_Triggered(object sender, Server.Notification.EventArgs.ChannelPasswordChangedEventArgs e)
        {
            Console.WriteLine($"Channel password changed: Channel password of channel with id {e.ChannelId} has changed.");
        }

        private static void ChannelDescriptionChanged_Triggered(object sender, Server.Notification.EventArgs.ChannelDescriptionChangedEventArgs e)
        {
            Console.WriteLine($"Channel description changed: Channel description of channel with id {e.ChannelId} has changed.");
        }

        private static void ChannelDeleted_Triggered(object sender, Server.Notification.EventArgs.ChannelDeletedEventArgs e)
        {
            Console.WriteLine($"Channel Delete: Channel with Id {e.ChannelId} was deleted by {e.InvokerName}.");
        }

        private static void ChannelMoved_Triggered(object sender, Server.Notification.EventArgs.ChannelMovedEventArgs e)
        {
            Console.WriteLine($"Channel move: Channel with Id {e.ChannelId}, parent channel id {e.ParentChannelId} and order {e.Order} was moved by {e.InvokerName} for reason with id  {e.ReasonId}");
        }

        private static void ChannelCreated_Triggered(object sender, Server.Notification.EventArgs.ChannelCreatedEventArgs e)
        {
            Console.WriteLine($"Channel Create: Channel with Id {e.ChannelId} was created by {e.InvokerName}");
        }

        private static void ChannelEdited_Triggered(object sender, Server.Notification.EventArgs.ChannelEditedEventArgs e)
        {
            Console.WriteLine($"Channel Edit: Channel with Id {e.ChannelId} was edited by {e.InvokerName} for reason with id {e.ReasonId}");
        }

        private static void TokenUsed_Triggered(object sender, Server.Notification.EventArgs.TokenUsedEventArgs e)
        {
            Console.WriteLine($"Token-Usage: ClientId:{e.ClientId}, Token={e.TokenText}");
        }

        private static void ClientMoved_JoiningChannelForced(object sender, Server.Notification.EventArgs.ClientMovedByClientEventArgs e)
        {
            Console.WriteLine($"Move: Type=Forced, ClientId={e.ClientId}, TargetChannelId={e.TargetChannelId}, Invoker={e.InvokerNickname}");
        }

        private static void ClientMoved_CreatingTemporaryChannel(object sender, Server.Notification.EventArgs.ClientMovedEventArgs e)
        {
            Console.WriteLine($"Move: Type=TempChannel, ClientId={e.ClientId}, TargetChannelId={e.TargetChannelId}");
        }

        private static void ClientMoved_JoiningChannel(object sender, Server.Notification.EventArgs.ClientMovedEventArgs e)
        {
            Console.WriteLine($"Move: Type=Self, ClientId={e.ClientId}, TargetChannelId={e.TargetChannelId}");
        }

        private static void ClientMessage_ReceivedFromServer(object sender, Server.Notification.EventArgs.MessageReceivedEventArgs e)
        {
            Console.WriteLine($"[Server] Message from {e.InvokerNickname}: {e.Message}");
        }

        private static void ClientMessage_ReceivedFromChannel(object sender, Server.Notification.EventArgs.MessageReceivedEventArgs e)
        {
            Console.WriteLine($"[Channel] Message from {e.InvokerNickname}: {e.Message}");
        }

        private static void ClientMessage_ReceivedFromClient(object sender, Server.Notification.EventArgs.MessageReceivedEventArgs e)
        {
            Console.WriteLine($"[Client] Message from {e.InvokerNickname}: {e.Message}");
        }

        private static void ClientLeft_Banned(object sender, Server.Notification.EventArgs.ClientBanEventArgs e)
        {
            Console.WriteLine($"Banned: {e.VictimClientId}");
        }

        private static void ClientLeft_ConnectionLost(object sender, Server.Notification.EventArgs.ClientConnectionLostEventArgs e)
        {
            Console.WriteLine($"Connection lost: {e.ClientId}");
        }

        private static void ClientLeft_Disconnected(object sender, Server.Notification.EventArgs.ClientDisconnectEventArgs e)
        {
            Console.WriteLine($"Disconnected: {e.ClientId}");
        }

        private static void ClientLeft_Kicked(object sender, Server.Notification.EventArgs.ClientKickEventArgs e)
        {
            Console.WriteLine($"Kicked: {e.VictimClientId}");
        }

        private static void ClientJoined_Triggered(object sender, Server.Notification.EventArgs.ClientJoinedEventArgs e)
        {
            Console.WriteLine($"Joined: {e.Nickname}");
        }

        private static void Connect(QueryClient client)
        {
            QueryClient.ConnectResponse connectResponse = client.Connect();

            Console.WriteLine($"Connected: {connectResponse.Success}");
            Console.WriteLine($"Query-Target: {connectResponse.QueryType}");
            Console.WriteLine($"Greeting: {connectResponse.Greeting}");
        }

        private static readonly Random _randomForFileClientTransferId = new Random();

        private static void DownloadFirstFileInCurrentChannel(QueryClient queryClient, string targetDirectory)
        {
            // get the channel we're currenlty in
            uint channelId = new WhoAmICommand().Execute(queryClient).ChannelId;

            // create a rondom id for the file transfer
            uint randomClientId = (uint)_randomForFileClientTransferId.Next(1,10000);
            
            // get the first file in the current channel
            FileTransferFileEntry firstFile = new FtGetFileListCommand(channelId, "/").Execute(queryClient).Values.FirstOrDefault();

            // initialize the file transfer to get the server file transfer key
            FtInitDownloadCommandResponse ftInitDownloadResponse = new FtInitDownloadCommand(randomClientId, "/"+firstFile.Name, firstFile.ChannelId, 0).Execute(queryClient);

            // calculate the target file path
            string fileName = firstFile.Name.Substring(firstFile.Name.LastIndexOf("/", StringComparison.Ordinal) + 1);
            string targetFilePath = Path.Combine(targetDirectory, fileName);

            // create the file transfer cleint with the host of the query client and the port we got from the init download response
            FileTransferClient transferClient = new FileTransferClient(queryClient.Host, ftInitDownloadResponse.FileTransferPort ?? 30033);

            // download the file synchron
            transferClient.DownloadFile(ftInitDownloadResponse.FileTransferKey, ftInitDownloadResponse.FileSize.Value, targetFilePath);
        }

        private static void UploadFileToCurrentChannel(QueryClient queryClient, string sourceFilePath)
        {
            // get the channel we're currenlty in
            uint channelId = new WhoAmICommand().Execute(queryClient).ChannelId;

            // create a rondom id for the file transfer
            uint randomClientId = (uint)_randomForFileClientTransferId.Next(1, 10000);

            // get only the filename
            FileInfo sourceFileInfo = new FileInfo(sourceFilePath);

            // initialize the file transfer to get the server file transfer key
            FtInitUploadCommandResponse ftInitUploadCommandResponse = new FtInitUploadCommand(randomClientId, "/" + sourceFileInfo.Name, channelId, (ulong) sourceFileInfo.Length, true, false).Execute(queryClient);
            
            // create the file transfer cleint with the host of the query client and the port we got from the init download response
            FileTransferClient transferClient = new FileTransferClient(queryClient.Host, ftInitUploadCommandResponse.FileTransferPort ?? 30033);

            // upload the file synchron
            transferClient.UploadFile(ftInitUploadCommandResponse.FileTransferKey, (ulong)sourceFileInfo.Length, sourceFileInfo.FullName);
        }
    }
}