using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   A structure that contains an efficient, driver-specific representation of pixel data.
    /// </summary>
    public class Texture
    {
        private IntPtr _sdlTexture;

        /// <summary>
        ///   Creates a texture from an image file. 24-bit BMP only.
        /// </summary>
        /// <param name="filePath">The filepath of the image file.</param>
        public Texture(string filePath)
        {
            var surface = SDL.SDL_LoadBMP(filePath);
            SdlTexture = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, surface);
            SDL.SDL_FreeSurface(surface);
        }

        /// <summary>
        ///   Creates a texture from an image file and sets the transparency colour key.
        /// </summary>
        /// <param name="filePath">The filepath of the image file.</param>
        /// <param name="tspCol">A colour type enum representing the colour to use for transparency.</param>
        public Texture(string filePath, ColourType tspCol)
        {
            var surface = SDL.SDL_LoadBMP(filePath);
            SDL.SDL_SetColorKey(surface, 1, tspCol.ColourKey());
            SdlTexture = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, surface);
            SDL.SDL_FreeSurface(surface);
        }

        /// <summary>
        ///   Creates a texture from a surface.
        /// </summary>
        /// <param name="surface">The surface to create a texture from.</param>
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

        /// <summary>
        ///   Gets the width, in pixels, of the texture.
        /// </summary>
        public int Width { get { SDL.SDL_QueryTexture(SdlTexture, out _, out _, out var width, out _); return width; } }

        /// <summary>
        ///   Gets the height, in pixels, of the texture.
        /// </summary>
        public int Height { get { SDL.SDL_QueryTexture(SdlTexture, out _, out _, out _, out var height); return height; } }

        /// <summary>
        ///   Pointer to the internal SDL_Texture structure.
        /// </summary>
        public IntPtr SdlTexture { get; }

        public void Lock(Rect rect) 
        {
            var rectCopy = rect.SdlRect;

            SDL.SDL_LockTexture(_sdlTexture, ref rectCopy, out IntPtr pixels, out int pitch);
        }

        /// <summary>
        ///   Use this function to unlock a texture, uploading the changes to video memory, if needed.
        /// </summary>
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
