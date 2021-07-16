using System;
using System.Runtime.InteropServices;
using SDL2;

namespace SdlSharpened
{
    public struct Rect
    {
        // The internal SDL_Rect struct.
        private SDL.SDL_Rect _sdlRect;

        public Rect(int xpos, int ypos, int width, int height)
        {
            _sdlRect = new SDL.SDL_Rect() { x = xpos, y = ypos, w = width, h = height };
        }

        public Rect(Rect rect)
        {
            _sdlRect = new SDL.SDL_Rect() { x = rect.X, y = rect.Y, w = rect.W, h = rect.H };
        }

        public static Rect Zero { get { return new Rect(0, 0, 0, 0); } }

        public SDL.SDL_Rect SdlRect { get { return _sdlRect; } }

        public int X
        {
            get { return _sdlRect.x; }
            set { _sdlRect.x = value; }
        }

        public int Y
        {
            get { return _sdlRect.y; }
            set { _sdlRect.y = value; }
        }

        public int W
        {
            get { return _sdlRect.w; }
            set { _sdlRect.w = value; }
        }

        public int H
        {
            get { return _sdlRect.h; }
            set { _sdlRect.h = value; }
        }

        public bool Empty()
        {
            var result = SDL.SDL_RectEmpty(ref _sdlRect);

            return (result == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public bool Equals(Rect otherRect)
        {
            var result = SDL.SDL_RectEquals(ref _sdlRect, ref otherRect._sdlRect);

            return (result == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public bool Intersect(Rect otherRect, out Rect resultRect)
        {
            var sdlBool = SDL.SDL_IntersectRect(ref _sdlRect, ref otherRect._sdlRect, out var sdlRect);

            resultRect = new Rect(sdlRect.x, sdlRect.y, sdlRect.w, sdlRect.h);

            return (sdlBool == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public bool HasIntersection(Rect otherRect) 
        {
            var otherCopy = otherRect.SdlRect;
            var sdlBool = SDL.SDL_HasIntersection(ref _sdlRect, ref otherCopy);

            return (sdlBool == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public bool LineIntersect(int x1, int y1, int x2, int y2) 
        {
            var sdlBool = SDL.SDL_IntersectRectAndLine(ref _sdlRect, ref x1, ref y1, ref x2, ref y2);

            return (sdlBool == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public void Union(Rect otherRect, out Rect resultRect) 
        {
            var otherCopy = otherRect.SdlRect;
            SDL.SDL_UnionRect(ref _sdlRect, ref otherCopy, out var sdlResultRect);

            resultRect = new Rect(sdlResultRect.x, sdlResultRect.y, sdlResultRect.w, sdlResultRect.h);
        }

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