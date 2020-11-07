using System;
using System.Collections.Generic;

namespace SdlSharpened
{
    public class KeyboardHandler : IHandler
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

        internal void InvokeKeyDownAction(KeyType keyType) 
        {
            bool gotVal = _keypressRegistry.TryGetValue(keyType, out var keyboardAction);

            if (gotVal)
            {
                keyboardAction.DownAction?.Invoke();
            }
        }

        internal void InvokeKeyUpAction(KeyType keyType)
        {
            bool gotVal = _keypressRegistry.TryGetValue(keyType, out var keyboardAction);

            if (gotVal)
            {
                keyboardAction.UpAction?.Invoke();
            }
        }
    }
}
