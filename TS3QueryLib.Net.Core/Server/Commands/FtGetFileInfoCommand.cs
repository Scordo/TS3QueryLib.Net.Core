using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class FtGetFileInfoCommand : ExecutableEntityListCommand<FileTransferFileEntry>
    {
        public FtGetFileInfoCommand(uint channelId, string name, string channelPassword) : this(channelId, new[] {name}, channelPassword)
        {
            
        }

        public FtGetFileInfoCommand(uint channelId, IEnumerable<string> names, string channelPassword = null) : base("FtGetFileInfo")
        {
            if (names == null)
                throw new ArgumentNullException(nameof(names));

            if (!names.Any())
                throw new ArgumentException("names is empty", nameof(names));

            AddParameter("cid", channelId);
            AddParameter("cpw", channelPassword);

            uint index = 0;
            foreach (string name in names)
            {
                AddParameter("name", name, index);
                index++;
            }
        }
    }
}