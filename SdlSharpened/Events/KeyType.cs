﻿using SDL2;

namespace SdlSharpened
{
    public enum KeyType
    {
        // Numerical Keys
        Key_0, Key_1, Key_2, Key_3, Key_4, Key_5, Key_6, Key_7, Key_8, Key_9,
        // Alphabetical Keys
        Key_A, Key_B, Key_C, Key_D, Key_E, Key_F, Key_G, Key_H, Key_I, Key_J,
        Key_K, Key_L, Key_M, Key_N, Key_O, Key_P, Key_Q, Key_R, Key_S, Key_T,
        Key_U, Key_V, Key_W, Key_X, Key_Y, Key_Z,
        // Control Keys
        Key_Escape, Key_PrintScreen, Key_ScrollLock, Key_Pause, Key_Pipe, 
        Key_Underscore, Key_Equals, Key_Backspace, Key_Insert, Key_Home, 
        Key_PageUp, Key_Tab, Key_SquareBracketLeft, Key_SquareBracketRight,
        Key_Enter, Key_Delete, Key_End, Key_PageDown, Key_CapsLock, 
        Key_LeftShift, Key_RightShift, Key_Colon, Key_At, Key_Hash,
        Key_Backslash, Key_Comma, Key_Period, Key_ForwardSlash, Key_Space,
        Key_LeftControl, Key_RightControl, Key_LeftAlt, Key_RightAlt,
        // Cursor Keys
        Key_Up, Key_Down, Key_Left, Key_Right,
        // Numpad Keys
        Key_Pad0, Key_Pad1, Key_Pad2, Key_Pad3, Key_Pad4, Key_Pad5, Key_Pad6,
        Key_Pad7, Key_Pad8, Key_Pad9, Key_PadDelete, Key_PadEnter, Key_PadPlus,
        Key_PadMinus, Key_PadNum, Key_PadSlash, Key_PadAsterisk,
        // Function Keys
        Key_F1, Key_F2, Key_F3, Key_F4, Key_F5, Key_F6, Key_F7, Key_F8,
        Key_F9, Key_F10, Key_F11, Key_F12
    }

