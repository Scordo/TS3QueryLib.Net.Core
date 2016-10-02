using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerStartCommand : ExecutableValuelessCommand
    {
        public ServerStartCommand(uint virtualServerId) : base("ServerStart")
        {
            AddParameter("sid", virtualServerId);
        }
    }
}