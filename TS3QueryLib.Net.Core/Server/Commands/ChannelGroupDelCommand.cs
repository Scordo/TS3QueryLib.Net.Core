using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelGroupDelCommand : ExecutableValuelessCommand
    {
        public ChannelGroupDelCommand(uint channelGroupId, bool forceDeleteWhenClientsExist = false) : base("ChannelGroupDel")
        {
            AddParameter("cgid", channelGroupId);
            AddParameter("force", forceDeleteWhenClientsExist);
        }
    }
}