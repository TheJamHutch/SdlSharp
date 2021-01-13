using System;

namespace SdlSharpened.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameConfig = new GameConfig();
            //gameConfig.Load();

            var game = new Game(gameConfig);

            // Blocking
            game.Start();
        }
    }
}
