using System;
using SdlSharp;
using SdlSharp.App;

namespace SdlSharp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Run();
        }
    }
}