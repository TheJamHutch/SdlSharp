using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class represents a software surface.
    /// </summary>
    public class Surface
    {
        /// <summary>
        ///   The width of the surface.
        /// </summary>
        public int Width { get { return _width; } }

        /// <summary>
        ///   The height of the sur
        /// </summary>
        public int Height { get { return _height; } }

        /// <summary>
        ///   The length of a row of pixels in bytes (read-only)
        /// </summary>
        public int Pitch { get { return _pitch; } }

        /// <summary>
        ///   Reference count that can be incremented by the application
        /// </summary>
        public int RefCount { get { return _refCount; } set { _refCount = value; } }

        /// <summary>
        ///   A pointer to the internal SDL_Surface struct.
        /// </summary>
        public IntPtr SdlSurface { get { return _sdlSurface; } }

        // Private backing fields.
        private int _width;
        private int _height;
        private int _pitch;
        private int _refCount;

        // The internal SDL_Surface structure.
        private IntPtr _sdlSurface;

        //private SDL.SDL_Surface _sdlSurface = new SDL.SDL_Surface();

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

            _sdlSurface = SDL.SDL_CreateRGBSurface(0, width, height, 32, rmask, gmask, bmask, amask);
            _width = width;
            _height = height;
        }

        /// <summary>
        ///   Loads an image from a file and uses it to create a new surface.
        ///   BMP, PNG, TIFF and JPG file formats supported.
        /// </summary>
        /// <param name="filePath">The path to the image file.</param>
        public Surface(string filePath)
        {
            _sdlSurface = SDL.SDL_LoadBMP(filePath);
            _width = 0;
            _height = 0;
        }

        ~Surface() 
        {
            SDL.SDL_FreeSurface(_sdlSurface);
        }

        /// <summary>
        ///   Sets the transparency colour key for the surface.
        /// </summary>
        /// <param name="tspCol">Colour type enum representing the tranparency colour key.</param>
        public void SetTransparentColour(ColourType tspCol)
        {
            SDL.SDL_SetColorKey(_sdlSurface, 1, tspCol.ColourKey());
        }

        /// <summary>
        ///  Gets the transparency colour key for the surface.
        /// </summary>
        /// <returns>A ColourType enum value.</returns>
        public ColourType GetTransparentColour()
        {
            SDL.SDL_GetColorKey(_sdlSurface, out var key);

            return ColourType.Black;
        }

        public bool MustLock() 
        {
            return SDL.SDL_MUSTLOCK(_sdlSurface);
        }

        public int Lock() 
        {
            return SDL.SDL_LockSurface(_sdlSurface);
        }

        public void Unlock()
        {
            SDL.SDL_UnlockSurface(_sdlSurface);
        }

        public void LoadFromBMP(string bmpPath) 
        {
            SDL.SDL_FreeSurface(_sdlSurface);
            _sdlSurface = SDL.SDL_LoadBMP(bmpPath);
            _width = 999;
            _height = 999;
        }

        public void SaveToBmp(string bmpPath) 
        {
            SDL.SDL_SaveBMP(_sdlSurface, bmpPath);
        }
    }
}