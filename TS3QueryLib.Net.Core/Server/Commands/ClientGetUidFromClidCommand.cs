using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientGetUidFromClidCommand : ExecutableCommand<ClientGetUidFromClidCommandResponse>
    {
        public ClientGetUidFromClidCommand(uint clientId) : base("ClientGetUidFromClid")
        {
            AddParameter("clid", clientId);
        }
    }
}