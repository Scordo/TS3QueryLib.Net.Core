using System;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Notification.EventArgs
{
    public class ClientMovedEventArgs : System.EventArgs, IDump
    {
        #region Properties

        public uint ClientId { get; protected set; }
        public uint TargetChannelId { get; protected set; }

        #endregion

        internal ClientMovedEventArgs(CommandParameterGroupList commandParameterGroupList)
        {
            if (commandParameterGroupList == null)
                throw new ArgumentNullException(nameof(commandParameterGroupList));

            ClientId = commandParameterGroupList.GetParameterValue<uint>("clid");
            TargetChannelId = commandParameterGroupList.GetParameterValue<uint>("ctid");
        }
    }
}
