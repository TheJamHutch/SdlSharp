/*  Game Tilemap
**
**  Description:
**  
**  +----+----+----+----+
**  |    |    |    |    |
**  +----+----+----+----+ 
**  +----+----+----+----+
**  |    |    |    |    |
**  +----+----+----+----+
**  +----+----+----+----+
**  |    |    |    |    |
**  +----+----+----+----+
**
**  This class does not have any direct association/ dependency on any other game class, but it does need the ViewRect from the Camera.
**  Since the Camera's ViewRect is value-type, it needs to be passed in to the constructor for intial setup AND passed into the Tilemap's
**  Render() method to ensure that the values received are up-to-date.
**  
**  Notes:
**    It is recommended to render a black Rect, the size of the entire view, behind this tilemap because any EMPTY tiles will be rendered
**    over when scrolling; creating an undesireable effect.
**
**  TODO:
**    Factor out primitive tilemap logic into separate class?
**    Implement save and load methods (as well as private Serialize and Deserialize methods).
**    Scrolling is broken at tilleSize: 21, 16 (if view == 640x480). Scrolls tiles to end and then won't scroll back.
**    Buffering effect occurs when scrolling X-ways when using 360x240 resolution.
*/
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SdlSharpened.App
{
    public class Tilemap : ITilemap
    {
        // Numerical constant for empty tiles in tilemap. All tiles are empty in initial map. Empty tiles are not rendered.
        private const int EMPTY_TILE = -1;

        private string _mapFolderPath;

        // 2D array holds the value of each tile.
        private int[,] _tileGrid;

        // How many tiles in map X and Y ways.
        private int _tilesX;
        private int _tilesY;

        // Square pixel size of tiles.
        private TileSize _tileSize;

        // Whether or not the tilemap scrolls X or Y ways. Tilemap scrolls when its resolution is greater than the viewport.
        private bool _scrollsX;
        private bool _scrollsY;

        // Tilesheet image texture
        private Texture _texture;

        // A Rect that encompasses the entire tilemap, represents its position in the game world.
        // X and Y are where the map starts ( it may be offset), and W and H are the resolution of the tilemap.
        private Rect _worldRect;
        //
        private Rect _viewRect;

        //
        private Dictionary<int, TileEffect> _tileEffectMap;

        private Logger _logger;

        public Tilemap(TilemapConfig config, Rect viewRect, Logger logger)
        {
            _logger = logger;

            // Set tilemap dimensions
            _tilesX = config.TilesX;
            _tilesY = config.TilesY;
            _tileSize = config.TilePixelSize;
            _logger.Info($"Tilemap - Tilemap dimensions: X: {_tilesX}, Y: {_tilesY}, TileSize: {_tileSize} ({(int)_tileSize} pixels)");

            _mapFolderPath = config.MapFolderPath;

            // Loads the tilesheet image into texture.
            _texture = new Texture(config.TilesheetPath);

            // Calculate X and Y resolution of tilemap.
            int mapResX = _tilesX * (int)_tileSize;
            int mapResY = _tilesY * (int)_tileSize;

            // Determine whether map scrolls X or Y ways.
            _scrollsX = (mapResX > viewRect.W);
            _scrollsY = (mapResY > viewRect.H);

            // Init positioning rects.
            _worldRect = new Rect(0, 0, mapResX, mapResY);
            _viewRect = viewRect;

            // Initialise grid of tiles and set all to EMPTY.
            _tileGrid = new int[_tilesX, _tilesY];
            for (int y = 0; y < _tilesY; y++)
            {
                for (int x = 0; x < _tilesX; x++)
                {
                    _tileGrid[x, y] = 0;
                }
            }

            _logger.Info($"Tilemap - Tilemap memory usage: ~ {_tileGrid.Length * sizeof(int)} bytes.");

            // The map of tile effects
            _tileEffectMap = new Dictionary<int, TileEffect>()
            { 
                { 1, TileEffect.Solid },
                { 5, TileEffect.Damage }
            };
        }

        // Getter properties.
        public Rect WorldRect { get { return _worldRect; } }
        public Rect ViewRect { get { return _viewRect; } }

        public bool ScrollsX { get { return _scrollsX; } }
        public bool ScrollsY { get { return _scrollsY; } }
        public TileSize TilePixelSize { get { return _tileSize; } }

        public void Init() 
        {
            
        }

        // TODO: Fails to save tilemaps that are too big, like 1000x1000
        public void Save()
        {
            // Save dimensions of current tilemap to string buffer
            string tileStream = $"{_tilesX},{_tilesY};";

            // Loop through every tile in grid and add to string buffer, followed by a comma
            for (int y = 0; y < _tilesY; y++)
            {
                for (int x = 0; x < _tilesX; x++)
                {
                    tileStream += $"{_tileGrid[x, y]},";
                }
            }
            // Remove last comma and add semicolon
            tileStream = tileStream.Substring(0, tileStream.Length - 1);
            tileStream += ";";

            // Write tilemap string to file
            File.WriteAllText($"{_mapFolderPath}mapsave.csv", tileStream);
            _logger.Info($"Wrote map save to: {_mapFolderPath}mapsave.csv");
        }

        // TODO: Bad. Factor out CSV parser, possibly deserializer. This will break very easily.
        public void Load()
        {
            // Read tilemap string from file.
            string rawText = File.ReadAllText($"{_mapFolderPath}mapsave.csv");

            // TODO: Sanitize.
            string mapStream = rawText;

            // Extract dimensions and tile string from mapStream string.
            int firstSemiIdx = mapStream.IndexOf(';');
            string dimStream = mapStream.Substring(0, firstSemiIdx);
            // TODO: Don't rely on adding literals to get the right results
            string tileStream = mapStream.Substring(firstSemiIdx + 1, mapStream.Length - firstSemiIdx - 2);

            // Convert
            int xDim = Int32.Parse(dimStream.Substring(0, mapStream.IndexOf(',')));
            int yDim = Int32.Parse(dimStream.Substring(mapStream.IndexOf(',') + 1));

            _tilesX = xDim;
            _tilesY = yDim;

            // Calculate X and Y resolution of tilemap.
            int resX = _tilesX * (int)_tileSize;
            int resY = _tilesY * (int)_tileSize;

            // Determine whether map scrolls X or Y ways.
            _scrollsX = (resX > 640);
            _scrollsY = (resY > 480);

            // Init positioning rects.
            _worldRect = new Rect(_viewRect.X, _viewRect.Y, resX, resY);

            int[] tileVals = tileStream.Split(',').Select((n) => Convert.ToInt32(n)).ToArray();

            int c = 0;
            _tileGrid = new int[_tilesX, _tilesY];
            for (int y = 0; y < _tilesY; y++)
            {
                for (int x = 0; x < _tilesX; x++)
                {
                    _tileGrid[x, y] = tileVals[c];
                    c += 1;
                }
            }

            _logger.Info($"Loaded map from folder: {_mapFolderPath}");
        }
        
        public void Render(Renderer renderer, Rect camRect)
        {
            Rect srcRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);
            Rect dstRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);

            // Calculate start and end X and Y indeces for rendering.
            int startX = camRect.X / (int)_tileSize;
            int startY = camRect.Y / (int)_tileSize;
            // Render whole row/ col if camera size is less than map resolution.
            // Over render by one tile.
            // Calcuate how many tiles in view X and Y ways, always round up.
            int inViewX = (int)Math.Ceiling((double)camRect.W / (double)_tileSize);
            int inViewY = (int)Math.Ceiling((double)camRect.H / (double)_tileSize);
            int endX = _scrollsX ? endX = startX + inViewX + 1 : _tilesX;
            int endY = _scrollsY ? endY = startY + inViewY + 1 : _tilesY;

            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    // TODO: Index OOB exception thrown here when tilemap viewRect is 240x240 and xTiles || yTiles == 8
                    srcRect = SetSrcRect(_tileGrid[x, y], (int)_tileSize);

                    dstRect.X = _viewRect.X + (x * (int)_tileSize - camRect.X);
                    dstRect.Y = _viewRect.Y + (y * (int)_tileSize - camRect.Y);

                    // Do not render empty tile.
                    if (_tileGrid[x, y] > EMPTY_TILE)
                    {
                        renderer.Copy(_texture, srcRect, dstRect);
                    }
                }
            }
        }

        // Might delete, helps player determine tilemap collision
        /*
        public CollisionTile[] GetEffectTilesInView(Rect viewRect) 
        {
            // Calculate dimensions
            int startX = viewRect.X / (int)_tileSize;
            int startY = viewRect.Y / (int)_tileSize;
            int inViewX = (int)Math.Ceiling((double)viewRect.W / (double)_tileSize);
            int inViewY = (int)Math.Ceiling((double)viewRect.H / (double)_tileSize);
            int endX = _offsetX == 0 ? endX = startX + (viewRect.W / (int)_tileSize) : _tilesX;
            int endY = _offsetY == 0 ? endY = startY + (viewRect.W / (int)_tileSize) : _tilesY;

            var effectTiles = new List<CollisionTile>();

            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    var effect = GetTileEffect(_tileGrid[x, y]);
                    if (effect != TileEffect.None) 
                    {
                        effectTiles.Add(new CollisionTile(effect, TileToWorldRect(new Point(x, y))));
                    }
                }
            }

            return effectTiles.ToArray();
        }

        public CollisionTile[] LocalTiles(Point worldPos)
        { 
            Point tile = PosToTile(worldPos);

            int startX = (tile.X > 0) ? tile.X - 1 : 0;
            int startY = (tile.Y > 0) ? tile.Y - 1 : 0;
            int endX = (tile.X < _tilesX) ? tile.X + 1 : tile.X;
            int endY = (tile.Y < _tilesY) ? tile.Y + 1 : tile.Y;

            CollisionTile[] localTiles = new CollisionTile[9];
            int c = 0;
            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    var effect = GetTileEffect(_tileGrid[x, y]);
                    var tilePos = TileToPos(new Point(x, y));
                    var worldRect = new Rect(tilePos.X, tilePos.Y, (int)_tileSize, (int)_tileSize);

                    localTiles[c] = new CollisionTile(effect, worldRect);
                    c += 1;
                }
            }

            return localTiles;
        }*/

        private Rect SetSrcRect(int tile, int tileSize)
        {
            int sheetTilesX = _texture.Width / tileSize;
            int sheetTilesY = _texture.Height / tileSize;

            Rect srcRect = new Rect(0, 0, tileSize, tileSize);

            int row = 0;
            int col = 0;
            int currentTile = 0;
            int targetTile = tile;

            while (currentTile < targetTile)
            {
                row += 1;
                if (row >= sheetTilesX)
                {
                    row = 0;
                    col += 1;

                    if (col >= sheetTilesY)
                    {
                        row = -1;
                        col = -1;
                        _logger.Warn($"Tilemap.SetSrcRect - Failed to clip tile sheet texture. Requested tile {tile} too high. ");
                        break;
                    }
                }
                currentTile += 1;
            }

            srcRect.X = row * tileSize;
            srcRect.Y = col * tileSize;

            return srcRect;
        }

        // TODO: Get rid of some of these.
        private Rect TileToWorldRect(Point tilePos) 
        {
            return new Rect((tilePos.X * (int)_tileSize) + _viewRect.X, 
                            (tilePos.Y * (int)_tileSize) + _viewRect.Y, 
                            (int)_tileSize, (int)_tileSize);
        }

        // Gets the current XY tile from a world position.
        private Point PosToTile(Point pos)
        {
            return new Point() { X = ((pos.X - _viewRect.X) / (int)_tileSize), Y = ((pos.Y - _viewRect.Y) / (int)_tileSize) };
        }

        // Gets the XY world position from the current XY tile.
        public Point TileToPos(Point tile)
        {
            return new Point()
            {
                X = (tile.X * (int)_tileSize) + _viewRect.X,
                Y = (tile.Y * (int)_tileSize) + _viewRect.Y
            };
        }

        // Used to position player on first tile in map
        // Returns a point representing the position of the first non-solid tile in the tilemap. Used to place entities.
        public Point FirstAvailableTile()
        {
            var posPoint = new Point(0, 0);

            for (int y = 0; y < _tilesY; y++)
            {
                for (int x = 0; x < _tilesX; x++)
                {
                    if (_tileGrid[x, y] == 0)
                    {
                        posPoint.X = x;
                        posPoint.Y = y;

                        return posPoint;
                    }
                }
            }

            return posPoint;
        }

        //
        public int GetTileType(Point tile)
        {
            return _tileGrid[tile.X, tile.Y];
        }

        //
        private TileEffect GetTileEffect(int tileType)
        {
            _tileEffectMap.TryGetValue(tileType, out var tileEffect);

            return tileEffect;
        }

        public void SetTile(Point tilePos, int tileType) 
        {
            _tileGrid[tilePos.X, tilePos.Y] = tileType;
        }
    }
}
