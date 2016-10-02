using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupRenameCommand : ExecutableValuelessCommand
    {
        public ServerGroupRenameCommand(uint serverGroupId, string newName) : base("ServerGroupRename")
        {
            if (newName.IsNullOrTrimmedEmpty())
                throw new ArgumentException("newName is null or trimmed empty", nameof(newName));

            AddParameter("sgid", serverGroupId);
            AddParameter("name", newName);
        }
    }
}