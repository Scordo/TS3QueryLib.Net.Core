using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class ServerListItem : ServerListItemBase, IEntity<ServerListItem> 
    {
        #region Properties

        public string UniqueId { get; protected set; }
        public uint? ServerNumberOfClientsOnline { get; protected set; }
        public uint? ServerNumberOfQueryClientsOnline { get; protected set; }
        public uint? ServerMaximumClientsAllowed { get; protected set; }
        public TimeSpan? ServerUptime { get; protected set; }
        public string ServerName { get; protected set; }
        public bool ServerAutoStart { get; protected set; }
        public string ServerMachineId { get; protected set; }


        #endregion

        ServerListItem IEntity<ServerListItem>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            string statusString = currentParameterGroup.GetParameterValue("virtualserver_status");
            VirtualServerStatus status = VirtualServerStatusHelper.Parse(statusString);
            uint? uptime = currentParameterGroup.GetParameterValue<uint?>("virtualserver_uptime");
            
            UniqueId = currentParameterGroup.GetParameterValue("virtualserver_unique_identifier");
            ServerId = currentParameterGroup.GetParameterValue<uint>("virtualserver_id");
            ServerPort = currentParameterGroup.GetParameterValue<ushort>("virtualserver_port");
            ServerStatus = status;
            ServerNumberOfClientsOnline = currentParameterGroup.GetParameterValue<uint?>("virtualserver_clientsonline");
            ServerNumberOfQueryClientsOnline = currentParameterGroup.GetParameterValue<uint?>("virtualserver_queryclientsonline");
            ServerMaximumClientsAllowed = currentParameterGroup.GetParameterValue<uint?>("virtualserver_maxclients");
            ServerUptime = uptime.HasValue ? (TimeSpan?)TimeSpan.FromSeconds(uptime.Value) : null;
            ServerName = currentParameterGroup.GetParameterValue("virtualserver_name");
            ServerAutoStart = currentParameterGroup.GetParameterValue("virtualserver_autostart") == "1";
            ServerMachineId = currentParameterGroup.GetParameterValue("virtualserver_machine_id");

            return this;
        }
    }
}