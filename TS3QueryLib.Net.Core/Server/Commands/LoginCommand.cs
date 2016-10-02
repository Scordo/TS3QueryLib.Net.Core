using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class LoginCommand : ExecutableValuelessCommand
    {
        public LoginCommand(string username, string password) : base("Login")
        {
            if (username.IsNullOrTrimmedEmpty())
                throw new ArgumentException("username is null or trimmed empty", nameof(username));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password is null or empty", nameof(password));
            
            AddParameter("client_login_name", username);
            AddParameter("client_login_password", password);
        }
    }
}