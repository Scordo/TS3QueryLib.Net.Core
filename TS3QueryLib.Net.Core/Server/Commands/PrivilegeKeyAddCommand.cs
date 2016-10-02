using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class PrivilegeKeyAddCommand : ExecutableSingleValueCommand<string>
    {
        public PrivilegeKeyAddCommand(bool isChannelGroupIdInsteadOfServerGroupId, uint groupId, uint channelId, IEnumerable<KeyValuePair<string, string>> identValuePairs) : this(isChannelGroupIdInsteadOfServerGroupId, groupId, channelId, null, identValuePairs)
        {
        }

        public PrivilegeKeyAddCommand(bool isChannelGroupIdInsteadOfServerGroupId, uint groupId, uint channelId, string tokenDescription, IEnumerable<KeyValuePair<string, string>> identValuePairs) : base("PrivilegeKeyAdd", "token")
        {
            string tokenCustomSettings = string.Join("|", identValuePairs.Select(ivp => string.Format("ident={0} value={1}", ivp.Key, ivp.Value)).ToArray());

            if (tokenCustomSettings.IsNullOrTrimmedEmpty())
                tokenCustomSettings = null;

            AddToCommand(isChannelGroupIdInsteadOfServerGroupId, groupId, channelId, tokenDescription, tokenCustomSettings);
        }

        public PrivilegeKeyAddCommand(bool isChannelGroupIdInsteadOfServerGroupId, uint groupId, uint channelId, string tokenDescription = null, string tokenCustomSettings = null) : base("PrivilegeKeyAdd", "token")
        {   
            AddToCommand(isChannelGroupIdInsteadOfServerGroupId, groupId, channelId, tokenDescription, tokenCustomSettings);
        }

        private void AddToCommand(bool isChannelGroupIdInsteadOfServerGroupId, uint groupId, uint channelId, string tokenDescription, string tokenCustomSettings)
        {
            AddParameter("tokentype", isChannelGroupIdInsteadOfServerGroupId);
            AddParameter("tokenid1", groupId);
            AddParameter("tokenid2", channelId);

            if (!tokenDescription.IsNullOrTrimmedEmpty())
                AddParameter("tokendescription", tokenDescription);

            if (!tokenCustomSettings.IsNullOrTrimmedEmpty())
                AddParameter("tokencustomset", tokenCustomSettings);
        }
    }
}