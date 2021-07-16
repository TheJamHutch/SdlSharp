using System;
using SDL2;

namespace SdlSharpened
{
    public class Renderer
    {
        private IntPtr _sdlRenderer;
        private IntPtr _sdlDefaultTarget;

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

        public IntPtr SdlRenderer { get { return _sdlRenderer; } }

        public BlendMode GetDrawBlendMode() 
        {
            SDL.SDL_GetRenderDrawBlendMode(_sdlRenderer, out var sdlBlendMode);

            return (BlendMode)sdlBlendMode;
        }

        public void SetDrawBlendMode(BlendMode blendMode)
        {
            SDL.SDL_SetRenderDrawBlendMode(_sdlRenderer, (SDL.SDL_BlendMode)blendMode);
        }

        public bool GetDrawColour(out byte r, out byte g, out byte b, out byte a) 
        {
            int success = SDL.SDL_GetRenderDrawColor(_sdlRenderer, out r, out g, out b, out a);

            return success == 0 ? true : false;
        }

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

        public void SetTarget(Texture texture)
        {
            SDL.SDL_SetRenderTarget(_sdlRenderer, texture.SdlTexture);
        }

        public void ResetTarget() 
        {
            SDL.SDL_SetRenderTarget(_sdlRenderer, _sdlDefaultTarget);
        }

        public void Clear() 
        {
            SDL.SDL_RenderClear(_sdlRenderer);
        }

        public void Copy(Texture texture, Rect srcRect, Rect dstRect) 
        {
            // TODO: Add Rect.Null (not the same as Rect.Zero) static property to Rect struct definition,
            //       detect Rect.Null from here and pass srcRect as IntPtr.Zero
            var src = srcRect.SdlRect;
            var dst = dstRect.SdlRect;

            SDL.SDL_RenderCopy(_sdlRenderer, texture.SdlTexture, ref src, ref dst);
        }

        public void CopyEx(Texture texture, Rect srcRect, Rect dstRect, double angle, Point? centerPoint = null, RendererFlip rendererFlip = RendererFlip.FlipNone) 
        {
            // TODO: Also handle Rect.Null being passed into here
            var src = new SDL.SDL_Rect() { x = srcRect.X, y = srcRect.Y, w = srcRect.W, h = srcRect.H };
            var dst = new SDL.SDL_Rect() { x = dstRect.X, y = dstRect.Y, w = dstRect.W, h = dstRect.H };

            SDL.SDL_RenderCopyEx(_sdlRenderer, texture.SdlTexture, ref src, ref dst, angle, IntPtr.Zero, (SDL.SDL_RendererFlip)rendererFlip);
        }

        public void Present() 
        {
            SDL.SDL_RenderPresent(_sdlRenderer);
        }






        #region Draw Primitive Shapes

        public void DrawPoint(int xpos, int ypos)
        {
            SDL.SDL_RenderDrawPoint(_sdlRenderer, xpos, ypos);
        }

        public void DrawPoint(Point point)
        {
            SDL.SDL_RenderDrawPoint(_sdlRenderer, point.SdlPoint.x, point.SdlPoint.y);
        }

        public void DrawRect(Rect rect) 
        {
            SDL.SDL_Rect sdlRect = rect.SdlRect;
            SDL.SDL_RenderDrawRect(_sdlRenderer, ref sdlRect);
        }

        public void FillRect(Rect rect)
        {
            SDL.SDL_Rect sdlRect = rect.SdlRect;
            SDL.SDL_RenderFillRect(_sdlRenderer, ref sdlRect);
        }

        #endregion
    }
}