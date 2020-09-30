﻿using System;
using SDL2;

namespace SdlSharp
{
    public enum ColourType
    {
        Black = 0,
        Red,
        Green,
        Blue,
        Cyan, 
        Magenta,
        Yellow,
        White
    }

    public static class Extension 
    {
        /// <summary>
        ///   Maps the ColourType to an SDL Uint32 colour key.
        /// </summary>
        /// <param name="colour"></param>
        /// <returns></returns>
        public static UInt32 ColourKey(this ColourType colour) 
        {
            byte r = 0, g = 0, b = 0;

            switch (colour)
            {
                case ColourType.Black: { r = 0; g = 0; b = 0; } break;
                case ColourType.Red: { r = 0xff; g = 0; b = 0; } break;
                case ColourType.Green: { r = 0; g = 0xff; b = 0; } break;
                case ColourType.Blue: { r = 0; g = 0; b = 0xff; } break;
                case ColourType.Cyan: { r = 0; g = 0xff; b = 0xff; } break;
                case ColourType.Magenta: { r = 0xff; g = 0; b = 0xff; } break;
                case ColourType.Yellow: { r = 0xff; g = 0xff; b = 0; } break;
                case ColourType.White: { r = 0xff; g = 0xff; b = 0xff; } break;
            }

            var pixelFormat = SDL.SDL_GetWindowPixelFormat(Global.WindowPointer);
            var pixelStruct = SDL.SDL_AllocFormat(pixelFormat);
            UInt32 sdlColour = SDL.SDL_MapRGB(pixelStruct, r, g, b);

            return sdlColour;
        }
    }
}
