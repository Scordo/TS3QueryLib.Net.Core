using System.Threading;
using TS3QueryLib.Net.Core.Common.Notification;
using TS3QueryLib.Net.Core.Server.Notification.Handlers;

namespace TS3QueryLib.Net.Core.Server.Notification
{
    public class NotificationHub : NotificationHubBase
    {
        #region Constructors

        public ClientJoinedNotificationHandler ClientJoined { get; } = new ClientJoinedNotificationHandler();
        public ClientLeavedNotificationHandler ClientLeft { get; } = new ClientLeavedNotificationHandler();
        public ClientMessageNotificationHandler ClientMessage { get; } = new ClientMessageNotificationHandler();
        public ClientMovedNotificationHandler ClientMoved { get; } = new ClientMovedNotificationHandler();
        public TokenUsedNotificationHandler TokenUsed { get; } = new TokenUsedNotificationHandler();


        public NotificationHub() : this(SynchronizationContext.Current)
        {
            
        }

        public NotificationHub(SynchronizationContext synchronizationContext) : base(synchronizationContext)
        {
            AddHandler("notifycliententerview", ClientJoined);
            AddHandler("notifyclientleftview", ClientLeft);
            AddHandler("notifytextmessage", ClientMessage);
            AddHandler("notifyclientmoved", ClientMoved);
            AddHandler("notifytokenused", TokenUsed);
        }

        #endregion
    }
}