using System;
using SDL2;

namespace SdlSharpened
{
    public enum GameControllerAxis
    { 
        Invalid = -1,
        LeftX = 0,
        LeftY = 1,
        RightX = 2,
        RightY = 3,
        TriggerLeft = 4,
        TriggerRight = 5,
        Max = 6
    }

    public static class GameControllerAxisExtension
    {
        public static SDL.SDL_GameControllerAxis ToSdl(this GameControllerAxis gameControllerAxis)
        {
            return (SDL.SDL_GameControllerAxis)gameControllerAxis;
        }

        public static GameControllerAxis FromSdl(SDL.SDL_GameControllerAxis sdlGameControllerAxis)
        {
            return (GameControllerAxis)sdlGameControllerAxis;
        }    
    }
}
