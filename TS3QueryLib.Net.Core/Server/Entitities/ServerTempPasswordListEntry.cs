using System;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ServerTempPasswordListEntry : IEntity<ServerTempPasswordListEntry>
    {
        public string NickName { get; set; }
        public string UniqueId { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public DateTime StartTimeUtc { get; set; }
        public DateTime EndTimeUtc { get; set; }
        public uint ChannelId { get; set; }
        public string ChannelPassword { get; set; }

        ServerTempPasswordListEntry IEntity<ServerTempPasswordListEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));
            
            NickName = currentParameterGroup.GetParameterValue("nickname");
            UniqueId = currentParameterGroup.GetParameterValue("uid");
            Description = currentParameterGroup.GetParameterValue("desc");
            Password = currentParameterGroup.GetParameterValue("pw_clear");
            StartTimeUtc = Util.TS3DateTimeFromSeconds(currentParameterGroup.GetParameterValue<uint>("start"));
            EndTimeUtc = Util.TS3DateTimeFromSeconds(currentParameterGroup.GetParameterValue<uint>("end"));
            ChannelId = currentParameterGroup.GetParameterValue<uint>("tcid");
            ChannelPassword = currentParameterGroup.GetParameterValue("tcpw");
            
            return this;
        }
    }
}