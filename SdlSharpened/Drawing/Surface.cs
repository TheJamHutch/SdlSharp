using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class represents a software surface.
    /// </summary>
    public class Surface
    {
        // The width and height of the surface
        public int Width { get; }
        public int Height { get; }

        /// <summary>
        ///   A pointer to the internal SDL_Surface.
        /// </summary>
        public IntPtr Pointer { get; }

        /// <summary>
        ///   Creates a blank surface of specified width and height.
        /// </summary>
        /// <param name="width">The width of the surface in pixels.</param>
        /// <param name="height">The height of the surface in pixels</param>
        public Surface(int width, int height)
        {
            uint rmask = 0;
            uint gmask = 0;
            uint bmask = 0;
            uint amask = 0;

            Pointer = SDL.SDL_CreateRGBSurface(0, width, height, 32, rmask, gmask, bmask, amask);
            Width = width;
            Height = height;
        }

        /// <summary>
        ///   Loads an image from a file and uses it to create a new surface.
        ///   BMP, PNG, TIFF and JPG file formats supported.
        /// </summary>
        /// <param name="filePath">The path to the image file.</param>
        public Surface(string filePath)
        {
            Pointer = SDL_image.IMG_Load(filePath);
            Width = 0;
            Height = 0;
        }

        ~Surface() 
        {
            SDL.SDL_FreeSurface(Pointer);
        }

        /// <summary>
        ///   Sets the transparency colour key for the surface.
        /// </summary>
        /// <param name="tspCol">Colour type enum representing the tranparency colour key.</param>
        public void SetTransparentColour(ColourType tspCol)
        {
            SDL.SDL_SetColorKey(Pointer, 1, tspCol.ColourKey());
        }

        /// <summary>
        ///  GSets the transparency colour key for the surface.
        /// </summary>
        /// <returns>A ColourType enum value.</returns>
        public ColourType GetTransparentColour()
        {
            SDL.SDL_GetColorKey(Pointer, out var key);

            return ColourType.Black;
        }
    }
}