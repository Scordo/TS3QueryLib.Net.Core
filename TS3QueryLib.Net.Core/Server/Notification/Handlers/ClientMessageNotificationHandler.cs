using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Common.Notification;
using TS3QueryLib.Net.Core.Server.Notification.EventArgs;

namespace TS3QueryLib.Net.Core.Server.Notification.Handlers
{
    public class ClientMessageNotificationHandler : INotificationHandler
    {
        public event EventHandler<MessageReceivedEventArgs> ReceivedFromServer;
        public event EventHandler<MessageReceivedEventArgs> ReceivedFromChannel;
        public event EventHandler<MessageReceivedEventArgs> ReceivedFromClient;

        void INotificationHandler.HandleResponse(IQueryClient queryClient, string responseText)
        {
            CommandParameterGroupList parameterGroupList = CommandParameterGroupList.Parse(responseText);

            MessageTarget messageTarget = (MessageTarget)parameterGroupList.GetParameterValue<uint>("targetmode");

            switch (messageTarget)
            {
                case MessageTarget.Client:
                    ReceivedFromClient?.Invoke(queryClient, new MessageReceivedEventArgs(parameterGroupList));
                    break;
                case MessageTarget.Channel:
                    ReceivedFromChannel?.Invoke(queryClient, new MessageReceivedEventArgs(parameterGroupList));
                    break;
                case MessageTarget.Server:
                    ReceivedFromServer?.Invoke(queryClient, new MessageReceivedEventArgs(parameterGroupList));
                    break;
            }
        }
    }
}