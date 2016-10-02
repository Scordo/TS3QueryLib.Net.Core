using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientSetServerQueryLoginCommand : ExecutableSingleValueCommand<string>
    {
        public ClientSetServerQueryLoginCommand(string username) : base("ClientSetServerQueryLogin", "client_login_password")
        {
            if (username.IsNullOrTrimmedEmpty())
                throw new ArgumentException("username is null or trimmed empty", nameof(username));

            AddParameter("client_login_name", username);
        }
    }
}