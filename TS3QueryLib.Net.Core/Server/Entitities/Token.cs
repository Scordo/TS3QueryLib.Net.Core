using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class Token : IEntity<Token>
    {
        #region Properties

        public string TokenText { get; protected set; }
        public uint Type { get; protected set; }
        public uint GroupId { get; protected set; }
        public uint ChannelId { get; protected set; }
        public string Description { get; protected set; }

        #endregion

        #region Public Methods

        public Token ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            TokenText = currentParameterGroup.GetParameterValue("token");
            Type = currentParameterGroup.GetParameterValue<uint>("token_type");
            GroupId = currentParameterGroup.GetParameterValue<uint>("token_id1");
            ChannelId = currentParameterGroup.GetParameterValue<uint>("token_id2");
            Description = currentParameterGroup.GetParameterValue("token_description");

            return this;
        }

        #endregion
    }
}