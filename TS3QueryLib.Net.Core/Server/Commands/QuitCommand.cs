using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class QuitCommand : ExecutableValuelessCommand
    {
        public QuitCommand() : base("Quit")
        {
        }
    }
}