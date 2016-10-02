using System;
using TS3QueryLib.Net.Core.Common.Commands;
using TS3QueryLib.Net.Core.Common.Entities;

namespace TS3QueryLib.Net.Core.Server.Commands
{
    public class ServerTempPasswordAddCommand : ExecutableValuelessCommand
    {
        public ServerTempPasswordAddCommand(string password, string description, TimeSpan duration, uint? channelId = null, string channelPassword = null) : base("SERVERTEMPPASSWORDADD")
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            if (description == null)
                throw new ArgumentNullException(nameof(description));

            new Modification { Password = password, Description = description, Duration = duration, ChannelId = channelId, ChannelPassword = channelPassword}.AddToCommand(this);
        }

        private class Modification : ModificationBase
        {
            public string Password { get; set; }
            public string Description { get; set; }
            public TimeSpan Duration { get; set; }
            public uint? ChannelId { get; set; }
            public string ChannelPassword { get; set; }

            public void AddToCommand(Command command)
            {
                AddToCommand(command, "pw", Password);
                AddToCommand(command, "desc", Description);
                AddToCommand(command, "duration", Duration);
                AddToCommand(command, "tcid", ChannelId);
                AddToCommand(command, "tcpw", ChannelPassword);
            }
        }
    }
}