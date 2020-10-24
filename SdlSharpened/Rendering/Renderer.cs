using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class represents a rendering context used to render to the window.
    /// </summary>
    public class Renderer
    {
        /// <summary>
        ///   A pointer to the internal SDL renderer.
        /// </summary>
        public IntPtr Pointer { get; }

        /// <summary>
        ///   Creates the renderer from the window.
        /// </summary>
        /// <param name="window">A window object.</param>
        public Renderer(Window window)
        {
            Pointer = SDL.SDL_CreateRenderer(window.Pointer, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            SdlSystem.RendererPointer = Pointer;
        }

        ~Renderer() 
        {
            SDL.SDL_DestroyRenderer(Pointer);
        }

        /// <summary>
        ///   Gets the current renderer draw colour.
        /// </summary>
        /// <returns>A colour type enum representing the current renderer draw colour.</returns>
        public ColourType GetDrawColour() 
        {
            SDL.SDL_GetRenderDrawColor(Pointer, out byte r, out byte g, out byte b, out var a);

            ColourType colour = ColourType.Black;

            colour.SetFromBytes(r, g, b);

            return colour;
        }

        /// <summary>
        ///   Sets the current draw colour of the renderer.
        /// </summary>
        /// <param name="colour">A colour type enum value.</param>
        public void SetDrawColour(ColourType colour) 
        {
            colour.ColourBytes(out var r, out var g, out var b);

            SDL.SDL_SetRenderDrawColor(Pointer, r, g, b, 0xff);
        }

        /// <summary>
        ///   Clears the renderer in the current draw colour.
        /// </summary>
        public void Clear() 
        {
            SDL.SDL_RenderClear(Pointer);
        }

        /// <summary>
        ///   Performs a renderer copy.
        /// </summary>
        /// <param name="texture">The texture to copy to the renderer.</param>
        /// <param name="srcRect">Clipping rect.</param>
        /// <param name="dstRect">Positioning rect.</param>
        public void Copy(Texture texture, Rect srcRect, Rect dstRect) 
        {
            var src = srcRect.Pointer();
            var dst = dstRect.Pointer();

            SDL.SDL_RenderCopy(Pointer, texture.Pointer, ref src, ref dst);
        }

       /// <summary>
       ///   Perfors a renderer present.
       /// </summary>
        public void Present() 
        {
            SDL.SDL_RenderPresent(Pointer);
        }

        #region Draw Primitive Shapes

        /// <summary>
        ///   Draws the outline of the rect in the current renderer draw colour.
        /// </summary>
        /// <param name="rect">The rect to draw.</param>
        public void DrawRect(Rect rect) 
        {
            SDL.SDL_Rect sdlRect = rect.Pointer();
            SDL.SDL_RenderDrawRect(Pointer, ref sdlRect);
        }

        /// <summary>
        ///   Draws the outline of the given Rect in the specified renderer draw colour.
        /// </summary>
        /// <param name="rect">The rect to draw.</param>
        /// <param name="colour">The colour to draw the rect in.</param>
        public void DrawRect(Rect rect, ColourType colour)
        {
            SDL.SDL_Rect sdlRect = rect.Pointer();
            ColourType prevColour = GetDrawColour();
            SetDrawColour(colour);
            SDL.SDL_RenderDrawRect(Pointer, ref sdlRect);
            SetDrawColour(prevColour);
        }

        /// <summary>
        ///   Fills the given rect in the current renderer draw colour.
        /// </summary>
        /// <param name="rect">The rect to fill.</param>
        public void FillRect(Rect rect)
        {
            SDL.SDL_Rect sdlRect = rect.Pointer();
            SDL.SDL_RenderFillRect(Pointer, ref sdlRect);
        }

        /// <summary>
        ///   Fills the given rect in the specified renderer draw colour.
        /// </summary>
        /// <param name="rect">The rect to fill.</param>
        /// <param name="colour">The colour to fill the rect in.</param>
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