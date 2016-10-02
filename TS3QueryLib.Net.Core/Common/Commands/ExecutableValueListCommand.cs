using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Common.Commands
{
    public class ExecutableValueListCommand<TValue> : ExecutableCommand<ValueListCommandResponse<TValue>>
    {
        public ExecutableValueListCommand(string commandName) : base(commandName)
        {
        }
    }
}