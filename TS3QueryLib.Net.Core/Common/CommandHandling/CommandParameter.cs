using System;
using TS3QueryLib.Net.Core.Common;

namespace TS3QueryLib.Net.Core.Common.CommandHandling
{
    public class CommandParameter
    {
        #region Properties

        public string Name { get; protected set; }
        public string EncodedName => Util.EncodeString(Name);
        public string Value { get; set; }
        public string EncodedValue => Util.EncodeString(Value);

        #endregion

        #region Constructors

        public CommandParameter(string name) : this(name, null)
        {

        }

        public CommandParameter(string name, string value)
        {
            if (name.IsNullOrTrimmedEmpty())
                throw new ArgumentException("name is null or trimmed empty", nameof(name));

            Name = name.Trim();
            Value = value?.Trim();
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Value == null ? EncodedName : string.Format("{0}={1}", Name, EncodedValue);
        }

        #endregion
    }
}
