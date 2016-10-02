using System;
using TS3QueryLib.Net.Core.Common.Responses;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class ServerInfoCommandResponse : CommandResponse
    {
        #region Properties

        public string UniqueId { get; protected set; }
        public string Name { get; protected set; }
        public string WelcomeMessage { get; protected set; }
        public string Platform { get; protected set; }
        public string Version { get; protected set; }
        public string MinClientVersion { get; protected set; }
        public string PasswordHash { get; protected set; }
        public string HostMessage { get; protected set; }
        public string FileBase { get; protected set; }
        public string HostButtonTooltip { get; protected set; }
        public string HostButtonUrl { get; protected set; }
        public string HostBannerUrl { get; protected set; }
        public string HostBannerGraphicsUrl { get; protected set; }
        public DateTime DateCreatedUtc { get; protected set; }

        public uint Id { get; protected set; }
        public ushort Port { get; protected set; }
        public ushort ReservedSlots { get; protected set; }
        public uint NumberOfClientsOnline { get; protected set; }
        public uint NumberOfQueryClientsOnline { get; protected set; }
        public uint MaximumClientsAllowed { get; protected set; }
        public TimeSpan Uptime { get; protected set; }
        public bool? AutoStart { get; protected set; }
        public string MachineId { get; protected set; }

        public int? AntiFloodPointsTickReduce { get; protected set; }
        public int AntiFloodPointsNeededIPBlock { get; protected set; }
        public int AntiFloodPointsNeededCommandBlock { get; protected set; }

        public bool LogClient { get; protected set; }
        public bool LogQuery { get; protected set; }
        public bool LogChannel { get; protected set; }
        public bool LogPermission { get; protected set; }
        public bool LogServer { get; protected set; }
        public bool LogFiletransfer { get; protected set; }
        public VirtualServerStatus ServerStatus { get; protected set; }
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
        public double PrioritySpeakerDimmModification { get; protected set; }

        public int ClientConnections { get; protected set; }
        public int QueryClientConnections { get; protected set; }
        public int DefaultChannelAdminGroupId { get; protected set; }
        public int DefaultServerGroupId { get; protected set; }
        public int DefaultChannelGroupId { get; protected set; }
        public int HostBannerGraphicsInterval { get; protected set; }
        public int ChannelsOnline { get; protected set; }
        public int ComplainAutoBanCount { get; protected set; }
        public int ComplainAutoBanTime { get; protected set; }
        public int ComplainRemoveTime { get; protected set; }
        public int MinClientsBeforeForcedSilence { get; protected set; }
        public int NeededIdentitySecurityLevel { get; protected set; }

        public ulong DownloadQuota { get; protected set; }
        public ulong UploadQuota { get; protected set; }
        public ulong MaxDownloadTotalBandwidth { get; protected set; }
        public ulong MaxUploadTotalBandwidth { get; protected set; }
        public ulong MonthBytesDownloaded { get; protected set; }
        public ulong MonthBytesUploaded { get; protected set; }
        public ulong TotalBytesDownloaded { get; protected set; }
        public ulong TotalBytesUploaded { get; protected set; }

        public bool IsPasswordProtected { get; protected set; }
        public HostMessageMode HostMessageMode { get; protected set; }
        public string PhoneticName { get; protected set; }
        public uint IconId { get; protected set; }
        public string HostButtonGraphicsUrl { get; protected set; }

        public HostBannerMode HostBannerMode { get; protected set; }
        public double TotalPacketLossSpeech { get; protected set; }
        public double TotalPacketLossKeepalive { get; protected set; }
        public double TotalPacketLossControl { get; protected set; }
        public double TotalPacketLossTotal { get; protected set; }
        public double TotalPing { get; protected set; }
        public string IP { get; protected set; }
        public bool WeblistEnabled { get; protected set; }
        public bool AskForPrivilegKey { get; protected set; }
        public ulong FileTransferBytesSentTotal { get; protected set; }
        public ulong FileTransferBytesReceivedTotal { get; protected set; }
        public ulong PacketsSentSpeech { get; protected set; }
        public ulong BytesSentSpeech { get; protected set; }
        public ulong PacketsReceivedSpeech { get; protected set; }
        public ulong BytesReceivedSpeech { get; protected set; }
        public ulong PacketsSentKeepAlive { get; protected set; }
        public ulong BytesSentKeepAlive { get; protected set; }
        public ulong PacketsReceivedKeepAlive { get; protected set; }
        public ulong BytesReceivedKeepAlive { get; protected set; }
        public ulong PacketsSentControl { get; protected set; }
        public ulong BytesSentControl { get; protected set; }
        public ulong PacketsReceivedControl { get; protected set; }
        public ulong BytesReceivedControl { get; protected set; }

        #endregion

        #region Non Public Methods

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            UniqueId = BodyCommandParameterGroupList.GetParameterValue("virtualserver_unique_identifier");
            Name = BodyCommandParameterGroupList.GetParameterValue("virtualserver_name");
            WelcomeMessage = BodyCommandParameterGroupList.GetParameterValue("virtualserver_welcomemessage");
            Platform = BodyCommandParameterGroupList.GetParameterValue("virtualserver_platform");
            Version = BodyCommandParameterGroupList.GetParameterValue("virtualserver_version");
            MinClientVersion = BodyCommandParameterGroupList.GetParameterValue("virtualserver_min_client_version");
            PasswordHash = BodyCommandParameterGroupList.GetParameterValue("virtualserver_password");
            HostMessage = BodyCommandParameterGroupList.GetParameterValue("virtualserver_hostmessage");
            FileBase = BodyCommandParameterGroupList.GetParameterValue("virtualserver_filebase");
            HostButtonTooltip = BodyCommandParameterGroupList.GetParameterValue("virtualserver_hostbutton_tooltip");
            HostButtonUrl = BodyCommandParameterGroupList.GetParameterValue("virtualserver_hostbutton_url");
            HostBannerUrl = BodyCommandParameterGroupList.GetParameterValue("virtualserver_hostbanner_url");
            HostBannerGraphicsUrl = BodyCommandParameterGroupList.GetParameterValue("virtualserver_hostbanner_gfx_url");
            DateCreatedUtc = new DateTime(1970, 1, 1).AddSeconds(BodyCommandParameterGroupList.GetParameterValue<ulong>("virtualserver_created"));

            Id = BodyCommandParameterGroupList.GetParameterValue<uint>("virtualserver_id");
            Port = BodyCommandParameterGroupList.GetParameterValue<ushort>("virtualserver_port");
            ReservedSlots = BodyCommandParameterGroupList.GetParameterValue<ushort>("VIRTUALSERVER_RESERVED_SLOTS");
            NumberOfClientsOnline = BodyCommandParameterGroupList.GetParameterValue<uint>("virtualserver_clientsonline");
            NumberOfQueryClientsOnline = BodyCommandParameterGroupList.GetParameterValue<uint>("virtualserver_queryclientsonline");
            MaximumClientsAllowed = BodyCommandParameterGroupList.GetParameterValue<uint>("virtualserver_maxclients");
            Uptime = TimeSpan.FromSeconds(BodyCommandParameterGroupList.GetParameterValue<uint>("virtualserver_uptime"));
            AutoStart = BodyCommandParameterGroupList.GetParameterValue("virtualserver_autostart") == "1";
            MachineId = BodyCommandParameterGroupList.GetParameterValue("virtualserver_machine_id");

            AntiFloodPointsTickReduce = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_antiflood_points_tick_reduce");
            AntiFloodPointsNeededIPBlock = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_antiflood_points_needed_ip_block");
            AntiFloodPointsNeededCommandBlock = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_antiflood_points_needed_command_block");

            LogClient = BodyCommandParameterGroupList.GetParameterValue("virtualserver_log_client") == "1";
            LogQuery = BodyCommandParameterGroupList.GetParameterValue("virtualserver_log_query") == "1";
            LogChannel = BodyCommandParameterGroupList.GetParameterValue("virtualserver_log_channel") == "1";
            LogPermission = BodyCommandParameterGroupList.GetParameterValue("virtualserver_log_permissions") == "1";
            LogServer = BodyCommandParameterGroupList.GetParameterValue("virtualserver_log_server") == "1";
            LogFiletransfer = BodyCommandParameterGroupList.GetParameterValue("virtualserver_log_filetransfer") == "1";

            string statusString = BodyCommandParameterGroupList.GetParameterValue("virtualserver_status");
            ServerStatus = VirtualServerStatusHelper.Parse(statusString);
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
            PrioritySpeakerDimmModification = BodyCommandParameterGroupList.GetParameterValue<double>("virtualserver_priority_speaker_dimm_modificator");

            ClientConnections = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_client_connections");
            QueryClientConnections = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_query_client_connections");
            DefaultChannelAdminGroupId = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_default_channel_admin_group");
            DefaultServerGroupId = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_default_server_group");
            DefaultChannelGroupId = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_default_channel_group");
            HostBannerGraphicsInterval = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_hostbanner_gfx_interval");
            ChannelsOnline = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_channelsonline");
            ComplainAutoBanCount = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_complain_autoban_count");
            ComplainAutoBanTime = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_complain_autoban_time");
            ComplainRemoveTime = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_complain_remove_time");
            MinClientsBeforeForcedSilence = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_min_clients_in_channel_before_forced_silence");
            NeededIdentitySecurityLevel = BodyCommandParameterGroupList.GetParameterValue<int>("virtualserver_needed_identity_security_level");

            DownloadQuota = BodyCommandParameterGroupList.GetParameterValue<ulong>("virtualserver_download_quota");
            UploadQuota = BodyCommandParameterGroupList.GetParameterValue<ulong>("virtualserver_upload_quota");
            MaxDownloadTotalBandwidth = BodyCommandParameterGroupList.GetParameterValue<ulong>("virtualserver_max_download_total_bandwidth");
            MaxUploadTotalBandwidth = BodyCommandParameterGroupList.GetParameterValue<ulong>("virtualserver_max_upload_total_bandwidth");
            MonthBytesDownloaded = BodyCommandParameterGroupList.GetParameterValue<ulong>("virtualserver_month_bytes_downloaded");
            MonthBytesUploaded = BodyCommandParameterGroupList.GetParameterValue<ulong>("virtualserver_month_bytes_uploaded");
            TotalBytesDownloaded = BodyCommandParameterGroupList.GetParameterValue<ulong>("virtualserver_total_bytes_downloaded");
            TotalBytesUploaded = BodyCommandParameterGroupList.GetParameterValue<ulong>("virtualserver_total_bytes_uploaded");

            IsPasswordProtected = BodyCommandParameterGroupList.GetParameterValue("virtualserver_flag_password") == "1";
            HostMessageMode = (HostMessageMode)BodyCommandParameterGroupList.GetParameterValue<uint>("virtualserver_hostmessage_mode");
            PhoneticName = BodyCommandParameterGroupList.GetParameterValue("virtualserver_name_phonetic");
            IconId = BodyCommandParameterGroupList.GetParameterValue<uint>("virtualserver_icon_id");
            HostButtonGraphicsUrl = BodyCommandParameterGroupList.GetParameterValue("virtualserver_hostbutton_gfx_url");

            TotalPacketLossSpeech = BodyCommandParameterGroupList.GetParameterValue<double>("virtualserver_total_packetloss_speech");
            TotalPacketLossKeepalive = BodyCommandParameterGroupList.GetParameterValue<double>("virtualserver_total_packetloss_keepalive");
            TotalPacketLossControl = BodyCommandParameterGroupList.GetParameterValue<double>("virtualserver_total_packetloss_control");
            TotalPacketLossTotal = BodyCommandParameterGroupList.GetParameterValue<double>("virtualserver_total_packetloss_total");
            TotalPing = BodyCommandParameterGroupList.GetParameterValue<double>("virtualserver_total_ping");
            IP = BodyCommandParameterGroupList.GetParameterValue("virtualserver_ip");
            WeblistEnabled = BodyCommandParameterGroupList.GetParameterValue("virtualserver_weblist_enabled") == "1";
            AskForPrivilegKey = BodyCommandParameterGroupList.GetParameterValue("virtualserver_ask_for_privilegekey") == "1";
            HostBannerMode = (HostBannerMode)BodyCommandParameterGroupList.GetParameterValue<uint>("virtualserver_hostbanner_mode");
            FileTransferBytesSentTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_filetransfer_bytes_sent_total");
            FileTransferBytesReceivedTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_filetransfer_bytes_received_total");
            PacketsSentSpeech = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_packets_sent_speech");
            BytesSentSpeech = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_bytes_sent_speech");
            PacketsReceivedSpeech = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_packets_received_speech");
            BytesReceivedSpeech = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_bytes_received_speech");
            PacketsSentKeepAlive = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_packets_sent_keepalive");
            BytesSentKeepAlive = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_bytes_sent_keepalive");
            PacketsReceivedKeepAlive = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_packets_received_keepalive");
            BytesReceivedKeepAlive = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_bytes_received_keepalive");
            PacketsSentControl = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_packets_sent_control");
            BytesSentControl = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_bytes_sent_control");
            PacketsReceivedControl = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_packets_received_control");
            BytesReceivedControl = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_bytes_received_control");
        }

        #endregion
    }
}
