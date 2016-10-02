using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class GmCommand : ExecutableValuelessCommand
    {
        public GmCommand(string message) : base("Gm")
        {
            if (message.IsNullOrTrimmedEmpty())
                throw new ArgumentException("message is null or trimmed empty", nameof(message));
            
            AddParameter("msg", message);
        }
    }
}