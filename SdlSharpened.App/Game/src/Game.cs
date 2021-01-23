using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Game
    {
        public static bool NewFrame { get; set; } = false;

        private bool _running;
        private int _frameDelay;

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
        private Tilemap _tilemap;

        public Game(GameConfig gameConfig)
        {
            // Instantiate game objects
            _system = new SdlSystem();
            _window = new Window(gameConfig.WindowTitle, gameConfig.WindowResX, gameConfig.WindowResY);
            _renderer = new Renderer(_window);
            _eventHandler = new EventHandler();
            _bitmapText = new BitmapText();

            // Create in order: Tilemap -> Camera -> Player -> Enemies
            var camRect = new Rect(10, 10, gameConfig.WindowResX, gameConfig.WindowResY);
            _tilemap = new Tilemap(gameConfig.TilesheetPath, gameConfig.TilesX, gameConfig.TilesY, gameConfig.TilePixels, camRect);
            _camera = new Camera(_tilemap, camRect);
            _player = new Player(_tilemap, _camera, new Rect(600, 224, 32, 32));
            //_enemy = new Enemy(_tilemap, _camera);

            _frameDelay = 1000 / gameConfig.TargetFps;

            // Init eventing stuff
            Action stopAction = () => { _camera.Direction = MoveDirection.None; _player.Direction = MoveDirection.None; };
            var keypressActions = new List<KeyValuePair<Keycode, PressAction>>()
            {
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_Escape, new PressAction(() => Stop())),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_F5, new PressAction(() => Task.Run(() => _tilemap.Save()))),
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
            //_enemy.Update();
            _player.Update();
            _camera.Update();
        }

        public void Render()
        {
            _renderer.FillRect(_camera.ViewRect, ColourType.Black);
             _tilemap.Render(_renderer, _camera.WorldRect);
            //_enemy.Render(_renderer);
            _player.Render(_renderer);
            //_bitmapText.Render(_renderer);
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
                // Wait for the shortest possible time if frame took too long.
                if (timeDiff > _frameDelay)
                {
                    timeDiff = 1;
                }
                NewFrame = false;
                Timing.Delay((uint)(33 - timeDiff));
                NewFrame = true;
            }
        }
    }
}