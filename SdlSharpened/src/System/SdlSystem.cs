using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class represents the SDL system.
    /// </summary>
    public static class SdlSystem
    {
        // Used all over the place
        internal static IntPtr WindowPointer { get; set; }
        internal static IntPtr RendererPointer { get; set; }

        /// <summary>
        ///   Creates an object representing the SDL system. Must be created before any other SdlSharpened objects.
        /// </summary>
        public static void Init()
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
        }

        public static void Quit()
        {
            SDL.SDL_Quit();
        }

        /// <summary>
        ///   Delays the SDL system's clock for the specified number of milliseconds.
        /// </summary>
        /// <param name="millis">The number of milliseconds to delay.</param>
        public static void Delay(int millis)
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
        public static uint Ticks()
        {
            return SDL.SDL_GetTicks();
        }

        /// <summary>
        ///   Gets the major, minor, and patch version numbers of the currently installed version of SDL2. 
        /// </summary>
        /// <returns>A formatted string representing the SDL version.</returns>
        public static string Version()
        {
            SDL.SDL_GetVersion(out var sdlVersion);

            return $"SDL2: {sdlVersion.major}.{sdlVersion.minor}.{sdlVersion.patch} \n";
        }

        /// <summary>
        ///   Returns the base file path.
        /// </summary>
        /// <returns>The base file path string.</returns>
        public static string GetAppPath() 
        {
            return SDL.SDL_GetBasePath();
        }

        /// <summary>
        ///   Gets the most recently flagged SDL error.
        /// </summary>
        /// <returns>The SDL error.</returns>
        public static string GetError()
        {
            return $"{SDL.SDL_GetError()}";
        }

        /// <summary>
        ///   Clears SDL of errors.
        /// </summary>
        public static void ClearError() 
        {
            SDL.SDL_ClearError();
        }

        /// <summary>
        ///   Sets the SDL error.
        /// </summary>
        /// <param name="error">The error to set.</param>
        public static void SetError(string error) 
        {
            SDL.SDL_SetError(error);
        }
    }
}