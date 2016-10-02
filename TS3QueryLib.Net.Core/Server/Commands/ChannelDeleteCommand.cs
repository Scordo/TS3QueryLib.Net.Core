using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelDeleteCommand : ExecutableValuelessCommand
    {
        public ChannelDeleteCommand(uint channelId, bool forceDeleteWhenClientsExist = false) : base("ChannelDelete")
        {
            AddParameter("cid", channelId);
            AddParameter("force", forceDeleteWhenClientsExist);
        }
    }
}