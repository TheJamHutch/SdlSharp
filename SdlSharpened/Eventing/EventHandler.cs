using SDL2;

namespace SdlSharpened
{
    public class EventHandler
    {
        public KeyboardEventHandler KeyboardEvents { get { return _keyboardEventHandler; } }

        public MouseEventHandler MouseEvents { get { return _mouseEventHandler; } }

        private KeyboardEventHandler _keyboardEventHandler;

        private MouseEventHandler _mouseEventHandler;

        // The internal SDL_Event struct
        private SDL.SDL_Event _sdlEvent;

        public EventHandler()
        {
            _keyboardEventHandler = new KeyboardEventHandler();
            _mouseEventHandler = new MouseEventHandler();
            _sdlEvent = new SDL.SDL_Event();
        }

        public int PollEvents() 
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
                    _keyboardEventHandler.InvokeKeyDownAction(key);
                }
                else if (_sdlEvent.type == SDL.SDL_EventType.SDL_KEYUP)
                {
                    // Get the key type from SDL, convert it to a KeyType enum value and pass to keyboard
                    // handler to invoke.
                    SDL.SDL_Keycode sdlKey = _sdlEvent.key.keysym.sym;
                    KeyType key = KeyTypeExtension.MapSdlKeycode(sdlKey);
                    _keyboardEventHandler.InvokeKeyUpAction(key);
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
