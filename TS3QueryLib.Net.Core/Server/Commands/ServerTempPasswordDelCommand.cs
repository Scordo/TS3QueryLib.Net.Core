using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerTempPasswordDelCommand : ExecutableValuelessCommand
    {
        public ServerTempPasswordDelCommand(string password) : base("SERVERTEMPPASSWORDDEL")
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            AddParameter("pw", password);
        }
    }
}