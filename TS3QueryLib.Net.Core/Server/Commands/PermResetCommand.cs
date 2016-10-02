using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class PermResetCommand : ExecutableSingleValueCommand<string>
    {
        public PermResetCommand() : base("PermReset", "token")
        {
        }
    }
}