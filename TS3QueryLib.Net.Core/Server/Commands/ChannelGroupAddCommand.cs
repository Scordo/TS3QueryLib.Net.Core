using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Entities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelGroupAddCommand : ExecutableSingleValueCommand<uint?>
    {
        public ChannelGroupAddCommand(string channelGroupName, GroupDatabaseType? groupType = null) : base("ChannelGroupAdd", "cgid")
        {
            if (channelGroupName.IsNullOrTrimmedEmpty())
                throw new ArgumentException("channelGroupName is null or trimmed empty", nameof(channelGroupName));

            AddParameter("name", channelGroupName);

            if (groupType.HasValue)
                AddParameter("type", (int)groupType);
        }
    }
}