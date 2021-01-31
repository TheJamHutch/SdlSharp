using System;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class TilemapConfig
    {
        public string TilesheetPath { get; } = "..\\..\\..\\Game\\img\\basetiles.bmp";

        public string MapFolderPath { get; } = "..\\..\\..\\Game\\map\\";

        public TileSize TilePixelSize { get; } = TileSize.Medium;

        public int TilesX { get; } = 400;
        public int TilesY { get; } = 400;

        public Dictionary<int, TileEffect> _tileEffectMap = new Dictionary<int, TileEffect>()
        {
            { 1, TileEffect.Solid },
            { 5, TileEffect.Damage }
        };

        public TilemapConfig()
        {

        }

        private void Load()
        { 
            
        }
    }
}
