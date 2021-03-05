using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            // Blocking
            game.Start();
        }
    }
}
