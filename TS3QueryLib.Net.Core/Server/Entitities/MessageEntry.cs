using System;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class MessageEntry : IEntity<MessageEntry>
    {
        #region Properties

        public uint MessageId { get; protected set; }
        public string SenderUniqueId { get; protected set; }
        public string Subject { get; protected set; }
        public DateTime Created { get; protected set; }
        public bool WasRead { get; protected set; }

        #endregion

        #region Public Methods

        public MessageEntry ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        { 
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));


            MessageId = currentParameterGroup.GetParameterValue<uint>("msgid");
            SenderUniqueId = currentParameterGroup.GetParameterValue("cluid");
            Subject = currentParameterGroup.GetParameterValue("subject");
            Created = new DateTime(1970, 1, 1).AddSeconds(currentParameterGroup.GetParameterValue<ulong>("timestamp"));
            WasRead = currentParameterGroup.GetParameterValue("flag_read").ToBool();

            return this;
        }

        #endregion
    }
}