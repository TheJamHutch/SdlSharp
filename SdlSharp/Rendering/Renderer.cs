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

        public ColourType GetDrawColour() 
        {
            SDL.SDL_GetRenderDrawColor(Pointer, out byte r, out byte g, out byte b, out var a);

            ColourType colour = ColourType.Black;

            colour.SetFromBytes(r, g, b);

            return colour;
        }

        public void SetDrawColour(ColourType colour) 
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

        // Present the renderer.
        public void Present() 
        {
            SDL.SDL_RenderPresent(Pointer);
        }

        #region Draw Primitive Shapes
        // Draws the outline of the given Rect, in the current renderer draw colour.
        public void DrawRect(Rect rect) 
        {
            SDL.SDL_Rect sdlRect = rect.Pointer();
            SDL.SDL_RenderDrawRect(Pointer, ref sdlRect);
        }

        // Draws the outline of the given Rect, in the specified renderer draw colour.
        public void DrawRect(Rect rect, ColourType colour)
        {
            SDL.SDL_Rect sdlRect = rect.Pointer();
            ColourType prevColour = GetDrawColour();
            SetDrawColour(colour);
            SDL.SDL_RenderDrawRect(Pointer, ref sdlRect);
            SetDrawColour(prevColour);
        }

        // Fills the given rect, in the current renderer draw colour.
        public void FillRect(Rect rect)
        {
            SDL.SDL_Rect sdlRect = rect.Pointer();
            SDL.SDL_RenderFillRect(Pointer, ref sdlRect);
        }

        // Fills the given Rect, in the specified renderer draw colour.
        public void FillRect(Rect rect, ColourType colour)
        {
            SDL.SDL_Rect sdlRect = rect.Pointer();
            ColourType prevColour = GetDrawColour();
            SetDrawColour(colour);
            SDL.SDL_RenderFillRect(Pointer, ref sdlRect);
            SetDrawColour(prevColour);
        }
        #endregion
    }
}