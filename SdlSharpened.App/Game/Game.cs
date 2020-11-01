using System;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Game
    {
        private readonly int WINDOW_XRES = 640;
        private readonly int WINDOW_YRES = 480;
        private readonly int FRAME_DELAY = 33;

        private bool _running;

        // SdlSharpened objects
        private SdlSystem _system;
        private Window _window;
        private Renderer _renderer;
        private EventHandler _eventHandler;

        // Game objects
        private RenderPipeline _renderPipeline;
        private Camera _camera;
        private Player _player;
        private List<Enemy> enemies;
        private Tilemap _baseMap;
        private Tilemap _topMap;

        public Game()
        {
            _running = false;

            // Instantiate game objects
            _system = new SdlSystem();
            _window = new Window("Tile Game", WINDOW_XRES, WINDOW_YRES);
            _renderer = new Renderer(_window);
            _eventHandler = new EventHandler();
            _renderPipeline = new RenderPipeline();
            _camera = new Camera(WINDOW_XRES, WINDOW_YRES);
            _player = new Player();
            //_enemy = new Enemy();
            enemies = new List<Enemy>()
            {
                new Enemy(),
                new Enemy(),
                new Enemy(),
                new Enemy(),
                new Enemy()
            };

            _baseMap = new Tilemap("./img/tilesheet.bmp", 30, 20, TileSize.Medium);
            _topMap = new Tilemap("./img/topsheet.bmp", 30, 20, TileSize.Medium, ColourType.Magenta);

            // Push newly created renderables onto render pipeline (order is important)
            _renderPipeline.Push(_baseMap);
            _renderPipeline.Push(_topMap);
            _renderPipeline.Push(_player);
            //_renderPipeline.Push(_enemy);
            foreach (var enemy in enemies)
            {
                _renderPipeline.Push(enemy);
            }

            

            // Register event callbacks
            _eventHandler.KeyboardEvents.OnKeypress(KeyType.Key_Escape, () => Stop());
            _eventHandler.KeyboardEvents.OnKeypress(KeyType.Key_F5, () => Save());
            _eventHandler.KeyboardEvents.OnKeypress(KeyType.Key_F6, () => Load());
            _eventHandler.KeyboardEvents.OnKeypress(KeyType.Key_W,
            () =>
            {
                _camera.Direction = MoveDirection.North;
                _player.Direction = MoveDirection.North;
            },
            () =>
            {
                _camera.Direction = MoveDirection.Stopped;
                _player.Direction = MoveDirection.Stopped;
            });
            _eventHandler.KeyboardEvents.OnKeypress(KeyType.Key_D,
            () =>
            {
                _camera.Direction = MoveDirection.East;
                _player.Direction = MoveDirection.East;
            },
            () =>
            {
                _camera.Direction = MoveDirection.Stopped;
                _player.Direction = MoveDirection.Stopped;
            });
            _eventHandler.KeyboardEvents.OnKeypress(KeyType.Key_S,
            () =>
            {
                _camera.Direction = MoveDirection.South;
                _player.Direction = MoveDirection.South;
            },
            () =>
            {
                _camera.Direction = MoveDirection.Stopped;
                _player.Direction = MoveDirection.Stopped;
            });
            _eventHandler.KeyboardEvents.OnKeypress(KeyType.Key_A,
            () =>
            {
                _camera.Direction = MoveDirection.West;
                _player.Direction = MoveDirection.West;
            },
            () =>
            {
                _camera.Direction = MoveDirection.Stopped;
                _player.Direction = MoveDirection.Stopped;
            });
            _eventHandler.KeyboardEvents.OnKeypress(KeyType.Key_Space, () => _window.ShowMessageBox("A", "B"));
            _renderer.SetDrawColour(ColourType.Black);
        }

        public void Update() 
        {
            _camera.Update(_baseMap.MapArea);
            _player.Update(_baseMap.MapArea);
            foreach (var enemy in enemies)
            {
                enemy.Update();
            }
        }

        public void Render()
        {
            _renderer.Clear();

            foreach (IRenderable item in _renderPipeline)
            {
                item.Render(_renderer, _camera);
            }

            _renderer.Present();
        }

        public void Start() 
        {
            Run();
        }

        public void Pause() 
        {
            _running = false;
        }

        public void Stop() 
        {
            Console.WriteLine("Stopping Game...");
            _running = false;
        }
        
        public void Save() 
        {
            Console.WriteLine("Save Game");
        }

        public void Load() 
        {
            Console.WriteLine("Load Game");
        }

        private void Run()
        {
            _running = true;

            while (_running)
            {
                // Check for quit event
                if (_eventHandler.PollEvents() == -1)
                {
                    _running = false;
                }

                // Time how long it takes to update and render
                int beforeTicks = 0;
                int afterTicks = 0;
                int timeTaken = 0;
                beforeTicks = (int)_system.Ticks();
                Update();
                Render();
                afterTicks = (int)_system.Ticks();
                timeTaken = afterTicks - beforeTicks;
                // If it took too long, wait for the shortest possible time
                if (timeTaken > FRAME_DELAY)
                {
                    timeTaken = FRAME_DELAY - 1;
                }
                _system.Delay(FRAME_DELAY - timeTaken);
            }
        }
    }
}
