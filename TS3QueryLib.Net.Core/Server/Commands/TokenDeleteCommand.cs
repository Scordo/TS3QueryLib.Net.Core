using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class TokenDeleteCommand : ExecutableValuelessCommand
    {
        public TokenDeleteCommand(string token) : base("TokenDelete")
        {
            if (token.IsNullOrTrimmedEmpty())
                throw new ArgumentException("token is null or trimmed empty", nameof(token));

            AddParameter("token", token);
        }
    }
}