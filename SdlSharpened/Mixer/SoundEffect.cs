using System;
using SDL2;

namespace SdlSharpened
{
    public class SoundEffect
    {
        public IntPtr Pointer { get; }

        public SoundEffect(string filePath)
        {
            Pointer = SDL_mixer.Mix_LoadWAV(filePath);
        }

        ~SoundEffect() 
        {
            SDL_mixer.Mix_FreeChunk(Pointer);
        }
    }
}