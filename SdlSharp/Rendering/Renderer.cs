using System;
using SDL2;

namespace SdlSharp
{
    public class Renderer
    {
        public IntPtr Pointer { get; }

        public Renderer()
        {
            Pointer = SDL.SDL_CreateRenderer(Global.WindowPointer, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            Global.RendererPointer = Pointer;
        }

        ~Renderer() 
        {
            SDL.SDL_DestroyRenderer(Pointer);
        }

        public void SetRenderColour(ColourType colour) 
        {
            colour.ColourBytes(out var r, out var g, out var b);

            SDL.SDL_SetRenderDrawColor(Pointer, r, g, b, 0xff);
        }

        public void Clear() 
        {
            SDL.SDL_RenderClear(Pointer);
        }

        public void Copy(Texture texture, Rect srcRect, Rect dstRect) 
        {
            var src = srcRect.Pointer();
            var dst = dstRect.Pointer();

            SDL.SDL_RenderCopy(Pointer, texture.Pointer, ref src, ref dst);
        }

        public void Present() 
        {
            SDL.SDL_RenderPresent(Pointer);
        }
    }
}