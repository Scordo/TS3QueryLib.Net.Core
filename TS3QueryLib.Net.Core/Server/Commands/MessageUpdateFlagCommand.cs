using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class MessageUpdateFlagCommand : ExecutableValuelessCommand
    {
        public MessageUpdateFlagCommand(uint messageId, bool setRead) : base("MessageUpdateFlag")
        {
            AddParameter("msgid", messageId);
            AddParameter("flag", setRead);
        }
    }
}