using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Entities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupAddCommand : ExecutableSingleValueCommand<uint?>
    {
        public ServerGroupAddCommand(string serverGroupName, GroupDatabaseType? groupType = null) : base("ServerGroupAdd", "sgid")
        {
            if (serverGroupName.IsNullOrTrimmedEmpty())
                throw new ArgumentException("serverGroupName is null or trimmed empty", nameof(serverGroupName));

            AddParameter("name", serverGroupName);

            if (groupType.HasValue)
                AddParameter("type", (int)groupType);
        }
    }
}