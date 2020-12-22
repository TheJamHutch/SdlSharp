using System;
using System.Collections.Generic;
using System.Text;
using SdlSharpened;

namespace SdlSharpened.App
{
    public static class Config
    {
        public static readonly string WindowTitle = "TileGame";
        public static readonly int WindowXres = 640;
        public static readonly int WindowYres = 480;

        public static readonly int FrameDelay = 33;

        public static readonly ColourType TransparentColour = ColourType.Magenta;

        public static readonly int TilemapXtiles = 200;
        public static readonly int TilemapYtiles = 200;
        public static readonly TileSize TilemapTileSize = TileSize.Medium;

        public static readonly string SpritesheetBaseTiles = "D:\\Programming\\C#\\Projects\\SdlSharpened\\SdlSharpened.App\\Game\\img\\basetiles.bmp";
        public static readonly string SpritesheetTopTiles = "D:\\Programming\\C#\\Projects\\SdlSharpened\\SdlSharpened.App\\Game\\img\\toptiles.bmp";

        public static readonly string SpritesheetPlayer = "D:\\Programming\\C#\\Projects\\SdlSharpened\\SdlSharpened.App\\Game\\img\\player.bmp";

        public static readonly string MapFolderPath = "D:\\Programming\\C#\\Projects\\SdlSharpened\\SdlSharpened.App\\Game\\map";

        public static readonly int PlayerSpriteSize = 32;
    }
}
