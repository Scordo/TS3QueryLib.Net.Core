using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelGroupDelPermCommand : ExecutableValuelessCommand
    {
        public ChannelGroupDelPermCommand(uint channelGroupId, uint permissionId, bool continueOnError = false) : this(channelGroupId, new []{ permissionId}, continueOnError)
        {
        }

        public ChannelGroupDelPermCommand(uint channelGroupId, IEnumerable<uint> permissionIdList, bool continueOnError = false) : base("ChannelGroupDelPerm")
        {
            if (permissionIdList == null)
                throw new ArgumentNullException(nameof(permissionIdList));

            if (!permissionIdList.Any())
                throw new ArgumentException("permissions are empty");

            AddParameter("cgid", channelGroupId);

            uint index = 0;
            foreach (uint permissionId in permissionIdList)
            {
                AddParameter("permid", permissionId, index);
                index++;
            }
        }

        public ChannelGroupDelPermCommand(uint channelGroupId, string permissionName, bool continueOnError) : this(channelGroupId, new [] {permissionName}, continueOnError)
        {
            
        }

        public ChannelGroupDelPermCommand(uint channelGroupId, IEnumerable<string> permissionNameList, bool continueOnError) : base("ChannelGroupDelPerm")
        {
            if (permissionNameList == null)
                throw new ArgumentNullException(nameof(permissionNameList));

            if (!permissionNameList.Any())
                throw new ArgumentException("permissions are empty");

            AddParameter("cgid", channelGroupId);

            if (continueOnError)
                AddParameter("continueonerror", 1);

            uint index = 0;
            foreach (string permissionName in permissionNameList)
            {
                AddParameter("permsid", permissionName, index);
                index++;
            }
        }
    }
}