using System;
using SdlSharp;

namespace SdlSharp_App
{
    class GameState 
    {
        private Window _window;
        private Renderer _renderer;

        private Texture _tex1;

        private Rect _srcRect;
        private Rect _dstRect;

        public GameState()
        {

        }
    }

    class Program
    {
        private static Rect _dstRect = new Rect(0, 0, 32, 32);

        static void Render(Renderer renderer, Texture texture) 
        {
            renderer.Clear();
            renderer.Copy(texture, new Rect(0, 0, 32, 32), _dstRect);
            renderer.Present();
        }

        static void Main(string[] args)
        {
            using (var sdlSystem = new SdlSystem())
            {
                Console.WriteLine("Initialized " + sdlSystem.GetVersion());

                using (var window = new Window("SdlSharp Test", 640, 480))
                {
                    using (var renderer = new Renderer(window))
                    {
                        bool quit = false;

                        var tex = new Texture("./img/testimg.bmp", ColourType.Magenta);

                        Action movePlayer = () => { _dstRect.X += 2; };

                        Eventing.RegisterKeypressAction(KeyType.Key_0, () => {});
                        Eventing.RegisterKeypressAction(KeyType.Key_1, movePlayer);
                        Eventing.RegisterKeypressAction(KeyType.Key_LCtrl, () => Console.WriteLine("Left ctrl"));
                        Eventing.RegisterKeypressAction(KeyType.Key_RCtrl, () => Console.WriteLine("Right ctrl"));
                        Eventing.RegisterKeypressAction(KeyType.Key_w, movePlayer);

                        while (!quit)
                        {
                            if (Eventing.PollEvents() == Eventing.EventType.Quit)
                            {
                                quit = true;
                            }

                            Render(renderer, tex);
                            sdlSystem.Delay(33);
                        }
                    }
                }
            }
        }
    }
}