using System;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class MessageGetCommandResponse : CommandResponse
    {
        #region Properties

        public uint MessageId { get; protected set; }
        public string SenderUniqueId { get; protected set; }
        public string Subject { get; protected set; }
        public DateTime Created { get; protected set; }
        public bool WasRead { get; protected set; }

        #endregion

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            MessageId = BodyCommandParameterGroupList.GetParameterValue<uint>("msgid");
            SenderUniqueId = BodyCommandParameterGroupList.GetParameterValue("cluid");
            Subject = BodyCommandParameterGroupList.GetParameterValue("subject");
            Created = new DateTime(1970, 1, 1).AddSeconds(BodyCommandParameterGroupList.GetParameterValue<ulong>("timestamp"));
            WasRead = BodyCommandParameterGroupList.GetParameterValue("flag_read").ToBool();
        }
    }
}