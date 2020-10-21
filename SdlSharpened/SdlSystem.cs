using System;
using SDL2;

namespace SdlSharpened
{
    public class SdlSystem
    {
        public SdlSystem()
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
        }

        ~SdlSystem()
        {
            SDL.SDL_Quit();
        }

        public void Delay(int millis)
        {
            if (millis > 0)
            {
                SDL.SDL_Delay((uint)millis);
            }
        }

        public uint Ticks()
        {
            return SDL.SDL_GetTicks();
        }

        public string GetVersion()
        {
            SDL.SDL_version version;
            SDL.SDL_GetVersion(out version);

            return $"SDL2 Version: {version.major}.{version.minor}.{version.patch}";
        }

        public string GetError()
        {
            return $"{SDL.SDL_GetError()}";
        }

        public void ClearError() 
        {
            SDL.SDL_ClearError();
        }

        public void SetError(string error) 
        {
            SDL.SDL_SetError(error);
        }
    }
}