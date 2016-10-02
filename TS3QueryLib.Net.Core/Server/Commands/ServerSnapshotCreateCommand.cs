using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerSnapshotCreateCommand : ExecutableValuelessCommand
    {
        public ServerSnapshotCreateCommand() : base("ServerSnapshotCreate")
        {
        }
    }
}