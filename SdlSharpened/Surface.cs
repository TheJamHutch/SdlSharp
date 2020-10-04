using System;
using SDL2;

namespace SdlSharpened
{
    public class Surface
    {
        public IntPtr Pointer { get; }

        public Surface(int width, int height)
        {
            uint rmask = 0;
            uint gmask = 0;
            uint bmask = 0;
            uint amask = 0;

            Pointer = SDL.SDL_CreateRGBSurface(0, width, height, 32, rmask, gmask, bmask, amask);
        }

        public Surface(string filePath)
        {
            Pointer = SDL.SDL_LoadBMP(filePath);
        }
    }
}