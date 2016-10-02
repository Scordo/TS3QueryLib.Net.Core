using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerTempPasswordListCommand : ExecutableEntityListCommand<ServerTempPasswordListEntry>
    {
        public ServerTempPasswordListCommand() : base("SERVERTEMPPASSWORDLIST")
        {
        }
    }
}
