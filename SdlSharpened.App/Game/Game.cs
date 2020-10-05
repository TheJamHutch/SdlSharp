using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Game
    {
        private bool _running;
        private SdlSystem _system;
        private Mixer _mixer;
        private Window _window;
        private Renderer _renderer;
        private Player _player;

        private MusicTrack _musicTrack;
        private SoundEffect _soundEffect;

        public int xv = 0;
        public int yv = 0;

        public Game()
        {
            _running = false;
            _system = new SdlSystem();
            Console.WriteLine("Initialized SDL Version: " + _system.GetVersion());
            _mixer = new Mixer();
            _window = new Window("My SdlSharp App", 640, 480);
            _renderer = new Renderer();
            _player = new Player();

            _musicTrack = new MusicTrack("./sound/arena_main.mp3");
            _soundEffect = new SoundEffect("./sound/shit.wav");

            Eventing.OnKeypress(KeyType.Key_Escape, () => { Stop(); });
            Eventing.OnKeypress(KeyType.Key_F5, () => { Save(); });
            Eventing.OnKeypress(KeyType.Key_F6, () => { Load(); });
            Eventing.OnKeypress(KeyType.Key_W, () => { yv = -2; }, () => { yv = 0; });
            Eventing.OnKeypress(KeyType.Key_S, () => { yv = 2; }, () => { yv = 0; });
            Eventing.OnKeypress(KeyType.Key_A, () => { xv = -2; }, () => { xv = 0; });
            Eventing.OnKeypress(KeyType.Key_D, () => { xv = 2; }, () => { xv = 0; });
            Eventing.OnKeypress(KeyType.Key_B, () => { _mixer.PlaySoundEffect(_soundEffect); });

            Eventing.OnMouseMove((x, y) => { Console.WriteLine($"{x}, {y}"); });
            Eventing.OnMouseButtonDown((x, y) => { Console.WriteLine($"Clicked at: {x}, {y}"); });
            Eventing.OnMouseButtonUp((x, y) => { Console.WriteLine($"Unclicked at: {x}, {y}"); });

            _renderer.SetDrawColour(ColourType.Black);

            _mixer.PlayMusic(_musicTrack);
        }

        public void Update() 
        {
            
        }

        public void Render()
        {
            _renderer.Clear();
            _player.Render(_renderer);
            _renderer.FillRect(new Rect(400, 200, 50, 50), ColourType.Magenta);
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
                if (Eventing.PollEvents() == -1)
                {
                    _running = false;
                }

                // Move player
                _player.Move(xv, yv);

                Render();
                _system.Delay(33);
            }
        }
    }
}
