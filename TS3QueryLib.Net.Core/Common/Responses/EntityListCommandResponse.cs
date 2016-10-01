using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Common.Responses
{
    public class EntityListCommandResponse<TEntity> : CommandResponse where TEntity: IEntity<TEntity>, new()
    {
        //public string ValueName { get; set; }
        //public Func<CommandParameterGroup, CommandParameterGroup, TEntity> ParseMethod { get; set; }

        public IReadOnlyList<TEntity> Values { get; protected set; }

        protected override void OnPostApplyResponse()
        {
            CommandParameterGroup firstGroup = BodyCommandParameterGroupList.FirstOrDefault();
            Values = BodyCommandParameterGroupList.Select(currentGroup =>
                                                          {
                                                              TEntity entity = new TEntity();
                                                              entity.ApplyFrom(currentGroup, firstGroup);

                                                              return entity;
                                                          }).ToList();

            //if (ValueName == null)
            //    throw new InvalidOperationException("ValueName was not set and is null!");

            //if (BodyCommandParameterGroupList.Count == 0 || (ValueName == null && ParseMethod == null))
            //    Value = new List<TEntity>();

            //if (ParseMethod != null)
            //{
            //    CommandParameterGroup firstGroup = BodyCommandParameterGroupList.FirstOrDefault();
            //    Value = BodyCommandParameterGroupList.Select(currentGroup => ParseMethod(currentGroup, firstGroup)).ToList();
            //}
            //else
            //    Value = BodyCommandParameterGroupList.Select(cpg => cpg.GetParameterValue(ValueName).ChangeTypeInvariant(default(TEntity))).ToList();
        }
    }
}