    public static class KeyTypeExtension
    {
        public static KeyType MapSdlKeycode(SDL.SDL_Keycode sdlKey)
        {
            KeyType key;

            switch (sdlKey)
            {
                // Numerical keys
                case (SDL.SDL_Keycode.SDLK_0): { key = KeyType.Key_0; } break;
                case (SDL.SDL_Keycode.SDLK_1): { key = KeyType.Key_1; } break;
                case (SDL.SDL_Keycode.SDLK_2): { key = KeyType.Key_2; } break;
                case (SDL.SDL_Keycode.SDLK_3): { key = KeyType.Key_3; } break;
                case (SDL.SDL_Keycode.SDLK_4): { key = KeyType.Key_4; } break;
                case (SDL.SDL_Keycode.SDLK_5): { key = KeyType.Key_5; } break;
                case (SDL.SDL_Keycode.SDLK_6): { key = KeyType.Key_6; } break;
                case (SDL.SDL_Keycode.SDLK_7): { key = KeyType.Key_7; } break;
                case (SDL.SDL_Keycode.SDLK_8): { key = KeyType.Key_8; } break;
                case (SDL.SDL_Keycode.SDLK_9): { key = KeyType.Key_9; } break;
                // Alphabetical keys
                case (SDL.SDL_Keycode.SDLK_a): { key = KeyType.Key_A; } break;
                case (SDL.SDL_Keycode.SDLK_b): { key = KeyType.Key_B; } break;
                case (SDL.SDL_Keycode.SDLK_c): { key = KeyType.Key_C; } break;
                case (SDL.SDL_Keycode.SDLK_d): { key = KeyType.Key_D; } break;
                case (SDL.SDL_Keycode.SDLK_e): { key = KeyType.Key_E; } break;
                case (SDL.SDL_Keycode.SDLK_f): { key = KeyType.Key_F; } break;
                case (SDL.SDL_Keycode.SDLK_g): { key = KeyType.Key_G; } break;
                case (SDL.SDL_Keycode.SDLK_h): { key = KeyType.Key_H; } break;
                case (SDL.SDL_Keycode.SDLK_i): { key = KeyType.Key_I; } break;
                case (SDL.SDL_Keycode.SDLK_j): { key = KeyType.Key_J; } break;
                case (SDL.SDL_Keycode.SDLK_k): { key = KeyType.Key_K; } break;
                case (SDL.SDL_Keycode.SDLK_l): { key = KeyType.Key_L; } break;
                case (SDL.SDL_Keycode.SDLK_m): { key = KeyType.Key_M; } break;
                case (SDL.SDL_Keycode.SDLK_n): { key = KeyType.Key_N; } break;
                case (SDL.SDL_Keycode.SDLK_o): { key = KeyType.Key_O; } break;
                case (SDL.SDL_Keycode.SDLK_p): { key = KeyType.Key_P; } break;
                case (SDL.SDL_Keycode.SDLK_q): { key = KeyType.Key_Q; } break;
                case (SDL.SDL_Keycode.SDLK_r): { key = KeyType.Key_R; } break;
                case (SDL.SDL_Keycode.SDLK_s): { key = KeyType.Key_S; } break;
                case (SDL.SDL_Keycode.SDLK_t): { key = KeyType.Key_T; } break;
                case (SDL.SDL_Keycode.SDLK_u): { key = KeyType.Key_U; } break;
                case (SDL.SDL_Keycode.SDLK_v): { key = KeyType.Key_V; } break;
                case (SDL.SDL_Keycode.SDLK_w): { key = KeyType.Key_W; } break;
                case (SDL.SDL_Keycode.SDLK_x): { key = KeyType.Key_X; } break;
                case (SDL.SDL_Keycode.SDLK_y): { key = KeyType.Key_Y; } break;
                case (SDL.SDL_Keycode.SDLK_z): { key = KeyType.Key_Z; } break;
                // Control Keys
                case (SDL.SDL_Keycode.SDLK_ESCAPE): { key = KeyType.Key_Escape; } break;
                case (SDL.SDL_Keycode.SDLK_PRINTSCREEN): { key = KeyType.Key_PrintScreen; } break;
                case (SDL.SDL_Keycode.SDLK_SCROLLLOCK): { key = KeyType.Key_ScrollLock; } break;
                case (SDL.SDL_Keycode.SDLK_PAUSE): { key = KeyType.Key_Pause; } break;
                //case (SDL.SDL_Keycode.SDLK_z): { key = KeyType.Key_Pipe; } break;
                case (SDL.SDL_Keycode.SDLK_UNDERSCORE): { key = KeyType.Key_Underscore; } break;
                case (SDL.SDL_Keycode.SDLK_EQUALS): { key = KeyType.Key_Equals; } break;
                case (SDL.SDL_Keycode.SDLK_BACKSPACE): { key = KeyType.Key_Backspace; } break;
                case (SDL.SDL_Keycode.SDLK_INSERT): { key = KeyType.Key_Insert; } break;
                case (SDL.SDL_Keycode.SDLK_HOME): { key = KeyType.Key_Home; } break;
                case (SDL.SDL_Keycode.SDLK_PAGEUP): { key = KeyType.Key_PageUp; } break;
                case (SDL.SDL_Keycode.SDLK_TAB): { key = KeyType.Key_Tab; } break;
                case (SDL.SDL_Keycode.SDLK_LEFTBRACKET): { key = KeyType.Key_SquareBracketLeft; } break;
                case (SDL.SDL_Keycode.SDLK_RIGHTBRACKET): { key = KeyType.Key_SquareBracketRight; } break;
                case (SDL.SDL_Keycode.SDLK_RETURN): { key = KeyType.Key_Enter; } break;
                case (SDL.SDL_Keycode.SDLK_DELETE): { key = KeyType.Key_Delete; } break;
                case (SDL.SDL_Keycode.SDLK_END): { key = KeyType.Key_End; } break;
                case (SDL.SDL_Keycode.SDLK_PAGEDOWN): { key = KeyType.Key_PageDown; } break;
                case (SDL.SDL_Keycode.SDLK_CAPSLOCK): { key = KeyType.Key_CapsLock; } break;
                case (SDL.SDL_Keycode.SDLK_LSHIFT): { key = KeyType.Key_LeftShift; } break;
                case (SDL.SDL_Keycode.SDLK_RSHIFT): { key = KeyType.Key_RightShift; } break;
                case (SDL.SDL_Keycode.SDLK_COLON): { key = KeyType.Key_Colon; } break;
                case (SDL.SDL_Keycode.SDLK_AT): { key = KeyType.Key_At; } break;
                case (SDL.SDL_Keycode.SDLK_HASH): { key = KeyType.Key_Hash; } break;
                case (SDL.SDL_Keycode.SDLK_BACKSLASH): { key = KeyType.Key_Backslash; } break;
                case (SDL.SDL_Keycode.SDLK_COMMA): { key = KeyType.Key_Comma; } break;
                case (SDL.SDL_Keycode.SDLK_PERIOD): { key = KeyType.Key_Period; } break;
                case (SDL.SDL_Keycode.SDLK_SLASH): { key = KeyType.Key_ForwardSlash; } break;
                case (SDL.SDL_Keycode.SDLK_SPACE): { key = KeyType.Key_Space; } break;
                case (SDL.SDL_Keycode.SDLK_LCTRL): { key = KeyType.Key_LeftControl; } break;
                case (SDL.SDL_Keycode.SDLK_RCTRL): { key = KeyType.Key_RightControl; } break;
                case (SDL.SDL_Keycode.SDLK_LALT): { key = KeyType.Key_LeftAlt; } break;
                case (SDL.SDL_Keycode.SDLK_RALT): { key = KeyType.Key_RightAlt; } break;
                // Cursor Keys
                case (SDL.SDL_Keycode.SDLK_UP): { key = KeyType.Key_Up; } break;
                case (SDL.SDL_Keycode.SDLK_DOWN): { key = KeyType.Key_Down; } break;
                case (SDL.SDL_Keycode.SDLK_LEFT): { key = KeyType.Key_Left; } break;
                case (SDL.SDL_Keycode.SDLK_RIGHT): { key = KeyType.Key_Right; } break;
                // Numpad Keys
                case (SDL.SDL_Keycode.SDLK_KP_0): { key = KeyType.Key_Pad0; } break;
                case (SDL.SDL_Keycode.SDLK_KP_1): { key = KeyType.Key_Pad1; } break;
                case (SDL.SDL_Keycode.SDLK_KP_2): { key = KeyType.Key_Pad2; } break;
                case (SDL.SDL_Keycode.SDLK_KP_3): { key = KeyType.Key_Pad3; } break;
                case (SDL.SDL_Keycode.SDLK_KP_4): { key = KeyType.Key_Pad4; } break;
                case (SDL.SDL_Keycode.SDLK_KP_5): { key = KeyType.Key_Pad5; } break;
                case (SDL.SDL_Keycode.SDLK_KP_6): { key = KeyType.Key_Pad6; } break;
                case (SDL.SDL_Keycode.SDLK_KP_7): { key = KeyType.Key_Pad7; } break;
                case (SDL.SDL_Keycode.SDLK_KP_8): { key = KeyType.Key_Pad8; } break;
                case (SDL.SDL_Keycode.SDLK_KP_9): { key = KeyType.Key_Pad9; } break;
                case (SDL.SDL_Keycode.SDLK_KP_PERIOD): { key = KeyType.Key_PadDelete; } break;
                case (SDL.SDL_Keycode.SDLK_KP_ENTER): { key = KeyType.Key_PadEnter; } break;
                case (SDL.SDL_Keycode.SDLK_KP_PLUS): { key = KeyType.Key_PadPlus; } break;
                case (SDL.SDL_Keycode.SDLK_KP_MINUS): { key = KeyType.Key_PadMinus; } break;
                case (SDL.SDL_Keycode.SDLK_NUMLOCKCLEAR): { key = KeyType.Key_PadNum; } break;
                case (SDL.SDL_Keycode.SDLK_KP_DIVIDE): { key = KeyType.Key_PadSlash; } break;
                case (SDL.SDL_Keycode.SDLK_KP_MULTIPLY): { key = KeyType.Key_PadAsterisk; } break;
                // Function Keys
                case (SDL.SDL_Keycode.SDLK_F1): { key = KeyType.Key_F1; } break;
                case (SDL.SDL_Keycode.SDLK_F2): { key = KeyType.Key_F2; } break;
                case (SDL.SDL_Keycode.SDLK_F3): { key = KeyType.Key_F3; } break;
                case (SDL.SDL_Keycode.SDLK_F4): { key = KeyType.Key_F4; } break;
                case (SDL.SDL_Keycode.SDLK_F5): { key = KeyType.Key_F5; } break;
                case (SDL.SDL_Keycode.SDLK_F6): { key = KeyType.Key_F6; } break;
                case (SDL.SDL_Keycode.SDLK_F7): { key = KeyType.Key_F7; } break;
                case (SDL.SDL_Keycode.SDLK_F8): { key = KeyType.Key_F8; } break;
                case (SDL.SDL_Keycode.SDLK_F9): { key = KeyType.Key_F9; } break;
                case (SDL.SDL_Keycode.SDLK_F10): { key = KeyType.Key_F10; } break;
                case (SDL.SDL_Keycode.SDLK_F11): { key = KeyType.Key_F11; } break;
                case (SDL.SDL_Keycode.SDLK_F12): { key = KeyType.Key_F12; } break;
                // Default
                default: { key = KeyType.Key_Escape; } break;
            }

            return key;
        }
    }
}