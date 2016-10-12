using System;
using System.Linq;
using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Common.Notification;
using TS3QueryLib.Net.Core.Server.Notification.EventArgs;

namespace TS3QueryLib.Net.Core.Server.Notification.Handlers
{
    public class UnknownNotificationHandler : INotificationHandler
    {
        public event EventHandler<UnknownNotificationEventArgs> Triggered;

        void INotificationHandler.HandleResponse(IQueryClient queryClient, string responseText)
        {
            CommandParameterGroupList commandParameterGroupList = CommandParameterGroupList.Parse(responseText);
            Triggered?.Invoke(queryClient, new UnknownNotificationEventArgs(commandParameterGroupList.First()?.First()?.Name, commandParameterGroupList, responseText));
        }
    }
}