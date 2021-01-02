using System;
using System.Collections.Generic;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   This class is responsible for handling keyboard input.
    /// </summary>
    public class KeyboardHandler
    {
        private Dictionary<Keycode, PressAction> _keypressRegistry;

        public KeyboardHandler()
        {
            _keypressRegistry = new Dictionary<Keycode, PressAction>();
        }

        /// <summary>
        ///   Registers the action to invoke when a keyboard key press event occurs, and optionally a key up event, to the event handler.
        /// </summary>
        /// <param name="key">A KeyType enum value representing the key that was pressed.</param>
        /// <param name="downAction">The action to invoke when a key down event occurs.</param>
        /// <param name="upAction">The action to invoke when a key up event occurs.</param>
        public void OnKeypress(Keycode key, PressAction pressAction)
        {
            _keypressRegistry[key] = new PressAction(pressAction.DownAction, pressAction.UpAction);
        }

        public void BindKeypressActions(IEnumerable<KeyValuePair<Keycode, PressAction>> keypressActions) 
        {
            foreach (var keyAct in keypressActions)
            {
                _keypressRegistry.Add(keyAct.Key, keyAct.Value);
            }
        }

        public void PollEvents(Event pollEvent) 
        {
            if (pollEvent.Type == EventType.KeyDown)
            {
                if (_keypressRegistry.TryGetValue(pollEvent.Keycode, out var keypressAction))
                {
                    keypressAction.DownAction?.Invoke();
                }
            }
            else if (pollEvent.Type == EventType.KeyUp)
            {
                if (_keypressRegistry.TryGetValue(pollEvent.Keycode, out var keypressAction))
                {
                    keypressAction.UpAction?.Invoke();
                }
            }
        }
    }
}
