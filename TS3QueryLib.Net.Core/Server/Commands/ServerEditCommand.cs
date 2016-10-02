using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerEditCommand : ExecutableValuelessCommand
    {
        public ServerEditCommand(VirtualServerModification serverModification) : base("ServerEdit")
        {
            if (serverModification == null)
                throw new ArgumentNullException(nameof(serverModification));

            serverModification.AddToCommand(this);
        }
    }
}