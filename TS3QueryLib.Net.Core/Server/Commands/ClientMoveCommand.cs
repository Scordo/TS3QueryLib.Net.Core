using System.Collections.Generic;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientMoveCommand : ExecutableValuelessCommand
    {
        public ClientMoveCommand(uint clientId, uint channelId, string channelPassword = null) : base("ClientMove")
        {
            AddParameter("clid", clientId);
            AddParameter("cid", channelId);

            if (channelPassword != null)
                AddParameter("cpw", channelPassword);
        }

        public ClientMoveCommand(IEnumerable<uint> clientIds, uint channelId, string channelPassword = null) : base("ClientMove")
        {
            AddParameter("cid", channelId);

            if (channelPassword != null)
                AddParameter("cpw", channelPassword);

            uint index = 0;
            foreach (uint clientId in clientIds)
            {
                AddParameter("clid", clientId, index);
                index++;
            }
        }
    }
}