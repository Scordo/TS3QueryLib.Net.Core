using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ClientGetNameFromUIdCommandResponse : CommandResponse
    {
        #region Properties

        public uint? ClientDatabaseId { get; protected set; }
        public string NickName { get; protected set; }

        #endregion

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            ClientDatabaseId = BodyCommandParameterGroupList.GetParameterValue<uint?>("cldbid");
            NickName = BodyCommandParameterGroupList.GetParameterValue("name");
        }
    }
}