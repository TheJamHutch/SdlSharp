using System;
using SDL2;

namespace SdlSharp
{
    public class Renderer : IDisposable
    {
        public IntPtr Pointer { get; }

        public Renderer(Window window)
        {
            Pointer = SDL.SDL_CreateRenderer(window.Pointer, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        }

        void IDisposable.Dispose() 
        {
            SDL.SDL_DestroyRenderer(Pointer);
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