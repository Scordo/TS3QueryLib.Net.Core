using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientPokeCommand : ExecutableValuelessCommand
    {
        public ClientPokeCommand(uint clientId, string message) : base("ClientPoke")
        {
            AddParameter("clid", clientId);
            AddParameter("msg", message);
        }
    }
}