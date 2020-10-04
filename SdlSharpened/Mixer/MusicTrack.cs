using System;
using SDL2;

namespace SdlSharpened
{
    public class MusicTrack
    {
        public IntPtr Pointer { get; }

        public MusicTrack(string filePath)
        {
            Pointer = SDL_mixer.Mix_LoadMUS(filePath);
        }

        ~MusicTrack()
        {
            SDL_mixer.Mix_FreeMusic(Pointer);
        }
    }
}