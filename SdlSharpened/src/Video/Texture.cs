using System;
using SDL2;

namespace SdlSharpened
{
    public class Texture
    {
        private IntPtr _sdlTexture;

        public Texture(string filePath)
        {
            var surface = SDL.SDL_LoadBMP(filePath);
            SdlTexture = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, surface);
            SDL.SDL_FreeSurface(surface);
        }

        public Texture(Surface surface) 
        {
            SdlTexture = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, surface.SdlSurface);
        }

        public Texture(int width, int height)
        {
            SdlTexture = SDL.SDL_CreateTexture(SdlSystem.RendererPointer, SDL.SDL_PIXELFORMAT_UNKNOWN, (int)SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_TARGET, width, height);
        }

        ~Texture()
        {
            SDL.SDL_DestroyTexture(SdlTexture);
        }

        public int Width { get { SDL.SDL_QueryTexture(SdlTexture, out _, out _, out var width, out _); return width; } }

        public int Height { get { SDL.SDL_QueryTexture(SdlTexture, out _, out _, out _, out var height); return height; } }

        internal IntPtr SdlTexture { get { return _sdlTexture; } set { _sdlTexture = value; } }

        public void Lock(Rect rect) 
        {
            var rectCopy = rect.SdlRect;

            SDL.SDL_LockTexture(_sdlTexture, ref rectCopy, out IntPtr pixels, out int pitch);
        }

        public void Unlock() 
        {
            SDL.SDL_UnlockTexture(_sdlTexture);
        }

        // TODO: Change format from int to PixelFormat enum value
        public void Query(int format, int access, int width, int height) 
        {
            SDL.SDL_QueryTexture(_sdlTexture, out uint sdlFormat, out int sdlAccess, out int sdlWidth, out int sdlHeight);
        }
    }
}
