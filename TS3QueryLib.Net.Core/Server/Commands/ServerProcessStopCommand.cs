using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerProcessStopCommand : ExecutableValuelessCommand
    {
        public ServerProcessStopCommand() : base("ServerProcessStop")
        {
        }
    }
}