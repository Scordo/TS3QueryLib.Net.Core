using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class FtStopCommand : ExecutableValuelessCommand
    {
        public FtStopCommand(uint serverFileTransferId, bool deleteFile = false) : base("FtStop")
        {
            AddParameter("serverftfid", serverFileTransferId);
            AddParameter("delete", deleteFile);
        }
    }
}