using System;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class BanAddCommand : ExecutableSingleValueCommand<uint?>
    {
        public BanAddCommand(string ipPattern, string namePattern, string clientUniqueId, TimeSpan? duration, string banReason) : base("BanAdd", "banid")
        {
            if (!ipPattern.IsNullOrTrimmedEmpty())
                AddParameter("ip", ipPattern);

            if (!namePattern.IsNullOrTrimmedEmpty())
                AddParameter("name", namePattern);

            if (!clientUniqueId.IsNullOrTrimmedEmpty())
                AddParameter("uid", clientUniqueId);

            if (duration.HasValue)
                AddParameter("time", Convert.ToUInt32(Math.Floor(duration.Value.TotalSeconds)));

            if (!banReason.IsNullOrTrimmedEmpty())
                AddParameter("banreason", banReason);
        }
    }
}