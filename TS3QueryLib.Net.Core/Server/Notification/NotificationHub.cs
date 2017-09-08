using System.Threading;
using TS3QueryLib.Net.Core.Common.Notification;
using TS3QueryLib.Net.Core.Server.Commands;
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
        public ChannelEditedNotificationHandler ChannelEdited { get; } = new ChannelEditedNotificationHandler();
        public ChannelCreatedNotificationHandler ChannelCreated { get; } = new ChannelCreatedNotificationHandler();
        public ChannelMovedNotificationHandler ChannelMoved { get; } = new ChannelMovedNotificationHandler();
        public ChannelDeletedNotificationHandler ChannelDeleted { get; } = new ChannelDeletedNotificationHandler();
        public ChannelDescriptionChangedNotificationHandler ChannelDescriptionChanged { get; } = new ChannelDescriptionChangedNotificationHandler();
        public ChannelPasswordChangedNotificationHandler ChannelPasswordChanged { get; } = new ChannelPasswordChangedNotificationHandler();
        public ServerEditedNotificationHandler ServerEdited { get; } = new ServerEditedNotificationHandler();
        public UnknownNotificationHandler UnknownNotificationReceived { get; } = new UnknownNotificationHandler();


        public NotificationHub() : this(SynchronizationContext.Current)
        {
            
        }

        public NotificationHub(SynchronizationContext synchronizationContext) : base(synchronizationContext)
        {
            AddHandler("notifycliententerview", ClientJoined);
            AddHandler("notifyclientleftview", ClientLeft);
            AddHandler("notifytextmessage", ClientMessage);
            AddHandler("notifyclientmoved", ClientMoved);
            AddHandler("notifychanneledited", ChannelEdited);
            AddHandler("notifychannelcreated", ChannelCreated);
            AddHandler("notifychannelmoved", ChannelMoved);
            AddHandler("notifychanneldeleted", ChannelDeleted);
            AddHandler("notifychanneldescriptionchanged", ChannelDescriptionChanged);
            AddHandler("notifychannelpasswordchanged", ChannelPasswordChanged);
            AddHandler("notifyserveredited", ServerEdited);
            AddHandler("notifytokenused", TokenUsed);
            AddHandler("*", UnknownNotificationReceived);
        }

        #endregion
    }
}