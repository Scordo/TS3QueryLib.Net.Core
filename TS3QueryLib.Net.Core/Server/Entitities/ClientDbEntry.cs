using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ClientDbEntry : IEntity<ClientDbEntry>
    {
        #region Properties

        public uint DatabaseId { get; protected set; }
        public string NickName { get; protected set; }
        public string UniqueId { get; protected set; }
        public string Description { get; protected set; }
        public DateTime LastConnected { get; protected set; }
        public string LastIP { get; protected set; }
        public uint TotalConnections { get; protected set; }

        #endregion

        #region Public Methods

        ClientDbEntry IEntity<ClientDbEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));


            DatabaseId = currentParameterGroup.GetParameterValue<uint>("cldbid");
                NickName = currentParameterGroup.GetParameterValue("client_nickname");
            UniqueId = currentParameterGroup.GetParameterValue("client_unique_identifier");
            Description = currentParameterGroup.GetParameterValue("client_description");
            LastConnected = new DateTime(1970, 1, 1).AddSeconds(currentParameterGroup.GetParameterValue<ulong>("client_lastconnected"));
            TotalConnections = currentParameterGroup.GetParameterValue<uint>("client_totalconnections");
            LastIP = currentParameterGroup.GetParameterValue("client_lastip");

            return this;
        }

        #endregion
    }
}