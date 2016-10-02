using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class FtInitUploadCommandResponse : CommandResponse
    {
        #region Properties

        public uint? ClientFileTransferId { get; protected set; }
        public uint? ServerFileTransferId { get; protected set; }
        public string FileTransferKey { get; protected set; }
        public ushort? FileTransferPort { get; protected set; }
        public ulong? SeekPosition { get; protected set; }

        #endregion

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            ClientFileTransferId = BodyCommandParameterGroupList.GetParameterValue<uint?>("clientftfid");
            ServerFileTransferId = BodyCommandParameterGroupList.GetParameterValue<uint?>("serverftfid");
            FileTransferKey = BodyCommandParameterGroupList.GetParameterValue("ftkey");
            FileTransferPort = BodyCommandParameterGroupList.GetParameterValue<ushort?>("port");
            SeekPosition = BodyCommandParameterGroupList.GetParameterValue<ulong?>("seekpos");
        }
    }
}