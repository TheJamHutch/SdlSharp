/*  TODO: IntPtr to SDL_Rect
 */
using System;
using System.Runtime.InteropServices;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   A structure that contains the definition of a rectangle, with the origin at the upper left.
    /// </summary>
    public class Rect
    {
        // The internal SDL_Rect struct.
        private SDL.SDL_Rect _sdlRect;

        /// <summary>
        ///   Creates a new Rect of specified position, width, and height.
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
        ///   Creates a new Rect with the same position and size as another Rect.
        /// </summary>
        /// <param name="xpos">The pixel X postion of the Rect.</param>
        /// <param name="ypos">The pixel Y postion of the Rect.</param>
        /// <param name="width">The pixel width of the Rect.</param>
        /// <param name="height">The pixel height of the Rect.</param>
        public Rect(Rect rect)
        {
            _sdlRect = new SDL.SDL_Rect() { x = rect.X, y = rect.Y, w = rect.W, h = rect.H };
        }

        /// <summary>
        ///   Returns a new instance of <see cref="Rect"/> with all properties initialised to zero.
        /// </summary>
        public static Rect Zero { get { return new Rect(0, 0, 0, 0); } }

        /// <summary>
        ///   SDL's internal SDL_Rect struct.
        /// </summary>
        public SDL.SDL_Rect SdlRect { get { return _sdlRect; } }

        /// <summary>
        ///   The X location of the rectangle's upper left corner.
        /// </summary>
        public int X
        {
            get { return _sdlRect.x; }
            set { _sdlRect.x = value; }
        }

        /// <summary>
        ///   The Y location of the rectangle's upper left corner.
        /// </summary>
        public int Y
        {
            get { return _sdlRect.y; }
            set { _sdlRect.y = value; }
        }

        /// <summary>
        ///   The width of the Rect.
        /// </summary>
        public int W
        {
            get { return _sdlRect.w; }
            set { _sdlRect.w = value; }
        }

        /// <summary>
        ///   The height of the Rect.
        /// </summary>
        public int H
        {
            get { return _sdlRect.h; }
            set { _sdlRect.h = value; }
        }

        /// <summary>
        ///   Checks if the Rect has no area. A Rect has no area if its width and height are both zero.
        /// </summary>
        /// <returns>True if the Rect is empty.</returns>
        public bool Empty()
        {
            var result = SDL.SDL_RectEmpty(ref _sdlRect);

            return (result == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        /// <summary>
        ///   Use this function to check whether two Rects are equal.
        /// </summary>
        /// <param name="otherRect">The other Rect.</param>
        /// <returns>True if both Rects are equal.</returns>
        public bool Equals(Rect otherRect)
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
        public bool Intersect(Rect otherRect, out Rect resultRect)
        {
            var sdlBool = SDL.SDL_IntersectRect(ref _sdlRect, ref otherRect._sdlRect, out var sdlRect);

            resultRect = new Rect(sdlRect.x, sdlRect.y, sdlRect.w, sdlRect.h);

            return (sdlBool == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        /// <summary>
        ///   Use this function to determine whether two rectangles intersect.
        /// </summary>
        /// <param name="otherRect">The other Rect.</param>
        /// <returns>
        ///   Returns true if there is an intersection, false otherwise.
        /// </returns>
        public bool HasIntersection(Rect otherRect) 
        {
            var otherCopy = otherRect.SdlRect;
            var sdlBool = SDL.SDL_HasIntersection(ref _sdlRect, ref otherCopy);

            return (sdlBool == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        /// <summary>
        ///   Use this function to calculate the intersection of a Rect and line segment.
        /// </summary>
        /// <param name="x1">Starting X-coordinate of the line.</param>
        /// <param name="y1">Starting Y-coordinate of the line.</param>
        /// <param name="x2">Ending X-coordinate of the line.</param>
        /// <param name="y2">Ending Y-coordinate of the line.</param>
        /// <returns>Returns true if there is an intersection, false otherwise.</returns>
        public bool LineIntersect(int x1, int y1, int x2, int y2) 
        {
            var sdlBool = SDL.SDL_IntersectRectAndLine(ref _sdlRect, ref x1, ref y1, ref x2, ref y2);

            return (sdlBool == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        /// <summary>
        ///   Use this function to calculate the union of this Rect and another Rect.
        /// </summary>
        /// <param name="otherRect">The other Rect.</param>
        /// <param name="resultRect">The result Rect.</param>
        public void Union(Rect otherRect, out Rect resultRect) 
        {
            var otherCopy = otherRect.SdlRect;
            SDL.SDL_UnionRect(ref _sdlRect, ref otherCopy, out var sdlResultRect);

            resultRect = new Rect(sdlResultRect.x, sdlResultRect.y, sdlResultRect.w, sdlResultRect.h);
        }

        /// <summary>
        ///   Use this function to calculate a minimal rectangle enclosing a set of points.
        /// </summary>
        /// <remarks>
        ///   If clip is not null then only points inside of the clipping rectangle are considered.
        /// </remarks>
        /// <param name="points">An array of Point structs representing points to be .</param>
        /// <param name="clipRect">A Rect struct used for clipping or null to enclose all Points.</param>
        /// <param name="resultRect">A Rect struct filled in with the minimal enclosing Rect.</param>
        /// <returns>
        ///   True if any points were enclosed or false if all the points were outside of the clipping Rect.
        /// </returns>
        public static bool EnclosePoints(Point[] points, Rect clipRect, Rect resultRect) 
        {
            // Convert Point array to SDL_Point array
            SDL.SDL_Point[] sdlPoints = new SDL.SDL_Point[points.Length];

            var clipCopy = clipRect.SdlRect;
            var sdlBool = SDL.SDL_EnclosePoints(sdlPoints, sdlPoints.Length, ref clipCopy, out var sdlResultRect);

            return (sdlBool == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public override string ToString()
        {
            return $"{_sdlRect.x},{_sdlRect.y},{_sdlRect.w},{_sdlRect.h}";
        }
    }
}