namespace TS3QueryLib.Net.Core.Common.Responses
{
    public interface ICommandResponse
    {
        uint ErrorId { get; }
        string ErrorMessage { get; }
        uint? FailedPermissionId { get; }
        bool IsBanned { get; }
        string BanExtraMessage { get; }
        string BodyText { get; }
        string StatusText { get; }
        string ResponseText { get; }

        void ApplyResponseText(string responseText);
    }
}