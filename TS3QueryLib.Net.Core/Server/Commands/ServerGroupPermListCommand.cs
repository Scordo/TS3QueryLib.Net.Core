using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupPermListCommand : ExecutableEntityListCommand<Permission>
    {
        public ServerGroupPermListCommand(uint serverGroupId, bool returnNameInsteadOfId = false) : base("ServerGroupPermList")
        {
            AddParameter("sgid", serverGroupId);

            if (returnNameInsteadOfId)
                AddOption("permsid");
        }
    }
}