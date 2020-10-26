using SDL2;

namespace SdlSharpened
{
    public class Blitting
    {
        public static void BlitSurface(Surface src, Surface dst, Rect srcRect, Rect dstRect) 
        {
            var sdlSrc = srcRect.SdlRect;
            var sdlDst = dstRect.SdlRect;

            SDL.SDL_BlitSurface(src.Pointer, ref sdlSrc, dst.Pointer, ref sdlDst);
        }

        public static void BlitScaled(Surface src, Surface dst, Rect srcRect, Rect dstRect)
        {
            var sdlSrc = srcRect.SdlRect;
            var sdlDst = dstRect.SdlRect;

            SDL.SDL_BlitScaled(src.Pointer, ref sdlSrc, dst.Pointer, ref sdlDst);
        }
    }
}