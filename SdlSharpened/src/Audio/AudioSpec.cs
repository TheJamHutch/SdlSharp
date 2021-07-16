using System;
using SDL2;

namespace SdlSharpened
{
    public class AudioSpec
    {
        public int Freq 
        { 
            get { return _sdlAudioSpec.freq; }
            set { _sdlAudioSpec.freq = value; }
        }

        public byte Channels
        {
            get { return _sdlAudioSpec.channels; }
            set { _sdlAudioSpec.channels = value; }
        }

        public byte Silence
        {
            get { return _sdlAudioSpec.silence; }
            set { _sdlAudioSpec.silence = value; }
        }

        public ushort Samples
        {
            get { return _sdlAudioSpec.samples; }
            set { _sdlAudioSpec.samples = value; }
        }

        public uint Size
        {
            get { return _sdlAudioSpec.size; }
            set { _sdlAudioSpec.size = value; }
        }

        private SDL.SDL_AudioSpec _sdlAudioSpec = new SDL.SDL_AudioSpec();
    }
}
