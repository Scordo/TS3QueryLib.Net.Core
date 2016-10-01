namespace TS3QueryLib.Net.Core.Common.Notification
{
    public interface INotificationHandler
    {
        void HandleResponse(IQueryClient queryClient, string responseText);
    }
}
