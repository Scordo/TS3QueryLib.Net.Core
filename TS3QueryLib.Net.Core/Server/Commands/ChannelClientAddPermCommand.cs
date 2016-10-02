using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelClientAddPermCommand : ExecutableValuelessCommand
    {
        public ChannelClientAddPermCommand(uint channelId, uint clientDatabaseId, PermissionLight permission) : this(channelId, clientDatabaseId, new[] { permission })
        {
            
        }

        public ChannelClientAddPermCommand(uint channelId, uint clientDatabaseId, IEnumerable<PermissionLight> permissions) : base("ChannelClientAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cid", channelId);
            AddParameter("cldbid", clientDatabaseId);

            uint index = 0;
            foreach (PermissionLight permission in permissions)
            {
                AddParameter("permid", permission.Id, index);
                AddParameter("permvalue", permission.Value, index);
                index++;
            }
        }

        public ChannelClientAddPermCommand(uint channelId, uint clientDatabaseId, NamedPermissionLight permission) : this(channelId, clientDatabaseId, new[] { permission })
        {

        }

        public ChannelClientAddPermCommand(uint channelId, uint clientDatabaseId, IEnumerable<NamedPermissionLight> permissions) : base("ChannelClientAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cid", channelId);
            AddParameter("cldbid", clientDatabaseId);

            uint index = 0;
            foreach (NamedPermissionLight permission in permissions)
            {
                AddParameter("permsid", permission.Name, index);
                AddParameter("permvalue", permission.Value, index);
                index++;
            }
        }
    }
}