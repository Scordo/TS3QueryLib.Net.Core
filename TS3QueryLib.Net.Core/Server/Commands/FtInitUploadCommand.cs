using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class FtInitUploadCommand : ExecutableCommand<FtInitUploadCommandResponse>
    {
        public FtInitUploadCommand(uint clientFileTransferId, string name, uint channelId, ulong size, bool overwrite, bool resume, string channelPassword = null) : base("FtInitUpload")
        {
            AddParameter("clientftfid", clientFileTransferId);
            AddParameter("name", name);
            AddParameter("cid", channelId);
            AddParameter("size", size);
            AddParameter("overwrite", overwrite);
            AddParameter("resume", resume);
            AddParameter("cpw", channelPassword);
        }
    }
}