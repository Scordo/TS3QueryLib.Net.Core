using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TS3QueryLib.Net.Core
{
    public class SimpleCommunicationLog : ICommunicationLog, IEnumerable<SimpleCommunicationLog.Entry>
    {
        private ConcurrentQueue<Entry> Entries { get; } = new ConcurrentQueue<Entry>();

        void ICommunicationLog.RawMessageReceived(string message)
        {
            Entries.Enqueue(new Entry(CommunicationType.Receive, message));
        }

        void ICommunicationLog.RawMessageSending(string message)
        {
            Entries.Enqueue(new Entry(CommunicationType.Sending, message));
        }

        void ICommunicationLog.RawMessageSent(string message)
        {
            Entries.Enqueue(new Entry(CommunicationType.Sent, message));
        }

        public void Clear()
        {
            while (Entries.TryDequeue(out _))
            {
             
            }
        }

        public enum CommunicationType
        {
            Receive,
            Sending,
            Sent
        }

        public class Entry
        {
            public CommunicationType Type { get; }
            public string Message { get; }
            public DateTime Time { get; }

            public Entry(CommunicationType type, string message)
            {
                Type = type;
                Message = message;
                Time = DateTime.Now;
            }
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            foreach (Entry entry in Entries)
            {
                yield return entry;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
