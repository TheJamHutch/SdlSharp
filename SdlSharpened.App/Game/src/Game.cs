using System;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Game
    {
        // Renderer singleton
        public static Renderer RendererInstance;

        private bool _running;

        // SdlSharpened objects
        private SdlSystem _system;
        private Window _window;
        private Renderer _renderer;
        private EventHandler _eventHandler;

        // Game objects
        private BitmapText _bitmapText;
        private Camera _camera;
        private Player _player;
        private Enemy _enemy;
        private ITilemap _tilemap;

        public Game()
        {
            // Instantiate game objects
            _system = new SdlSystem();
            _window = new Window(Config.WindowTitle, Config.WindowXres, Config.WindowYres);
            _renderer = new Renderer(_window);
            RendererInstance = _renderer;

            _eventHandler = new EventHandler();

            // Create in order: Tilemap -> Camera -> Player -> Enemies
            _bitmapText = new BitmapText();
            _tilemap = new Tilemap();
            _camera = new Camera(_tilemap);
            _player = new Player(_tilemap, _camera);
            _enemy = new Enemy(_tilemap, _camera);

            // Init eventing stuff
            Action stopAction = () => { _camera.Direction = MoveDirection.None; _player.Direction = MoveDirection.None; };
            var keypressActions = new List<KeyValuePair<Keycode, PressAction>>()
            {
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_Escape, new PressAction(() => Stop())),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_F5, new PressAction(() => _tilemap.Save())),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_F6, new PressAction(() => _tilemap.Load())),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_W, new PressAction(
                    () => { _camera.Direction = MoveDirection.North;  _player.Direction = MoveDirection.North; }, stopAction)),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_D, new PressAction(
                    () => { _camera.Direction = MoveDirection.East;  _player.Direction = MoveDirection.East; }, stopAction)),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_S, new PressAction(
                    () => { _camera.Direction = MoveDirection.South;  _player.Direction = MoveDirection.South; }, stopAction)),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_A, new PressAction(
                    () => { _camera.Direction = MoveDirection.West;  _player.Direction = MoveDirection.West; }, stopAction)),
            };

            _eventHandler.Keyboard.BindKeypressActions(keypressActions);
        }

        public void Update()
        {
            _enemy.Update();
            _player.Update();
            _camera.Update();
        }

        public void Render()
        {
            _tilemap.Render(_camera);
            _enemy.Render();
            _player.Render();
            _bitmapText.Render();
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

                int startTime = (int)Timing.Ticks();
                Update();
                Render();
                int endTime = (int)Timing.Ticks();
                int timeDiff = endTime - startTime;
                // Wait for the shortest possible time if frame took too long to draw
                if (timeDiff > Config.FrameDelay)
                {
                    timeDiff = 1;
                }

                int fps = 1000 / (Config.FrameDelay - timeDiff) - 1;
                _bitmapText.SetValue(fps); 

                Timing.Delay((uint)(Config.FrameDelay - timeDiff)); 
            }
        }
    }
}