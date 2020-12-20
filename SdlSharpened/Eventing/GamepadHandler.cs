using System;
using System.Collections.Generic;
using SDL2;

namespace SdlSharpened
{
    public class GamepadHandler
    {
        private Dictionary<GamepadButton, PressAction> _buttonpressRegistry;
        private Action _axisAction;

        private IntPtr _sdlGameController;

        private GamepadButton _lastPressed = GamepadButton.Btn_Invalid;

        public GamepadHandler()
        {
            _buttonpressRegistry = new Dictionary<GamepadButton, PressAction>();
            // TODO: Don't rely on the controller always being 0
            _sdlGameController = SDL.SDL_GameControllerOpen(0);
            Eventing.GamepadHandlerInstance = this;
        }

        // Close all SDL game controllers
        ~GamepadHandler() 
        {
            SDL.SDL_GameControllerClose(_sdlGameController);
        }

        /// <summary>
        ///   Returns the number of joysticks attached to the system.
        /// </summary>
        public int AttachedCount() 
        {
            return SDL.SDL_NumJoysticks();
        }

        public void OnButtonpress(GamepadButton button, Action downAction, Action upAction = null) 
        {
            _buttonpressRegistry[button] = new PressAction(downAction, upAction);
        }

        public void OnAxis(Action action) 
        {
            _axisAction = action;
        }

        internal void PollEvents(SDL.SDL_Event sdlEvent)
        {
            if (sdlEvent.type == SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN)
            {
                GamepadButton btnCode = GamepadButton.Btn_Invalid;

                foreach (var enumVal in GamepadButtonExtension.GetValues())
                {
                    byte btnDown = SDL.SDL_GameControllerGetButton(_sdlGameController, enumVal.ToSdl());
                    if (btnDown == 1)
                    {
                        btnCode = enumVal;
                        break;
                    }
                }

                if (_buttonpressRegistry.TryGetValue(btnCode, out var pressAction))
                {
                    pressAction.DownAction?.Invoke();
                    _lastPressed = btnCode;
                }
                else 
                {
                    Console.WriteLine("Button not mapped");
                }
            }
            
            if (sdlEvent.type == SDL.SDL_EventType.SDL_CONTROLLERBUTTONUP)
            { 
                if (_buttonpressRegistry.TryGetValue(_lastPressed, out var pressAction))
                {
                    pressAction.UpAction?.Invoke();
                }
            }
        }
    }
}
