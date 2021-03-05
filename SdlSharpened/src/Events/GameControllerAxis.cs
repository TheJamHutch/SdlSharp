using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of axes available from a controller.
    /// </summary>
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

    /// <summary>
    ///   Exension methods for GameControllerAxis.
    /// </summary>
    public static class GameControllerAxisExtension
    {
        /// <summary>
        ///   
        /// </summary>
        /// <param name="gameControllerAxis"></param>
        /// <returns></returns>
        public static SDL.SDL_GameControllerAxis ToSdl(this GameControllerAxis gameControllerAxis)
        {
            return (SDL.SDL_GameControllerAxis)gameControllerAxis;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sdlGameControllerAxis"></param>
        /// <returns></returns>
        public static GameControllerAxis FromSdl(SDL.SDL_GameControllerAxis sdlGameControllerAxis)
        {
            return (GameControllerAxis)sdlGameControllerAxis;
        }    
    }
}
