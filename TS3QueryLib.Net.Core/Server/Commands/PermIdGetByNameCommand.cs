using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class PermIdGetByNameCommand : ExecutableEntityListCommand<PermissionInfo>
    {
        public PermIdGetByNameCommand(string permissionName) : this(new[] { permissionName })
        {
            
        }

        public PermIdGetByNameCommand(IEnumerable<string> permissionNames) : base("PermIdGetByName")
        {
            if (permissionNames == null)
                throw new ArgumentNullException(nameof(permissionNames));

            if (!permissionNames.Any())
                throw new ArgumentException("permissionNames are empty");

            uint index = 0;
            foreach (string permissionName in permissionNames)
            {
                AddParameter("permsid", permissionName, index);
                index++;
            }

        }
    }
}