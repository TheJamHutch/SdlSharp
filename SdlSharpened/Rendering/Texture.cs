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
        ///   Pointer to the internal SDL texture.
        /// </summary>
        public IntPtr Pointer { get; }

        /// <summary>
        ///   Creates a texture from an image file. 24-bit BMP only.
        /// </summary>
        public Texture()
        {
            //Pointer = SDL.SDL_CreateTexture(SdlSystem.RendererPointer, );
        }

        /// <summary>
        ///   Creates a texture from an image file. 24-bit BMP only.
        /// </summary>
        /// <param name="filePath">The filepath of the image file.</param>
        public Texture(string filePath)
        {
            var srfc = SDL_image.IMG_Load(filePath);
            Pointer = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, srfc);
            SDL.SDL_FreeSurface(srfc);
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
        }

        /// <summary>
        ///   Creates a texture from a surface.
        /// </summary>
        /// <param name="surface">The surface to create a texture from.</param>
        public Texture(Surface surface) 
        {
            Pointer = SDL.SDL_CreateTextureFromSurface(SdlSystem.RendererPointer, surface.Pointer);
        }

        ~Texture() 
        {
            SDL.SDL_DestroyTexture(Pointer);
        }
    }
}