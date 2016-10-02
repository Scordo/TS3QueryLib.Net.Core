using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientGetDbIdFromUIdCommand : ExecutableValueListCommand<uint>
    {
        public ClientGetDbIdFromUIdCommand(string clientUniqueId) : base("ClientGetDbIdFromUId", "cldbid")
        {
            if (clientUniqueId.IsNullOrTrimmedEmpty())
                throw new ArgumentException("clientUniqueId is null or trimmed empty", nameof(clientUniqueId));

            AddParameter("cluid", clientUniqueId);
        }
    }
}