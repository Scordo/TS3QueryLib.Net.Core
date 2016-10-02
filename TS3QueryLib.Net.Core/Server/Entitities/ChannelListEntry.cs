using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ChannelListEntry : ChannelListEntryBase, IEntity<ChannelListEntry>
    {
        #region Properties

        #region Always returned Properties

        public uint NeededSubscribePower { get; protected set; }

        #endregion

        #region Limits-Properties

        public int? TotalClientsFamily { get; protected set; }

        #endregion

        #endregion

        #region Public Methods

        ChannelListEntry IEntity<ChannelListEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            ChannelListEntry result = new ChannelListEntry();
            ApplyFrom(currentParameterGroup, firstParameterGroup);
            result.NeededSubscribePower = currentParameterGroup.GetParameterValue<uint>("channel_needed_subscribe_power");
            result.TotalClientsFamily = currentParameterGroup.GetParameterValue<int?>("total_clients_family");

            return this;

        }
        
        #endregion
    }
}
