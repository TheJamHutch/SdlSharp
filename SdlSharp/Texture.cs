using System;
using SDL2;

namespace SdlSharp
{
    public class Texture
    {
        public IntPtr Pointer { get; }

        public Texture(Renderer renderer, string filePath)
        {
            var srfc = SDL.SDL_LoadBMP(filePath);
            Pointer = SDL.SDL_CreateTextureFromSurface(renderer.Pointer, srfc);
            SDL.SDL_FreeSurface(srfc);
        }
    }
}
