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

        private IntPtr _sdlDefaultTarget;

        /// <summary>
        ///   Creates the renderer from the window.
        /// </summary>
        public Renderer(Window window)
        {
            Pointer = SDL.SDL_CreateRenderer(window.SdlWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            SdlSystem.RendererPointer = Pointer;
            _sdlDefaultTarget = SDL.SDL_GetRenderTarget(Pointer);
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

        public void GetTarget() 
        {
            SDL.SDL_GetRenderTarget(Pointer);
        }

        /// <summary>
        ///   Use this function to set a texture as the current rendering target.
        /// </summary>
        /// <param name="texture">
        ///   The targeted texture, which must be created with the SDL_TEXTUREACCESS_TARGET flag, or NULL for the default render target.
        /// </param>
        public void SetTarget(Texture texture)
        {
            SDL.SDL_SetRenderTarget(Pointer, texture.Pointer);
        }

        public void ResetTarget() 
        {
            SDL.SDL_SetRenderTarget(Pointer, _sdlDefaultTarget);
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
            var src = srcRect.SdlRect;
            var dst = dstRect.SdlRect;

            SDL.SDL_RenderCopy(Pointer, texture.Pointer, ref src, ref dst);
        }

        public void CopyEx() 
        {
            //SDL.SDL_RenderCopyEx(Pointer, );
        }

       /// <summary>
       ///   Performs a renderer present.
       /// </summary>
        public void Present() 
        {
            SDL.SDL_RenderPresent(Pointer);
        }






        #region Draw Primitive Shapes

        /// <summary>
        ///   Renders a point in the current draw colour.
        /// </summary>
        /// <param name="xpos">The X position value.</param>
        /// <param name="ypos">The Y position value.</param>
        public void DrawPoint(int xpos, int ypos)
        {
            SDL.SDL_RenderDrawPoint(Pointer, xpos, ypos);
        }

        /// <summary>
        ///   Renders a point in the current draw colour.
        /// </summary>
        /// <param name="point"></param>
        public void DrawPoint(Point point)
        {
            SDL.SDL_RenderDrawPoint(Pointer, point.SdlPoint.x, point.SdlPoint.y);
        }

        /// <summary>
        ///   Draws the outline of the rect in the current renderer draw colour.
        /// </summary>
        /// <param name="rect">The rect to draw.</param>
        public void DrawRect(Rect rect) 
        {
            SDL.SDL_Rect sdlRect = rect.SdlRect;
            SDL.SDL_RenderDrawRect(Pointer, ref sdlRect);
        }

        /// <summary>
        ///   Draws the outline of the given Rect in the specified renderer draw colour.
        /// </summary>
        /// <param name="rect">The rect to draw.</param>
        /// <param name="colour">The colour to draw the rect in.</param>
        public void DrawRect(Rect rect, ColourType colour)
        {
            SDL.SDL_Rect sdlRect = rect.SdlRect;
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
            SDL.SDL_Rect sdlRect = rect.SdlRect;
            SDL.SDL_RenderFillRect(Pointer, ref sdlRect);
        }

        /// <summary>
        ///   Fills the given rect in the specified renderer draw colour.
        /// </summary>
        /// <param name="rect">The rect to fill.</param>
        /// <param name="colour">The colour to fill the rect in.</param>
        public void FillRect(Rect rect, ColourType colour)
        {
            SDL.SDL_Rect sdlRect = rect.SdlRect;
            ColourType prevColour = GetDrawColour();
            SetDrawColour(colour);
            SDL.SDL_RenderFillRect(Pointer, ref sdlRect);
            SetDrawColour(prevColour);
        }

        #endregion
    }
}