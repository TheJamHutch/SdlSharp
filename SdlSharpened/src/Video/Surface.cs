using System;
using SDL2;

namespace SdlSharpened
{
    public class Surface
    {
        // Private backing fields.
        private int _width;
        private int _height;
        private int _pitch;
        private int _refCount;

        // The internal SDL_Surface structure.
        private IntPtr _sdlSurface;

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

        public int Width { get { return _width; } }

        public int Height { get { return _height; } }

        public int Pitch { get { return _pitch; } }

        public int RefCount { get { return _refCount; } set { _refCount = value; } }

        public IntPtr SdlSurface { get { return _sdlSurface; } }

        public void SetColorKey()
        {
            //SDL.SDL_SetColorKey(_sdlSurface, 1, tspCol.ColourKey());
        }

        public void GetTransparentColour()
        {
            SDL.SDL_GetColorKey(_sdlSurface, out var key);
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