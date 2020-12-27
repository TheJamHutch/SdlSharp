using System;
using System.Collections.Generic;
using System.Text;
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

        public bool Collision(Camera camera, Player player) 
        {
            bool collide = false;
            var playerTile = TileFromPos(camera, player);

            int[,] localTiles = new int[3, 3];
            localTiles = _topTilemapLayer.LocalTiles(playerTile);

            const int EMPTY_TILE = -1;

            if ( (localTiles[1, 0] > EMPTY_TILE && player.Direction == MoveDirection.North) ||
                 (localTiles[2, 1] > EMPTY_TILE && player.Direction == MoveDirection.East)  ||
                 (localTiles[1, 2] > EMPTY_TILE && player.Direction == MoveDirection.South) ||
                 (localTiles[0, 1] > EMPTY_TILE && player.Direction == MoveDirection.West)   )
            {
                collide = true;
            }

            return collide;
        }

        // Gets the current X and Y tile from the camera position
        private Point TileFromPos(Camera camera, Player player)
        {
            int tileX = 0;
            int tileY = 0;

            int camX = camera.WorldRect.X;
            int camY = camera.WorldRect.Y;

            int plrX = player.ViewRect.X;
            int plrY = player.ViewRect.Y;

            tileX = (camX + (plrX + 16)) / 32;
            tileY = (camY + (plrY + 16)) / 32;

            return new Point(tileX, tileY);
        }

        private Point PosFromTile(Point tile)
        {
            Point pos = new Point();

            pos.X = tile.X * (int)_tileSize;
            pos.Y = tile.Y * (int)_tileSize;

            return pos;
        }
    }
}
