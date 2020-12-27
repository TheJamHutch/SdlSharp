using System;
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

        private IntPtr _surface;

        // Game objects
        private BitmapText _bitmapText;
        private Camera _camera;
        private Player _player;
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

            // Init eventing stuff
            InitKeypresses();
            //InitGamepad();

            _surface = SDL2.SDL.SDL_LoadBMP(Config.SpritesheetNumsheet);
        }

        public void Update()
        {

            _player.Update();
            _camera.Update();
        }

        public void Render()
        {
            _tilemap.Render(_camera);
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

                int startTime = (int)SdlSystem.Tickss();
                Update();
                Render();
                int endTime = (int)_system.Ticks();
                int timeDiff = endTime - startTime;
                // Wait for the shortest possible time if frame took too long to draw
                if (timeDiff > Config.FrameDelay)
                {
                    timeDiff = 1;
                }

                Console.WriteLine($"FPS: {1000 / (Config.FrameDelay - timeDiff) - 1}");

                _system.Delay(Config.FrameDelay - timeDiff); 
            }
        }

        private void InitKeypresses()
        {
            Action stopAction = () => { _camera.Direction = MoveDirection.None; _player.Direction = MoveDirection.None; };

            _eventHandler.Keyboard.OnKeypress(Keycode.Key_Escape, () => Stop());
            _eventHandler.Keyboard.OnKeypress(Keycode.Key_F5, () => _tilemap.Save());
            _eventHandler.Keyboard.OnKeypress(Keycode.Key_F6, () => _tilemap.Load());
            _eventHandler.Keyboard.OnKeypress(Keycode.Key_W,
                () => { _camera.Direction = MoveDirection.North; _player.Direction = MoveDirection.North; }, stopAction);
            _eventHandler.Keyboard.OnKeypress(Keycode.Key_D,
                () => { _camera.Direction = MoveDirection.East; _player.Direction = MoveDirection.East; }, stopAction);
            _eventHandler.Keyboard.OnKeypress(Keycode.Key_S,
                () => { _camera.Direction = MoveDirection.South; _player.Direction = MoveDirection.South; }, stopAction);
            _eventHandler.Keyboard.OnKeypress(Keycode.Key_A,
                () => { _camera.Direction = MoveDirection.West; _player.Direction = MoveDirection.West; }, stopAction);
        }

        /*
        private void InitGamepad() 
        {
            _gamepadHandler.OnButtonpress(GamepadButton.Btn_A, () => { Console.WriteLine("A Down!"); });
            _gamepadHandler.OnButtonpress(GamepadButton.Btn_B, 
                () => { _camera.Speed = MoveSpeed.Fast;  _player.Speed = MoveSpeed.Fast; },
                () => { _camera.Speed = MoveSpeed.Slow; _player.Speed = MoveSpeed.Slow; });
            _gamepadHandler.OnButtonpress(GamepadButton.Btn_X, () => { Console.WriteLine("X Down!"); });
            _gamepadHandler.OnButtonpress(GamepadButton.Btn_Y, () => { Console.WriteLine("Y Down!"); });

            Action stopAction = () => { _camera.Direction = MoveDirection.None; _player.Direction = MoveDirection.None; };

            _gamepadHandler.OnButtonpress(GamepadButton.Dpad_Up, 
                () => { _camera.Direction = MoveDirection.North; _player.Direction = MoveDirection.North; }, stopAction);
            _gamepadHandler.OnButtonpress(GamepadButton.Dpad_Down, 
                () => { _camera.Direction = MoveDirection.South; _player.Direction = MoveDirection.South; }, stopAction);
            _gamepadHandler.OnButtonpress(GamepadButton.Dpad_Left, 
                () => { _camera.Direction = MoveDirection.West; _player.Direction = MoveDirection.West; }, stopAction);
            _gamepadHandler.OnButtonpress(GamepadButton.Dpad_Right, 
                () => { _camera.Direction = MoveDirection.East; _player.Direction = MoveDirection.East; }, stopAction);
        }*/
    }
}