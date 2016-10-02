using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupDelPermCommand : ExecutableValuelessCommand
    {
        public ServerGroupDelPermCommand(uint serverGroupId, uint permissionId, bool continueOnError = false) : this(serverGroupId, new[] { permissionId }, continueOnError)
        {
        }

        public ServerGroupDelPermCommand(uint serverGroupId, IEnumerable<uint> permissionIdList, bool continueOnError = false) : base("ServerGroupDelPerm")
        {
            if (permissionIdList == null)
                throw new ArgumentNullException(nameof(permissionIdList));

            if (!permissionIdList.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("sgid", serverGroupId);

            if (continueOnError)
                AddParameter("continueonerror", 1);

            uint index = 0;
            foreach (uint permissionId in permissionIdList)
            {
                AddParameter("permid", permissionId, index);
                index++;
            }
        }

        public ServerGroupDelPermCommand(uint serverGroupId, string permissionName, bool continueOnError = false) : this(serverGroupId, new[] { permissionName }, continueOnError)
        {
        }

        public ServerGroupDelPermCommand(uint serverGroupId, IEnumerable<string> permissionNameList, bool continueOnError = false) : base("ServerGroupDelPerm")
        {
            if (permissionNameList == null)
                throw new ArgumentNullException(nameof(permissionNameList));

            if (!permissionNameList.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("sgid", serverGroupId);

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