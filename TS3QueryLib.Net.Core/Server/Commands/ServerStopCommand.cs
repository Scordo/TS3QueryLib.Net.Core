using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerStopCommand : ExecutableValuelessCommand
    {
        public ServerStopCommand(uint virtualServerId) : base("ServerStop")
        {
            AddParameter("sid", virtualServerId);
        }
    }
}
