using System;
using SDL2;

namespace SdlSharpened
{
    public class Font
    {
        public IntPtr Pointer { get; set; }

        public Font(string path)
        {
            Pointer = SDL_ttf.TTF_OpenFont(path, 36);
        }

        ~Font() 
        {
            SDL_ttf.TTF_CloseFont(Pointer);
        }
    }
}
