using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class MessageListCommand : ExecutableEntityListCommand<MessageEntry>
    {
        public MessageListCommand() : base("MessageList")
        {
        }
    }
}