using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class SendTextMessageCommand : ExecutableValuelessCommand
    {
        public SendTextMessageCommand(MessageTarget target, uint targetId, string message) : base("SendTextMessage")
        {
            if (message.IsNullOrTrimmedEmpty())
                throw new ArgumentException("message is null or trimmed empty", nameof(message));

            AddParameter("targetmode", (uint)target);
            AddParameter("msg", message);
            AddParameter("target", targetId);
        }
    }
}