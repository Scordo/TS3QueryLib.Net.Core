using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelListCommand : ExecutableEntityListCommand<ChannelListEntry>
    {
        public ChannelListCommand(bool includeAll, bool includeTopics = false, bool includeFlags = false, bool includeVoiceInfo = false, bool includeLimits = false, bool includeIcon = false) : base("ChannelList")
        {
            if (includeTopics || includeAll)
                AddOption("topic");

            if (includeFlags || includeAll)
                AddOption("flags");

            if (includeVoiceInfo || includeAll)
                AddOption("voice");

            if (includeLimits || includeAll)
                AddOption("limits");

            if (includeIcon || includeAll)
                AddOption("icon");
        }
    }
}