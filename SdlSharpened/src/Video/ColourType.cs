using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Enum representing every possbile colour choice. Currently severely limited.
    /// </summary>
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

    /// <summary>
    ///   Enum extension methods.
    /// </summary>
    public static class ColourTypeExtension 
    {
        /// <summary>
        ///   Outputs the RGB byte values associated with the colour type enum.
        /// </summary>
        /// <param name="colour">The colour type enum value.</param>
        /// <param name="r">Red byte value.</param>
        /// <param name="g">Green byte value.</param>
        /// <param name="b">Blue byte value.</param>
        public static void ColourBytes(this ColourType colour, out byte r, out byte g, out byte b)
        {
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
                default: { r = 0; g = 0; b = 0; } break;
            }
        }

        /// <summary>
        ///   Sets the colour type enum value from RGB byte values. If no direct equivalence is found between the 
        ///   bytes and the enums, enum will be set to closest corresponding value.
        /// </summary>
        /// <param name="colour">The colour type enum value.</param>
        /// <param name="r">Red byte value.</param>
        /// <param name="g">Red byte value.</param>
        /// <param name="b">Red byte value.</param>
        public static void SetFromBytes(this ColourType colour, byte r, byte g, byte b)
        {
            // Must be a better way
            if (r == 0 && g == 0 && b == 0)
            {
                colour = ColourType.Black;
            }
            else if (r == 0xff && g == 0 && b == 0)
            {
                colour = ColourType.Red;
            }
            else if (r == 0 && g == 0xff && b == 0)
            {
                colour = ColourType.Green;
            }
            else if (r == 0 && g == 0 && b == 0xff)
            {
                colour = ColourType.Blue;
            }
            else if (r == 0 && g == 0xff && b == 0xff)
            {
                colour = ColourType.Cyan;
            }
            else if (r == 0xff && g == 0 && b == 0xff)
            {
                colour = ColourType.Magenta;
            }
            else if (r == 0xff && g == 0xff && b == 0)
            {
                colour = ColourType.Yellow;
            }
            else
            {
                colour = ColourType.Black;
            }
        }

        internal static UInt32 ColourKey(this ColourType colour)
        {
            ColourBytes(colour, out var r, out var g, out var b);

            var pixelFormat = SDL.SDL_GetWindowPixelFormat(SdlSystem.WindowPointer);
            var pixelStruct = SDL.SDL_AllocFormat(pixelFormat);
            UInt32 sdlColour = SDL.SDL_MapRGB(pixelStruct, r, g, b);

            return sdlColour;
        }
    }
}