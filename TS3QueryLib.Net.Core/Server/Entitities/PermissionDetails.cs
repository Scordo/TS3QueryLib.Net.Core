using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class PermissionDetails : IEntity<PermissionDetails>
    {
        #region Properties

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion

        #region Public Methods

        public PermissionDetails ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            Id = currentParameterGroup.GetParameterValue<uint>("permid");
            Name = currentParameterGroup.GetParameterValue("permname");
            Description = currentParameterGroup.GetParameterValue("permdesc");

            return this;
        }

        #endregion
    }
}