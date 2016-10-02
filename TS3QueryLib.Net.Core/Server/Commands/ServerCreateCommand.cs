using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerCreateCommand : ExecutableCommand<ServerCreateCommandResponse>
    {
        public ServerCreateCommand(VirtualServerModification serverModification) : base("ServerCreate")
        {
            if (serverModification == null)
                throw new ArgumentNullException(nameof(serverModification));
            
            serverModification.AddToCommand(this);
        }
    }
}