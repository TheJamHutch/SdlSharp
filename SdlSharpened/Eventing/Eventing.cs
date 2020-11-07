using SDL2;

namespace SdlSharpened
{
    public static class Eventing
    {
        internal static KeyboardHandler KeyboardHandlerInstance;

        // The internal SDL_Event struct
        private static SDL.SDL_Event _sdlEvent = new SDL.SDL_Event();

        public static int PollEvents() 
        {
            while (SDL.SDL_PollEvent(out _sdlEvent) != 0)
            {
                if (_sdlEvent.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    return -1;
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
                /*
                else if (_sdlEvent.type == SDL.SDL_EventType.SDL_MOUSEMOTION)
                {
                    _mouseEventHandlerMove?.Invoke(_sdlEvent.button.x, _sdlEvent.button.y);
                }
                else if (_event.type == SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN)
                {
                    MouseAction.ButtonDown?.Invoke(_sdlEvent.button.x, _sdlEvent.button.y);
                }
                else if (_event.type == SDL.SDL_EventType.SDL_MOUSEBUTTONUP)
                {
                    MouseAction.ButtonUp?.Invoke(_sdlEvent.button.x, _sdlEvent.button.y);
                }*/
            }

            return 0;
        }
    }
}
