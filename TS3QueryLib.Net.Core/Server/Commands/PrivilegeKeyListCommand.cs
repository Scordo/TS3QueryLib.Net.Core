using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class PrivilegeKeyListCommand : ExecutableEntityListCommand<Token>
    {
        public PrivilegeKeyListCommand() : base("PrivilegeKeyList")
        {
        }
    }
}