using SDL2;

namespace SdlSharpened
{
    public enum Keycode
    {
        // Numerical Keys
        Key_0 = '0',
        Key_1 = '1', 
        Key_2 = '2', 
        Key_3 = '3', 
        Key_4 = '4', 
        Key_5 = '5', 
        Key_6 = '6', 
        Key_7 = '7', 
        Key_8 = '8', 
        Key_9 = '9',
        // Alphabetical Keys
        Key_A = 'a', 
        Key_B = 'b', 
        Key_C = 'c', 
        Key_D = 'd', 
        Key_E = 'e', 
        Key_F = 'f', 
        Key_G = 'g', 
        Key_H = 'h', 
        Key_I = 'i', 
        Key_J = 'j',
        Key_K = 'k', 
        Key_L = 'l', 
        Key_M = 'm', 
        Key_N = 'n', 
        Key_O = 'o', 
        Key_P = 'p', 
        Key_Q = 'q', 
        Key_R = 'r', 
        Key_S = 's', 
        Key_T = 't',
        Key_U = 'u', 
        Key_V = 'v', 
        Key_W = 'w', 
        Key_X = 'x', 
        Key_Y = 'y', 
        Key_Z = 'z',
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

    public static class KeycodeEx
    {
        public static SDL.SDL_Keycode ToSdl(this Keycode keycode)
        {
            return (SDL.SDL_Keycode)keycode;
        }

