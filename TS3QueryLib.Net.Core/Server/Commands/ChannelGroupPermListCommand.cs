using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelGroupPermListCommand : ExecutableEntityListCommand<Permission>
    {
        public ChannelGroupPermListCommand(uint channelGroupId, bool returnNameInsteadOfId = false) : base("ChannelGroupPermList")
        {
            AddParameter("cgid", channelGroupId);

            if (returnNameInsteadOfId)
                AddOption("permsid");
        }
    }
}