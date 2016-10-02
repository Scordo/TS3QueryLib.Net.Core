using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class MessageDelCommand : ExecutableValuelessCommand
    {
        public MessageDelCommand(uint messageId) : base("MessageDel")
        {
            AddParameter("msgid", messageId);
        }
    }
}