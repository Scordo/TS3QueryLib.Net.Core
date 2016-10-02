using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ServerGroupLight : IEntity<ServerGroupLight>
    {
        #region Properties

        public uint Id { get; set; }
        public string Name { get; set; }

        #endregion

        ServerGroupLight IEntity<ServerGroupLight>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            ApplyFrom(currentParameterGroup);

            return this;
        }

        protected virtual void ApplyFrom(CommandParameterGroup currentParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            Id = currentParameterGroup.GetParameterValue<uint>("sgid");
            Name = currentParameterGroup.GetParameterValue("name");
        }
    }
}