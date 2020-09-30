using System;
using SDL2;

namespace SdlSharp
{
    public class Window : IDisposable
    {
        public IntPtr Pointer { get; }

        public Window(string title, int width, int height)
        {
            Pointer = SDL.SDL_CreateWindow(title, 100, 100, width, height, 0);
            Global.WindowPointer = Pointer;
        }

        void IDisposable.Dispose() 
        {
            SDL.SDL_DestroyWindow(Pointer);
        }
    }
}
