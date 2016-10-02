using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerNotifyUnregisterCommand : ExecutableValuelessCommand
    {
        public ServerNotifyUnregisterCommand() : base("ServerNotifyUnregister")
        {
        }
    }
}