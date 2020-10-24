using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class representing a rectangle that can be used to clip and position rendered items.
    /// </summary>
    public class Rect
    {
        /// <summary>
        ///   The X position of the Rect.
        /// </summary>
        public int X
        {
            get { return _sdlRect.x; }
            set { _sdlRect.x = value; }
        }

        /// <summary>
        ///   The Y position of the Rect.
        /// </summary>
        public int Y
        {
            get { return _sdlRect.y; }
            set { _sdlRect.y = value; }
        }

        /// <summary>
        ///   The pixel width of the Rect.
        /// </summary>
        public int W
        {
            get { return _sdlRect.w; }
            set { _sdlRect.w = value; }
        }

        /// <summary>
        ///   The pixel height of the Rect.
        /// </summary>
        public int H
        {
            get { return _sdlRect.h; }
            set { _sdlRect.h = value; }
        }

        // The internal SDL_Rect struct
        internal SDL.SDL_Rect _sdlRect;

        /// <summary>
        ///   Creates a default, non-empty Rect with a positon of (0, 0) and a width and height of one.
        /// </summary>
        public Rect()
        {
            _sdlRect = new SDL.SDL_Rect() { x = 0, y = 0, w = 1, h = 1 };
        }

        /// <summary>
        ///   Creates a Rect of a specified width and height at the default position (0, 0). 
        /// </summary>
        /// <param name="w">The pixel width of the Rect.</param>
        /// <param name="h">The pixel width of the Rect.</param>
        public Rect(int w, int h)
        {
            _sdlRect = new SDL.SDL_Rect() { x = 0, y = 0, w = w, h = h };
        }

        /// <summary>
        ///   Creates a Rect of specifified position, width, and height.
        /// </summary>
        /// <param name="x">The pixel X postion of the Rect.</param>
        /// <param name="y">The pixel Y postion of the Rect.</param>
        /// <param name="w">The pixel width of the Rect.</param>
        /// <param name="h">The pixel height of the Rect.</param>
        public Rect(int x, int y, int w, int h)
        {
            _sdlRect = new SDL.SDL_Rect() { x = x, y = y, w = w, h = h };
        }

        /// <summary>
        ///   Swaps the width and height values of the Rect.
        /// </summary>
        public void Rotate()
        {
            int w = _sdlRect.w;
            _sdlRect.w = _sdlRect.h;
            _sdlRect.h = w;
        }

        /// <summary>
        ///   Checks if the Rect has no area. A Rect has no area if its width and height are both zero.
        /// </summary>
        /// <returns>True if the Rect is empty.</returns>
        public bool IsEmpty()
        {
            var empty = SDL.SDL_RectEmpty(ref rect._sdlRect);

            return (empty == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        /// <summary>
        ///   Checks if the Rect has the exact same values as another Rect.
        /// </summary>
        /// <param name="rect">The Rect object.</param>
        /// <param name="otherRect">The other Rect.</param>
        /// <returns>True if both Rects are equal.</returns>
        public static bool IsEqualTo(this Rect rect, Rect otherRect)
        {
            var equal = SDL.SDL_RectEquals(ref rect._sdlRect, ref otherRect._sdlRect);

            return (equal == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        internal SDL.SDL_Rect Pointer()
        {
            return _sdlRect;
        }
    }
}