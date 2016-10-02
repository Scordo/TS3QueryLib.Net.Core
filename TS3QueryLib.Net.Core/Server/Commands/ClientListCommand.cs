using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientListCommand : ExecutableEntityListCommand<ClientListEntry>
    {
        public ClientListCommand(bool includeAll = false, bool includeUniqueId = false, bool includeAwayState = false, bool includeVoiceInfo = false, bool includeGroupInfo = false, bool includeClientInfo = false, bool includeTimes = false, bool includeIcon = false, bool includeCountry = false, bool includeIPs = false) : base("ClientList")
        {
            if (includeUniqueId || includeAll)
                AddOption("uid");

            if (includeAwayState || includeAll)
                AddOption("away");

            if (includeVoiceInfo || includeAll)
                AddOption("voice");

            if (includeGroupInfo || includeAll)
                AddOption("groups");

            if (includeClientInfo || includeAll)
                AddOption("info");

            if (includeTimes || includeAll)
                AddOption("times");

            if (includeIcon || includeAll)
                AddOption("icon");

            if (includeCountry || includeAll)
                AddOption("country");

            if (includeIPs || includeAll)
                AddOption("ip");
        }
    }
}