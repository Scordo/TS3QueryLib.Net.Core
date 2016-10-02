using System;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Common.Commands
{
    public class ExecutableSingleValueCommand<TValue> : ExecutableCommand<SingleValueCommandResponse<TValue>>
    {
        protected string ValueKey { get; }

        public ExecutableSingleValueCommand(string commandName, string valueKey) : base(commandName)
        {
            if (valueKey == null)
                throw new ArgumentNullException(nameof(valueKey));

            ValueKey = valueKey;
        }

        protected override void BeforApplyResponseText(SingleValueCommandResponse<TValue> response, string responseText)
        {
            response.ValueKey = ValueKey;
        }
    }
}