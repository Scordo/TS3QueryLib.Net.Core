using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerDeleteCommand: ExecutableValuelessCommand
    {
        public ServerDeleteCommand(uint virtualServerId) : base("ServerDelete")
        {
            AddParameter("sid", virtualServerId);
        }
    }
}