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

        //void Save();

        //void Load();

        //CollisionTile[] LocalTiles(Point worldPos);

        //Point TileToPos(Point tile);

        //Point FirstAvailableTile();

        //int GetTileType(Point tile);

        //CollisionTile[] GetEffectTilesInView(Rect viewRect);

        //void SetTile(Point tilePos, int tileType);
    }
}
