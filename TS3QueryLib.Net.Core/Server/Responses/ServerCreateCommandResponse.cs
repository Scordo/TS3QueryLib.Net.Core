using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class ServerCreateCommandResponse : CommandResponse
    {
        #region Properties

        public uint ServerId { get; protected set; }
        public ushort ServerPort { get; protected set; }
        public string Token { get; protected set; }

        #endregion

        #region Non Public Methods

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            ServerId = BodyCommandParameterGroupList.GetParameterValue<uint>("sid");
            ServerPort = BodyCommandParameterGroupList.GetParameterValue<ushort>("virtualserver_port");
            Token = BodyCommandParameterGroupList.GetParameterValue("token");
        }

        #endregion
    }
}