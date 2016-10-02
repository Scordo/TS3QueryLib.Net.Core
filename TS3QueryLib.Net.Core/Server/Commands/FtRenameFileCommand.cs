using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class FtRenameFileCommand : ExecutableValuelessCommand
    {
        public FtRenameFileCommand(uint channelId, string oldName, string newName, uint? targetChannelId = null, string channelPassword = null, string targetChannelPassword = null) : base("FtRenameFile")
        {
            if (oldName.IsNullOrTrimmedEmpty())
                throw new ArgumentException("oldName is null or trimmed empty", nameof(oldName));

            if (newName.IsNullOrTrimmedEmpty())
                throw new ArgumentException("oldName is null or trimmed empty", nameof(newName));
            
            AddParameter("cid", channelId);
            AddParameter("cpw", channelPassword);
            AddParameter("oldname", oldName);
            AddParameter("newname", newName);

            if (targetChannelId.HasValue)
                AddParameter("tcid", targetChannelId.Value);

            if (targetChannelPassword != null)
                AddParameter("tcpw", targetChannelPassword);
        }
    }
}