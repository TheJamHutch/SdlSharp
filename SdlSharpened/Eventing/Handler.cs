using SDL2;

namespace SdlSharpened
{
    public abstract class Handler
    {
        internal abstract void PollEvents(SDL.SDL_Event sdlEvent);
    }
}