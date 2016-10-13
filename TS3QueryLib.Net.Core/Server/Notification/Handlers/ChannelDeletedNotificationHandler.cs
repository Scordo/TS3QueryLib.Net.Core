using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Common.Notification;
using TS3QueryLib.Net.Core.Server.Notification.EventArgs;

namespace TS3QueryLib.Net.Core.Server.Notification.Handlers
{
    public class ChannelDeletedNotificationHandler : INotificationHandler
    {
        public event EventHandler<ChannelDeletedEventArgs> Triggered;

        void INotificationHandler.HandleResponse(IQueryClient queryClient, string responseText)
        {
            Triggered?.Invoke(queryClient, new ChannelDeletedEventArgs(CommandParameterGroupList.Parse(responseText)));
        }
    }
}