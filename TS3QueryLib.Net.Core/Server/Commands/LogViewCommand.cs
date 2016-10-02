using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class LogViewCommand : ExecutableEntityListCommand<LogEntry>
    {
        public LogViewCommand(ushort lines, uint beginPos, bool reverse = false, bool instance = false) : base("LogView")
        {
            lines = Math.Max(Math.Min(lines, (ushort)100), (ushort)1);

            AddParameter("lines", lines);
            AddParameter("begin_pos", beginPos);
            AddParameter("instance", instance ? 1 : 0);
            AddParameter("reverse", reverse ? 1 : 0);
        }
    }
}