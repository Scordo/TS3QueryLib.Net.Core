using System;
using System.Collections.Generic;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class ClientInfoCommandResponse : ClientInfoBaseCommandResponse
    {
        #region Properties

        public string Version { get; set; }
        public string Platform { get; set; }

        public bool InputMuted { get; protected set; }
        public bool OutputMuted { get; protected set; }
        public bool OuputOnlyMuted { get; protected set; }
        public bool HasInputHardware { get; protected set; }
        public bool HasOutputHardware { get; protected set; }
        public bool IsRecording { get; protected set; }
        public bool IsAway { get; protected set; }
        public bool IsTalker { get; protected set; }
        public bool IsPrioritySpeaker { get; protected set; }
        public string AwayMessage { get; protected set; }

        public string DefaultChannel { get; protected set; }
        public string MetaData { get; protected set; }
        public string LoginName { get; protected set; }
        public string TalkRequestMessage { get; protected set; }
        public string NicknamePhonetic { get; protected set; }

        public ulong FileTransferBandwidthSent { get; protected set; }
        public ulong FileTransferBandwidthReceived { get; protected set; }
        public ulong AmountOfPacketsSendTotal { get; protected set; }
        public ulong AmountOfPacketsReceivedTotal { get; protected set; }
        public ulong AmountOfBytesSendTotal { get; protected set; }
        public ulong AmountOfBytesReceivedTotal { get; protected set; }
        public ulong BandWidthSentLastSecondTotal { get; protected set; }
        public ulong BandWidthReceivedLastSecondTotal { get; protected set; }
        public ulong BandWidthSentLastMinuteTotal { get; protected set; }
        public ulong BandWidthReceivedLastMinuteTotal { get; protected set; }

        public uint ChannelId { get; protected set; }
        public uint ChannelGroupId { get; protected set; }
        public List<uint> ServerGroups { get; protected set; }
        public uint Type { get; protected set; }
        public uint TalkPower { get; protected set; }
        public uint TalkRequests { get; protected set; }
        public uint NeededServerQueryViewPower { get; protected set; }
        public string Avatar { get; protected set; }
        public TimeSpan IdleTime { get; protected set; }
        public TimeSpan ConnectedTime { get; protected set; }
        public string ClientIP { get; protected set; }
        public string ClientCountry { get; protected set; }

        #endregion

        protected override void OnPostApplyResponse()
        {
            base.OnPostApplyResponse();
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            Version = BodyCommandParameterGroupList.GetParameterValue("client_version");
            Platform = BodyCommandParameterGroupList.GetParameterValue("client_platform");
            InputMuted = BodyCommandParameterGroupList.GetParameterValue("client_input_muted").ToBool();
            OutputMuted = BodyCommandParameterGroupList.GetParameterValue("client_output_muted").ToBool();
            OuputOnlyMuted = BodyCommandParameterGroupList.GetParameterValue("client_outputonly_muted").ToBool();
            HasInputHardware = BodyCommandParameterGroupList.GetParameterValue("client_input_hardware").ToBool();
            HasOutputHardware = BodyCommandParameterGroupList.GetParameterValue("client_output_hardware").ToBool();
            IsRecording = BodyCommandParameterGroupList.GetParameterValue("client_is_recording").ToBool();
            IsAway = BodyCommandParameterGroupList.GetParameterValue("client_away").ToBool();
            IsTalker = BodyCommandParameterGroupList.GetParameterValue("client_is_talker").ToBool();
            IsPrioritySpeaker = BodyCommandParameterGroupList.GetParameterValue("client_is_priority_speaker").ToBool();
            AwayMessage = BodyCommandParameterGroupList.GetParameterValue("client_away_message");

            DefaultChannel = BodyCommandParameterGroupList.GetParameterValue("client_default_channel");
            MetaData = BodyCommandParameterGroupList.GetParameterValue("client_meta_data");
            LoginName = BodyCommandParameterGroupList.GetParameterValue("client_login_name");
            TalkRequestMessage = BodyCommandParameterGroupList.GetParameterValue("client_talk_request_msg");
            NicknamePhonetic = BodyCommandParameterGroupList.GetParameterValue("client_nickname_phonetic");

            FileTransferBandwidthSent = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_FILETRANSFER_BANDWIDTH_SENT");
            FileTransferBandwidthReceived = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_FILETRANSFER_BANDWIDTH_RECEIVED");
            AmountOfPacketsSendTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_PACKETS_SENT_TOTAL");
            AmountOfPacketsReceivedTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_PACKETS_RECEIVED_TOTAL");
            AmountOfBytesSendTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_BYTES_SENT_TOTAL");
            AmountOfBytesReceivedTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_BYTES_RECEIVED_TOTAL");
            BandWidthSentLastSecondTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_BANDWIDTH_SENT_LAST_SECOND_TOTAL");
            BandWidthReceivedLastSecondTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_BANDWIDTH_RECEIVED_LAST_SECOND_TOTAL");
            BandWidthSentLastMinuteTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_BANDWIDTH_SENT_LAST_MINUTE_TOTAL");
            BandWidthReceivedLastMinuteTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("CONNECTION_BANDWIDTH_RECEIVED_LAST_MINUTE_TOTAL");

            DatabaseId = BodyCommandParameterGroupList.GetParameterValue<uint>("client_database_id");
            ChannelId = BodyCommandParameterGroupList.GetParameterValue<uint>("cid");
            ChannelGroupId = BodyCommandParameterGroupList.GetParameterValue<uint>("client_channel_group_id");

            ServerGroups = BodyCommandParameterGroupList.GetParameterValue("client_servergroups").ToIdList();
            Type = BodyCommandParameterGroupList.GetParameterValue<uint>("client_type");
            TalkPower = BodyCommandParameterGroupList.GetParameterValue<uint>("client_talk_power");
            TalkRequests = BodyCommandParameterGroupList.GetParameterValue<uint>("client_talk_request");
            NeededServerQueryViewPower = BodyCommandParameterGroupList.GetParameterValue<uint>("client_needed_serverquery_view_power");

            Avatar = BodyCommandParameterGroupList.GetParameterValue("client_flag_avatar");
            IdleTime = TimeSpan.FromMilliseconds(BodyCommandParameterGroupList.GetParameterValue<uint>("client_idle_time"));
            ConnectedTime = TimeSpan.FromMilliseconds(BodyCommandParameterGroupList.GetParameterValue<uint>("connection_connected_time"));
            ClientIP = BodyCommandParameterGroupList.GetParameterValue("connection_client_ip");
            ClientCountry = BodyCommandParameterGroupList.GetParameterValue("client_country");
        }
    }
}