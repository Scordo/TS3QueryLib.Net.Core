using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Client.Commands
{
    /// <summary>
    /// Sends a text message a specified target.
    /// </summary>
    public class SendTextMessageCommand : ExecutableValuelessCommand
    {
        /// <summary>
        /// Creates an instance of SendTextMessageCommand
        /// </summary>
        /// <param name="message">The message to send</param>
        /// <param name="target">The target of the message</param>
        /// <param name="targetId">The id of the client, if target is MessageTarget.Client</param>
        public SendTextMessageCommand(string message, MessageTarget target, uint? targetId = null) : base("SendTextMessage")
        {
            if (message.IsNullOrTrimmedEmpty())
                throw new ArgumentException("message is null or trimmed empty", nameof(message));

            AddParameter("targetmode", (uint)target);
            AddParameter("msg", message);

            if (targetId.HasValue)
                AddParameter("target", targetId.Value);
        }
    }
}