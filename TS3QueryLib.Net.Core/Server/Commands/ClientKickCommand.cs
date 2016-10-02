using System;
using System.Collections.Generic;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Entities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientKickCommand : ExecutableValuelessCommand
    {
        public ClientKickCommand(uint clientId, KickReason kickReason, string reasonMessage = null) : this(new[] {clientId}, kickReason, reasonMessage)
        {
            
        }

        public ClientKickCommand(IEnumerable<uint> clientIds, KickReason kickreason, string reasonMessage = null) : base("ClientKick")
        {
            foreach (uint clientId in clientIds)
                AddParameter("clid", clientId);

            AddParameter("reasonid", (uint)kickreason);

            if (!reasonMessage.IsNullOrTrimmedEmpty())
            {
                if (reasonMessage?.Length > 40)
                    reasonMessage = reasonMessage.Substring(0, 40);

                AddParameter("reasonmsg", reasonMessage);
            }
        }
    }
}
