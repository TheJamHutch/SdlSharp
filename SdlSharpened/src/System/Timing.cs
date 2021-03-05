using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Contains functions for handling the SDL time management routines.
    /// </summary>
    public static class Timing
    {
        /// <summary>
        ///   Use this function to get the number of milliseconds since the SDL library initialization.
        /// </summary>
        /// <remarks>
        ///   This value wraps if the program runs for more than ~49 days.
        /// </remarks>
        /// <returns>
        ///   Returns an unsigned 32-bit value representing the number of milliseconds since the SDL library initialized.
        /// </returns>
        public static uint Ticks() 
        {
            return SDL.SDL_GetTicks();
        }

        /// <summary>
        ///   Use this function to compare SDL ticks values.
        /// </summary>
        /// <param name="leftTick">The first ticks value.</param>
        /// <param name="rightTick">The second ticks values</param>
        /// <returns>
        ///   Returns return "true" if A has passed B.
        /// </returns>
        public static bool CompareTicks(uint firstTicks, uint secondTicks) 
        {
            return SDL.SDL_TICKS_PASSED(firstTicks, secondTicks);
        }

        /// <summary>
        ///   Use this function to wait a specified number of milliseconds before returning.
        /// </summary>
        /// <remarks>
        ///   This function waits a specified number of milliseconds before returning. It waits at least the specified time, 
        ///   but possibly longer due to OS scheduling.
        /// </remarks>
        /// <param name="delayMs">The number of milliseconds to wait for.</param>
        public static void Delay(uint delayMs) 
        {
            SDL.SDL_Delay(delayMs);
        }

        public static uint foo(uint interval, IntPtr param) 
        {
            Console.WriteLine("Euuppp!");
            return 1;
        }

        public static void AddTimer(uint interval) 
        {
            Func<uint, IntPtr, uint> funcv = foo;
            SDL.SDL_TimerCallback callback = new SDL.SDL_TimerCallback(funcv);
            SDL.SDL_AddTimer(interval, callback, IntPtr.Zero);
        }

        public static bool RemoveTimer() 
        {
            return false;
        }

        /// <summary>
        ///   Use this function to get the current value of the high resolution counter.
        /// </summary>
        /// <remarks>
        ///   This function is typically used for profiling. The counter values are only meaningful relative to each other. 
        ///   Differences between values can be converted to times by using PerformanceFrequency().
        /// </remarks>
        /// <returns>
        ///   Returns the current counter value.
        /// </returns>
        public static ulong PerformanceCounter() 
        {
            return SDL.SDL_GetPerformanceCounter();
        }

        /// <summary>
        ///   Use this function to get the count per second of the high resolution counter.
        /// </summary>
        /// <returns>
        ///   Returns a platform-specific count per second.
        /// </returns>
        public static ulong PerformanceFrequency() 
        {
            return SDL.SDL_GetPerformanceFrequency();
        }
    }
}
