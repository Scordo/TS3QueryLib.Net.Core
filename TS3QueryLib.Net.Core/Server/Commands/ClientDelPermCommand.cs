using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientDelPermCommand : ExecutableValuelessCommand
    {
        public ClientDelPermCommand(uint clientDatabaseId, uint permissionId) : this(clientDatabaseId, new []{permissionId})
        {
            
        }

        public ClientDelPermCommand(uint clientDatabaseId, IEnumerable<uint> permissionIdList) : base("ClientDelPerm")
        {
            if (permissionIdList == null)
                throw new ArgumentNullException(nameof(permissionIdList));

            if (!permissionIdList.Any())
                throw new ArgumentException("permissions are empty");

            AddParameter("cldbid", clientDatabaseId);

            uint index = 0;
            foreach (uint permissionId in permissionIdList)
            {
                AddParameter("permid", permissionId, index);
                index++;
            }
        }

        public ClientDelPermCommand(uint clientDatabaseId, string permissionName) : this(clientDatabaseId, new[] { permissionName })
        {

        }

        public ClientDelPermCommand(uint clientDatabaseId, IEnumerable<string> permissionNameList) : base("ClientDelPerm")
        {
            if (permissionNameList == null)
                throw new ArgumentNullException(nameof(permissionNameList));

            if (!permissionNameList.Any())
                throw new ArgumentException("permissions are empty");

            AddParameter("cldbid", clientDatabaseId);

            uint index = 0;
            foreach (string permissionName in permissionNameList)
            {
                AddParameter("permsid", permissionName, index);
                index++;
            }
        }
    }
}