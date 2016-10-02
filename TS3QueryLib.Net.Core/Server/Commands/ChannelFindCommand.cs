using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelFindCommand : ExecutableEntityListCommand<ChannelFindEntry>
    {
        public ChannelFindCommand(string pattern) : base("ChannelFind")
        {
            if (!pattern.IsNullOrTrimmedEmpty())
                AddParameter("pattern", pattern);
        }
    }
}