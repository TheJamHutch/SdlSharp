using System;
using System.Collections.Generic;
using SDL2;

namespace SdlSharpened
{
    public enum GameControllerButton
    {
        Btn_Invalid = -1,
        Btn_A = 0,
        Btn_B = 1,
        Btn_X = 2,
        Btn_Y = 3,
        Shldr_Left = 9,
        Shldr_Right = 10,
        Dpad_Up = 11,
        Dpad_Down = 12,
        Dpad_Left = 13,
        Dpad_Right = 14,
        Btn_Start = 6,
        Btn_Back = 4,
        Stick_Left = 7,
        Stick_Right = 8,
    }

    public static class GameControllerButtonExtension
    {
        public static IEnumerable<GameControllerButton> GetValues() 
        {
            return (GameControllerButton[])EventType.GetValues(typeof(GameControllerButton));
        }

        public static SDL.SDL_GameControllerButton ToSdl(this GameControllerButton button) 
        {
            return (SDL.SDL_GameControllerButton)button;
        }

        public static GameControllerButton FromSdl(SDL.SDL_GameControllerButton sdlButton)
        {
            return (GameControllerButton)sdlButton;
        }
    }
}
