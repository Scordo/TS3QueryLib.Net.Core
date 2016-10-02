using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class InstanceEditCommand : ExecutableValuelessCommand
    {
        public InstanceEditCommand(ServerInstanceModification modificationInstance) : base("InstanceEdit")
        {
            if (modificationInstance == null)
                throw new ArgumentNullException(nameof(modificationInstance));

            modificationInstance.AddToCommand(this);
        }
    }
}