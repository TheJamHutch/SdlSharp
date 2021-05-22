using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   A class that contains a rendering state..
    /// </summary>
    public class Renderer
    {
        private IntPtr _sdlRenderer;
        private IntPtr _sdlDefaultTarget;

        /// <summary>
        ///   Creates the renderer from the window.
        /// </summary>
        public Renderer(Window window)
        {
            _sdlRenderer = SDL.SDL_CreateRenderer(window.SdlWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);
            SdlSystem.RendererPointer = _sdlRenderer;
            _sdlDefaultTarget = SDL.SDL_GetRenderTarget(_sdlRenderer);
        }

        ~Renderer() 
        {
            SDL.SDL_DestroyRenderer(_sdlRenderer);
        }

        #region Statics

        public bool TargetSupported(Renderer renderer)
        {
            return (SDL.SDL_RenderTargetSupported(renderer.SdlRenderer) == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        #endregion

        /// <summary>
        ///   A pointer to SDL's internal SDL_Renderer struct.
        /// </summary>
        public IntPtr SdlRenderer { get { return _sdlRenderer; } }

        /// <summary>
        ///   Use this function to get the blend mode used for drawing operations.
        /// </summary>
        /// <returns>
        ///   The current BlendMode.
        /// </returns>
        public BlendMode GetDrawBlendMode() 
        {
            SDL.SDL_GetRenderDrawBlendMode(_sdlRenderer, out var sdlBlendMode);

            return (BlendMode)sdlBlendMode;
        }

        /// <summary>
        ///   Use this function to set the blend mode used for drawing operations.
        /// </summary>
        /// <param name="blendMode">The BlendMode used for blending.</param>
        public void SetDrawBlendMode(BlendMode blendMode)
        {
            SDL.SDL_SetRenderDrawBlendMode(_sdlRenderer, (SDL.SDL_BlendMode)blendMode);
        }

        /// <summary>
        ///   Get the color used for drawing operations.
        /// </summary>
        /// <returns>True on success; call SdlSystem.GetError() for more information.</returns>
        public bool GetDrawColour(out byte r, out byte g, out byte b, out byte a) 
        {
            int success = SDL.SDL_GetRenderDrawColor(_sdlRenderer, out r, out g, out b, out a);

            return success == 0 ? true : false;
        }

        /// <summary>
        ///   Sets the current draw colour of the renderer.
        /// </summary>
        /// <param name="colour">A colour type enum value.</param>
        public void SetDrawColour(byte r, byte g, byte b, byte a) 
        {
            SDL.SDL_SetRenderDrawColor(_sdlRenderer, r, g, b, a);
        }

        public Texture GetTarget() 
        {
            var texture = new Texture(1, 1);

            texture.SdlTexture = SDL.SDL_GetRenderTarget(_sdlRenderer);

            return texture;
        }

        /// <summary>
        ///   Use this function to set a texture as the current rendering target.
        /// </summary>
        /// <param name="texture">
        ///   The targeted texture, which must be created with the SDL_TEXTUREACCESS_TARGET flag, or NULL for the default render target.
        /// </param>
        public void SetTarget(Texture texture)
        {
            SDL.SDL_SetRenderTarget(_sdlRenderer, texture.SdlTexture);
        }

        public void ResetTarget() 
        {
            SDL.SDL_SetRenderTarget(_sdlRenderer, _sdlDefaultTarget);
        }

        /// <summary>
        ///   Clears the renderer in the current draw colour.
        /// </summary>
        public void Clear() 
        {
            SDL.SDL_RenderClear(_sdlRenderer);
        }

        /// <summary>
        ///   Performs a renderer copy.
        /// </summary>
        /// <param name="texture">The texture to copy to the renderer.</param>
        /// <param name="srcRect">Clipping rect.</param>
        /// <param name="dstRect">Positioning rect.</param>
        public void Copy(Texture texture, Rect srcRect, Rect dstRect) 
        {
            // TODO: Add Rect.Null (not the same as Rect.Zero) static property to Rect struct definition,
            //       detect Rect.Null from here and pass srcRect as IntPtr.Zero
            var src = srcRect.SdlRect;
            var dst = dstRect.SdlRect;

            SDL.SDL_RenderCopy(_sdlRenderer, texture.SdlTexture, ref src, ref dst);
        }

        /// <summary>
        ///   Use this function to copy a portion of the texture to the current rendering target, optionally 
        ///   rotating it by angle around the given center and also flipping it top-bottom and/or left-right.
        /// </summary>
        /// <param name="texture">The source texture.</param>
        /// <param name="srcRect">The source Rect structure or Rect.Zero for the entire texture.</param>
        /// <param name="dstRect">The destination Rect structure or Rect.Zero for the entire rendering target.</param>
        /// <param name="angle">An angle in degrees that indicates the rotation that will be applied to dstrect, rotating it in a clockwise direction.</param>
        /// <param name="centerPoint">A point indicating the point around which dstrect will be rotated (if Point.Zero, rotation will be done around dstrect.w/2, dstrect.h/2)</param>
        /// <param name="rendererFlip">A SDL_RendererFlip value stating which flipping actions should be performed on the texture.</param>
        public void CopyEx(Texture texture, Rect srcRect, Rect dstRect, double angle, Point? centerPoint = null, RendererFlip rendererFlip = RendererFlip.FlipNone) 
        {
            // TODO: Also handle Rect.Null being passed into here
            var src = new SDL.SDL_Rect() { x = srcRect.X, y = srcRect.Y, w = srcRect.W, h = srcRect.H };
            var dst = new SDL.SDL_Rect() { x = dstRect.X, y = dstRect.Y, w = dstRect.W, h = dstRect.H };

            SDL.SDL_RenderCopyEx(_sdlRenderer, texture.SdlTexture, ref src, ref dst, angle, IntPtr.Zero, (SDL.SDL_RendererFlip)rendererFlip);
        }

        /// <summary>
        ///   Performs a renderer present.
        /// </summary>
        public void Present() 
        {
            SDL.SDL_RenderPresent(_sdlRenderer);
        }






        #region Draw Primitive Shapes

        /// <summary>
        ///   Renders a point in the current draw colour.
        /// </summary>
        /// <param name="xpos">The X position value.</param>
        /// <param name="ypos">The Y position value.</param>
        public void DrawPoint(int xpos, int ypos)
        {
            SDL.SDL_RenderDrawPoint(_sdlRenderer, xpos, ypos);
        }

        /// <summary>
        ///   Renders a point in the current draw colour.
        /// </summary>
        /// <param name="point"></param>
        public void DrawPoint(Point point)
        {
            SDL.SDL_RenderDrawPoint(_sdlRenderer, point.SdlPoint.x, point.SdlPoint.y);
        }

        /// <summary>
        ///   Draws the outline of the rect in the current renderer draw colour.
        /// </summary>
        /// <param name="rect">The rect to draw.</param>
        public void DrawRect(Rect rect) 
        {
            SDL.SDL_Rect sdlRect = rect.SdlRect;
            SDL.SDL_RenderDrawRect(_sdlRenderer, ref sdlRect);
        }

        /// <summary>
        ///   Fills the given rect in the current renderer draw colour.
        /// </summary>
        /// <param name="rect">The rect to fill.</param>
        public void FillRect(Rect rect)
        {
            SDL.SDL_Rect sdlRect = rect.SdlRect;
            SDL.SDL_RenderFillRect(_sdlRenderer, ref sdlRect);
        }

        #endregion
    }
}