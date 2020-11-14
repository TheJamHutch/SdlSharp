using System;
using SDL2;

namespace SdlSharpened
{
    public static class Eventing
    {
        // Not good.
        internal static KeyboardHandler KeyboardHandlerInstance;
        internal static MouseHandler MouseHandlerInstance;
        internal static GamepadHandler GamepadHandlerInstance;
        internal static JoystickHandler JoystickHandlerInstance;

        private static Action _quitAction;

        // The internal SDL_Event struct
        private static SDL.SDL_Event _sdlEvent = new SDL.SDL_Event();

        public static void OnQuit(Action quitAction)
        {
            _quitAction = quitAction;
        }

        /// <summary>
        ///   Call this in your main loop. Polls the internal SDL event queue, and invokes any actions bound to that event, 
        ///   until all events have been dealt with.
        /// </summary>
        public static void PollEvents()
        {
            while (SDL.SDL_PollEvent(out _sdlEvent) != 0)
            {
                if (_sdlEvent.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    _quitAction?.Invoke();
                }

                KeyboardHandlerInstance?.PollEvents(_sdlEvent);
                MouseHandlerInstance?.PollEvents(_sdlEvent);
                GamepadHandlerInstance?.PollEvents(_sdlEvent);
                JoystickHandlerInstance?.PollEvents(_sdlEvent);
            }
        }
    }
}