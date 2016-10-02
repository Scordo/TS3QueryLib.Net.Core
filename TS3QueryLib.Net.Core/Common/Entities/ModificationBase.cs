using System;
using System.Globalization;
using TS3QueryLib.Net.Core.Common.Commands;

namespace TS3QueryLib.Net.Core.Common.Entities
{
    public class ModificationBase : IDump
    {
        #region Non Public Methods

        protected static void AddToCommand(Command command, string key, object value)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (value == null)
                return;

            if (key.IsNullOrTrimmedEmpty())
                throw new ArgumentException($"{nameof(key)} is null or trimmed empty.");

            if (value is bool?)
                command.AddParameter(key, ((bool)value) ? "1" : "0");
            else if (value is TimeSpan?)
                command.AddParameter(key, ((TimeSpan)value).TotalSeconds.ChangeTypeInvariant<string>());
            else
                command.AddParameter(key, Convert.ToString(value, CultureInfo.InvariantCulture));
        }

        #endregion
    }
}