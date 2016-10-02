using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class FtGetFileListCommand : ExecutableEntityListCommand<FileTransferFileEntry>
    {
        public FtGetFileListCommand(uint channelId, string filePath, string channelPassword = null) : base("FtGetFileList")
        {
            if (filePath.IsNullOrTrimmedEmpty())
                throw new ArgumentException("filePath is null or trimmed empty", nameof(filePath));

            AddParameter("cid", channelId);
            AddParameter("cpw", channelPassword);
            AddParameter("path", filePath);
        }
    }
}