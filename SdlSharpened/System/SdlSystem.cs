﻿using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class represents the SDL system.
    /// </summary>
    public class SdlSystem
    {
        // Used all over the place
        internal static IntPtr WindowPointer { get; set; }
        internal static IntPtr RendererPointer { get; set; }

        /// <summary>
        ///   Creates an object representing the SDL system. Must be created before any other SdlSharpened objects.
        /// </summary>
        public SdlSystem()
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
            SDL_image.IMG_Init(SDL_image.IMG_InitFlags.IMG_INIT_JPG | SDL_image.IMG_InitFlags.IMG_INIT_PNG | SDL_image.IMG_InitFlags.IMG_INIT_TIF);
        }

        ~SdlSystem()
        {
            SDL_image.IMG_Quit();
            SDL.SDL_Quit();
        }

        /// <summary>
        ///   Delays the SDL system's clock for the specified number of milliseconds.
        /// </summary>
        /// <param name="millis">The number of milliseconds to delay.</param>
        public void Delay(int millis)
        {
            if (millis > 0)
            {
                SDL.SDL_Delay((uint)millis);
            }
        }

        /// <summary>
        ///   Gets the number of ticks since the SDL system was initialised.
        /// </summary>
        /// <returns>The tick count.</returns>
        public uint Ticks()
        {
            return SDL.SDL_GetTicks();
        }

        /// <summary>
        ///   Gets the major, minor, and patch version numbers of the currently installed version of SDL2. 
        /// </summary>
        /// <returns>A formatted string representing the SDL version.</returns>
        public string GetVersion()
        {
            SDL.SDL_GetVersion(out var version);

            return $"{version.major}.{version.minor}.{version.patch}";
        }

        /// <summary>
        ///   Returns the base file path.
        /// </summary>
        /// <returns>The base file path string.</returns>
        public string GetAppPath() 
        {
            return SDL.SDL_GetBasePath();
        }

        /// <summary>
        ///   Gets the most recently flagged SDL error.
        /// </summary>
        /// <returns>The SDL error.</returns>
        public string GetError()
        {
            return $"{SDL.SDL_GetError()}";
        }

        /// <summary>
        ///   Clears SDL of errors.
        /// </summary>
        public void ClearError() 
        {
            SDL.SDL_ClearError();
        }

        /// <summary>
        ///   Sets the SDL error.
        /// </summary>
        /// <param name="error">The error to set.</param>
        public void SetError(string error) 
        {
            SDL.SDL_SetError(error);
        }
    }
}