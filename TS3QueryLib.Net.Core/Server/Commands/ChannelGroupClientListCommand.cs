using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelGroupClientListCommand : ExecutableEntityListCommand<ChannelGroupClient>
    {
        public ChannelGroupClientListCommand(uint? channelId = null, uint? clientDatabaseId = null, uint? channelGroupId = null) : base("ChannelGroupClientList")
        {
            if (channelId.HasValue)
                AddParameter("cid", channelId.Value);

            if (clientDatabaseId.HasValue)
                AddParameter("cldbid", clientDatabaseId.Value);

            if (channelGroupId.HasValue)
                AddParameter("cgid", channelGroupId.Value);
        }
    }
}