using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientGetIdsCommand : ExecutableEntityListCommand<ClientIdEntry>
    {
        public ClientGetIdsCommand(string clientUniqueId) : base("ClientGetIds")
        {
            if (clientUniqueId.IsNullOrTrimmedEmpty())
                throw new ArgumentException("clientUniqueId is null or trimmed empty", nameof(clientUniqueId));

            AddParameter("cluid", clientUniqueId);
        }
    }
}