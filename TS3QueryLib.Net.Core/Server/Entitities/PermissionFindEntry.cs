using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class PermissionFindEntry : IEntity<PermissionFindEntry>
    {
        #region Properties

        public uint T { get; set; }
        public uint Id1 { get; set; }
        public uint Id2 { get; set; }
        public int PermissionId { get; set; }

        #endregion

        #region Public Methods

        PermissionFindEntry IEntity<PermissionFindEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            T = currentParameterGroup.GetParameterValue<uint>("t");
            Id1 = currentParameterGroup.GetParameterValue<uint>("id1");
            Id2 = currentParameterGroup.GetParameterValue<uint>("id2");
            PermissionId = currentParameterGroup.GetParameterValue<int>("p");
            
            return this;
        }

        #endregion
    }
}