using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class CustomInfoCommand : ExecutableEntityListCommand<CustomInfoEntry>
    {
        public CustomInfoCommand(int clientDatabaseId) : base("CustomInfo")
        {
            AddParameter("cldbid", clientDatabaseId);
        }
    }
}