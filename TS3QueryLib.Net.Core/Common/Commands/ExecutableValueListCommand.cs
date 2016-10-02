using System;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Common.Commands
{
    public class ExecutableValueListCommand<TValue> : ExecutableCommand<ValueListCommandResponse<TValue>>
    {
        protected string ValueKey { get; }

        public ExecutableValueListCommand(string commandName, string valueKey) : base(commandName)
        {
            if (valueKey == null)
                throw new ArgumentNullException(nameof(valueKey));

            ValueKey = valueKey;
        }

        protected override void BeforApplyResponseText(ValueListCommandResponse<TValue> response, string responseText)
        {
            response.ValueName = ValueKey;
        }
    }
}