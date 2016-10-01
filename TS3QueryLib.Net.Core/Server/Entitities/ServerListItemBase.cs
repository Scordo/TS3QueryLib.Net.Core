using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ServerListItemBase : IEntity<ServerListItemBase> 
    {
        #region Properties

        public uint ServerId { get; protected set; }
        public ushort ServerPort { get; protected set; }
        public VirtualServerStatus ServerStatus { get; protected set; }

        #endregion

        public ServerListItemBase ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            string statusString = currentParameterGroup.GetParameterValue("virtualserver_status");
            VirtualServerStatus status = VirtualServerStatusHelper.Parse(statusString);

            ServerId = currentParameterGroup.GetParameterValue<uint>("virtualserver_id");
            ServerPort = currentParameterGroup.GetParameterValue<ushort>("virtualserver_port");
            ServerStatus = status;

            return this;
        }
    }
}