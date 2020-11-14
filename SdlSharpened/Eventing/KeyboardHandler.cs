﻿using System;
using System.Collections.Generic;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   This class is responsible for handling keyboard input.
    /// </summary>
    public class KeyboardHandler : Handler
    {
        private Dictionary<KeyType, KeyboardAction> _keypressRegistry;

        public KeyboardHandler()
        {
            _keypressRegistry = new Dictionary<KeyType, KeyboardAction>();
            Eventing.KeyboardHandlerInstance = this;
        }

        /// <summary>
        ///   Registers the action to invoke when a keyboard key press event occurs, and optionally a key up event, to the event handler.
        /// </summary>
        /// <param name="key">A KeyType enum value representing the key that was pressed.</param>
        /// <param name="downAction">The action to invoke when a key down event occurs.</param>
        /// <param name="upAction">The action to invoke when a key up event occurs.</param>
        public void OnKeypress(KeyType key, Action downAction, Action upAction = null)
        {
            _keypressRegistry[key] = new KeyboardAction(downAction, upAction);
        }

        internal override void PollEvents(SDL.SDL_Event sdlEvent) 
        {
            if (sdlEvent.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                var sdlKey = sdlEvent.key.keysym.sym;
                var key = KeyTypeExtension.MapSdlKeycode(sdlKey);

                if (_keypressRegistry.TryGetValue(key, out var action))
                {
                    action.DownAction?.Invoke();
                }
            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_KEYUP)
            {
                var sdlKey = sdlEvent.key.keysym.sym;
                var key = KeyTypeExtension.MapSdlKeycode(sdlKey);

                if (_keypressRegistry.TryGetValue(key, out var action))
                {
                    action.UpAction?.Invoke();
                }
            }
        }
    }
}
