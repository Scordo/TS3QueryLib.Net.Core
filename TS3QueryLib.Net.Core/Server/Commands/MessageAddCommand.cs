using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class MessageAddCommand : ExecutableValuelessCommand
    {
        public MessageAddCommand(uint clientUniqueId, string subject, string message) : base("MessageAdd")
        {
            if (subject.IsNullOrTrimmedEmpty())
                throw new ArgumentException("subject is null or trimmed empty", nameof(subject));

            if (message.IsNullOrTrimmedEmpty())
                throw new ArgumentException("message is null or trimmed empty", nameof(message));

            
            AddParameter("cluid", clientUniqueId);
            AddParameter("subject", subject);
            AddParameter("message", message);
        }
    }
}