using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class LogoutCommand : ExecutableValuelessCommand
    {
        public LogoutCommand() : base("Logout")
        {
        }
    }
}