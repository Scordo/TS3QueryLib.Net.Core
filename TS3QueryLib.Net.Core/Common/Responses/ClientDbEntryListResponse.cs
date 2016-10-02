using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Common.Responses
{
    public class ClientDbEntryListResponse : EntityListCommandResponse<ClientDbEntry>
    {
        public uint? TotalClientsInDatabase { get; protected set; }

        protected override void OnPostApplyResponse()
        {
            base.OnPostApplyResponse();

            CommandParameterGroup firstCommandParameterGroup = BodyCommandParameterGroupList.Count == 0 ? null : BodyCommandParameterGroupList[0];

            if (firstCommandParameterGroup != null)
                TotalClientsInDatabase = firstCommandParameterGroup.GetParameterValue<uint?>("count");
        }
    }
}