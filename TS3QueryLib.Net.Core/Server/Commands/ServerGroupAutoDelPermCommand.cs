using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerGroupAutoDelPermCommand : ExecutableValuelessCommand
    {
        public ServerGroupAutoDelPermCommand(ServerGroupType serverGroupType, IEnumerable<uint> permissionIdList) : base("ServerGroupAutoDelPerm")
        {
            if (permissionIdList == null)
                throw new ArgumentNullException(nameof(permissionIdList));

            if (!permissionIdList.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("sgtype", (uint)serverGroupType);

            uint index = 0;
            foreach (uint permissionId in permissionIdList)
            {
                AddParameter("permid", permissionId, index);
                index++;
            }
        }
        

        public ServerGroupAutoDelPermCommand(ServerGroupType serverGroupType, IEnumerable<string> permissionNameList) : base("ServerGroupAutoDelPerm")
        {
            if (permissionNameList == null)
                throw new ArgumentNullException(nameof(permissionNameList));

            if (!permissionNameList.Any())
                throw new ArgumentException("permissions are empty.");

            AddParameter("sgtype", (uint) serverGroupType);

            uint index = 0;
            foreach (string permissionName in permissionNameList)
            {
                AddParameter("permsid", permissionName, index);
                index++;
            }
        }
    }
}