using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelClientDelPermCommand : ExecutableValuelessCommand
    {
        public ChannelClientDelPermCommand(uint channelId, uint clientDatabaseId, uint permissionId) : this(channelId, clientDatabaseId, new[] { permissionId })
        {
            
        }

        public ChannelClientDelPermCommand(uint channelId, uint clientDatabaseId, IEnumerable<uint> permissionIdList) : base("ChannelClientDelPerm")
        {
            if (permissionIdList == null)
                throw new ArgumentNullException(nameof(permissionIdList));

            if (!permissionIdList.Any())
                throw new ArgumentException("permissions are empty");


            AddParameter("cid", channelId);
            AddParameter("cldbid", clientDatabaseId);

            uint index = 0;
            foreach (uint permissionId in permissionIdList)
            {
                AddParameter("permid", permissionId, index);
                index++;
            }
        }

        public ChannelClientDelPermCommand(uint channelId, uint clientDatabaseId, string permissionName) : this(channelId, clientDatabaseId, new[] { permissionName })
        {

        }

        public ChannelClientDelPermCommand(uint channelId, uint clientDatabaseId, IEnumerable<string> permissionIdList) : base("ChannelClientDelPerm")
        {
            if (permissionIdList == null)
                throw new ArgumentNullException(nameof(permissionIdList));

            if (!permissionIdList.Any())
                throw new ArgumentException("permissions are empty");

            AddParameter("cid", channelId);
            AddParameter("cldbid", clientDatabaseId);

            uint index = 0;
            foreach (string permissionName in permissionIdList)
            {
                AddParameter("permsid", permissionName, index);
                index++;
            }
        }
    }
}