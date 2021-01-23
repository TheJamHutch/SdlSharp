using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace SdlSharpened.App
{
    public class GameConfig
    {
        // Window config
        public string WindowTitle { get; } = "Tile Game";

        // Tested @ 640x480, 800x600, 960x540
        public int WindowResX { get; } = 640;
        public int WindowResY { get; } = 480;

        public int TargetFps { get; } = 30;

        // Tilemap config
        public TileSize TilePixels { get; } = TileSize.Medium;
        public int TilesX { get; } = 500;
        public int TilesY { get; } = 400;

        public string TilesheetPath { get; } = "..\\..\\..\\Game\\img\\basetiles.bmp";

        private readonly string _iniPath = "..\\..\\..\\Game\\config.ini";






        private Dictionary<string, string> _configDictionary;

        public GameConfig()
        {
            _configDictionary = new Dictionary<string, string>();

            // Create config.ini file if it doesn't alread exist.
            if (!File.Exists(_iniPath))
            {
                File.Create(_iniPath);
            }
        }

        /*
        public void Load() 
        {
            var allLines = File.ReadLines(_iniPath).ToList();

            allLines.RemoveAll((ln) => { return ln.StartsWith(';') || ln.StartsWith('#') || ln.StartsWith('['); });

            foreach (string line in allLines)
            {
                Console.WriteLine(line);   
            }
        }*/
    }
}
