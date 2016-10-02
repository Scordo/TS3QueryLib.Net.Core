namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public enum Codec
    {
        /// <summary>
        /// speex narrowband mono, 16bit, 8kHz)
        /// </summary>
        SpeexNarrowband = 0,

        /// <summary>
        /// speex wideband (mono, 16bit, 16kHz)
        /// </summary>
        SpeexWideband = 1,

        /// <summary>
        /// speex ultra-wideband (mono, 16bit, 32kHz)
        /// </summary>
        SpeexUltrawideband = 2,

        /// <summary>
        /// celt mono (mono, 16bit, 48kHz)
        /// </summary>
        CeltMono = 3
    }
}