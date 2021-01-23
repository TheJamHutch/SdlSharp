using System;
using System.Collections.Generic;
using System.Text;

namespace SdlSharpened.App
{
    public interface ITilemap
    {
        bool ScrollsX { get; }
        bool ScrollsY { get; }
        TileSize TilePixelSize { get; }
        Rect WorldRect { get; }

        void Save();

        void Load();

        TileEffect[ , ] LocalTiles(Point tilePos);

        Point PosFromTile(Point tile);

        Point FirstTilePos();

        int GetTileType(Point tile);
    }
}
