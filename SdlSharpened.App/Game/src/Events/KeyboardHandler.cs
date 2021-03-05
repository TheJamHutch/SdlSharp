using System;
using System.Collections.Generic;
using SDL2;

namespace SdlSharpened.App
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



        public void OnKeypress(Keycode key, Action downAction, Action upAction = null)
        {
            _keypressRegistry[key] = new PressAction(downAction, upAction);
        }

        public void OnKeypress(Keycode key, PressAction pressAction)
        {
            _keypressRegistry[key] = pressAction;
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
