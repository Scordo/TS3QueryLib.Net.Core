using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientInfoCommand : ExecutableCommand<ClientInfoCommandResponse>
    {
        public ClientInfoCommand(uint clientId) : base("ClientInfo")
        {
            AddParameter("clid", clientId);
        }
    }
}