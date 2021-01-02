using System;
using SDL2;

// TODO: union

namespace SdlSharpened
{
    /// <summary>
    ///   A class that contains objects for the different event types.
    /// </summary>
    public class Event
    {
        public EventType Type { get { return (EventType)_sdlEvent.type; } }

        public Keycode Keycode { get { return KeycodeEx.FromSdl(_sdlEvent.key.keysym.sym); } }

        // The internal SDL_Event structure.
        private SDL.SDL_Event _sdlEvent = new SDL.SDL_Event();

        public int Poll()
        {
            return SDL.SDL_PollEvent(out _sdlEvent);
        }

        /// <summary>
        ///   Use this function to check for the existence of certain event types in the event queue.
        /// </summary>
        /// <remarks>
        ///   If you need to check for a range of event types, use HasEvents() instead.
        /// </remarks>
        /// <param name="eventType">The type of event to be queried.</param>
        /// <returns>
        ///   Returns true if events matching type are present, or false if events matching type are not present.
        /// </returns>
        public bool HasEvent(EventType eventType) 
        {
            return (SDL.SDL_HasEvent((SDL.SDL_EventType)eventType) == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        /// <summary>
        ///   Use this function to check for the existence of a range of event types in the event queue.
        /// </summary>
        /// <remarks>
        ///   If you need to check for a single event type, you can use HasEvent() instead.
        /// </remarks>
        /// <param name="minEventType">The minimum type of event to be queried.</param>
        /// <param name="maxEventType">The maximum type of event to be queried.</param>
        /// <returns>
        ///   Returns true if events with types in the range between minEventType and maxEventType are present, or false if not.
        /// </returns>
        public bool HasEvents(EventType minEventType, EventType maxEventType)
        {
            return (SDL.SDL_HasEvents((SDL.SDL_EventType)minEventType, (SDL.SDL_EventType)maxEventType) == SDL.SDL_bool.SDL_TRUE) ? true : false;
        }

        /// <summary>
        ///   Use this function to clear events of a particular type from the event queue.
        /// </summary>
        /// <param name="eventType">The type of event to be cleared.</param>
        public void FlushEvent(EventType eventType) 
        {
            SDL.SDL_FlushEvent((SDL.SDL_EventType)eventType);
        }

        /// <summary>
        ///   Use this function to clear a range of events from the event queue.
        /// </summary>
        /// <param name="minEventType">The minimum event type to be cleared.</param>
        /// <param name="maxEventType">The maximum event type to be cleared.</param>
        public void FlushEvents(EventType minEventType, EventType maxEventType)
        {
            SDL.SDL_FlushEvents((SDL.SDL_EventType)minEventType, (SDL.SDL_EventType)maxEventType);
        }
    }
}
