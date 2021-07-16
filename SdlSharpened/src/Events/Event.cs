using System;
using SDL2;

namespace SdlSharpened
{
    public class Event
    {
        private MouseMotionEvent _motion;
        private MouseButtonEvent _button;
        private MouseWheelEvent _wheel;

        private static SDL.SDL_Event _sdlEvent = new SDL.SDL_Event();

        public Event()
        {
            _motion = new MouseMotionEvent();  
            _button = new MouseButtonEvent();
            _wheel = new MouseWheelEvent();
        }

        public EventType Type { get { return (EventType)_sdlEvent.type; } }
        public Keycode Keycode { get { return KeycodeEx.FromSdl(_sdlEvent.key.keysym.sym); } }

        public MouseButtonEvent Button { get { return _button; } }
        public MouseMotionEvent Motion { get { return _motion; } }

        internal static SDL.SDL_Event SdlEvent { get { return _sdlEvent; } }


        public int Poll()
        {
            return SDL.SDL_PollEvent(out _sdlEvent);
        }

        public bool HasEvent(EventType eventType) 
        {
            return (SDL.SDL_HasEvent((SDL.SDL_EventType)eventType) == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public bool HasEvents(EventType minEventType, EventType maxEventType)
        {
            return (SDL.SDL_HasEvents((SDL.SDL_EventType)minEventType, (SDL.SDL_EventType)maxEventType) == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        public void FlushEvent(EventType eventType) 
        {
            SDL.SDL_FlushEvent((SDL.SDL_EventType)eventType);
        }

        public void FlushEvents(EventType minEventType, EventType maxEventType)
        {
            SDL.SDL_FlushEvents((SDL.SDL_EventType)minEventType, (SDL.SDL_EventType)maxEventType);
        }
    }
}
