using System;
using SDL2;

namespace SdlSharpened
{
    public class MouseHandler
    {
        private Action<int, int> _buttonDownAction;
        private Action<int, int> _buttonUpAction;
        private Action<int, int> _moveAction;
        private Action<int, int> _wheelAction;

        public MouseHandler()
        {

        }

        /// <summary>
        ///   Registers the action to invoke when a mouse button down event occurs.
        /// </summary>
        /// <param name="action"></param>
        public void OnButtonDown(Action<int, int> action)
        {
            _buttonDownAction = action;
        }

        /// <summary>
        ///   Registers the action to invoke when a mouse button up event occurs.
        /// </summary>
        /// <param name="action"></param>
        public void OnButtonUp(Action<int, int> action)
        {
            _buttonUpAction = action;
        }

        /// <summary>
        ///   Registers the action to invoke when a mouse move event occurs.
        /// </summary>
        /// <param name="action"></param>
        public void OnMove(Action<int, int> action)
        {
            _moveAction = action;
        }

        /// <summary>
        ///   Registers the action to invoke when a mouse wheel event occurs.
        /// </summary>
        /// <param name="action"></param>
        public void OnWheel(Action<int, int> action) 
        {
            _wheelAction = action;
        }

        public void PollEvents(Event pollEvent) 
        {
            /*
            if (pollEvent.Type == SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN)
            {
                _buttonDownAction?.Invoke(sdlEvent.button.x, sdlEvent.button.y);
            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_MOUSEBUTTONUP)
            {
                _buttonUpAction?.Invoke(sdlEvent.button.x, sdlEvent.button.y);
            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_MOUSEMOTION)
            {
                _moveAction?.Invoke(sdlEvent.motion.x, sdlEvent.motion.y);
            }
            else if (sdlEvent.type == SDL.SDL_EventType.SDL_MOUSEWHEEL)
            {
                _wheelAction?.Invoke(sdlEvent.wheel.x, sdlEvent.wheel.y);
            }*/
        }
    }
}
