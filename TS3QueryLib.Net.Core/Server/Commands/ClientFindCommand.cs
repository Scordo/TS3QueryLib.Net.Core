using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientFindCommand : ExecutableEntityListCommand<ClientFindEntry>
    {
        public ClientFindCommand(string pattern) : base("ClientFind")
        {
            if (pattern.IsNullOrTrimmedEmpty())
                throw new ArgumentException("pattern is null or trimmed empty", nameof(pattern));

            AddParameter("pattern", pattern);
        }
    }
}