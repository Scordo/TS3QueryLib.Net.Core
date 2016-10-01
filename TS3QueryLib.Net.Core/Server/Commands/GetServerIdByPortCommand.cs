using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class GetServerIdByPortCommand : ExecutableCommand<SingleValueCommandResponse<uint?>>
    {
        public GetServerIdByPortCommand(ushort virtualServerPort) : base(CommandName.ServerIdGetByPort)
        {
            AddParameter("virtualserver_port", virtualServerPort);
        }
        
        protected override void BeforApplyResponseText(SingleValueCommandResponse<uint?> response, string responseText)
        {
            response.ValueKey = "server_id";
        }
    }
}