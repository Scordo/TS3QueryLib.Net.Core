using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelInfoCommand : ExecutableCommand<ChannelInfoCommandResponse>
    {
        public ChannelInfoCommand(uint channelId) : base("ChannelInfo")
        {
            AddParameter("cid", channelId);
        }
    }
}