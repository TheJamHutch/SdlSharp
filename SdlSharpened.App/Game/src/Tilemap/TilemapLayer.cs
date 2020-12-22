using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class TilemapLayer
    {
        private const int EMPTY_TILE = -1;

        private int[ , ] _tileGrid;
        private int _xTiles;
        private int _yTiles;
        private TileSize _tileSize;
        private SpriteSheet _tileSheet;

        /// <summary>
        ///   Creates a base tillemap layer.
        /// </summary>
        public TilemapLayer(string path, int xTiles, int yTiles, TileSize tileSize)
        {
            _xTiles = xTiles;
            _yTiles = yTiles;
            _tileSize = tileSize;

            _tileSheet = new SpriteSheet(path, new Point((int)_tileSize, (int)_tileSize));

            _tileGrid = new int[_xTiles, _yTiles];
        }

        /// <summary>
        ///   Creates a top tilemap layer.
        /// </summary>
        public TilemapLayer(string path, int xTiles, int yTiles, TileSize tileSize, ColourType tspCol)
        {
            _xTiles = xTiles;
            _yTiles = yTiles;
            _tileSize = tileSize;

            int mapW = _xTiles * (int)_tileSize;
            int mapH = _yTiles * (int)_tileSize;

            _tileSheet = new SpriteSheet(path, new Point((int)tileSize, (int)tileSize), tspCol);

            _tileGrid = new int[_xTiles, _yTiles];

            SetAllTiles(EMPTY_TILE);
        }

        public void Render(Rect cameraRect)
        {
            Rect dstRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);
            
            int startX = cameraRect.X / (int)_tileSize;
            int startY = cameraRect.Y / (int)_tileSize;
            int endX = startX + (cameraRect.W / (int)_tileSize) + 1;
            int endY = startY + (cameraRect.H / (int)_tileSize) + 1;

            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    SetFrame(_tileGrid[x, y]);

                    dstRect.X = x * (int)_tileSize - cameraRect.X;
                    dstRect.Y = y * (int)_tileSize - cameraRect.Y;

                    if (_tileGrid[x, y] > EMPTY_TILE)
                    {
                        Game.RendererInstance.Copy(_tileSheet.SheetTexture, _tileSheet.SheetFrame, dstRect);
                    }
                }
            }
        }

        public string Serialize() 
        {
            string outstr = "";

            for (int y = 0; y < _yTiles; y++)
            {
                for (int x = 0; x < _xTiles; x++)
                {
                    outstr += $"{_tileGrid[x, y]},";
                }
            }

            outstr = outstr.Substring(0, outstr.Length - 1);

            return outstr;
        }

        public int[,] Deserialize(int xc, int yc, string buff) 
        {
            int[,] tiles = new int[xc, yc];

            int lastCommaIdx = 0;
            int nextCommaIdx = buff.IndexOf(',');

            Console.WriteLine($"F: {lastCommaIdx}, L: {nextCommaIdx}");

            for (int y = 0; y < yc; y++)
            {
                for (int x = 0; x < xc; x++)
                {
                    string token = buff.Substring(lastCommaIdx, nextCommaIdx);

                    lastCommaIdx = nextCommaIdx;
                    nextCommaIdx = buff.Substring(lastCommaIdx).IndexOf(',');
                    Console.WriteLine($"F: {lastCommaIdx}, L: {nextCommaIdx}");
                    int val = Int32.Parse(token);
                    Console.WriteLine(val);

                    tiles[x, y] = val;

                    Console.ReadKey(true);
                }
            }

            return tiles;
        }

        public void Load(string serialMap) 
        {
            // Bloody awful

            string dims = serialMap.Substring(0, serialMap.IndexOf(';'));
            string xdim = dims.Substring(0, dims.IndexOf(','));
            string ydim = dims.Substring(dims.IndexOf(',') + 1);

            int xCells = Int32.Parse(xdim);
            int yCells = Int32.Parse(ydim);

            string baseSerial = serialMap.Substring(serialMap.IndexOf(';') + 1, serialMap.Length - serialMap.IndexOf(';') - 1);

            Console.WriteLine($" x: {xCells}, y: {yCells}\n\n");

            _xTiles = xCells;
            _yTiles = yCells;
            _tileGrid = Deserialize(_xTiles, _yTiles, baseSerial);

            Console.WriteLine($"{_tileGrid}");
        }

        public void SetTile(int xcell, int ycell, int tileType) 
        {
            _tileGrid[xcell, ycell] = tileType;
        }

        public void SetAllTiles(int tileType) 
        {
            for (int y = 0; y < _yTiles; y++)
            {
                for (int x = 0; x < _xTiles; x++)
                {
                    _tileGrid[x, y] = tileType;
                }
            }
        }

        private void SetFrame(int tile)
        {
            Rect srcRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);

            int row = 0;
            int col = 0;
            int currentTile = 0;
            int targetTile = tile;

            while (currentTile < targetTile)
            {
                row += 1;
                if (row >= _xTiles)
                {
                    row = 0;
                    col += 1;
                }
                currentTile += 1;
            }

            _tileSheet.SetFrame(row, col);
        }

        public int[,] LocalTiles(Point tilePos) 
        {
            int startX = tilePos.X - 1;
            int startY = tilePos.Y - 1;
            int endX = tilePos.X + 1;
            int endY = tilePos.Y + 1;

            int[,] localTiles = new int[3, 3];
            int lx = 0;
            int ly = 0;
            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    localTiles[lx, ly] = _tileGrid[x, y];
                    Console.Write(localTiles[lx, ly] + ", ");

                    lx += 1;
                }
                ly += 1;
                lx = 0;
                Console.WriteLine();
            }
            Console.WriteLine("\n");

            return localTiles;
        }
    }
}
