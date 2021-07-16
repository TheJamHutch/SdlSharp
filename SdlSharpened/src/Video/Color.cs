using System;
using SDL2;

namespace SdlSharpened
{
    public struct Color
    {
        public byte Red 
        { 
            get { return _sdlColor.r; }
            set { _sdlColor.r = value; }
        }

        public byte Green
        {
            get { return _sdlColor.g; }
            set { _sdlColor.g = value; }
        }

        public byte Blue
        {
            get { return _sdlColor.b; }
            set { _sdlColor.b = value; }
        }

        public byte Alpha
        {
            get { return _sdlColor.a; }
            set { _sdlColor.a = value; }
        }

        private SDL.SDL_Color _sdlColor;

        public Color(byte red, byte green, byte blue, byte alpha)
        {
            _sdlColor = new SDL.SDL_Color()
            {
                r = red, g = green, b = blue, a = alpha
            };
        }
    }
}
