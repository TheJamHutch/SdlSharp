using System;
using System.Collections.Generic;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Enum of all possible buttons on a typical 360 controller.
    ///   Direct one-to-one mapping with <see cref="SDL.SDL_GameControllerButton"/> enum.
    /// </summary>
    public enum GamepadButton
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

    public static class GamepadButtonExtension
    {
        public static IEnumerable<GamepadButton> GetValues() 
        {
            return (GamepadButton[])Enum.GetValues(typeof(GamepadButton));
        }

        public static SDL.SDL_GameControllerButton ToSdl(this GamepadButton button) 
        {
            return (SDL.SDL_GameControllerButton)button;
        }

        public static GamepadButton FromSdl(this SDL.SDL_GameControllerButton sdlButton)
        {
            return (GamepadButton)sdlButton;
        }
    }
}
