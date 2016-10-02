using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Common.Commands
{
    public class ExecutableValuelessCommand : ExecutableCommand<CommandResponse>
    {
        public ExecutableValuelessCommand(string commandName) : base(commandName)
        {
        }
    }
}