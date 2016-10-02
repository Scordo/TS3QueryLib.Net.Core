using System;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class ClientInfoBaseCommandResponse : CommandResponse
    {
        public string UniqueId { get; protected set; }
        public string Nickname { get; protected set; }
        public uint DatabaseId { get; protected set; }
        public DateTime LastConnected { get; protected set; }
        public DateTime Created { get; protected set; }
        public uint TotalConnections { get; protected set; }
        public string Description { get; protected set; }
        public ulong MonthBytesUploaded { get; protected set; }
        public ulong MonthBytesDonwloaded { get; protected set; }
        public ulong TotalBytesUploaded { get; protected set; }
        public ulong TotalBytesDownloaded { get; protected set; }
        public uint IconId { get; protected set; }
        public string HashedUniqueId { get; protected set; }

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            UniqueId = BodyCommandParameterGroupList.GetParameterValue("client_unique_identifier");
            Nickname = BodyCommandParameterGroupList.GetParameterValue("client_nickname");
            DatabaseId = BodyCommandParameterGroupList.GetParameterValue<uint>("client_database_id");
            Created = new DateTime(1970, 1, 1).AddSeconds(BodyCommandParameterGroupList.GetParameterValue<ulong>("client_created"));
            LastConnected = new DateTime(1970, 1, 1).AddSeconds(BodyCommandParameterGroupList.GetParameterValue<ulong>("client_lastconnected"));
            TotalConnections = BodyCommandParameterGroupList.GetParameterValue<uint>("client_totalconnections");
            Description = BodyCommandParameterGroupList.GetParameterValue("client_description");
            MonthBytesUploaded = BodyCommandParameterGroupList.GetParameterValue<ulong>("client_month_bytes_uploaded");
            MonthBytesDonwloaded = BodyCommandParameterGroupList.GetParameterValue<ulong>("client_month_bytes_downloaded");
            TotalBytesUploaded = BodyCommandParameterGroupList.GetParameterValue<ulong>("client_total_bytes_uploaded");
            TotalBytesDownloaded = BodyCommandParameterGroupList.GetParameterValue<ulong>("client_total_bytes_downloaded");
            IconId = BodyCommandParameterGroupList.GetParameterValue<uint>("client_icon_id");
            HashedUniqueId = BodyCommandParameterGroupList.GetParameterValue("client_base64HashClientUID");
        }
    }
}