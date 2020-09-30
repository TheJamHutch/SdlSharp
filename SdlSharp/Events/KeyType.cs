using System;
using SDL2;

namespace SdlSharp
{
    /// <summary>
    ///   Enum representing the range of possible key types.
    /// </summary>
    public enum KeyType
    {
        Key_0,
        Key_1,
        Key_2,
        Key_3,
        Key_4,
        Key_5,
        Key_6,
        Key_7,
        Key_8,
        Key_9,

        Key_a,
        Key_b,
        Key_c,
        Key_d,
        Key_e,
        Key_f,
        Key_g,
        Key_h,
        Key_i,
        Key_j,
        Key_k,
        Key_l,
        Key_m,
        Key_n,
        Key_o,
        Key_p,
        Key_q,
        Key_r,
        Key_s,
        Key_t,
        Key_u,
        Key_v,
        Key_w,
        Key_x,
        Key_y,
        Key_z,

        Key_Minus,
        Key_Plus,
        Key_Backspace,
        Key_Tab,
        Key_Space,
        Key_Enter,
        Key_LCtrl,
        Key_RCtrl,
        Key_LAlt,
        Key_RAlt
    }

    public static class KeyTypeExtension
    {
        /// <summary>
        ///   Maps an SDL_Keycode to a KeyType.
        /// </summary>
        /// <param name="sdlKey">The SDL key.</param>
        public static KeyType MapSdlKeycode(SDL.SDL_Keycode sdlKey)
        {
            KeyType key;

            # region Numerical keys
            if (sdlKey == SDL.SDL_Keycode.SDLK_0)
                key = KeyType.Key_0;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_1)
                key = KeyType.Key_1;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_2)
                key = KeyType.Key_2;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_3)
                key = KeyType.Key_3;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_4)
                key = KeyType.Key_4;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_5)
                key = KeyType.Key_5;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_6)
                key = KeyType.Key_6;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_7)
                key = KeyType.Key_7;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_8)
                key = KeyType.Key_8;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_9)
                key = KeyType.Key_9;
            #endregion
            #region Alphabetical keys
            else if (sdlKey == SDL.SDL_Keycode.SDLK_a)
                key = KeyType.Key_a;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_b)
                key = KeyType.Key_b;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_c)
                key = KeyType.Key_c;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_d)
                key = KeyType.Key_d;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_e)
                key = KeyType.Key_e;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_f)
                key = KeyType.Key_f;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_g)
                key = KeyType.Key_g;
            #endregion
            #region Control Keys
            else if (sdlKey == SDL.SDL_Keycode.SDLK_LCTRL)
                key = KeyType.Key_LCtrl;
            else if (sdlKey == SDL.SDL_Keycode.SDLK_RCTRL)
                key = KeyType.Key_RCtrl;
            #endregion
            else
                key = KeyType.Key_0;

            return key;
        }
    }
}