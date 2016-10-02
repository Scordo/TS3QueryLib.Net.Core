using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class BanClientCommand : ExecutableValueListCommand<uint>
    {
        public BanClientCommand(uint clientId, TimeSpan? duration = null, string reason = null) : base("BanClient", "banid")
        {
            AddParameter("clid", clientId);

            if (duration.HasValue)
                AddParameter("time", Convert.ToUInt32(Math.Floor(duration.Value.TotalSeconds)));

            if (reason != null)
                AddParameter("banreason", reason);
        }
    }
}
