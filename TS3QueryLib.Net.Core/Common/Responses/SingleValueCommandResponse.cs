using System;

namespace TS3QueryLib.Net.Core.Common.Responses
{
    public class SingleValueCommandResponse<TValueType> : CommandResponse
    {
        public TValueType Value { get; protected set; }
        public string ValueKey { get; set; }
        
        protected override void OnPostApplyResponse()
        {
            if (ValueKey == null)
                throw new InvalidOperationException($"{nameof(ValueKey)} was not set and is null!");

            Value = BodyCommandParameterGroupList.Count == 0 ? default(TValueType) : BodyCommandParameterGroupList.GetParameterValue(ValueKey).ChangeTypeInvariant(default(TValueType));
        }
    }
}