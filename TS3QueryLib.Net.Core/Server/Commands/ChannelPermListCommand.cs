using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelPermListCommand : ExecutableEntityListCommand<Permission>
    {
        public ChannelPermListCommand(uint channelId, bool returnNameInsteadOfId = false) : base("ChannelPermList")
        {
            AddParameter("cid", channelId);

            if (returnNameInsteadOfId)
                AddOption("permsid");
        }
    }
}