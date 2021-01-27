using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    static class Program
    {
        public static void DoFirst() 
        {
            var system = new SdlSystem();
            var window = new Window("test", new Point(640, 480));
            var renderer = new Renderer(window);

            var texture = new Texture("..\\..\\..\\Game\\img\\basetiles.bmp");
            var target = new Texture(32, 32);

            // Render
            renderer.FillRect(new Rect(0, 0, 640, 480), ColourType.Red);

            renderer.SetTarget(target);
            renderer.Copy(texture, new Rect(0, 0, 32, 32), new Rect(0, 0, 32, 32));

            renderer.Present();
        }

        static void Main(string[] args)
        {
            ///DoFirst();
            //Console.ReadKey();
            //return;

            var game = new Game();

            // Blocking
            game.Start();
        }
    }
}
