using System;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class InstanceInfoCommandResponse : CommandResponse
    {
        #region Properties

        public uint DatabaseVersion { get; protected set; }
        public uint GuestServerQueryGroupId { get; protected set; }
        public uint TemplateServerAdminGroupId { get; protected set; }
        public uint TemplateServerDefaultGroupId { get; protected set; }
        public uint TemplateChannelAdminGroupId { get; protected set; }
        public uint TemplateChannelDefaultGroupId { get; protected set; }
        public ushort FileTransferPort { get; protected set; }
        public ulong MaxDownloadTotalBandWidth { get; protected set; }
        public ulong MaxUploadTotalBandWidth { get; protected set; }

        public uint ServerQueryFloodCommandsCount { get; protected set; }
        public TimeSpan ServerQueryFloodRatingDuration { get; protected set; }
        public TimeSpan ServerQueryBanDuration { get; protected set; }

        #endregion

        #region Non Public Methods

        protected override void OnPostApplyResponse()
        {
            
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            DatabaseVersion = BodyCommandParameterGroupList.GetParameterValue<uint>("SERVERINSTANCE_DATABASE_VERSION");
            GuestServerQueryGroupId = BodyCommandParameterGroupList.GetParameterValue<uint>("SERVERINSTANCE_GUEST_SERVERQUERY_GROUP");
            TemplateServerAdminGroupId = BodyCommandParameterGroupList.GetParameterValue<uint>("SERVERINSTANCE_TEMPLATE_SERVERADMIN_GROUP");
            TemplateServerDefaultGroupId = BodyCommandParameterGroupList.GetParameterValue<uint>("serverinstance_template_serverdefault_group");
            TemplateChannelAdminGroupId = BodyCommandParameterGroupList.GetParameterValue<uint>("serverinstance_template_channeladmin_group");
            TemplateChannelDefaultGroupId = BodyCommandParameterGroupList.GetParameterValue<uint>("serverinstance_template_channeldefault_group");
            FileTransferPort = BodyCommandParameterGroupList.GetParameterValue<ushort>("SERVERINSTANCE_FILETRANSFER_PORT");
            MaxDownloadTotalBandWidth = BodyCommandParameterGroupList.GetParameterValue<ulong>("SERVERINSTANCE_MAX_DOWNLOAD_TOTAL_BANDWIDTH");
            MaxUploadTotalBandWidth = BodyCommandParameterGroupList.GetParameterValue<ulong>("SERVERINSTANCE_MAX_UPLOAD_TOTAL_BANDWIDTH");

            ServerQueryFloodCommandsCount = BodyCommandParameterGroupList.GetParameterValue<uint>("serverinstance_serverquery_flood_commands");
            ServerQueryFloodRatingDuration = TimeSpan.FromSeconds(BodyCommandParameterGroupList.GetParameterValue<double>("serverinstance_serverquery_flood_time"));
            ServerQueryBanDuration = TimeSpan.FromSeconds(BodyCommandParameterGroupList.GetParameterValue<double>("serverinstance_serverquery_ban_time"));
        }

        #endregion
    }
}
