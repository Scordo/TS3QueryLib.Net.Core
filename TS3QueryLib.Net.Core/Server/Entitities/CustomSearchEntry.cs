using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class CustomSearchEntry : IEntity<CustomSearchEntry>
    {
        #region Properties

        public uint ClientDatabaseId { get; protected set; }
        public string Ident { get; protected set; }
        public string Value { get; protected set; }

        #endregion

        #region Public Methods

        CustomSearchEntry IEntity<CustomSearchEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            ApplyFrom(currentParameterGroup);

            return this;
        }

        protected void ApplyFrom(CommandParameterGroup currentParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            ClientDatabaseId = currentParameterGroup.GetParameterValue<uint>("cldbid");
            Ident = currentParameterGroup.GetParameterValue("ident");
            Value = currentParameterGroup.GetParameterValue("value");
        }

        #endregion
    }
}