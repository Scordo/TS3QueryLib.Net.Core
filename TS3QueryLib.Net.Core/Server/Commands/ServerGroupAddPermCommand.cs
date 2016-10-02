using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupAddPermCommand : ExecutableValuelessCommand
    {
        public ServerGroupAddPermCommand(uint serverGroupId, Permission permission, bool continueOnError = false) : this(serverGroupId, new[] { permission}, continueOnError)
        {
        }

        public ServerGroupAddPermCommand(uint serverGroupId, IEnumerable<Permission> permissions, bool continueOnError = false) : base("ServerGroupAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("sgid", serverGroupId);

            if (continueOnError)
                AddParameter("continueonerror", 1);

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