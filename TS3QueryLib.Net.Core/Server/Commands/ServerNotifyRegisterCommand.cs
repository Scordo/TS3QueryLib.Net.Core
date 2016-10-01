using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerNotifyRegisterCommand : ExecutableValuelessCommand
    {
        public ServerNotifyRegisterCommand(ServerNotifyRegisterEvent eventSource, uint? channelId = null) : this(eventSource.ToString(), channelId)
        {
        }

        public ServerNotifyRegisterCommand(string eventSource, uint? channelId = null) : base(CommandName.ServerNotifyRegister)
        {
            AddParameter("event", eventSource?.ToLower());

            if (channelId.HasValue)
                AddParameter("id", channelId.Value);
        }
    }
}