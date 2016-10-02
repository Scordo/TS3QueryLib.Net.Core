using System;
using System.Threading;
using TS3QueryLib.Net.Core;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.Commands;
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

            QueryClient client = new QueryClient(notificationHub: notifications);
            client.BanDetected += Client_BanDetected;
            client.ConnectionClosed += Client_ConnectionClosed;
            Connect(client);

            // username and password are random and only valid on my dev box. So dont bother
            Console.WriteLine("Admin login:" + !new LoginCommand("serveradmin", "RWkzzXu9").Execute(client).IsErroneous);
            Console.WriteLine("Switch to server with port 9987: " + !new UseCommand(9987).Execute(client).IsErroneous);

            uint? channelId = 1;
            Console.WriteLine("Register notify [Server]: "+ !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.Server).Execute(client).IsErroneous);
            Console.WriteLine("Register notify [Channel]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.Channel, channelId).Execute(client).IsErroneous);
            Console.WriteLine("Register notify [Channel-Text]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.TextChannel, channelId).Execute(client).IsErroneous);
            Console.WriteLine("Register notify [Server-Text]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.TextServer).Execute(client).IsErroneous);
            Console.WriteLine("Register notify [Private-Text]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.TextPrivate).Execute(client).IsErroneous);
            Console.WriteLine("Register notify [TokenUsed]: " + !new ServerNotifyRegisterCommand(ServerNotifyRegisterEvent.TokenUsed).Execute(client).IsErroneous);
            

            //Console.WriteLine(new ServerListCommand(true).Execute(client).GetDumpString());
            

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

        private static void Client_BanDetected(object sender, EventArgs<TS3QueryLib.Net.Core.Common.Responses.ICommandResponse> e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!! BAN DETECTED !!!");
            Console.ResetColor();
        }

        private static void TokenUsed_Triggered(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.TokenUsedEventArgs e)
        {
            Console.WriteLine($"Token-Usage: ClientId:{e.ClientId}, Token={e.TokenText}");
        }

        private static void ClientMoved_JoiningChannelForced(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.ClientMovedByClientEventArgs e)
        {
            Console.WriteLine($"Move: Type=Forced, ClientId={e.ClientId}, TargetChannelId={e.TargetChannelId}, Invoker={e.InvokerNickname}");
        }

        private static void ClientMoved_CreatingTemporaryChannel(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.ClientMovedEventArgs e)
        {
            Console.WriteLine($"Move: Type=TempChannel, ClientId={e.ClientId}, TargetChannelId={e.TargetChannelId}");
        }

        private static void ClientMoved_JoiningChannel(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.ClientMovedEventArgs e)
        {
            Console.WriteLine($"Move: Type=Self, ClientId={e.ClientId}, TargetChannelId={e.TargetChannelId}");
        }

        private static void ClientMessage_ReceivedFromServer(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.MessageReceivedEventArgs e)
        {
            Console.WriteLine($"[Server] Message from {e.InvokerNickname}: {e.Message}");
        }

        private static void ClientMessage_ReceivedFromChannel(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.MessageReceivedEventArgs e)
        {
            Console.WriteLine($"[Channel] Message from {e.InvokerNickname}: {e.Message}");
        }

        private static void ClientMessage_ReceivedFromClient(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.MessageReceivedEventArgs e)
        {
            Console.WriteLine($"[Client] Message from {e.InvokerNickname}: {e.Message}");
        }

        private static void ClientLeft_Banned(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.ClientBanEventArgs e)
        {
            Console.WriteLine($"Banned: {e.VictimClientId}");
        }

        private static void ClientLeft_ConnectionLost(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.ClientConnectionLostEventArgs e)
        {
            Console.WriteLine($"Connection lost: {e.ClientId}");
        }

        private static void ClientLeft_Disconnected(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.ClientDisconnectEventArgs e)
        {
            Console.WriteLine($"Disconnected: {e.ClientId}");
        }

        private static void ClientLeft_Kicked(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.ClientKickEventArgs e)
        {
            Console.WriteLine($"Kicked: {e.VictimClientId}");
        }

        private static void ClientJoined_Triggered(object sender, TS3QueryLib.Net.Core.Server.Notification.EventArgs.ClientJoinedEventArgs e)
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
    }
}
