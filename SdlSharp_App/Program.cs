using System;
using SdlSharp;
using SDL2;

namespace SdlSharp_App
{
    class GameState 
    {
    
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

                        SDL.SDL_Event e = new SDL.SDL_Event();

                        while (!quit)
                        {
                            while (SDL.SDL_PollEvent(out e) != 0)
                            {
                                if (e.type == SDL.SDL_EventType.SDL_QUIT)
                                {
                                    quit = true;
                                }
                                else if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
                                {
                                    switch (e.key.keysym.sym)
                                    {
                                        case SDL.SDL_Keycode.SDLK_ESCAPE:
                                        {
                                            quit = true;
                                            break;
                                        }
                                        case SDL.SDL_Keycode.SDLK_0:
                                        {
                                                Console.WriteLine(new Rect().X);
                                                break;
                                        }
                                    }
                                }
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