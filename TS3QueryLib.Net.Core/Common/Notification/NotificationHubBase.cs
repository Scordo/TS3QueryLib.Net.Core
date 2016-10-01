using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace TS3QueryLib.Net.Core.Common.Notification
{
    public abstract class NotificationHubBase : INotificationHub
    {
        #region Properties
        
        public SynchronizationContext SynchronizationContext { get; protected set; }
        protected ConcurrentDictionary<string, INotificationHandler> NotificationHandlerMapping { get; } = new ConcurrentDictionary<string, INotificationHandler>();

        #endregion

        #region Constructor

        protected NotificationHubBase() : this(SynchronizationContext.Current)
        {

        }

        protected NotificationHubBase(SynchronizationContext synchronizationContext)
        {
            SynchronizationContext = synchronizationContext;
        }

        #endregion

        #region INotificationHub Implementation

        void INotificationHub.HandleRawNotification(IQueryClient queryClient, string notificationName, string responseText)
        {
            // run the handling on a task to not block message handling in queryclient
            Task.Run(() => HandleRawNotificationAsync(queryClient, notificationName, responseText));
        }

        bool INotificationHub.AddHandler(string notificationName, INotificationHandler notificationHandler)
        {
            return AddHandler(notificationName, notificationHandler);
        }

        bool INotificationHub.RemoveHandler(string notificationName, INotificationHandler notificationHandler)
        {
            return RemoveHandler(notificationName, notificationHandler);

        }

        #endregion

        #region Methods

        protected bool AddHandler(string notificationName, INotificationHandler notificationHandler)
        {
            return NotificationHandlerMapping.TryAdd(notificationName, notificationHandler);
        }

        protected bool RemoveHandler(string notificationName, INotificationHandler notificationHandler)
        {
            INotificationHandler handler;
            if (!NotificationHandlerMapping.TryGetValue(notificationName, out handler) || handler != notificationHandler)
                return false;

            return NotificationHandlerMapping.TryRemove(notificationName, out handler);

        }
        
        private void HandleRawNotificationAsync(IQueryClient queryClient, string notificationName, string responseText)
        {
            SendOrPostCallback callback = state =>
            {
                object[] values = (object[]) state;
                HandleRawNotificationOnSyncContextOrInCurrentThread((IQueryClient) values[0], (string) values[1], (string) values[2]);
            };

            object[] callBackState = { queryClient, notificationName, responseText };

            if (SynchronizationContext == null)
                callback(callBackState);
            else
                SynchronizationContext.Post(callback, callBackState);
        }

        protected void HandleRawNotificationOnSyncContextOrInCurrentThread(IQueryClient queryClient, string notificationName, string responseText)
        {
            INotificationHandler handler;
            if(NotificationHandlerMapping.TryGetValue(notificationName, out handler))
                handler.HandleResponse(queryClient, responseText);
        }

        #endregion
    }
}