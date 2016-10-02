using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ChannelFindEntry : IEntity<ChannelFindEntry>
    {
        #region Properties

        public uint Id { get; protected set; }
        public string Name { get; protected set; }

        #endregion
        
        #region Public Methods

        public ChannelFindEntry ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));


            Id = currentParameterGroup.GetParameterValue<uint>("cid");
            Name = currentParameterGroup.GetParameterValue("channel_name");

            return this;
        }

        #endregion
    }
}