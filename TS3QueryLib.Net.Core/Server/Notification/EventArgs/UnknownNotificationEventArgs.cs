using System;
using TS3QueryLib.Net.Core.Common;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Notification.EventArgs
{
    public class UnknownNotificationEventArgs : System.EventArgs, IDump
    {
        #region Properties

        public string Name { get; protected set; }
        public CommandParameterGroupList CommandParameterGroupList { get; protected set; }

        public string ResponseText { get; protected set; }

        #endregion

        #region Constructors

        public UnknownNotificationEventArgs(string name, CommandParameterGroupList commandParameterGroupList, string responseText)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (commandParameterGroupList == null)
                throw new ArgumentNullException(nameof(commandParameterGroupList));
            if (responseText == null)
                throw new ArgumentNullException(nameof(responseText));

            Name = name;
            CommandParameterGroupList = commandParameterGroupList;
            ResponseText = responseText;
        }

        #endregion
    }
}