        public static Keycode FromSdl (SDL.SDL_Keycode sdlKey)
        {
            Keycode key;

            switch (sdlKey)
            {
                // Numerical keys
                case (SDL.SDL_Keycode.SDLK_0): { key = Keycode.Key_0; } break;
                case (SDL.SDL_Keycode.SDLK_1): { key = Keycode.Key_1; } break;
                case (SDL.SDL_Keycode.SDLK_2): { key = Keycode.Key_2; } break;
                case (SDL.SDL_Keycode.SDLK_3): { key = Keycode.Key_3; } break;
                case (SDL.SDL_Keycode.SDLK_4): { key = Keycode.Key_4; } break;
                case (SDL.SDL_Keycode.SDLK_5): { key = Keycode.Key_5; } break;
                case (SDL.SDL_Keycode.SDLK_6): { key = Keycode.Key_6; } break;
                case (SDL.SDL_Keycode.SDLK_7): { key = Keycode.Key_7; } break;
                case (SDL.SDL_Keycode.SDLK_8): { key = Keycode.Key_8; } break;
                case (SDL.SDL_Keycode.SDLK_9): { key = Keycode.Key_9; } break;
                // Alphabetical keys
                case (SDL.SDL_Keycode.SDLK_a): { key = Keycode.Key_A; } break;
                case (SDL.SDL_Keycode.SDLK_b): { key = Keycode.Key_B; } break;
                case (SDL.SDL_Keycode.SDLK_c): { key = Keycode.Key_C; } break;
                case (SDL.SDL_Keycode.SDLK_d): { key = Keycode.Key_D; } break;
                case (SDL.SDL_Keycode.SDLK_e): { key = Keycode.Key_E; } break;
                case (SDL.SDL_Keycode.SDLK_f): { key = Keycode.Key_F; } break;
                case (SDL.SDL_Keycode.SDLK_g): { key = Keycode.Key_G; } break;
                case (SDL.SDL_Keycode.SDLK_h): { key = Keycode.Key_H; } break;
                case (SDL.SDL_Keycode.SDLK_i): { key = Keycode.Key_I; } break;
                case (SDL.SDL_Keycode.SDLK_j): { key = Keycode.Key_J; } break;
                case (SDL.SDL_Keycode.SDLK_k): { key = Keycode.Key_K; } break;
                case (SDL.SDL_Keycode.SDLK_l): { key = Keycode.Key_L; } break;
                case (SDL.SDL_Keycode.SDLK_m): { key = Keycode.Key_M; } break;
                case (SDL.SDL_Keycode.SDLK_n): { key = Keycode.Key_N; } break;
                case (SDL.SDL_Keycode.SDLK_o): { key = Keycode.Key_O; } break;
                case (SDL.SDL_Keycode.SDLK_p): { key = Keycode.Key_P; } break;
                case (SDL.SDL_Keycode.SDLK_q): { key = Keycode.Key_Q; } break;
                case (SDL.SDL_Keycode.SDLK_r): { key = Keycode.Key_R; } break;
                case (SDL.SDL_Keycode.SDLK_s): { key = Keycode.Key_S; } break;
                case (SDL.SDL_Keycode.SDLK_t): { key = Keycode.Key_T; } break;
                case (SDL.SDL_Keycode.SDLK_u): { key = Keycode.Key_U; } break;
                case (SDL.SDL_Keycode.SDLK_v): { key = Keycode.Key_V; } break;
                case (SDL.SDL_Keycode.SDLK_w): { key = Keycode.Key_W; } break;
                case (SDL.SDL_Keycode.SDLK_x): { key = Keycode.Key_X; } break;
                case (SDL.SDL_Keycode.SDLK_y): { key = Keycode.Key_Y; } break;
                case (SDL.SDL_Keycode.SDLK_z): { key = Keycode.Key_Z; } break;
                // Control Keys
                case (SDL.SDL_Keycode.SDLK_ESCAPE): { key = Keycode.Key_Escape; } break;
                case (SDL.SDL_Keycode.SDLK_PRINTSCREEN): { key = Keycode.Key_PrintScreen; } break;
                case (SDL.SDL_Keycode.SDLK_SCROLLLOCK): { key = Keycode.Key_ScrollLock; } break;
                case (SDL.SDL_Keycode.SDLK_PAUSE): { key = Keycode.Key_Pause; } break;
                //case (SDL.SDL_Keycode.SDLK_z): { key = KeyType.Key_Pipe; } break;
                case (SDL.SDL_Keycode.SDLK_UNDERSCORE): { key = Keycode.Key_Underscore; } break;
                case (SDL.SDL_Keycode.SDLK_EQUALS): { key = Keycode.Key_Equals; } break;
                case (SDL.SDL_Keycode.SDLK_BACKSPACE): { key = Keycode.Key_Backspace; } break;
                case (SDL.SDL_Keycode.SDLK_INSERT): { key = Keycode.Key_Insert; } break;
                case (SDL.SDL_Keycode.SDLK_HOME): { key = Keycode.Key_Home; } break;
                case (SDL.SDL_Keycode.SDLK_PAGEUP): { key = Keycode.Key_PageUp; } break;
                case (SDL.SDL_Keycode.SDLK_TAB): { key = Keycode.Key_Tab; } break;
                case (SDL.SDL_Keycode.SDLK_LEFTBRACKET): { key = Keycode.Key_SquareBracketLeft; } break;
                case (SDL.SDL_Keycode.SDLK_RIGHTBRACKET): { key = Keycode.Key_SquareBracketRight; } break;
                case (SDL.SDL_Keycode.SDLK_RETURN): { key = Keycode.Key_Enter; } break;
                case (SDL.SDL_Keycode.SDLK_DELETE): { key = Keycode.Key_Delete; } break;
                case (SDL.SDL_Keycode.SDLK_END): { key = Keycode.Key_End; } break;
                case (SDL.SDL_Keycode.SDLK_PAGEDOWN): { key = Keycode.Key_PageDown; } break;
                case (SDL.SDL_Keycode.SDLK_CAPSLOCK): { key = Keycode.Key_CapsLock; } break;
                case (SDL.SDL_Keycode.SDLK_LSHIFT): { key = Keycode.Key_LeftShift; } break;
                case (SDL.SDL_Keycode.SDLK_RSHIFT): { key = Keycode.Key_RightShift; } break;
                case (SDL.SDL_Keycode.SDLK_COLON): { key = Keycode.Key_Colon; } break;
                case (SDL.SDL_Keycode.SDLK_AT): { key = Keycode.Key_At; } break;
                case (SDL.SDL_Keycode.SDLK_HASH): { key = Keycode.Key_Hash; } break;
                case (SDL.SDL_Keycode.SDLK_BACKSLASH): { key = Keycode.Key_Backslash; } break;
                case (SDL.SDL_Keycode.SDLK_COMMA): { key = Keycode.Key_Comma; } break;
                case (SDL.SDL_Keycode.SDLK_PERIOD): { key = Keycode.Key_Period; } break;
                case (SDL.SDL_Keycode.SDLK_SLASH): { key = Keycode.Key_ForwardSlash; } break;
                case (SDL.SDL_Keycode.SDLK_SPACE): { key = Keycode.Key_Space; } break;
                case (SDL.SDL_Keycode.SDLK_LCTRL): { key = Keycode.Key_LeftControl; } break;
                case (SDL.SDL_Keycode.SDLK_RCTRL): { key = Keycode.Key_RightControl; } break;
                case (SDL.SDL_Keycode.SDLK_LALT): { key = Keycode.Key_LeftAlt; } break;
                case (SDL.SDL_Keycode.SDLK_RALT): { key = Keycode.Key_RightAlt; } break;
                // Cursor Keys
                case (SDL.SDL_Keycode.SDLK_UP): { key = Keycode.Key_Up; } break;
                case (SDL.SDL_Keycode.SDLK_DOWN): { key = Keycode.Key_Down; } break;
                case (SDL.SDL_Keycode.SDLK_LEFT): { key = Keycode.Key_Left; } break;
                case (SDL.SDL_Keycode.SDLK_RIGHT): { key = Keycode.Key_Right; } break;
                // Numpad Keys
                case (SDL.SDL_Keycode.SDLK_KP_0): { key = Keycode.Key_Pad0; } break;
                case (SDL.SDL_Keycode.SDLK_KP_1): { key = Keycode.Key_Pad1; } break;
                case (SDL.SDL_Keycode.SDLK_KP_2): { key = Keycode.Key_Pad2; } break;
                case (SDL.SDL_Keycode.SDLK_KP_3): { key = Keycode.Key_Pad3; } break;
                case (SDL.SDL_Keycode.SDLK_KP_4): { key = Keycode.Key_Pad4; } break;
                case (SDL.SDL_Keycode.SDLK_KP_5): { key = Keycode.Key_Pad5; } break;
                case (SDL.SDL_Keycode.SDLK_KP_6): { key = Keycode.Key_Pad6; } break;
                case (SDL.SDL_Keycode.SDLK_KP_7): { key = Keycode.Key_Pad7; } break;
                case (SDL.SDL_Keycode.SDLK_KP_8): { key = Keycode.Key_Pad8; } break;
                case (SDL.SDL_Keycode.SDLK_KP_9): { key = Keycode.Key_Pad9; } break;
                case (SDL.SDL_Keycode.SDLK_KP_PERIOD): { key = Keycode.Key_PadDelete; } break;
                case (SDL.SDL_Keycode.SDLK_KP_ENTER): { key = Keycode.Key_PadEnter; } break;
                case (SDL.SDL_Keycode.SDLK_KP_PLUS): { key = Keycode.Key_PadPlus; } break;
                case (SDL.SDL_Keycode.SDLK_KP_MINUS): { key = Keycode.Key_PadMinus; } break;
                case (SDL.SDL_Keycode.SDLK_NUMLOCKCLEAR): { key = Keycode.Key_PadNum; } break;
                case (SDL.SDL_Keycode.SDLK_KP_DIVIDE): { key = Keycode.Key_PadSlash; } break;
                case (SDL.SDL_Keycode.SDLK_KP_MULTIPLY): { key = Keycode.Key_PadAsterisk; } break;
                // Function Keys
                case (SDL.SDL_Keycode.SDLK_F1): { key = Keycode.Key_F1; } break;
                case (SDL.SDL_Keycode.SDLK_F2): { key = Keycode.Key_F2; } break;
                case (SDL.SDL_Keycode.SDLK_F3): { key = Keycode.Key_F3; } break;
                case (SDL.SDL_Keycode.SDLK_F4): { key = Keycode.Key_F4; } break;
                case (SDL.SDL_Keycode.SDLK_F5): { key = Keycode.Key_F5; } break;
                case (SDL.SDL_Keycode.SDLK_F6): { key = Keycode.Key_F6; } break;
                case (SDL.SDL_Keycode.SDLK_F7): { key = Keycode.Key_F7; } break;
                case (SDL.SDL_Keycode.SDLK_F8): { key = Keycode.Key_F8; } break;
                case (SDL.SDL_Keycode.SDLK_F9): { key = Keycode.Key_F9; } break;
                case (SDL.SDL_Keycode.SDLK_F10): { key = Keycode.Key_F10; } break;
                case (SDL.SDL_Keycode.SDLK_F11): { key = Keycode.Key_F11; } break;
                case (SDL.SDL_Keycode.SDLK_F12): { key = Keycode.Key_F12; } break;
                // Default
                default: { key = Keycode.Key_Escape; } break;
            }

            return key;
        }
    }
}