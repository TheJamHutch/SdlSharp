using System;
using SDL2;

namespace SdlSharpened
{
    public static class SdlSystem
    {
        internal static IntPtr WindowPointer { get; set; }
        internal static IntPtr RendererPointer { get; set; }

        public static bool Init()
        {
            return (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) == 0) ? true : false;
        }

        public static bool Init(uint flags)
        {
            return (SDL.SDL_Init(flags) == 0) ? true : false;
        }

        public static bool Init(params InitFlags[] initFlags)
        {
            uint result = 0;

            foreach (var flag in initFlags)
            {
                result |= (uint)flag;
            }

            return (SDL.SDL_Init(result) == 0) ? true : false;
        }

        public static bool InitSubSystem(InitFlags initFlag)
        {
            return (SDL.SDL_InitSubSystem((uint)initFlag) == 0) ? true : false;
        }

        public static void WasInit() 
        {
        }

        public static void Quit()
        {
            SDL.SDL_Quit();
        }

        public static void Delay(uint millis)
        {
            if (millis > 0)
            {
                SDL.SDL_Delay(millis);
            }
        }

        public static uint Ticks()
        {
            return SDL.SDL_GetTicks();
        }

        public static string Version()
        {
            SDL.SDL_GetVersion(out var sdlVersion);

            return $"SDL2: {sdlVersion.major}.{sdlVersion.minor}.{sdlVersion.patch} \n";
        }

        public static string GetAppPath() 
        {
            return SDL.SDL_GetBasePath();
        }

        public static string GetError()
        {
            return $"{SDL.SDL_GetError()}";
        }

        public static void ClearError() 
        {
            SDL.SDL_ClearError();
        }

        public static void SetError(string error) 
        {
            SDL.SDL_SetError(error);
        }
    }
}