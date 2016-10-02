using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerListCommand : ExecutableEntityListCommand<ServerListItem>
    {
        public ServerListCommand(bool includeAll = false, bool includeRemoteServers = false, bool includeUniqueId = false, bool onlyOfflineServers = false) : base("ServerList")
        {
            if (includeRemoteServers || includeAll)
                AddOption("all");

            if (includeUniqueId || includeAll)
                AddOption("uid");

            if (onlyOfflineServers)
                AddOption("onlyoffline");
        }
    }
}