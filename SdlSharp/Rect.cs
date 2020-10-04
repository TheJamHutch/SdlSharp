using System;
using SDL2;

namespace SdlSharp
{
    public class Rect
    {
        public int X 
        { 
            get { return _rect.x; }
            set { _rect.x = value; }
        }

        public int Y
        {
            get { return _rect.y; }
            set { _rect.y = value; }
        }

        public int W
        {
            get { return _rect.w; }
            set { _rect.w = value; }
        }

        public int H
        {
            get { return _rect.h; }
            set { _rect.h = value; }
        }

        private SDL.SDL_Rect _rect;

        public Rect()
        {
            _rect = new SDL.SDL_Rect() { x = 0, y = 0, w = 1, h = 1 };
        }

        public Rect(int w, int h)
        {
            _rect = new SDL.SDL_Rect() { x = 0, y = 0, w = w, h = h };
        }

        public Rect(int x, int y, int w, int h)
        {
            _rect = new SDL.SDL_Rect() { x = x, y = y, w = w, h = h };
        }

        public SDL.SDL_Rect Pointer()
        {
            return _rect;
        }
    }
}