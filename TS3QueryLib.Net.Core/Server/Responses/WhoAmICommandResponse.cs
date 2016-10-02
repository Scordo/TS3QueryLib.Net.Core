using TS3QueryLib.Net.Core.Common.Responses;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class WhoAmICommandResponse : CommandResponse
    {
        #region Properties

        public uint ClientId { get; protected set; }
        public uint ChannelId { get; protected set; }
        public string ClientUniqueId { get; protected set; }
        public string ClientNickName { get; protected set; }
        public string ClientLoginName { get; protected set; }
        public uint ClientDatabaseId { get; protected set; }
        public uint VirtualServerId { get; protected set; }
        public string VirtualServerUniqueId { get; protected set; }
        public VirtualServerStatus VirtualServerStatus { get; protected set; }
        public ushort ServerPort { get; protected set; }
        public uint OriginServerId { get; protected set; }

        #endregion


        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            string statusString = BodyCommandParameterGroupList.GetParameterValue("virtualserver_status");
            VirtualServerStatus = VirtualServerStatusHelper.Parse(statusString);
            ClientId = BodyCommandParameterGroupList.GetParameterValue<uint>("client_id");
            VirtualServerUniqueId = BodyCommandParameterGroupList.GetParameterValue("virtualserver_unique_identifier");
            VirtualServerId = BodyCommandParameterGroupList.GetParameterValue<uint>("virtualserver_id");
            ChannelId = BodyCommandParameterGroupList.GetParameterValue<uint>("client_channel_id");
            ClientDatabaseId = BodyCommandParameterGroupList.GetParameterValue<uint>("client_database_id");
            ClientNickName = BodyCommandParameterGroupList.GetParameterValue("client_nickname");
            ClientLoginName = BodyCommandParameterGroupList.GetParameterValue("client_login_name");
            ClientUniqueId = BodyCommandParameterGroupList.GetParameterValue("client_unique_identifier");
            ServerPort = BodyCommandParameterGroupList.GetParameterValue<ushort>("virtualserver_port");
            OriginServerId = BodyCommandParameterGroupList.GetParameterValue<uint>("client_origin_server_id");
        }
    }
}