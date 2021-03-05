using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Game
    {
        private bool _running;

        private SdlSystem _system;
        private Window _window;
        private Renderer _renderer;
        private EventHandler _eventHandler;
        private Tilemap _tilemap;

        public Game()
        {
            _system = new SdlSystem();
            _window = new Window("Isometric Tilemap Test", 640, 480);
            _renderer = new Renderer(_window);
            _eventHandler = new EventHandler();
            _tilemap = new Tilemap();

            InitKeyboardEvents();
            InitMouseEvents();
        }

        public void Update()
        {

        }

        public void Render()
        {
            _renderer.FillRect(new Rect(0, 0, 640, 480), ColourType.Black);
            _tilemap.Render(_renderer);
            _renderer.Present();
        }

        public void Start()
        {
            _running = true;
            Run();
        }

        public void Stop()
        {
            _running = false;
        }

        private void Run()
        {
            while (_running)
            {
                _eventHandler.PollEvents();

                Update();
                Render();
                Timing.Delay(33);
            }
        }

        private void InitKeyboardEvents()
        {
            var keypressActions = new List<KeyValuePair<Keycode, PressAction>>()
            {
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_Escape, new PressAction(() => Stop())),
            };

            _eventHandler.Keyboard.BindKeypressActions(keypressActions);
        }

        private void InitMouseEvents()
        {

        }
    }
}