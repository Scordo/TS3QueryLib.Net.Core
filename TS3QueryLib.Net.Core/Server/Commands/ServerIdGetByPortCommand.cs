using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerIdGetByPortCommand : ExecutableSingleValueCommand<uint?>
    {
        public ServerIdGetByPortCommand(ushort virtualServerPort) : base("ServerIdGetByPort")
        {
            AddParameter("virtualserver_port", virtualServerPort);
        }
        
        protected override void BeforApplyResponseText(SingleValueCommandResponse<uint?> response, string responseText)
        {
            response.ValueKey = "server_id";
        }
    }
}