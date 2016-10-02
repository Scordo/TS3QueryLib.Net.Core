using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelMoveCommand : ExecutableValuelessCommand
    {
        public ChannelMoveCommand(uint channelId, uint channelParentId, ushort? order = null) : base("ChannelMove")
        {
            AddParameter("cid", channelId);
            AddParameter("cpid", channelParentId);

            if (order.HasValue)
                AddParameter("order", order.Value);
        }
    }
}