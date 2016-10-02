using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelAddPermCommand : ExecutableValuelessCommand
    {
        public ChannelAddPermCommand(uint channelId, PermissionLight permission) : this(channelId, new [] {permission})
        {
        }

        public ChannelAddPermCommand(uint channelId, IEnumerable<PermissionLight> permissions) : base("ChannelAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cid", channelId);

            uint index = 0;
            foreach (PermissionLight permission in permissions)
            {
                AddParameter("permid", permission.Id, index);
                AddParameter("permvalue", permission.Value, index);
                index++;
            }
        }

        public ChannelAddPermCommand(uint channelId, NamedPermissionLight permission) : this(channelId, new[] { permission })
        {
        }

        public ChannelAddPermCommand(uint channelId, IEnumerable<NamedPermissionLight> permissions) : base("ChannelAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cid", channelId);

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