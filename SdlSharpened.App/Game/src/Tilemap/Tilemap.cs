using System;
using System.Collections.Generic;
using System.IO;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Tilemap : ITilemap
    {
        public Point Area { get { return _area; } }
        public Point Resolution { get { return _resolution; } }

        private Point _area;
        private Point _resolution;
        private TileSize _tileSize = Config.TilemapTileSize;
        private TilemapLayer _baseTilemapLayer;
        private TilemapLayer _topTilemapLayer;

        public Tilemap()
        {
            _area = new Point(Config.TilemapXtiles, Config.TilemapYtiles);
            _resolution = new Point(Config.TilemapXtiles * (int)_tileSize, Config.TilemapYtiles * (int)_tileSize);

            _baseTilemapLayer = new TilemapLayer(Config.SpritesheetBaseTiles, _area.X, _area.Y, _tileSize);
            _topTilemapLayer = new TilemapLayer(Config.SpritesheetTopTiles, _area.X, _area.Y, _tileSize, ColourType.Magenta);

            _topTilemapLayer.SetTile(12, 12, 1);
            _topTilemapLayer.SetTile(10, 14, 1);
            _topTilemapLayer.SetTile(15, 10, 2);
            _topTilemapLayer.SetTile(17, 12, 1);
            _topTilemapLayer.SetTile(14, 14, 1);
            _topTilemapLayer.SetTile(18, 9, 2);
        }

        public void Save()
        {
            string dirPath = Config.MapFolderPath;
            string name = $"map001.map";

            string payload = $"{_area.X},{_area.Y};{_baseTilemapLayer.Serialize()};";

            File.WriteAllText(Path.Combine(dirPath, name), payload);
        }

        public void Load() 
        {
            string dirPath = Config.MapFolderPath;
            string name = $"map001.map";

            string buffer = File.ReadAllText(Path.Combine(dirPath, name));

            _baseTilemapLayer.Load(buffer);
        }

        public void Render(Camera camera) 
        {
            _baseTilemapLayer.Render(camera.WorldRect);
            _topTilemapLayer.Render(camera.WorldRect);
        }

        public int[,] LocalTiles(Point pos)
        {
            Point tile = TileFromPos(pos, (int)_tileSize);

            int startX = (tile.X > 0) ? tile.X - 1 : 0;
            int startY = (tile.Y > 0) ? tile.Y - 1 : 0;
            int endX = (tile.X < _area.X - 1) ? tile.X + 1 : tile.X;
            int endY = (tile.Y < _area.Y - 1) ? tile.Y + 1 : tile.Y;

            int[ , ] localTiles = new int[3, 3];
            int lx = 0;
            int ly = 0;
            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    localTiles[lx, ly] = _topTilemapLayer._tileGrid[x, y];
                    lx += 1;
                }
                ly += 1;
                lx = 0;
            }

            return localTiles;
        }

        // Gets the current XY tile from a world position
        private Point TileFromPos(Point pos, int tileSize)
        {
            return new Point() { X = pos.X / tileSize, Y = pos.Y / tileSize };
        }

        private Point PosFromTile(Point tile, int tileSize)
        {
            return new Point() { X = tile.X * tileSize, Y = tile.Y * tileSize };
        }
    }
}
