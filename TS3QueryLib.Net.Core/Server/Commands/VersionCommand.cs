﻿using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class VersionCommand : ExecutableCommand<VersionCommandResponse>
    {
        public VersionCommand() : base("Version")
        {
        }
    }
}