using System;
using SDL2;

namespace SdlSharpened
{
    public struct Point
    {
        internal SDL.SDL_Point SdlPoint { get { return _sdlPoint; } }

        private SDL.SDL_Point _sdlPoint;

        public int X
        {
            get { return _sdlPoint.x; }
            set { _sdlPoint.x = value; }
        }

        public int Y
        {
            get { return _sdlPoint.y; }
            set { _sdlPoint.y = value; }
        }

        public Point(int pointX, int pointY)
        {
            _sdlPoint = new SDL.SDL_Point() { x = pointX, y = pointY };
        }

        public Point(Point point)
        {
            _sdlPoint = new SDL.SDL_Point() { x = point.X, y = point.Y };
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
