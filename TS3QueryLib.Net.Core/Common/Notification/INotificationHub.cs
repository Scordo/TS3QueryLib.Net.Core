namespace TS3QueryLib.Net.Core.Common.Notification
{
    public interface INotificationHub
    {
        void HandleRawNotification(IQueryClient queryClient, string notificationName, string responseText);
        bool RemoveHandler(string notificationName, INotificationHandler notificationHandler);
        bool AddHandler(string notificationName, INotificationHandler notificationHandler);
    }
}