using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Common.Notification;
using TS3QueryLib.Net.Core.Server.Notification.EventArgs;

namespace TS3QueryLib.Net.Core.Server.Notification.Handlers
{
    public class ClientMovedNotificationHandler : INotificationHandler
    {
        public event EventHandler<ClientMovedEventArgs> JoiningChannel;
        public event EventHandler<ClientMovedEventArgs> CreatingTemporaryChannel;
        public event EventHandler<ClientMovedByClientEventArgs> JoiningChannelForced;

        void INotificationHandler.HandleResponse(IQueryClient queryClient, string responseText)
        {
            CommandParameterGroupList parameterGroupList = CommandParameterGroupList.Parse(responseText);

            int? invokerId = parameterGroupList.GetParameterValue<int?>("invokerid");

            if (!invokerId.HasValue)
            {
                JoiningChannel?.Invoke(queryClient, new ClientMovedEventArgs(parameterGroupList));
                return;
            }

            if (invokerId == 0)
                CreatingTemporaryChannel?.Invoke(queryClient, new ClientMovedEventArgs(parameterGroupList));
            else
                JoiningChannelForced?.Invoke(queryClient, new ClientMovedByClientEventArgs(parameterGroupList));
        }
    }
}