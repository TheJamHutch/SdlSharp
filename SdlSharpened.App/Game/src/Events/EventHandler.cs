using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class EventHandler
    {
        private Event _event;
        private KeyboardHandler _keyboardHandler;
        private MouseHandler _mouseHandler;
        private GamepadHandler _gamepadHandler;

        public EventHandler()
        {
            _event = new Event();
            _keyboardHandler = new KeyboardHandler();
            _mouseHandler = new MouseHandler();
        }

        public KeyboardHandler Keyboard { get { return _keyboardHandler; } }

        public MouseHandler Mouse { get { return _mouseHandler; } }

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