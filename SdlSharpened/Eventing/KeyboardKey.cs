using SDL2;

namespace SdlSharpened
{
    public enum KeyboardKey
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

    public static class KeybordKeyExtension
    {
        public static KeyboardKey MapSdlKeycode(SDL.SDL_Keycode sdlKey)
        {
            KeyboardKey key;

            switch (sdlKey)
            {
                // Numerical keys
                case (SDL.SDL_Keycode.SDLK_0): { key = KeyboardKey.Key_0; } break;
                case (SDL.SDL_Keycode.SDLK_1): { key = KeyboardKey.Key_1; } break;
                case (SDL.SDL_Keycode.SDLK_2): { key = KeyboardKey.Key_2; } break;
                case (SDL.SDL_Keycode.SDLK_3): { key = KeyboardKey.Key_3; } break;
                case (SDL.SDL_Keycode.SDLK_4): { key = KeyboardKey.Key_4; } break;
                case (SDL.SDL_Keycode.SDLK_5): { key = KeyboardKey.Key_5; } break;
                case (SDL.SDL_Keycode.SDLK_6): { key = KeyboardKey.Key_6; } break;
                case (SDL.SDL_Keycode.SDLK_7): { key = KeyboardKey.Key_7; } break;
                case (SDL.SDL_Keycode.SDLK_8): { key = KeyboardKey.Key_8; } break;
                case (SDL.SDL_Keycode.SDLK_9): { key = KeyboardKey.Key_9; } break;
                // Alphabetical keys
                case (SDL.SDL_Keycode.SDLK_a): { key = KeyboardKey.Key_A; } break;
                case (SDL.SDL_Keycode.SDLK_b): { key = KeyboardKey.Key_B; } break;
                case (SDL.SDL_Keycode.SDLK_c): { key = KeyboardKey.Key_C; } break;
                case (SDL.SDL_Keycode.SDLK_d): { key = KeyboardKey.Key_D; } break;
                case (SDL.SDL_Keycode.SDLK_e): { key = KeyboardKey.Key_E; } break;
                case (SDL.SDL_Keycode.SDLK_f): { key = KeyboardKey.Key_F; } break;
                case (SDL.SDL_Keycode.SDLK_g): { key = KeyboardKey.Key_G; } break;
                case (SDL.SDL_Keycode.SDLK_h): { key = KeyboardKey.Key_H; } break;
                case (SDL.SDL_Keycode.SDLK_i): { key = KeyboardKey.Key_I; } break;
                case (SDL.SDL_Keycode.SDLK_j): { key = KeyboardKey.Key_J; } break;
                case (SDL.SDL_Keycode.SDLK_k): { key = KeyboardKey.Key_K; } break;
                case (SDL.SDL_Keycode.SDLK_l): { key = KeyboardKey.Key_L; } break;
                case (SDL.SDL_Keycode.SDLK_m): { key = KeyboardKey.Key_M; } break;
                case (SDL.SDL_Keycode.SDLK_n): { key = KeyboardKey.Key_N; } break;
                case (SDL.SDL_Keycode.SDLK_o): { key = KeyboardKey.Key_O; } break;
                case (SDL.SDL_Keycode.SDLK_p): { key = KeyboardKey.Key_P; } break;
                case (SDL.SDL_Keycode.SDLK_q): { key = KeyboardKey.Key_Q; } break;
                case (SDL.SDL_Keycode.SDLK_r): { key = KeyboardKey.Key_R; } break;
                case (SDL.SDL_Keycode.SDLK_s): { key = KeyboardKey.Key_S; } break;
                case (SDL.SDL_Keycode.SDLK_t): { key = KeyboardKey.Key_T; } break;
                case (SDL.SDL_Keycode.SDLK_u): { key = KeyboardKey.Key_U; } break;
                case (SDL.SDL_Keycode.SDLK_v): { key = KeyboardKey.Key_V; } break;
                case (SDL.SDL_Keycode.SDLK_w): { key = KeyboardKey.Key_W; } break;
                case (SDL.SDL_Keycode.SDLK_x): { key = KeyboardKey.Key_X; } break;
                case (SDL.SDL_Keycode.SDLK_y): { key = KeyboardKey.Key_Y; } break;
                case (SDL.SDL_Keycode.SDLK_z): { key = KeyboardKey.Key_Z; } break;
                // Control Keys
                case (SDL.SDL_Keycode.SDLK_ESCAPE): { key = KeyboardKey.Key_Escape; } break;
                case (SDL.SDL_Keycode.SDLK_PRINTSCREEN): { key = KeyboardKey.Key_PrintScreen; } break;
                case (SDL.SDL_Keycode.SDLK_SCROLLLOCK): { key = KeyboardKey.Key_ScrollLock; } break;
                case (SDL.SDL_Keycode.SDLK_PAUSE): { key = KeyboardKey.Key_Pause; } break;
                //case (SDL.SDL_Keycode.SDLK_z): { key = KeyType.Key_Pipe; } break;
                case (SDL.SDL_Keycode.SDLK_UNDERSCORE): { key = KeyboardKey.Key_Underscore; } break;
                case (SDL.SDL_Keycode.SDLK_EQUALS): { key = KeyboardKey.Key_Equals; } break;
                case (SDL.SDL_Keycode.SDLK_BACKSPACE): { key = KeyboardKey.Key_Backspace; } break;
                case (SDL.SDL_Keycode.SDLK_INSERT): { key = KeyboardKey.Key_Insert; } break;
                case (SDL.SDL_Keycode.SDLK_HOME): { key = KeyboardKey.Key_Home; } break;
                case (SDL.SDL_Keycode.SDLK_PAGEUP): { key = KeyboardKey.Key_PageUp; } break;
                case (SDL.SDL_Keycode.SDLK_TAB): { key = KeyboardKey.Key_Tab; } break;
                case (SDL.SDL_Keycode.SDLK_LEFTBRACKET): { key = KeyboardKey.Key_SquareBracketLeft; } break;
                case (SDL.SDL_Keycode.SDLK_RIGHTBRACKET): { key = KeyboardKey.Key_SquareBracketRight; } break;
                case (SDL.SDL_Keycode.SDLK_RETURN): { key = KeyboardKey.Key_Enter; } break;
                case (SDL.SDL_Keycode.SDLK_DELETE): { key = KeyboardKey.Key_Delete; } break;
                case (SDL.SDL_Keycode.SDLK_END): { key = KeyboardKey.Key_End; } break;
                case (SDL.SDL_Keycode.SDLK_PAGEDOWN): { key = KeyboardKey.Key_PageDown; } break;
                case (SDL.SDL_Keycode.SDLK_CAPSLOCK): { key = KeyboardKey.Key_CapsLock; } break;
                case (SDL.SDL_Keycode.SDLK_LSHIFT): { key = KeyboardKey.Key_LeftShift; } break;
                case (SDL.SDL_Keycode.SDLK_RSHIFT): { key = KeyboardKey.Key_RightShift; } break;
                case (SDL.SDL_Keycode.SDLK_COLON): { key = KeyboardKey.Key_Colon; } break;
                case (SDL.SDL_Keycode.SDLK_AT): { key = KeyboardKey.Key_At; } break;
                case (SDL.SDL_Keycode.SDLK_HASH): { key = KeyboardKey.Key_Hash; } break;
                case (SDL.SDL_Keycode.SDLK_BACKSLASH): { key = KeyboardKey.Key_Backslash; } break;
                case (SDL.SDL_Keycode.SDLK_COMMA): { key = KeyboardKey.Key_Comma; } break;
                case (SDL.SDL_Keycode.SDLK_PERIOD): { key = KeyboardKey.Key_Period; } break;
                case (SDL.SDL_Keycode.SDLK_SLASH): { key = KeyboardKey.Key_ForwardSlash; } break;
                case (SDL.SDL_Keycode.SDLK_SPACE): { key = KeyboardKey.Key_Space; } break;
                case (SDL.SDL_Keycode.SDLK_LCTRL): { key = KeyboardKey.Key_LeftControl; } break;
                case (SDL.SDL_Keycode.SDLK_RCTRL): { key = KeyboardKey.Key_RightControl; } break;
                case (SDL.SDL_Keycode.SDLK_LALT): { key = KeyboardKey.Key_LeftAlt; } break;
                case (SDL.SDL_Keycode.SDLK_RALT): { key = KeyboardKey.Key_RightAlt; } break;
                // Cursor Keys
                case (SDL.SDL_Keycode.SDLK_UP): { key = KeyboardKey.Key_Up; } break;
                case (SDL.SDL_Keycode.SDLK_DOWN): { key = KeyboardKey.Key_Down; } break;
                case (SDL.SDL_Keycode.SDLK_LEFT): { key = KeyboardKey.Key_Left; } break;
                case (SDL.SDL_Keycode.SDLK_RIGHT): { key = KeyboardKey.Key_Right; } break;
                // Numpad Keys
                case (SDL.SDL_Keycode.SDLK_KP_0): { key = KeyboardKey.Key_Pad0; } break;
                case (SDL.SDL_Keycode.SDLK_KP_1): { key = KeyboardKey.Key_Pad1; } break;
                case (SDL.SDL_Keycode.SDLK_KP_2): { key = KeyboardKey.Key_Pad2; } break;
                case (SDL.SDL_Keycode.SDLK_KP_3): { key = KeyboardKey.Key_Pad3; } break;
                case (SDL.SDL_Keycode.SDLK_KP_4): { key = KeyboardKey.Key_Pad4; } break;
                case (SDL.SDL_Keycode.SDLK_KP_5): { key = KeyboardKey.Key_Pad5; } break;
                case (SDL.SDL_Keycode.SDLK_KP_6): { key = KeyboardKey.Key_Pad6; } break;
                case (SDL.SDL_Keycode.SDLK_KP_7): { key = KeyboardKey.Key_Pad7; } break;
                case (SDL.SDL_Keycode.SDLK_KP_8): { key = KeyboardKey.Key_Pad8; } break;
                case (SDL.SDL_Keycode.SDLK_KP_9): { key = KeyboardKey.Key_Pad9; } break;
                case (SDL.SDL_Keycode.SDLK_KP_PERIOD): { key = KeyboardKey.Key_PadDelete; } break;
                case (SDL.SDL_Keycode.SDLK_KP_ENTER): { key = KeyboardKey.Key_PadEnter; } break;
                case (SDL.SDL_Keycode.SDLK_KP_PLUS): { key = KeyboardKey.Key_PadPlus; } break;
                case (SDL.SDL_Keycode.SDLK_KP_MINUS): { key = KeyboardKey.Key_PadMinus; } break;
                case (SDL.SDL_Keycode.SDLK_NUMLOCKCLEAR): { key = KeyboardKey.Key_PadNum; } break;
                case (SDL.SDL_Keycode.SDLK_KP_DIVIDE): { key = KeyboardKey.Key_PadSlash; } break;
                case (SDL.SDL_Keycode.SDLK_KP_MULTIPLY): { key = KeyboardKey.Key_PadAsterisk; } break;
                // Function Keys
                case (SDL.SDL_Keycode.SDLK_F1): { key = KeyboardKey.Key_F1; } break;
                case (SDL.SDL_Keycode.SDLK_F2): { key = KeyboardKey.Key_F2; } break;
                case (SDL.SDL_Keycode.SDLK_F3): { key = KeyboardKey.Key_F3; } break;
                case (SDL.SDL_Keycode.SDLK_F4): { key = KeyboardKey.Key_F4; } break;
                case (SDL.SDL_Keycode.SDLK_F5): { key = KeyboardKey.Key_F5; } break;
                case (SDL.SDL_Keycode.SDLK_F6): { key = KeyboardKey.Key_F6; } break;
                case (SDL.SDL_Keycode.SDLK_F7): { key = KeyboardKey.Key_F7; } break;
                case (SDL.SDL_Keycode.SDLK_F8): { key = KeyboardKey.Key_F8; } break;
                case (SDL.SDL_Keycode.SDLK_F9): { key = KeyboardKey.Key_F9; } break;
                case (SDL.SDL_Keycode.SDLK_F10): { key = KeyboardKey.Key_F10; } break;
                case (SDL.SDL_Keycode.SDLK_F11): { key = KeyboardKey.Key_F11; } break;
                case (SDL.SDL_Keycode.SDLK_F12): { key = KeyboardKey.Key_F12; } break;
                // Default
                default: { key = KeyboardKey.Key_Escape; } break;
            }

            return key;
        }
    }
}