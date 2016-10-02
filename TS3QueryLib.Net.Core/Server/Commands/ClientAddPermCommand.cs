using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientAddPermCommand : ExecutableValuelessCommand
    {
        public ClientAddPermCommand(uint clientDatabaseId, ClientPermission permission) : this(clientDatabaseId, new[] { permission })
        {
            
        }

        public ClientAddPermCommand(uint clientDatabaseId, IEnumerable<ClientPermission> permissions) : base("ClientAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cldbid", clientDatabaseId);

            uint index = 0;
            foreach (ClientPermission permission in permissions)
            {
                AddParameter("permid", permission.Id, index);
                AddParameter("permvalue", permission.Value, index);
                AddParameter("permskip", permission.Skip, index);
                index++;
            }
        }

        public ClientAddPermCommand(uint clientDatabaseId, NamedClientPermission permission) : this(clientDatabaseId, new[] { permission })
        {

        }

        public ClientAddPermCommand(uint clientDatabaseId, IEnumerable<NamedClientPermission> permissions) : base("ClientAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cldbid", clientDatabaseId);

            uint index = 0;
            foreach (NamedClientPermission permission in permissions)
            {
                AddParameter("permsid", permission.Name, index);
                AddParameter("permvalue", permission.Value, index);
                AddParameter("permskip", permission.Skip, index);
                index++;
            }
        }
    }
}