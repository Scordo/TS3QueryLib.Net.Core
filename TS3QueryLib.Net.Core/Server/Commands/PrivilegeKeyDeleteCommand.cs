using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class PrivilegeKeyDeleteCommand :ExecutableValuelessCommand
    {
        public PrivilegeKeyDeleteCommand(string privilegeKey) : base("PrivilegeKeyDelete")
        {
            if (privilegeKey.IsNullOrTrimmedEmpty())
                throw new ArgumentException("token is null or trimmed empty", nameof(privilegeKey));

            AddParameter("token", privilegeKey);
        }
    }
}