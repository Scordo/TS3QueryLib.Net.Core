using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class BanListEntry : IEntity<BanListEntry>
    {
        #region Properties

        public uint Id { get; protected set; }
        public string Ip { get; protected set; }
        public DateTime Created { get; protected set; }
        public string InvokerNickname { get; protected set; }
        public uint InvokerClientDatabaseId { get; protected set; }
        public string InvokerUniqueId { get; protected set; }
        public string Reason { get; protected set; }
        public uint Enforcements { get; protected set; }

        #endregion

        #region Public Methods

        BanListEntry IEntity<BanListEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            Id = currentParameterGroup.GetParameterValue<uint>("banid");
            Ip = currentParameterGroup.GetParameterValue("ip");
            Created = new DateTime(1970, 1, 1).AddSeconds(currentParameterGroup.GetParameterValue<ulong>("created"));
            InvokerNickname = currentParameterGroup.GetParameterValue("invokername");
            InvokerClientDatabaseId = currentParameterGroup.GetParameterValue<uint>("invokercldbid");
            InvokerUniqueId = currentParameterGroup.GetParameterValue("invokeruid");
            Reason = currentParameterGroup.GetParameterValue("reason");
            Enforcements = currentParameterGroup.GetParameterValue<uint>("enforcements");

            return this;
        }

        #endregion
    }
}