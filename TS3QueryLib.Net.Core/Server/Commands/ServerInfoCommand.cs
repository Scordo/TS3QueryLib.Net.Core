using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerInfoCommand : ExecutableCommand<ServerInfoCommandResponse>
    {
        public ServerInfoCommand() : base("ServerInfo")
        {
        }
    }
}
