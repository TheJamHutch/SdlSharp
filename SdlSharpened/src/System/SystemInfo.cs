using System;
using System.Collections.Generic;
using System.Text;
using SDL2;

namespace SdlSharpened
{
    public static class SystemInfo
    {
        public static int CoreCount => SDL.SDL_GetCPUCount();

        public static int CacheLineSize => SDL.SDL_GetCPUCacheLineSize();

        public static int MemoryInstalled => SDL.SDL_GetSystemRAM();

        public static string Platform => SDL.SDL_GetPlatform();

        public static string PowerStatus => PowerDescription();

        public static string Description() 
        {
            return $"CPU Cores: {CoreCount}\n" +
                   $"Cache Line Size: {CacheLineSize} KB\n" +
                   $"System RAM: {MemoryInstalled} MB\n" +
                   $"Platform: {Platform}\n" +
                   $"Power Status: {PowerStatus}\n";
        }

        private static string PowerDescription()
        {
            var powerState = SDL.SDL_GetPowerInfo(out var secs, out var percent);
            string stateDesc = "";

            switch (powerState)
            {
                case SDL.SDL_PowerState.SDL_POWERSTATE_UNKNOWN:
                    stateDesc = "Unknown";
                    break;
                case SDL.SDL_PowerState.SDL_POWERSTATE_ON_BATTERY:
                    stateDesc = "On Battery";
                    break;
                case SDL.SDL_PowerState.SDL_POWERSTATE_NO_BATTERY:
                    stateDesc = "No Battery";
                    break;
                case SDL.SDL_PowerState.SDL_POWERSTATE_CHARGING:
                    stateDesc = "Charging";
                    break;
                case SDL.SDL_PowerState.SDL_POWERSTATE_CHARGED:
                    stateDesc = "Charged";
                    break;
            }

            return stateDesc;
        }
    }
}
