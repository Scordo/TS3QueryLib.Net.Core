using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class ClientGetNameFromDbIdCommandResponse : CommandResponse
    {
        #region Properties

        public string ClientUniqueId { get; protected set; }
        public string NickName { get; protected set; }
        public uint? ClientDatabaseId { get; protected set; }

        #endregion

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            ClientUniqueId = BodyCommandParameterGroupList.GetParameterValue("cluid");
            NickName = BodyCommandParameterGroupList.GetParameterValue("name");
            ClientDatabaseId = BodyCommandParameterGroupList.GetParameterValue<uint?>("cldbid");
        }
    }
}