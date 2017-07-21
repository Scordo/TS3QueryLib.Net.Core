using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Client.Commands
{
    /// <summary>
    /// Authenticates connecting application with API key of user.
    /// </summary>
    public class AuthCommand : ExecutableValuelessCommand
    {
        public AuthCommand(string apiKey) : base("auth")
        {
            if (apiKey == null)
                throw new ArgumentNullException(nameof(apiKey));

            AddParameter("apikey", apiKey);
        }
    }
}