using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class representing a rectangle that can be used to clip and position rendered items.
    /// </summary>
    public class Rect
    {
        // Used by other classes to get the internal SDL_Rect
        internal SDL.SDL_Rect SdlRect { get { return _sdlRect; } }

        // The internal SDL_Rect
        private SDL.SDL_Rect _sdlRect;

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
        /// <param name="width">The pixel width of the Rect.</param>
        /// <param name="height">The pixel width of the Rect.</param>
        public Rect(int width, int height)
        {
            _sdlRect = new SDL.SDL_Rect() { x = 0, y = 0, w = width, h = height };
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

        public ref SDL.SDL_Rect Pointer()
        {
            return ref _sdlRect;
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

        /* NEEDS MOVING!
         * 
        /// <summary>
        ///   Calculates the minimum sized Rect needed to enclose a set of discrete points. 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public bool EnclosePoints(IEnumerable<Point> points) 
        {
            var sdlPoints = new List<SDL.SDL_Point>();

            foreach (var point in points)
            {
                sdlPoints.Add(point._sdlPoint);
            }

            SDL.SDL_EnclosePoints(sdlPoints.ToArray(), sdlPoints.Count, IntPtr.Zero, out var resultRect);

            return (result == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }*/
    }
}