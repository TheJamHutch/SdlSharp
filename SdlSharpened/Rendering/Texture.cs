using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class representing a texture which can be rendered to the window.
    /// </summary>
    public class Texture
    {
        public int Width { get; }
        public int Height { get; }

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
            SDL.SDL_QueryTexture(Pointer, out var format, out var access, out var w, out var h);
            Width = w;
            Height = h;
        }

        /// <summary>
        ///   Creates a texture from an image file and sets the transparency colour key.
        /// </summary>
        /// <param name="filePath">The filepath of the image file.</param>
        /// <param name="tspCol">A colour type enum representing the colour to use for transparency.</param>
        public Texture(string filePath, ColourType tspCol)
        {
            var srfc = SDL.SDL_LoadBMP(filePath);
            SDL.SDL_SetColorKey(srfc, 1, tspCol.ColourKey());
            Pointer = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, srfc);
            SDL.SDL_FreeSurface(srfc);

            SDL.SDL_QueryTexture(Pointer, out var format, out var access, out var w, out var h);
            Width = w;
            Height = h;
        }

        /// <summary>
        ///   Creates a texture from a surface.
        /// </summary>
        /// <param name="surface">The surface to create a texture from.</param>
        public Texture(Surface surface) 
        {
            Pointer = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, surface.Pointer);

            SDL.SDL_QueryTexture(Pointer, out var format, out var access, out var w, out var h);
            Width = w;
            Height = h;
        }

        ~Texture() 
        {
            SDL.SDL_DestroyTexture(Pointer);
        }
    }
}