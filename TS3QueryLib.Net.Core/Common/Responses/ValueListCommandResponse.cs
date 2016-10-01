using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Common.Responses
{
    public class ValueListCommandResponse<TValue> : CommandResponse
    {
        public string ValueName { get; set; }
        public Func<CommandParameterGroup, CommandParameterGroup, TValue> ParseMethod { get; set; }

        public IReadOnlyList<TValue> Values { get; protected set; }

        protected override void OnPostApplyResponse()
        { 
            if (ValueName == null)
                throw new InvalidOperationException("ValueName was not set and is null!");

            if (BodyCommandParameterGroupList.Count == 0 || ValueName == null)
                Values = new List<TValue>();

            Values = BodyCommandParameterGroupList.Select(cpg => cpg.GetParameterValue(ValueName).ChangeTypeInvariant(default(TValue))).ToList();
        }
    }
}