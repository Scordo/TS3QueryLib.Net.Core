using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ServerGroup : ServerGroupLight, IEntity<ServerGroup>
    {
        #region Properties

        public ushort Type { get; protected set; }
        public uint IconId { get; protected set; }
        public bool SaveDb { get; protected set; }

        #endregion

        #region Public Methods

        ServerGroup IEntity<ServerGroup>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            base.ApplyFrom(currentParameterGroup);
            Type = currentParameterGroup.GetParameterValue<ushort>("type");
            IconId = currentParameterGroup.GetParameterValue<uint>("iconid");
            SaveDb = currentParameterGroup.GetParameterValue("savedb") == "1";

            return this;
        }

        #endregion
    }
}