using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Common.Commands
{
    public class ExecutableSingleValueCommand<TValue> : ExecutableCommand<SingleValueCommandResponse<TValue>>
    {
        public ExecutableSingleValueCommand(string commandName) : base(commandName)
        {
        }
    }
}