using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   A structure that represents a color.
    /// </summary>
    public struct Color
    {
        /// <summary>
        ///   The red component in the range 0-255.
        /// </summary>
        public byte Red 
        { 
            get { return _sdlColor.r; }
            set { _sdlColor.r = value; }
        }

        /// <summary>
        ///   The green component in the range 0-255.
        /// </summary>
        public byte Green
        {
            get { return _sdlColor.g; }
            set { _sdlColor.g = value; }
        }

        /// <summary>
        ///   The blue component in the range 0-255.
        /// </summary>
        public byte Blue
        {
            get { return _sdlColor.b; }
            set { _sdlColor.b = value; }
        }

        /// <summary>
        ///   The alpha component in the range 0-255.
        /// </summary>
        public byte Alpha
        {
            get { return _sdlColor.a; }
            set { _sdlColor.a = value; }
        }

        // The internal SDL_Color struct.
        private SDL.SDL_Color _sdlColor;

        /// <summary>
        ///   Creates the color struct.
        /// </summary>
        /// <param name="red">The red component in the range 0-255.</param>
        /// <param name="green">The green component in the range 0-255.</param>
        /// <param name="blue">The blue component in the range 0-255.</param>
        /// <param name="alpha">The alpha component in the range 0-255.</param>
        public Color(byte red, byte green, byte blue, byte alpha)
        {
            _sdlColor = new SDL.SDL_Color()
            {
                r = red, g = green, b = blue, a = alpha
            };
        }
    }
}
