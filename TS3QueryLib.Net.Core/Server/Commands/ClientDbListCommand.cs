using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ClientDbListCommand : ExecutableCommand<ClientDbEntryListResponse>
    {
        public ClientDbListCommand(uint? numberOfRecords = null, bool includeTotalCount = false, uint? startIndex = null) : base("ClientDbList")
        {
            if (startIndex.HasValue)
                AddParameter("start", startIndex.Value);

            if (numberOfRecords.HasValue)
                AddParameter("duration", numberOfRecords.Value);

            if (includeTotalCount)
                AddOption("count");
        }
    }
}