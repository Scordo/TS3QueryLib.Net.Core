using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientDbEditCommand : ExecutableValuelessCommand
    {
        public ClientDbEditCommand(int clientDatabaseId, ClientModification modificationInstance) : base("ClientDbEdit")
        {
            if (modificationInstance == null)
                throw new ArgumentNullException(nameof(modificationInstance));

            AddParameter("cldbid", clientDatabaseId);
            modificationInstance.AddToCommand(this);
        }
    }
}