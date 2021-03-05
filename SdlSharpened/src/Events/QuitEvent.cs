using System;
using SDL2;

namespace SdlSharpened
{
    public class QuitEvent
    {
        public EventType Type { get { return EventType.Quit; } }
        public uint Timestamp { get { return _sdlQuitEvent.timestamp; } }

        // The internal SDL_Quit structure.
        private SDL.SDL_QuitEvent _sdlQuitEvent = new SDL.SDL_QuitEvent();
    }
}
