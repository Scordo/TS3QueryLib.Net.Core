using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientGetNameFromDbIdCommand : ExecutableCommand<ClientGetNameFromDbIdCommandResponse>
    {
        public ClientGetNameFromDbIdCommand(uint clientDatabaseId) : base("ClientGetNameFromDbId")
        {
            AddParameter("cldbid", clientDatabaseId);
        }
    }
}