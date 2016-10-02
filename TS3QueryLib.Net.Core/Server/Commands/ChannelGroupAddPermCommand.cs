using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelGroupAddPermCommand : ExecutableValuelessCommand
    {

        public ChannelGroupAddPermCommand(uint channelGroupId, PermissionLight permission) : this(channelGroupId, new[] {permission })
        {
        }

        public ChannelGroupAddPermCommand(uint channelGroupId, IEnumerable<PermissionLight> permissions, bool continueOnError = false) : base("ChannelGroupAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cgid", channelGroupId);

            if (continueOnError)
                AddParameter("continueonerror", 1);

            uint index = 0;
            foreach (PermissionLight permission in permissions)
            {
                AddParameter("permid", permission.Id, index);
                AddParameter("permvalue", permission.Value, index);
                index++;
            }
        }

        public ChannelGroupAddPermCommand(uint channelGroupId, NamedPermissionLight permission) : this(channelGroupId, new [] {permission})
        {
            
        }

        public ChannelGroupAddPermCommand(uint channelGroupId, IEnumerable<NamedPermissionLight> permissions, bool continueOnError = false) : base("ChannelGroupAddPerm")
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            if (!permissions.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cgid", channelGroupId);

            if (continueOnError)
                AddParameter("continueonerror", 1);

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
