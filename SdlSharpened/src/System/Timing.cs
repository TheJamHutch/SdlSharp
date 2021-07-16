using System;
using SDL2;

namespace SdlSharpened
{
    public static class Timing
    {
        public static uint Ticks() 
        {
            return SDL.SDL_GetTicks();
        }

        public static bool CompareTicks(uint firstTicks, uint secondTicks) 
        {
            return SDL.SDL_TICKS_PASSED(firstTicks, secondTicks);
        }

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

        public static ulong PerformanceCounter() 
        {
            return SDL.SDL_GetPerformanceCounter();
        }

        public static ulong PerformanceFrequency() 
        {
            return SDL.SDL_GetPerformanceFrequency();
        }
    }
}
