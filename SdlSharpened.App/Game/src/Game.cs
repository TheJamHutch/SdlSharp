/* Game Class
*/
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Game
    {
        public static bool NewFrame { get; set; } = false;

        // The delegate for a game reload handler.
        public static event Action ReloadEvent;


        // True when the game is running.
        private bool _running;
        // The maximum time (in milliseconds) to wait before the game renders the next frame.
        private int _frameDelay;
        private Point _viewSize;

        // SdlSharpened objects
        private SdlSystem _system;
        private Window _window;
        private Renderer _renderer;
        private EventHandler _eventHandler;

        // Game objects
        private GameConfig _config;
        private Logger _logger;
        private Camera _camera;
        private Player _player;
        private Tilemap _tilemap;
        private BitmapText _bitmapText;

        // Map editor stuff
        private Rect _cursorRect = new Rect(0, 0, 32, 32);
        private TilemapEditor _tilemapEditor;

        // Constructs the game object along with all other aggregate objects.
        public Game()
        {
            _logger = new Logger();
            _config = new GameConfig();
            _viewSize = new Point(_config.WindowResolution.X, _config.WindowResolution.Y);
            _logger.Info($"Using viewport size from config: {_viewSize.X}, {_viewSize.Y}");

            // Instantiate game objects
            _system = new SdlSystem();
            _window = new Window(_config.WindowTitle, _viewSize.X, _viewSize.Y);
            _renderer = new Renderer(_window);
            _eventHandler = new EventHandler();

            // Create in order: Tilemap -> Camera -> Player -> Enemies
            _tilemap = new Tilemap(_config.Tilemap, _viewSize, _logger);
            _camera = new Camera(_config.Entities, _tilemap, _viewSize, _logger);
            _player = new Player(_config.Entities, _tilemap, _camera, _logger);
            _bitmapText = new BitmapText();

            _tilemapEditor = new TilemapEditor(_tilemap);

            // Calculate frame delay. 
            _frameDelay = 1000 / _config.TargetFps;

            // Init events stuff.
            InitKeyboardEvents();
            InitMouseEvents();
        }

        public void Update()
        {
            _player.Update();
            _camera.Update();
            _bitmapText.Update();

            _tilemapEditor.Update();
        }

        public void Render()
        {
            // Render background.
            _renderer.FillRect(_camera.ViewRect, ColourType.Black);
            _tilemap.Render(_renderer, _camera.WorldRect);

            // Render map editor cursor over top of tilemap
            _renderer.DrawRect(_cursorRect, ColourType.Yellow);

            _player.Render(_renderer);
            _tilemapEditor.Render(_renderer);
            _bitmapText.Render(_renderer);
            _renderer.Present();
        }

        public void Start()
        {
            _logger.Trace("Game running...");
            _running = true;
            Run();
        }

        public void Stop()
        {
            _running = false;
        }

        public void Save()
        {
            _logger.Trace("Game save");
            // Save the current tilemap.
            _tilemap.Save();
        }

        public void Load()
        {
            _logger.Trace("Game load");
            // Load the tilemap.
            _tilemap.Load();
            // Fire reload event to tell subscribing classes to re-init.
            ReloadEvent.Invoke();
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

        private void InitKeyboardEvents()
        {
            Action stopAction = () => { _camera.Direction = MoveDirection.None; _player.Direction = MoveDirection.None; };
            var keypressActions = new List<KeyValuePair<Keycode, PressAction>>()
            {
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_Escape, new PressAction(() => Stop())),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_F5, new PressAction(() => Task.Run(() => Save()))),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_F6, new PressAction(() => Load())),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_W, new PressAction(
                    () => { _camera.Direction = MoveDirection.North;  _player.Direction = MoveDirection.North; }, stopAction)),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_D, new PressAction(
                    () => { _camera.Direction = MoveDirection.East;  _player.Direction = MoveDirection.East; }, stopAction)),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_S, new PressAction(
                    () => { _camera.Direction = MoveDirection.South;  _player.Direction = MoveDirection.South; }, stopAction)),
                new KeyValuePair<Keycode, PressAction>(Keycode.Key_A, new PressAction(
                    () => { _camera.Direction = MoveDirection.West;  _player.Direction = MoveDirection.West; }, stopAction)),
            };

            _eventHandler.Keyboard.BindKeypressActions(keypressActions) ;
        }

        private void InitMouseEvents()
        {
            _eventHandler.Mouse.OnButtonDown((mx, my) => SetMapTile(mx, my));
            //_eventHandler.Mouse.OnButtonUp((mx, my) => Console.WriteLine($"UP: {mx}, {my}"));
            _eventHandler.Mouse.OnMotion((mx, my) => UpdateCursor(mx, my) );
        }

        private void UpdateCursor(int mx, int my) 
        {
            int camX = _camera.WorldRect.X;
            int camY = _camera.WorldRect.Y;
            int tx = ((mx - (mx % 32)) - (camX % 32));
            int ty = ((my - (my % 32)) - (camY % 32));

            _cursorRect.X = tx;
            _cursorRect.Y = ty;
        }

        private void SetMapTile(int mx, int my)
        {
            int camX = _camera.WorldRect.X;
            int camY = _camera.WorldRect.Y;

            int tx = ((camX - (camX % 32)) / 32) + ((mx - (mx % 32)) / 32);
            int ty = ((camY - (camX % 32)) / 32) + ((my - (my % 32)) / 32);
            var tilePos = new Point(tx, ty);
            _tilemap.SetTile(tilePos, 1);
        }
    }
}