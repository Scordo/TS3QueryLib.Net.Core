using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public abstract class ExecutableValuelessCommand : ExecutableCommand<CommandResponse>
    {
        protected ExecutableValuelessCommand(string commandName) : base(commandName)
        {
        }
    }
}