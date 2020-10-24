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
        ///    A pointer to the internal SDL window.
        /// </summary>
        public IntPtr Pointer { get; }

        /// <summary>
        ///   Creates a window of a given pixel width and height and sets the title.
        /// </summary>
        /// <param name="title">The title text at the top of the window.</param>
        /// <param name="width">The pixel width of the window.</param>
        /// <param name="height">The pixel height of the window.</param>
        public Window(string title, int width, int height)
        {
            Pointer = SDL.SDL_CreateWindow(title, 100, 100, width, height, 0);
            SdlSystem.WindowPointer = Pointer;
        }

        ~Window()
        {
            SDL.SDL_DestroyWindow(Pointer);
        }

        /// <summary>
        ///   Minimize the window.
        /// </summary>
        public void Minimize() 
        {
            SDL.SDL_MinimizeWindow(Pointer);
        }

        /// <summary>
        ///   Maximize the window.
        /// </summary>
        public void Maximize() 
        {
            SDL.SDL_MaximizeWindow(Pointer);
        }

        #region Getters

        /// <summary>
        ///   Gets the window opacity.
        /// </summary>
        /// <returns>The window opacity value.</returns>
        public float GetOpacity() 
        {
            SDL.SDL_GetWindowOpacity(Pointer, out var opacity);
            return opacity;
        }

        /// <summary>
        ///   Gets the current window title text.
        /// </summary>
        /// <returns>The window title text.</returns>
        public string GetWindowTitle() 
        {
            return SDL.SDL_GetWindowTitle(Pointer);
        }

        /// <summary>
        ///   Gets the current pixel position of the window, relative to the whole screen.
        /// </summary>
        /// <param name="xPos">The X pixel position value.</param>
        /// <param name="yPos">The Y pixel position value.</param>
        public void GetPosition(out int xPos, out int yPos)
        {
            SDL.SDL_GetWindowPosition(Pointer, out xPos, out yPos);
        }

        /// <summary>
        ///   Gets the pixel width and height of the window.
        /// </summary>
        /// <param name="width">The pixel width value.</param>
        /// <param name="height">The pixel height value.</param>
        public void GetSize(out int width, out int height)
        {
            SDL.SDL_GetWindowSize(Pointer, out width, out height);
        }
        #endregion

        #region Setters

        /// <summary>
        ///   Sets the window title.
        /// </summary>
        /// <param name="title">The title text.</param>
        public void SetTitle(string title) 
        {
            SDL.SDL_SetWindowTitle(Pointer, title);
        }

        /// <summary>
        ///   Sets the pixel width and height of the screen.
        /// </summary>
        /// <param name="width">The pixel width value.</param>
        /// <param name="height">The pixel height value.</param>
        public void SetSize(int width, int height) 
        {
            SDL.SDL_SetWindowSize(Pointer, width, height);
        }

        /// <summary>
        ///   Sets the pixel position of the top left corner of the window, relative to the whole screen.
        /// </summary>
        /// <param name="xPos">The X pixel position.</param>
        /// <param name="yPos">The Y pixel position.</param>
        public void SetPosition(int xPos, int yPos) 
        {
            SDL.SDL_SetWindowPosition(Pointer, xPos, yPos);
        }

        /// <summary>
        ///   Sets the window opacity.
        /// </summary>
        /// <param name="opacity">The opacity value. 0.0f = Transparent, 1.0f = opaque.</param>
        public void SetWindowOpacity(float opacity) 
        {
            SDL.SDL_SetWindowOpacity(Pointer, opacity);
        }
        #endregion

        /// <summary>
        ///   Displays a simple message box with a single 'OK' button.
        /// </summary>
        /// <param name="title">The title text in the topbar of the message box.</param>
        /// <param name="message">The message text in the middle of the message box.</param>
        public void ShowMessageBox(string title, string message) 
        {
            SDL.SDL_ShowSimpleMessageBox(SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION, title, message, Pointer);
        }
    }
}