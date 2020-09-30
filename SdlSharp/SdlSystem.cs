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
    }
}