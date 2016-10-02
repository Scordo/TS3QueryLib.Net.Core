using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class MessageGetCommand : ExecutableCommand<MessageGetCommandResponse>
    {
        public MessageGetCommand(uint messageId) : base("MessageGet")
        {
            AddParameter("msgid", messageId);
        }
    }
}