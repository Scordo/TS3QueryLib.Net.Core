using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupAutoAddPermCommand : ExecutableValuelessCommand
    {
        public ServerGroupAutoAddPermCommand(ServerGroupType serverGroupType, IEnumerable<Permission> permissions) : base("ServerGroupAutoAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("sgtype", (uint)serverGroupType);
            
            uint index = 0;
            foreach (Permission permission in permissions)
            {
                AddParameter("permid", permission.Id, index);
                AddParameter("permvalue", permission.Value, index);
                AddParameter("permnegated", permission.Negated, index);
                AddParameter("permskip", permission.Skip, index);
                index++;
            }
        }
    }
}