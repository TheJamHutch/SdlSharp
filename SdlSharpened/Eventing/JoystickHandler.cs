using System;
using SDL2;

namespace SdlSharpened
{
    public class JoystickHandler : Handler
    {
        private Action _buttonDownAction;
        private Action _buttonUpAction;
        private Action _axisAction;
        private Action _ballAction;
        private Action _hatAction;

        public JoystickHandler()
        {
            Eventing.JoystickHandlerInstance = this;
        }

        public void OnButtonDown(Action action) 
        {
            _buttonDownAction = action;
        }

        public void OnButtonUp(Action action)
        {
            _buttonUpAction = action;
        }

        public void OnAxis(Action action)
        {
            _axisAction = action;
        }

        public void OnBall(Action action)
        {
            _ballAction = action;
        }

        public void OnHat(Action action)
        {
            _hatAction = action;
        }

        internal override void PollEvents(SDL.SDL_Event sdlEvent)
        {
            if (sdlEvent.type == SDL.SDL_EventType.SDL_JOYBUTTONDOWN)
            {
                _buttonDownAction?.Invoke();
            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_JOYBUTTONUP)
            {
                _buttonUpAction?.Invoke();
            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_JOYAXISMOTION)
            {
                _axisAction?.Invoke();
            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_JOYBALLMOTION)
            {
                _ballAction?.Invoke();
            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_JOYHATMOTION)
            {
                _hatAction?.Invoke();
            }
        }
    }
}
