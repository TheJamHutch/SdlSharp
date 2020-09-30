using System;
using SDL2;

namespace SdlSharp
{
    public class SdlSystem : IDisposable
    {
        public SdlSystem()
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
        }

        void IDisposable.Dispose()
        {
            SDL.SDL_Quit();
        }

        public void Delay(uint millis)
        {
            SDL.SDL_Delay(millis);
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