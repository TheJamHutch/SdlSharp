using System;
using System.Collections.Generic;
using SDL2;

namespace SdlSharpened
{
    public struct Palette
    {
        public int NumColors { get { return _sdlPalette.ncolors; } }

        // The internal SDL_Palette struct.
        private SDL.SDL_Palette _sdlPalette;

        public Palette(IEnumerable<Color> colors)
        {
            _sdlPalette = new SDL.SDL_Palette();
        }
    }
}
