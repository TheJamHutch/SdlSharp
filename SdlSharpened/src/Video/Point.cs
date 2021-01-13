using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Represents a two-dimensional point in space.
    /// </summary>
    public struct Point
    {
        internal SDL.SDL_Point SdlPoint { get { return _sdlPoint; } }

        private SDL.SDL_Point _sdlPoint;

        /// <summary>
        ///   The X position of the Point.
        /// </summary>
        public int X
        {
            get { return _sdlPoint.x; }
            set { _sdlPoint.x = value; }
        }

        /// <summary>
        ///   The Y position of the Point.
        /// </summary>
        public int Y
        {
            get { return _sdlPoint.y; }
            set { _sdlPoint.y = value; }
        }

        /// <summary>
        ///   Creates a point with the specified X and Y values.
        /// </summary>
        /// <param name="pointX">The X value of the point.</param>
        /// <param name="pointY">The Y value of the point.</param>
        public Point(int pointX, int pointY)
        {
            _sdlPoint = new SDL.SDL_Point() { x = pointX, y = pointY };
        }

        public override string ToString()
        {
            return $"X: {_sdlPoint.x}, Y: {_sdlPoint.y}";
        }

        public static Point Distance(Point src, Point dst)
        {
            return new Point(dst.X - src.X, dst.Y - src.Y);
        }
    }
}
