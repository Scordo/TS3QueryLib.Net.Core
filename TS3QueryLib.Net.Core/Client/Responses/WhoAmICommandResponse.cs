using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Client.Responses
{
    public class WhoAmICommandResponse : CommandResponse
    {
        #region Properties

        public uint ClientId { get; protected set; }
        public uint ChannelId { get; protected set; }
     
        #endregion


        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            ClientId = BodyCommandParameterGroupList.GetParameterValue<uint>("clid");
            ChannelId = BodyCommandParameterGroupList.GetParameterValue<uint>("cid");
        }
    }
}