using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Entities;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class LogAddCommand : ExecutableValuelessCommand
    {
        public LogAddCommand(LogLevel logLevel, string message) : this(new LogEntryLight(logLevel, message))
        {

        }

        public LogAddCommand(LogEntryLight logEntry) : base("LogAdd")
        {
            if (logEntry == null)
                throw new ArgumentNullException(nameof(logEntry));

            AddParameter("loglevel", (uint)logEntry.LogLevel);
            AddParameter("logmsg", logEntry.Message);
        }
    }
}