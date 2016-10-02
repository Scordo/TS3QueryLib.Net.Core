using System;
using System.Linq;
using TS3QueryLib.Net.Core.Common.CommandHandling;
using TS3QueryLib.Net.Core.Common.Entities;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class LogEntry : LogEntryLight, IEntity<LogEntry>
    {
        #region Properties

        public DateTime TimeStamp { get; protected set; }
        public uint LastPos { get; protected set; }
        public uint FileSize { get; protected set; }

        #endregion

        #region Public Methods

        LogEntry IEntity<LogEntry>.ApplyFrom(CommandParameterGroup currentParameterGroup, CommandParameterGroup firstParameterGroup)
        {
            if (currentParameterGroup == null)
                throw new ArgumentNullException(nameof(currentParameterGroup));

            string message = currentParameterGroup.GetParameterValue("l");

            DateTime timeStamp;
            DateTime.TryParse(message.Split('|')[0], System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out timeStamp);

            LogLevel logLevel = LogLevel.None;
            if (message.Split('|').Length >= 2 && Enum.GetNames(typeof(LogLevel)).Contains(message.Split('|')[1].Trim(), StringComparer.CurrentCultureIgnoreCase))
                logLevel = (LogLevel) Enum.Parse(typeof(LogLevel), message.Split('|')[1].Trim(), true);

            TimeStamp = timeStamp;
            LogLevel = logLevel;
            LastPos = firstParameterGroup.GetParameterValue<uint>("last_pos");
            FileSize = firstParameterGroup.GetParameterValue<uint>("file_size");
            Message = message;

            return this;
        }

        #endregion
    }
}