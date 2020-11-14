using SDL2;
using System;

namespace SdlSharpened
{
    public class GamepadHandler : Handler
    {
        private Action _buttonDownAction;

        private Action _buttonUpAction;

        private Action _axisAction;

        public GamepadHandler()
        {
            Eventing.GamepadHandlerInstance = this;
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

        internal override void PollEvents(SDL.SDL_Event sdlEvent)
        {
            if (sdlEvent.type == SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN)
            { 
            
            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_CONTROLLERBUTTONUP)
            {

            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_CONTROLLERAXISMOTION)
            {

            }
        }
    }
}
