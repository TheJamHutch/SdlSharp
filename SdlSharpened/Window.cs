using System;
using SDL2;

namespace SdlSharpened
{
    public class Window
    {
        public IntPtr Pointer { get; }

        public Window(string title, int width, int height)
        {
            Pointer = SDL.SDL_CreateWindow(title, 100, 100, width, height, 0);
            Global.WindowPointer = Pointer;
        }

        ~Window()
        {
            SDL.SDL_DestroyWindow(Pointer);
        }
    }
}
