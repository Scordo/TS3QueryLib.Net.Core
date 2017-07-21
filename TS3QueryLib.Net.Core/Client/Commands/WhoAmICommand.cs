using TS3QueryLib.Net.Core.Client.Responses;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Client.Commands
{
    /// <summary>
    /// Retrieves information about ourself
    /// </summary>
    public class WhoAmICommand : ExecutableCommand<WhoAmICommandResponse>
    {
        public WhoAmICommand() : base("WhoAmI")
        {
        }
    }
}