using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Represents a rectangle that can be used to clip and position rendered items.
    /// </summary>
    public struct Rect
    {
        // Used by other classes to get the internal SDL_Rect
        internal SDL.SDL_Rect SdlRect { get { return _sdlRect; } }

        // The internal SDL_Rect
        private SDL.SDL_Rect _sdlRect;

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

        /// <summary>
        ///   Creates a Rect of specified position, width, and height.
        /// </summary>
        /// <param name="xpos">The pixel X postion of the Rect.</param>
        /// <param name="ypos">The pixel Y postion of the Rect.</param>
        /// <param name="width">The pixel width of the Rect.</param>
        /// <param name="height">The pixel height of the Rect.</param>
        public Rect(int xpos, int ypos, int width, int height)
        {
            _sdlRect = new SDL.SDL_Rect() { x = xpos, y = ypos, w = width, h = height };
        }

        public Rect(Rect rect)
        {
            _sdlRect = new SDL.SDL_Rect() { x = rect.X, y = rect.Y, w = rect.W, h = rect.H };
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
            var result = SDL.SDL_RectEmpty(ref _sdlRect);

            return (result == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        /// <summary>
        ///   Checks if the Rect has the exact same values as another Rect.
        /// </summary>
        /// <param name="rect">The Rect object.</param>
        /// <param name="otherRect">The other Rect.</param>
        /// <returns>True if both Rects are equal.</returns>
        public bool IsEqualTo(Rect otherRect)
        {
            var result = SDL.SDL_RectEquals(ref _sdlRect, ref otherRect._sdlRect);

            return (result == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        /// <summary>
        ///   Checks if the Rect intersects with another Rect.
        /// </summary>
        /// <param name="rect">The Rect object.</param>
        /// <param name="otherRect">The other Rect.</param>
        /// <returns>True if both Rects are equal.</returns>
        public bool IntersectsWith(Rect otherRect)
        {
            // Ignore resultRect
            var result = SDL.SDL_IntersectRect(ref _sdlRect, ref otherRect._sdlRect, out var resultRect);

            return (result == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public override string ToString()
        {
            return $"X: {_sdlRect.x}, Y: {_sdlRect.y}, W: {_sdlRect.w}, H: {_sdlRect.h}";
        }
    }
}