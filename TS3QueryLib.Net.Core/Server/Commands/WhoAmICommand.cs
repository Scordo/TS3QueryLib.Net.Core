using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class WhoAmICommand : ExecutableCommand<WhoAmICommandResponse>
    {
        public WhoAmICommand() : base("WhoAmI")
        {
        }
    }
}