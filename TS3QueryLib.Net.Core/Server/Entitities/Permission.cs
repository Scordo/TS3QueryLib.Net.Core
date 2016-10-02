using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class Permission : ClientPermission, IEntity<Permission>
    {
        #region Properties

        public bool Negated { get; set; }
        public string Name { get; protected set; }

        #endregion

        #region Public Methods

        public Permission ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));
            
            Id = currentParameterGroup.GetParameter("permid") == null ? 0 : currentParameterGroup.GetParameterValue<uint>("permid");
            Name = currentParameterGroup.GetParameterValue("permsid");
            Value = currentParameterGroup.GetParameterValue<int>("permvalue");
            Negated = currentParameterGroup.GetParameterValue("permnegated") == "1";
            Skip = currentParameterGroup.GetParameterValue("permskip") == "1";

            return this;
        }

        #endregion
    }
}