using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Common.Notification;
using TS3QueryLib.Net.Core.Server.Notification.EventArgs;

namespace TS3QueryLib.Net.Core.Server.Notification.Handlers
{
    public class ClientLeavedNotificationHandler : INotificationHandler
    {
        public event EventHandler<ClientKickEventArgs> Kicked;
        public event EventHandler<ClientBanEventArgs> Banned;
        public event EventHandler<ClientConnectionLostEventArgs> ConnectionLost;
        public event EventHandler<ClientDisconnectEventArgs> Disconnected;

        void INotificationHandler.HandleResponse(IQueryClient queryClient, string responseText)
        {
            CommandParameterGroupList parameterGroupList = CommandParameterGroupList.Parse(responseText);

            int? reasonId = parameterGroupList.GetParameterValue<int?>("reasonid")??8;
            
            switch ((ClientLeftReason)reasonId.Value)
            {
                case ClientLeftReason.Kicked:
                    Kicked?.Invoke(queryClient, new ClientKickEventArgs(parameterGroupList));
                    break;
                case ClientLeftReason.Banned:
                    Banned?.Invoke(queryClient, new ClientBanEventArgs(parameterGroupList));
                    break;
                case ClientLeftReason.ConnectionLost:
                    ConnectionLost?.Invoke(queryClient, new ClientConnectionLostEventArgs(parameterGroupList));
                    break;
                case ClientLeftReason.Disconnect:
                    Disconnected?.Invoke(queryClient, new ClientDisconnectEventArgs(parameterGroupList));
                    break;
            }
        }
    }
}