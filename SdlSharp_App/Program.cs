using System;
using SdlSharp;
using SDL2;

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
        static void Render(Renderer renderer, Texture texture) 
        {
            renderer.Clear();
            renderer.Copy(texture, new Rect(0, 0, 32, 32), new Rect(100, 50, 32, 32));
            renderer.Present();
        }

        static void Main(string[] args)
        {
            using (var sdlSystem = new SdlSystem())
            {
                using (var window = new Window("SdlSharp Test", 640, 480))
                {
                    using (var renderer = new Renderer(window))
                    {
                        bool quit = false;

                        var tex = new Texture(renderer, "./img/testimg.bmp");

                        Eventing.RegisterKeypressAction(KeyType.Key_0, () => Console.WriteLine("Default"));
                        Eventing.RegisterKeypressAction(KeyType.Key_1, () => Console.WriteLine("Eeeexcellent"));
                        Eventing.RegisterKeypressAction(KeyType.Key_LCtrl, () => Console.WriteLine("Left ctrl"));
                        Eventing.RegisterKeypressAction(KeyType.Key_RCtrl, () => Console.WriteLine("Right ctrl"));

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