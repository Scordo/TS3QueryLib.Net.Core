using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelEditCommand : ExecutableValuelessCommand
    {
        public ChannelEditCommand(uint channelId, ChannelModification channelModification) : base("ChannelEdit")
        {
            if (channelModification == null)
                throw new ArgumentNullException(nameof(channelModification));
            
            AddParameter("cid", channelId);
            channelModification.AddToCommand(this);
        }
    }
}