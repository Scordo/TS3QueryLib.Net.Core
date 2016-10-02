using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class TokenUseCommand : ExecutableValuelessCommand
    {
        public TokenUseCommand(string token) : base("TokenUse")
        {
            if (token.IsNullOrTrimmedEmpty())
                throw new ArgumentException("token is null or trimmed empty", nameof(token));

            AddParameter("token", token);
        }
    }
}