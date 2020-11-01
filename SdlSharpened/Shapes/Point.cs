﻿using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   Class represents a two-dimensional point in space.
    /// </summary>
    public class Point
    {
        internal SDL.SDL_Point SdlPoint { get { return _sdlPoint; } }

        private SDL.SDL_Point _sdlPoint;

        /// <summary>
        ///   Creates a default point with x and y values of zero.
        /// </summary>
        public Point()
        {
            _sdlPoint = new SDL.SDL_Point() { x = 0, y = 0 };
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
    }
}
