using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class FtDeleteFileCommand : ExecutableValuelessCommand
    {
        public FtDeleteFileCommand(uint channelId, string filePath, string channelPassword = null) : base("FtDeleteFile")
        {
            if (filePath.IsNullOrTrimmedEmpty())
                throw new ArgumentException("filePath is null or trimmed empty", nameof(filePath));

            AddParameter("cid", channelId);
            AddParameter("cpw", channelPassword);
            AddParameter("name", filePath);
        }
    }
}