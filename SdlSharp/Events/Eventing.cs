using System;
using System.Collections.Generic;
using SDL2;

namespace SdlSharp
{
    public static class Eventing
    {
        /// <summary>
        ///   Enum representing the range of possible event types.
        /// </summary>
        public enum EventType
        {
            Quit = 0,
            Other
        }

        /// <summary>
        ///   SDL's internal SDL_Event structure.
        /// </summary>
        private static SDL.SDL_Event _event = new SDL.SDL_Event();

        /// <summary>
        ///   The keypress registry, which associates a particular key code with an action to be performed.
        /// </summary>
        private static Dictionary<KeyType, Action> _keypressRegistry = new Dictionary<KeyType, Action>();

        /// <summary>
        ///   Binds a particular action to a key. Whenever the key is pressed, the action will be executed.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        public static void RegisterKeypressAction(KeyType key, Action action) 
        {
            _keypressRegistry[key] = action;
        }

        /// <summary>
        ///   Polls the SDL event queue.
        /// </summary>
        /// <returns>
        ///   Returns the type of event that was taken off the queue.
        /// </returns>
        public static EventType PollEvents()
        {
            while (SDL.SDL_PollEvent(out _event) != 0)
            {
                if (_event.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    return EventType.Quit;
                }
                else if (_event.type == SDL.SDL_EventType.SDL_KEYDOWN)
                {
                    SDL.SDL_Keycode sdlKey = _event.key.keysym.sym;

                    if (sdlKey == SDL.SDL_Keycode.SDLK_ESCAPE)
                    {
                        return EventType.Quit;
                    }
                    else 
                    {
                        KeyType key = KeyTypeExtension.MapSdlKeycode(sdlKey);

                        Action toPerform = _keypressRegistry[key];
                        toPerform.Invoke();
                    }
                }
            }

            return EventType.Other;
        }
    }
}