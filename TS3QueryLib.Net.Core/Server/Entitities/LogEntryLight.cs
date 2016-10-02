using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS3QueryLib.Net.Core.Common.Entities;

namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public class LogEntryLight
    {
        #region Properties

        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }

        #endregion

        #region Constructor

        protected LogEntryLight()
        {

        }

        public LogEntryLight(LogLevel logLevel, string message)
        {
            if (message.IsNullOrTrimmedEmpty())
                throw new ArgumentException("message is null or trimmed empty");

            LogLevel = logLevel;
            Message = message;
        }

        #endregion
    }
}