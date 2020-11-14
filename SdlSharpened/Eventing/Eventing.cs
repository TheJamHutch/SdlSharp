using System;
using SDL2;

namespace SdlSharpened
{
    public static class Eventing
    {
        //
        internal static KeyboardHandler KeyboardHandlerInstance;
        //
        internal static MouseHandler MouseHandlerInstance;
        //
        internal static GamepadHandler GamepadHandlerInstance;

        private static Action _quitAction = () => { };

        // The internal SDL_Event struct
        private static SDL.SDL_Event _sdlEvent = new SDL.SDL_Event();

        public static void OnQuit(Action quitAction)
        {
            _quitAction = quitAction;
        }

        public static void PollEvents()
        {
            while (SDL.SDL_PollEvent(out _sdlEvent) != 0)
            {
                if (_sdlEvent.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    _quitAction?.Invoke();
                }
                else if (_sdlEvent.type == SDL.SDL_EventType.SDL_KEYDOWN)
                {
                    // Get the key type from SDL, convert it to a KeyType enum value and pass to keyboard
                    // handler to invoke.
                    SDL.SDL_Keycode sdlKey = _sdlEvent.key.keysym.sym;
                    KeyType key = KeyTypeExtension.MapSdlKeycode(sdlKey);
                    KeyboardHandlerInstance.InvokeKeyDownAction(key);
                }
                else if (_sdlEvent.type == SDL.SDL_EventType.SDL_KEYUP)
                {
                    // Get the key type from SDL, convert it to a KeyType enum value and pass to keyboard
                    // handler to invoke.
                    SDL.SDL_Keycode sdlKey = _sdlEvent.key.keysym.sym;
                    KeyType key = KeyTypeExtension.MapSdlKeycode(sdlKey);
                    KeyboardHandlerInstance.InvokeKeyUpAction(key);
                }
                else if (_sdlEvent.type == SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN)
                {
                    MouseHandlerInstance.InvokeButtonDownAction(_sdlEvent.button.x, _sdlEvent.button.y);
                }
                else if (_sdlEvent.type == SDL.SDL_EventType.SDL_MOUSEBUTTONUP)
                {
                    MouseHandlerInstance.InvokeButtonUpAction(_sdlEvent.button.x, _sdlEvent.button.y);
                }
                else if (_sdlEvent.type == SDL.SDL_EventType.SDL_MOUSEMOTION)
                {
                    MouseHandlerInstance.InvokeMoveAction(_sdlEvent.button.x, _sdlEvent.button.y);
                }
            }
        }
    }
}