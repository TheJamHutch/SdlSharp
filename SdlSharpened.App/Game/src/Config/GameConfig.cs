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
        public Point WindowResolution { get; } = new Point(640, 480);

        public int TargetFps { get; } = 30;

        public string BackgroundImagePath { get; } = "..\\..\\..\\Game\\img\\background.bmp";

        public Rect GameViewRect { get; } = new Rect(0, 0, 640, 480);


        public TilemapConfig Tilemap { get; }
        public EntitiesConfig Entities { get; }

        public GameConfig()
        {
            Tilemap = new TilemapConfig();
            Entities = new EntitiesConfig();
        }
    }
}
