using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class FtInitDownloadCommand : ExecutableCommand<FtInitDownloadCommandResponse>
    {
        public FtInitDownloadCommand(uint clientFileTransferId, string name, uint channelId, ulong seekPosition, string channelPassword = null) : base("FtInitDownload")
        {
            AddParameter("clientftfid", clientFileTransferId);
            AddParameter("name", name);
            AddParameter("cid", channelId);
            AddParameter("seekpos", seekPosition);
            AddParameter("cpw", channelPassword);
        }
    }
}