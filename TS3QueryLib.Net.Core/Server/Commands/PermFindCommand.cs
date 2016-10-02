using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class PermFindCommand : ExecutableEntityListCommand<PermissionFindEntry>
    {
        public PermFindCommand(uint permissionId) : base("PermFind")
        {
            AddParameter("permid", permissionId);
        }

        public PermFindCommand(string permissionName) : base("PermFind")
        {
            AddParameter("permsid", permissionName);
        }
    }
}