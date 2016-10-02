using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{

    public class PermGetCommandResponse : CommandResponse
    {
        public uint PermissionId { get; protected set; }
        public string PermissionName { get; protected set; }
        public int PermissionValue { get; protected set; }

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            PermissionId = BodyCommandParameterGroupList.GetParameterValue<uint>("permid");
            PermissionName = BodyCommandParameterGroupList.GetParameterValue("permsid");
            PermissionValue = BodyCommandParameterGroupList.GetParameterValue<int>("permvalue");
        }
    }
}