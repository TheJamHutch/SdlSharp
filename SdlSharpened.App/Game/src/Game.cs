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
        private KeyboardHandler _keyboardHandler;
        private MouseHandler _mouseHandler;
        private GamepadHandler _gamepadHandler;

        // Game objects
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

            _keyboardHandler = new KeyboardHandler();
            _mouseHandler = new MouseHandler();
            _gamepadHandler = new GamepadHandler();

            // Create in order: Tilemap -> Camera -> Player -> Enemies
            _tilemap = new Tilemap();
            _camera = new Camera(_tilemap);
            _player = new Player(_tilemap, _camera);

            // Init eventing stuff
            Eventing.OnQuit(() => Stop());
            InitKeypresses();
            InitMouseActions();
            InitGamepad();
        }

        public void Update()
        {
            _camera.Update();
            _player.Update();
        }

        public void Render()
        {
            _tilemap.Render(_camera);
            _player.Render();
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
                Eventing.PollEvents();

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

                _system.Delay(Config.FrameDelay - timeDiff); 
            }
        }

        private void InitKeypresses() 
        {
            Action stopAction = () => { _camera.Direction = MoveDirection.Stopped; _player.Direction = MoveDirection.Stopped; };

            _keyboardHandler.OnKeypress(KeyboardKey.Key_Escape, () => Stop());
            _keyboardHandler.OnKeypress(KeyboardKey.Key_F5, () => _tilemap.Save());
            _keyboardHandler.OnKeypress(KeyboardKey.Key_F6, () => _tilemap.Load());
            _keyboardHandler.OnKeypress(KeyboardKey.Key_W, 
                () => { _camera.Direction = MoveDirection.North; _player.Direction = MoveDirection.North; }, stopAction);
            _keyboardHandler.OnKeypress(KeyboardKey.Key_D,
                () => { _camera.Direction = MoveDirection.East; _player.Direction = MoveDirection.East; }, stopAction);
            _keyboardHandler.OnKeypress(KeyboardKey.Key_S,
                () => { _camera.Direction = MoveDirection.South; _player.Direction = MoveDirection.South; }, stopAction);
            _keyboardHandler.OnKeypress(KeyboardKey.Key_A,
                () => { _camera.Direction = MoveDirection.West; _player.Direction = MoveDirection.West; }, stopAction);
        }

        private void InitMouseActions() 
        {

        }

        private void InitGamepad() 
        {
            _gamepadHandler.OnButtonpress(GamepadButton.Btn_A, () => { Console.WriteLine("A Down!"); });
            _gamepadHandler.OnButtonpress(GamepadButton.Btn_B, 
                () => { _camera.Speed = MoveSpeed.Fast;  _player.Speed = MoveSpeed.Fast; },
                () => { _camera.Speed = MoveSpeed.Slow; _player.Speed = MoveSpeed.Slow; });
            _gamepadHandler.OnButtonpress(GamepadButton.Btn_X, () => { Console.WriteLine("X Down!"); });
            _gamepadHandler.OnButtonpress(GamepadButton.Btn_Y, () => { Console.WriteLine("Y Down!"); });

            Action stopAction = () => { _camera.Direction = MoveDirection.Stopped; _player.Direction = MoveDirection.Stopped; };

            _gamepadHandler.OnButtonpress(GamepadButton.Dpad_Up, 
                () => { _camera.Direction = MoveDirection.North; _player.Direction = MoveDirection.North; }, stopAction);
            _gamepadHandler.OnButtonpress(GamepadButton.Dpad_Down, 
                () => { _camera.Direction = MoveDirection.South; _player.Direction = MoveDirection.South; }, stopAction);
            _gamepadHandler.OnButtonpress(GamepadButton.Dpad_Left, 
                () => { _camera.Direction = MoveDirection.West; _player.Direction = MoveDirection.West; }, stopAction);
            _gamepadHandler.OnButtonpress(GamepadButton.Dpad_Right, 
                () => { _camera.Direction = MoveDirection.East; _player.Direction = MoveDirection.East; }, stopAction);
        }
    }
}