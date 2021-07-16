using System;
using SDL2;

namespace SdlSharpened
{
    public class Window
    {
        public IntPtr SdlWindow { get { return _sdlWindow; } }

        private IntPtr _sdlWindow;

        public Window(string title, int width, int height)
        {
            _sdlWindow = SDL.SDL_CreateWindow(title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, width, height, 0);
            SdlSystem.WindowPointer = _sdlWindow;
        }

        public Window(string title, Point point)
        {
            _sdlWindow = SDL.SDL_CreateWindow(title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, point.SdlPoint.x, point.SdlPoint.y, 0);
            SdlSystem.WindowPointer = _sdlWindow;
        }

        ~Window()
        {
            SDL.SDL_DestroyWindow(_sdlWindow);
        }

        public void Minimize() 
        {
            SDL.SDL_MinimizeWindow(_sdlWindow);
        }

        public void Maximize() 
        {
            SDL.SDL_MaximizeWindow(_sdlWindow);
        }

        #region Getters

        public float GetOpacity() 
        {
            SDL.SDL_GetWindowOpacity(_sdlWindow, out var opacity);
            return opacity;
        }

        public string GetTitle() 
        {
            return SDL.SDL_GetWindowTitle(_sdlWindow);
        }

        public void GetPosition(out int xPos, out int yPos)
        {
            SDL.SDL_GetWindowPosition(_sdlWindow, out xPos, out yPos);
        }

        public void GetSize(out int width, out int height)
        {
            SDL.SDL_GetWindowSize(_sdlWindow, out width, out height);
        }
        #endregion

        #region Setters

        public void SetTitle(string title) 
        {
            SDL.SDL_SetWindowTitle(_sdlWindow, title);
        }

        public void SetSize(int width, int height) 
        {
            SDL.SDL_SetWindowSize(_sdlWindow, width, height);
        }

        public void SetPosition(int xPos, int yPos) 
        {
            SDL.SDL_SetWindowPosition(_sdlWindow, xPos, yPos);
        }

        public void SetWindowOpacity(float opacity) 
        {
            SDL.SDL_SetWindowOpacity(_sdlWindow, opacity);
        }
        #endregion

        public void ShowMessageBox(string title, string message) 
        {
            SDL.SDL_ShowSimpleMessageBox(SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION, title, message, _sdlWindow);
        }
    }
}