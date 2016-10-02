using System;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class ServerRequestConnectionInfoCommandResponse : CommandResponse
    {
        #region Properties

        public uint FileTransferBandwidthSent { get; protected set; }
        public uint FileTransferBandwidthReceived { get; protected set; }
        public ulong PacketsSentTotal { get; protected set; }
        public ulong PacketsReceivedTotal { get; protected set; }
        public ulong BytesSentTotal { get; protected set; }
        public ulong BytesReceivedTotal { get; protected set; }
        public uint BandwidthSentLastSecond { get; protected set; }
        public uint BandwidthSentLastMinute { get; protected set; }
        public uint BandwidthReceivedLastSecond { get; protected set; }
        public uint BandwidthReceivedLastMinute { get; protected set; }
        public TimeSpan ConnectionDuration { get; protected set; }
        public ulong FileTransferBytesSentTotal { get; protected set; }
        public ulong FileTransferBytesReceivedTotal { get; protected set; }
        public double PacketLossTotal { get; protected set; }
        public double Ping { get; protected set; }

        #endregion

        #region Non Public Methods

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            FileTransferBandwidthSent = BodyCommandParameterGroupList.GetParameterValue<uint>("connection_filetransfer_bandwidth_sent");
            FileTransferBandwidthReceived = BodyCommandParameterGroupList.GetParameterValue<uint>("connection_filetransfer_bandwidth_received");
            PacketsSentTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_packets_sent_total");
            PacketsReceivedTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_bytes_sent_total");
            BytesSentTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_packets_received_total");
            BytesReceivedTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_bytes_received_total");
            BandwidthSentLastSecond = BodyCommandParameterGroupList.GetParameterValue<uint>("connection_bandwidth_sent_last_second_total");
            BandwidthSentLastMinute = BodyCommandParameterGroupList.GetParameterValue<uint>("connection_bandwidth_sent_last_minute_total");
            BandwidthReceivedLastSecond = BodyCommandParameterGroupList.GetParameterValue<uint>("connection_bandwidth_received_last_second_total");
            BandwidthReceivedLastMinute = BodyCommandParameterGroupList.GetParameterValue<uint>("connection_bandwidth_received_last_minute_total");
            ConnectionDuration = TimeSpan.FromMilliseconds(BodyCommandParameterGroupList.GetParameterValue<uint>("connection_connected_time"));

            FileTransferBytesSentTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_filetransfer_bytes_sent_total");
            FileTransferBytesReceivedTotal = BodyCommandParameterGroupList.GetParameterValue<ulong>("connection_filetransfer_bytes_received_total");
            PacketLossTotal = BodyCommandParameterGroupList.GetParameterValue<double>("connection_packetloss_total");
            Ping = BodyCommandParameterGroupList.GetParameterValue<double>("connection_ping");
        }

        #endregion
    }
}
