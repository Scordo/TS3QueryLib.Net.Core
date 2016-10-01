using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public interface IEntity<out TEntity> : IDump where TEntity: new()
    {
        TEntity ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup);
    }
}