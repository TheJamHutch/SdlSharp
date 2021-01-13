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
        public int WindowResX { get; } = 800;
        public int WindowResY { get; } = 600;

        public int TargetFps { get; } = 30;

        // Tilemap config
        public TileSize TilePixels { get; } = TileSize.Medium;
        public int TilesX { get; } = 40;
        public int TilesY { get; } = 60;

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
