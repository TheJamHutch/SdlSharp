using System;
using SdlSharpened;
using SdlSharpened.App;

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