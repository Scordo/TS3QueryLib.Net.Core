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
    }
}