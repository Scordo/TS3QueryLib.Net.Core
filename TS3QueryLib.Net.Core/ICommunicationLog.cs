namespace TS3QueryLib.Net.Core
{
    public interface ICommunicationLog
    {
        void RawMessageReceived(string message);
        void RawMessageSending(string message);
        void RawMessageSent(string message);
    }
}
