using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Notification.EventArgs
{
    public class ClientMovedByClientEventArgs: ClientMovedEventArgs
    {
        #region Properties

        public uint InvokerClientId { get; protected set; }
        public string InvokerNickname { get; protected set; }
        public string InvokerUniqueId { get; protected set; }

        #endregion

        #region Constructor

        internal ClientMovedByClientEventArgs(CommandParameterGroupList commandParameterGroupList) : base(commandParameterGroupList)
        {
            InvokerClientId = commandParameterGroupList.GetParameterValue<uint>("invokerid");
            InvokerNickname = commandParameterGroupList.GetParameterValue("invokername");
            InvokerUniqueId = commandParameterGroupList.GetParameterValue("invokeruid");
        }

        #endregion
    }
}