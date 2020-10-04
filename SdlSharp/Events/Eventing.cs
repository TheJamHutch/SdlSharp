using System;
using System.Collections.Generic;
using SDL2;

namespace SdlSharp
{
    public static class Eventing
    {
        private static SDL.SDL_Event _event = new SDL.SDL_Event();

        private static Dictionary<KeyType, KeyPressAction> _keypressRegistry = new Dictionary<KeyType, KeyPressAction>();

        public static void OnKeypress(KeyType key, Action downAction, Action? upAction = null) 
        {
            _keypressRegistry[key] = new KeyPressAction(downAction, upAction);
        }

        public static int PollEvents()
        {
            while (SDL.SDL_PollEvent(out _event) != 0)
            {
                if (_event.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    return -1;
                }
                else if (_event.type == SDL.SDL_EventType.SDL_KEYDOWN)
                {
                    SDL.SDL_Keycode sdlKey = _event.key.keysym.sym;

                    if (sdlKey == SDL.SDL_Keycode.SDLK_ESCAPE)
                    {
                        return 0;
                    }
                    else
                    {
                        KeyType key = KeyTypeExtension.MapSdlKeycode(sdlKey);
                        if (_keypressRegistry.TryGetValue(key, out var toPerform))
                        {
                            toPerform.DownAction.Invoke();
                        }
                        else
                        {
                            Console.WriteLine("You must bind this key to an action in order to use it.");
                        }
                    }
                }
                else if (_event.type == SDL.SDL_EventType.SDL_KEYUP)
                {
                    SDL.SDL_Keycode sdlKey = _event.key.keysym.sym;

                    KeyType key = KeyTypeExtension.MapSdlKeycode(sdlKey);
                    if (_keypressRegistry.TryGetValue(key, out var toPerform))
                    {
                        toPerform.UpAction.Invoke();
                    }
                    else
                    {
                        Console.WriteLine("You must bind this key to an action in order to use it.");
                    }
                }
            }

            return 0;
        }
    }
}