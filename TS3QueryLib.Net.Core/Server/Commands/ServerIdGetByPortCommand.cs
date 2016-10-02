using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerIdGetByPortCommand : ExecutableSingleValueCommand<uint?>
    {
        public ServerIdGetByPortCommand(ushort virtualServerPort) : base("ServerIdGetByPort", "server_id")
        {
            AddParameter("virtualserver_port", virtualServerPort);
        }
    }
}