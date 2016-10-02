using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class PermOverviewCommand : ExecutableEntityListCommand<PermissionOverviewEntry>
    {
        public PermOverviewCommand(uint channelId, uint clientDatabaseId, uint permissionId) : base("PermOverview")
        {
            AddParameter("cid", channelId);
            AddParameter("cldbid", clientDatabaseId);
            AddParameter("permid", permissionId);
        }

        public PermOverviewCommand(uint channelId, uint clientDatabaseId, string permissionName) : base("PermOverview")
        {
            AddParameter("cid", channelId);
            AddParameter("cldbid", clientDatabaseId);
            AddParameter("permsid", permissionName);
        }
    }
}