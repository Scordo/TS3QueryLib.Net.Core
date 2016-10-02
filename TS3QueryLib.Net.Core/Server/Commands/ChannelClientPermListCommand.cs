using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelClientPermListCommand : ExecutableEntityListCommand<Permission>
    {
        public ChannelClientPermListCommand(uint channelId, uint clientDatabaseId, bool returnNameInsteadOfId = false) : base("ChannelClientPermList")
        {
            AddParameter("cid", channelId);
            AddParameter("cldbid", clientDatabaseId);

            if (returnNameInsteadOfId)
                AddOption("permsid");
        }
    }
}