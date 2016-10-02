using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientDbInfoCommand : ExecutableCommand<ClientDbInfoCommandResponse>
    {
        public ClientDbInfoCommand(int clientDatabaseId) : base("ClientDbInfo")
        {
            AddParameter("cldbid", clientDatabaseId);
        }
    }
}