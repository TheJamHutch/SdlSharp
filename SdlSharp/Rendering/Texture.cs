using System;
using SDL2;

namespace SdlSharp
{
    public class Texture
    {
        public IntPtr Pointer { get; }

        public Texture(string filePath)
        {
            var srfc = SDL.SDL_LoadBMP(filePath);
            Pointer = SDL.SDL_CreateTextureFromSurface(Global.RendererPointer, srfc);
            SDL.SDL_FreeSurface(srfc);
        }

        public Texture(string filePath, ColourType tspCol)
        {
            var srfc = SDL.SDL_LoadBMP(filePath);
            SDL.SDL_SetColorKey(srfc, 1, tspCol.ColourKey());
            Pointer = SDL.SDL_CreateTextureFromSurface(Global.RendererPointer, srfc);
            SDL.SDL_FreeSurface(srfc);
        }
    }
}