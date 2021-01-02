using System;
using SdlSharpened;

namespace SdlSharpened
{
    public class EventHandler
    {
        public KeyboardHandler Keyboard { get { return _keyboardHandler; } }

        private Event _event;
        private KeyboardHandler _keyboardHandler;
        private MouseHandler _mouseHandler;
        private GamepadHandler _gamepadHandler;

        public EventHandler()
        {
            _event = new Event();
            _keyboardHandler = new KeyboardHandler();
        }
        
        public void PollEvents()
        {
            while (_event.Poll() != 0)
            {
                _keyboardHandler?.PollEvents(_event);
                _mouseHandler?.PollEvents(_event);
                _gamepadHandler?.PollEvents(_event);
            }
        }
    }
}