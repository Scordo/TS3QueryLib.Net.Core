using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class PermissionInfo : IEntity<PermissionInfo>
    {
        #region Properties

        public uint PermissionId { get; protected set; }
        public string PermissionName { get; protected set; }

        #endregion

        #region Public Methods

        PermissionInfo IEntity<PermissionInfo>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));
            
            PermissionId = currentParameterGroup.GetParameterValue<uint>("permid");
            PermissionName = currentParameterGroup.GetParameterValue("permsid");

            return this;
        }

        #endregion
    }
}