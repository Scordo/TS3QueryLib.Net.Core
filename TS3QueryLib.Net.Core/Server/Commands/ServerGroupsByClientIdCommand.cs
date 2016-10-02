using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupsByClientIdCommand : ExecutableEntityListCommand<ServerGroupLight>
    {
        public ServerGroupsByClientIdCommand(uint clientDatabaseId) : base("ServerGroupsByClientId")
        {
            AddParameter("cldbid", clientDatabaseId); // think this is wrong, should be cldbid
        }
    }
}