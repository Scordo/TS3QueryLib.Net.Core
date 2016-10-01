using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Responses;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class GetServerListShortCommand : ExecutableCommand<EntityListCommandResponse<ServerListItemBase>>
    {
        public GetServerListShortCommand() : base(CommandName.ServerList)
        {
            AddOption("short");
        }
    }
}