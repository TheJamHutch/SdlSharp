using System;
using SDL2;

namespace SdlSharpened
{
    public class AudioSpec
    {
        /// <summary>
        ///   DSP frequency (samples per second).
        /// </summary>
        public int Freq 
        { 
            get { return _sdlAudioSpec.freq; }
            set { _sdlAudioSpec.freq = value; }
        }

        /// <summary>
        ///   Number of separate sound channels.
        /// </summary>
        public byte Channels
        {
            get { return _sdlAudioSpec.channels; }
            set { _sdlAudioSpec.channels = value; }
        }

        /// <summary>
        ///   Audio buffer silence value (calculated).
        /// </summary>
        public byte Silence
        {
            get { return _sdlAudioSpec.silence; }
            set { _sdlAudioSpec.silence = value; }
        }

        /// <summary>
        ///   Audio buffer size in samples (power of two).
        /// </summary>
        public ushort Samples
        {
            get { return _sdlAudioSpec.samples; }
            set { _sdlAudioSpec.samples = value; }
        }

        /// <summary>
        ///  Audio buffer size in bytes (calculated).
        /// </summary>
        public uint Size
        {
            get { return _sdlAudioSpec.size; }
            set { _sdlAudioSpec.size = value; }
        }

        private SDL.SDL_AudioSpec _sdlAudioSpec = new SDL.SDL_AudioSpec();
    }
}
