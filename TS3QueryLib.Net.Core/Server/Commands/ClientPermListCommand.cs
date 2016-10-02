using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientPermListCommand : ExecutableEntityListCommand<Permission>
    {
        public ClientPermListCommand(uint clientDatabaseId, bool returnNameInsteadOfId = false) : base("ClientPermList")
        {
            AddParameter("cldbid", clientDatabaseId);

            if (returnNameInsteadOfId)
                AddOption("permsid");
        }
    }
}