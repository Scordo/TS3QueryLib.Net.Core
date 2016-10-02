using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Server.Entitities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ChannelCreateCommand : ExecutableSingleValueCommand<uint?>
    {
        public ChannelCreateCommand(ChannelModification channelModification) : base("ChannelCreate", "cid")
        {
            if (channelModification == null)
                throw new ArgumentNullException(nameof(channelModification));

            if (channelModification.Name.IsNullOrTrimmedEmpty())
                throw new ArgumentException("To create a channel you must at least provide a name for the channel.");

            channelModification.AddToCommand(this);
        }
    }
}