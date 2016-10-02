using System;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class HostInfoResponse : CommandResponse
    {
        #region Properties

        public TimeSpan Uptime { get; protected set; }
        public DateTime UtcTimeStamp { get; protected set; }
        public uint? VirtualServersCount { get; protected set; }
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
        public uint TotalMaxClients { get; protected set; }
        public uint TotalClientsOnline { get; protected set; }
        public uint TotalChannelsOnline { get; protected set; }
        public ulong FileTransferBytesSentTotal { get; protected set; }
        public ulong FileTransferBytesReceivedTotal { get; protected set; }

        #endregion

        #region Non Public Methods
        
        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            Uptime = TimeSpan.FromSeconds(BodyCommandParameterGroupList.GetParameterValue<ulong>("INSTANCE_UPTIME"));
            UtcTimeStamp = new DateTime(1970, 1, 1).AddSeconds(BodyCommandParameterGroupList.GetParameterValue<ulong>("HOST_TIMESTAMP_UTC"));
            VirtualServersCount = BodyCommandParameterGroupList.GetParameterValue<uint>("VIRTUALSERVERS_RUNNING_TOTAL");
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
            TotalMaxClients = BodyCommandParameterGroupList.GetParameterValue<uint>("virtualservers_total_maxclients");
            TotalClientsOnline = BodyCommandParameterGroupList.GetParameterValue<uint>("virtualservers_total_clients_online");
            TotalChannelsOnline = BodyCommandParameterGroupList.GetParameterValue<uint>("virtualservers_total_channels_online");

            FileTransferBytesSentTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_filetransfer_bytes_sent_total");
            FileTransferBytesReceivedTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_filetransfer_bytes_received_total");
        }

        #endregion
    }
}