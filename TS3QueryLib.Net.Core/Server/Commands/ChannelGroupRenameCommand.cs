using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelGroupRenameCommand : ExecutableValuelessCommand
    {
        public ChannelGroupRenameCommand(uint channelGroupId, string newName) : base("ChannelGroupRename")
        {
            if (newName.IsNullOrTrimmedEmpty())
                throw new ArgumentException("newName is null or trimmed empty", nameof(newName));
            
            AddParameter("cgid", channelGroupId);
            AddParameter("name", newName);
        }
    }
}