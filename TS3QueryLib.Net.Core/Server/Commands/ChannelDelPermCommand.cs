using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelDelPermCommand : ExecutableValuelessCommand
    {
        public ChannelDelPermCommand(uint channelId, uint permissionId) : this(channelId, new [] { permissionId })
        {
        }

        public ChannelDelPermCommand(uint channelId, IEnumerable<uint> permissionIdList) : base("ChannelDelPerm")
        {
            if (permissionIdList == null)
                throw new ArgumentNullException(nameof(permissionIdList));

            if (!permissionIdList.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cid", channelId);

            uint index = 0;
            foreach (uint permissionId in permissionIdList)
            {
                AddParameter("permid", permissionId, index);
                index++;
            }
        }

        public ChannelDelPermCommand(uint channelId, string permissionName) : this(channelId, new[] { permissionName })
        {
        }

        public ChannelDelPermCommand(uint channelId, IEnumerable<string> permissionNameList) : base("ChannelDelPerm")
        {
            if (permissionNameList == null)
                throw new ArgumentNullException(nameof(permissionNameList));

            if (!permissionNameList.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("cid", channelId);

            uint index = 0;
            foreach (string permissionName in permissionNameList)
            {
                AddParameter("permsid", permissionName, index);
                index++;
            }
        }
    }
}