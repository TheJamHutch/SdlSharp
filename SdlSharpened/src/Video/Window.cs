using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class represents a window which can be rendered to.
    /// </summary>
    public class Window
    {
        /// <summary>
        ///    A pointer to SDL's internal SDL_Window struct.
        /// </summary>
        public IntPtr SdlWindow { get { return _sdlWindow; } }

        private IntPtr _sdlWindow;

        /// <summary>
        ///   Creates a window in the center of the screen of a given pixel width and height, and sets the title.
        /// </summary>
        /// <param name="title">The title text at the top of the window.</param>
        /// <param name="width">The pixel width of the window.</param>
        /// <param name="height">The pixel height of the window.</param>
        public Window(string title, int width, int height)
        {
            _sdlWindow = SDL.SDL_CreateWindow(title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, width, height, 0);
            SdlSystem.WindowPointer = _sdlWindow;
        }

        /// <summary>
        ///   Creates a window in the center of the screen of a given pixel width and height, and sets the title.
        /// </summary>
        /// <param name="title">The title text at the top of the window.</param>
        /// <param name="point">A point representing the pixel width and height of the window.</param>
        public Window(string title, Point point)
        {
            _sdlWindow = SDL.SDL_CreateWindow(title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, point.SdlPoint.x, point.SdlPoint.y, 0);
            SdlSystem.WindowPointer = _sdlWindow;
        }

        ~Window()
        {
            SDL.SDL_DestroyWindow(_sdlWindow);
        }

        /// <summary>
        ///   Minimize the window.
        /// </summary>
        public void Minimize() 
        {
            SDL.SDL_MinimizeWindow(_sdlWindow);
        }

        /// <summary>
        ///   Maximize the window.
        /// </summary>
        public void Maximize() 
        {
            SDL.SDL_MaximizeWindow(_sdlWindow);
        }

        #region Getters

        /// <summary>
        ///   Gets the window opacity.
        /// </summary>
        /// <returns>The window opacity value.</returns>
        public float GetOpacity() 
        {
            SDL.SDL_GetWindowOpacity(_sdlWindow, out var opacity);
            return opacity;
        }

        /// <summary>
        ///   Gets the current window title text.
        /// </summary>
        /// <returns>The window title text.</returns>
        public string GetTitle() 
        {
            return SDL.SDL_GetWindowTitle(_sdlWindow);
        }

        /// <summary>
        ///   Gets the current pixel position of the window, relative to the whole screen.
        /// </summary>
        /// <param name="xPos">The X pixel position value.</param>
        /// <param name="yPos">The Y pixel position value.</param>
        public void GetPosition(out int xPos, out int yPos)
        {
            SDL.SDL_GetWindowPosition(_sdlWindow, out xPos, out yPos);
        }

        /// <summary>
        ///   Gets the pixel width and height of the window.
        /// </summary>
        /// <param name="width">The pixel width value.</param>
        /// <param name="height">The pixel height value.</param>
        public void GetSize(out int width, out int height)
        {
            SDL.SDL_GetWindowSize(_sdlWindow, out width, out height);
        }
        #endregion

        #region Setters

        /// <summary>
        ///   Sets the window title.
        /// </summary>
        /// <param name="title">The title text.</param>
        public void SetTitle(string title) 
        {
            SDL.SDL_SetWindowTitle(_sdlWindow, title);
        }

        /// <summary>
        ///   Sets the pixel width and height of the screen.
        /// </summary>
        /// <param name="width">The pixel width value.</param>
        /// <param name="height">The pixel height value.</param>
        public void SetSize(int width, int height) 
        {
            SDL.SDL_SetWindowSize(_sdlWindow, width, height);
        }

        /// <summary>
        ///   Sets the pixel position of the top left corner of the window, relative to the whole screen.
        /// </summary>
        /// <param name="xPos">The X pixel position.</param>
        /// <param name="yPos">The Y pixel position.</param>
        public void SetPosition(int xPos, int yPos) 
        {
            SDL.SDL_SetWindowPosition(_sdlWindow, xPos, yPos);
        }

        /// <summary>
        ///   Sets the window opacity.
        /// </summary>
        /// <param name="opacity">The opacity value. 0.0f = Transparent, 1.0f = opaque.</param>
        public void SetWindowOpacity(float opacity) 
        {
            SDL.SDL_SetWindowOpacity(_sdlWindow, opacity);
        }
        #endregion

        /// <summary>
        ///   Displays a simple message box with a single 'OK' button.
        /// </summary>
        /// <param name="title">The title text in the topbar of the message box.</param>
        /// <param name="message">The message text in the middle of the message box.</param>
        public void ShowMessageBox(string title, string message) 
        {
            SDL.SDL_ShowSimpleMessageBox(SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION, title, message, _sdlWindow);
        }
    }
}