using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class FtCreateDirCommand : ExecutableValuelessCommand
    {
        public FtCreateDirCommand(uint channelId, string directoryPath, string channelPassword = null) : base("FtCreateDir")
        {
            if (directoryPath.IsNullOrTrimmedEmpty())
                throw new ArgumentException("directoryPath is null or trimmed empty", nameof(directoryPath));
            
            AddParameter("cid", channelId);
            AddParameter("cpw", channelPassword);
            AddParameter("dirname", directoryPath);
        }
    }
}