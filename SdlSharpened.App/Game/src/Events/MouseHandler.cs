using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class MouseHandler
    {
        private Action<int, int> _buttonDownAction;
        private Action<int, int> _buttonUpAction;
        private Action<int, int> _motionAction;

        public MouseHandler()
        {

        }

        public void OnButtonDown(Action<int, int> action)
        {
            _buttonDownAction = action;
        }

        public void OnButtonUp(Action<int, int> action)
        {
            _buttonUpAction = action;
        }

        public void OnMotion(Action<int, int> action)
        {
            _motionAction = action;
        }

        public void PollEvents(Event pollEvent) 
        {
            if (pollEvent.Type == EventType.MouseButtonDown)
            {
                _buttonDownAction?.Invoke(pollEvent.Button.X, pollEvent.Button.Y);
            }
            else if (pollEvent.Type == EventType.MouseButtonUp)
            {
                _buttonUpAction?.Invoke(pollEvent.Button.X, pollEvent.Button.Y);
            }
            else if (pollEvent.Type == EventType.MouseMotion)
            {
                _motionAction?.Invoke(pollEvent.Motion.X, pollEvent.Motion.Y);
            }
        }
    }
}
