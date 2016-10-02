using System;
using TS3QueryLib.Net.Core.Common.Responses;

namespace TS3QueryLib.Net.Core.Server.Responses
{
    public class ChannelInfoCommandResponse : CommandResponse
    {
        #region Properties

        public uint ParentChannelId { get; protected set; }
        public string Name { get; protected set; }
        public string Topic { get; protected set; }
        public string Description { get; protected set; }
        public string PasswordHash { get; protected set; }
        public ushort Codec { get; protected set; }
        public double CodecQuality { get; protected set; }
        public int MaxClients { get; protected set; }
        public int MaxFamilyClients { get; protected set; }
        public uint Order { get; protected set; }
        public bool IsPermanent { get; protected set; }
        public bool IsSemiPermanent { get; protected set; }
        public bool IsDefaultChannel { get; protected set; }
        public bool IsPasswordProtected { get; protected set; }
        public uint LatencyFactor { get; protected set; }
        public bool IsUnencrypted { get; protected set; }
        public string SecuritySalt { get; protected set; }
        public uint DeleteDelay { get; protected set; }
        public bool IsMaxClientsUnlimited { get; protected set; }
        public bool IsMaxFamilyClientsUnlimited { get; protected set; }
        public bool IsMaxFamilyClientsInherited { get; protected set; }
        public string FilePath { get; protected set; }
        public uint NeededTalkPower { get; protected set; }
        public bool ForcedSilence { get; protected set; }
        public string PhoneticName { get; protected set; }
        public uint IconId { get; protected set; }
        public int SecondsEmpty { get; protected set; }

        #endregion

        protected override void OnPostApplyResponse()
        {
            if (BodyCommandParameterGroupList.Count == 0)
                return;

            ParentChannelId = BodyCommandParameterGroupList.GetParameterValue<uint>("pid");
            Name = BodyCommandParameterGroupList.GetParameterValue("channel_name");
            Topic = BodyCommandParameterGroupList.GetParameterValue("channel_topic");
            Description = BodyCommandParameterGroupList.GetParameterValue("channel_description");
            PasswordHash = BodyCommandParameterGroupList.GetParameterValue("channel_password");
            Codec = BodyCommandParameterGroupList.GetParameterValue<ushort>("channel_codec");
            CodecQuality = BodyCommandParameterGroupList.GetParameterValue<double>("channel_codec_quality");
            MaxClients = BodyCommandParameterGroupList.GetParameterValue<int>("channel_maxclients");
            MaxFamilyClients = BodyCommandParameterGroupList.GetParameterValue<int>("channel_maxfamilyclients");
            Order = BodyCommandParameterGroupList.GetParameterValue<uint>("channel_order");
            IsPermanent = BodyCommandParameterGroupList.GetParameterValue("channel_flag_permanent").ToBool();
            IsSemiPermanent = BodyCommandParameterGroupList.GetParameterValue("channel_flag_semi_permanent").ToBool();
            IsDefaultChannel = BodyCommandParameterGroupList.GetParameterValue("channel_flag_default").ToBool();
            IsPasswordProtected = BodyCommandParameterGroupList.GetParameterValue("channel_flag_password").ToBool();
            LatencyFactor = BodyCommandParameterGroupList.GetParameterValue<uint>("channel_codec_latency_factor");
            IsUnencrypted = BodyCommandParameterGroupList.GetParameterValue("channel_codec_is_unencrypted").ToBool();
            SecuritySalt = BodyCommandParameterGroupList.GetParameterValue("channel_security_salt");
            DeleteDelay = BodyCommandParameterGroupList.GetParameterValue<uint>("channel_delete_delay");
            IsMaxClientsUnlimited = BodyCommandParameterGroupList.GetParameterValue("channel_flag_maxclients_unlimited").ToBool();
            IsMaxFamilyClientsUnlimited = BodyCommandParameterGroupList.GetParameterValue("channel_flag_maxfamilyclients_unlimited").ToBool();
            IsMaxFamilyClientsInherited = BodyCommandParameterGroupList.GetParameterValue("channel_flag_maxfamilyclients_inherited").ToBool();
            FilePath = BodyCommandParameterGroupList.GetParameterValue("channel_filepath");
            NeededTalkPower = BodyCommandParameterGroupList.GetParameterValue<uint>("channel_needed_talk_power");
            ForcedSilence = BodyCommandParameterGroupList.GetParameterValue("channel_forced_silence").ToBool();
            PhoneticName = BodyCommandParameterGroupList.GetParameterValue("channel_name_phonetic");
            IconId = BodyCommandParameterGroupList.GetParameterValue<uint>("channel_icon_id");
            // channel_flag_private=0 | Not implemented yet by TeamSpeak.
            SecondsEmpty = BodyCommandParameterGroupList.GetParameterValue<int>("seconds_empty");
        }
    }
}