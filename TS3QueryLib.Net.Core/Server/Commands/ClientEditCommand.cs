using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientEditCommand : ExecutableValuelessCommand
    {
        public ClientEditCommand(uint clientId, ClientModification modificationInstance) : base("ClientEdit")
        {
            if (modificationInstance == null)
                throw new ArgumentNullException(nameof(modificationInstance));
            
            AddParameter("clid", clientId);
            modificationInstance.AddToCommand(this);
        }
    }
}