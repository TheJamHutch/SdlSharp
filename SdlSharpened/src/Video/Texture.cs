using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class representing a texture which can be rendered to the window.
    /// </summary>
    public class Texture
    {
        /// <summary>
        ///   Gets the width, in pixels, of the texture.
        /// </summary>
        public int Width { get { SDL.SDL_QueryTexture(Pointer, out _, out _, out var width, out _); return width; } }

        /// <summary>
        ///   Gets the height, in pixels, of the texture.
        /// </summary>
        public int Height { get { SDL.SDL_QueryTexture(Pointer, out _, out _, out _, out var height); return height; } }

        /// <summary>
        ///   Pointer to the internal SDL texture.
        /// </summary>
        public IntPtr Pointer { get; }

        /// <summary>
        ///   Creates a texture from an image file. 24-bit BMP only.
        /// </summary>
        /// <param name="filePath">The filepath of the image file.</param>
        public Texture(string filePath)
        {
            Pointer = SDL_image.IMG_LoadTexture(SdlSystem.RendererPointer, filePath);
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
            Pointer = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, surface);
            SDL.SDL_FreeSurface(surface);
        }

        /// <summary>
        ///   Creates a texture from a surface.
        /// </summary>
        /// <param name="surface">The surface to create a texture from.</param>
        public Texture(Surface surface) 
        {
            Pointer = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, surface.SdlSurface);
        }

        public Texture(int width, int height)
        {
            Pointer = SDL.SDL_CreateTexture(SdlSystem.RendererPointer, SDL.SDL_PIXELFORMAT_UNKNOWN, (int)SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_TARGET, width, height);
        }

        ~Texture()
        {
            SDL.SDL_DestroyTexture(Pointer);
        }
    }
}
