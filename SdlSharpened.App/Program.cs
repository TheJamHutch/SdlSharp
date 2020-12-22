using System;

namespace SdlSharpened.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            // Blocking
            game.Start();
        }
    }
}
