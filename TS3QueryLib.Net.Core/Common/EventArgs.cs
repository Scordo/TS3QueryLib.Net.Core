using System;

namespace TS3QueryLib.Net.Core.Common
{
    public class EventArgs<T> : EventArgs
    {
        public T Value { get; set; }

        public EventArgs(T value)
        {
            Value = value;
        }
    }
}