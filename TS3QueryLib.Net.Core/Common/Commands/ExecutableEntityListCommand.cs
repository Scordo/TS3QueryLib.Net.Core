using TS3QueryLib.Net.Core.Common.Responses;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Common.Commands
{
    public class ExecutableEntityListCommand<TEntity> : ExecutableCommand<EntityListCommandResponse<TEntity>> where TEntity: IEntity<TEntity>, new()
    {
        public ExecutableEntityListCommand(string commandName) : base(commandName)
        {

        }
    }
}