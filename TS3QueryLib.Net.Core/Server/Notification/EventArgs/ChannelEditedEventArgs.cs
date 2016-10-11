using System;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Notification.EventArgs
{
    public class ChannelEditedEventArgs : System.EventArgs, IDump
    {
        #region Properties

        public uint? ChannelId { get; protected set; }
        public uint? ReasonId { get; protected set; }
        public uint? InvokerId { get; protected set; }
        public string InvokerName { get; protected set; }
        public string InvokerUniqueId { get; protected set; }
        public string ChannelName { get; protected set; }

        #endregion

        #region Constructors

        public ChannelEditedEventArgs(CommandParameterGroupList commandParameterGroupList)
        {
            if (commandParameterGroupList == null)
                throw new ArgumentNullException(nameof(commandParameterGroupList));

            ChannelId = commandParameterGroupList.GetParameterValue<uint>("cid");
            ReasonId = commandParameterGroupList.GetParameterValue<uint>("reasonid");
            InvokerId = commandParameterGroupList.GetParameterValue<uint>("invokerid");
            InvokerName = commandParameterGroupList.GetParameterValue<string>("invokername");
            InvokerUniqueId = commandParameterGroupList.GetParameterValue<string>("invokeruid");
            ChannelName = commandParameterGroupList.GetParameterValue<string>("channel_name");
        }

        #endregion
    }
}