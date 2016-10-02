using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ChannelGroupClient : IEntity<ChannelGroupClient>
    {
        #region Properties

        public uint ChannelId { get; protected set; }
        public uint ClientDatabaseId { get; protected set; }
        public uint ChannelGroupId { get; protected set; }

        #endregion

        #region Public Methods

        public ChannelGroupClient ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            ChannelId = currentParameterGroup.GetParameterValue<uint>("cid");
            ClientDatabaseId = currentParameterGroup.GetParameterValue<uint>("cldbid");
            ChannelGroupId = currentParameterGroup.GetParameterValue<uint>("cgid");

            return this;
        }

        #endregion
    }
}