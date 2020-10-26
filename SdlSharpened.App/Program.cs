using System;
using SdlSharpened;
using SdlSharpened.App;
using SDL2;

namespace SdlSharpened.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game game = new Game();

            // Blocking
            //game.Start();

            var sdl = new SdlSystem();
            var window = new Window("title", new Point(640, 480));
            var renderer = new Renderer();

            var srfc = new Surface("./img/player.bmp");
            var ball = new Surface("./img/fireball.bmp");

            Console.WriteLine(SystemInfo.Description());

            Rect srcRect = new Rect(0, 0, 32, 32);
            Rect dstRect = new Rect(100, 100, 64, 64);

            Blitting.BlitSurface(ball, srfc, new Rect(0, 0, 10, 10), dstRect);

            var texture = new Texture(srfc);

            while (true)
            {
                renderer.Copy(texture, srcRect, dstRect);
                renderer.Present();
                sdl.Delay(33);
            }
        }
    }
}