using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class PrivilegeKeyUseCommand : ExecutableValuelessCommand
    {
        public PrivilegeKeyUseCommand(string privilegeKey) : base("PrivilegeKeyUse")
        {
            if (privilegeKey.IsNullOrTrimmedEmpty())
                throw new ArgumentException("token is null or trimmed empty", nameof(privilegeKey));

            AddParameter("token", privilegeKey);
        }
    }
}