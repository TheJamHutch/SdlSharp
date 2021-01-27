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

        // The X and Y offsets in pixels, where the tilemap starts to be rendered.
        private int _offsetX;
        private int _offsetY;

        // Whether or not the tilemap scrolls X or Y ways. Tilemap scrolls when its resolution is greater than the viewport.
        private bool _scrollsX;
        private bool _scrollsY;

        // Tilesheet image texture
        private Texture _texture;

        // A Rect that encompasses the entire tilemap, represents its position in the game world.
        // X and Y are where the map starts ( it may be offset), and W and H are the resolution of the tilemap.
        private Rect _worldRect;

        //
        private Dictionary<int, TileEffect> _tileEffectMap;

        private Logger _logger;

        public Tilemap(TilemapConfig config, Point viewSize, Logger logger)
        {
            _logger = logger;

            // Set tilemap dimensions
            _tilesX = config.TilesX;
            _tilesY = config.TilesY;
            _tileSize = config.TilePixelSize;

            _mapFolderPath = config.MapFolderPath;

            // Loads the tilesheet image into texture.
            _texture = new Texture(config.TilesheetPath);

            // Calculate X and Y resolution of tilemap.
            int resX = _tilesX * (int)_tileSize;
            int resY = _tilesY * (int)_tileSize;

            // Determine whether map scrolls X or Y ways.
            _scrollsX = (resX > viewSize.X);
            _scrollsY = (resY > viewSize.Y);

            // Pre-calculate tilemap render offsets if map scrolls X or Y ways, zero if not.
            _offsetX = !_scrollsX ? ((viewSize.X - resX) / 2) + 8 : 0;
            _offsetY = !_scrollsY ? ((viewSize.Y - resY) / 2) + 8 : 0;

            // Init positioning rects.
            _worldRect = new Rect(_offsetX, _offsetY, resX, resY);

            // Initialise grid of tiles and set all to EMPTY.
            _tileGrid = new int[_tilesX, _tilesY];
            for (int y = 0; y < _tilesY; y++)
            {
                for (int x = 0; x < _tilesX; x++)
                {
                    _tileGrid[x, y] = 0;
                }
            }

            _tileGrid[0, 0] = 1;
            _tileGrid[1, 0] = 1;
            _tileGrid[2, 3] = 1;
            _tileGrid[5, 5] = 1;

            _tileEffectMap = new Dictionary<int, TileEffect>()
            { 
                { 1, TileEffect.Solid },
                { 5, TileEffect.Damage }
            };
        }

        // Getter properties.
        public Rect WorldRect { get { return _worldRect; } }
        public bool ScrollsX { get { return _scrollsX; } }
        public bool ScrollsY { get { return _scrollsY; } }
        public TileSize TilePixelSize { get { return _tileSize; } }

        public void Init() 
        {
            
        }

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

            // Pre-calculate tilemap render offsets if map scrolls X or Y ways, zero if not.
            _offsetX = !_scrollsX ? ((640 - resX) / 2) + 8 : 0;
            _offsetY = !_scrollsY ? ((480 - resY) / 2) + 8 : 0;

            // Init positioning rects.
            _worldRect = new Rect(_offsetX, _offsetY, resX, resY);

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

            //_logger.Info($"Loaded map from folder: {_mapFolderPath}");
        }

        public void Render(Renderer renderer, Rect viewRect)
        {
            Rect srcRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);
            Rect dstRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);

            // Calculate start and end X and Y indeces for rendering.
            int startX = viewRect.X / (int)_tileSize;
            int startY = viewRect.Y / (int)_tileSize;
            // Render whole row/ col if camera size is less than map resolution.
            // Over render by one tile.
            // Calcuate how many tiles in view X and Y ways, always round up.
            int inViewX = (int)Math.Ceiling((double)viewRect.W / (double)_tileSize);
            int inViewY = (int)Math.Ceiling((double)viewRect.H / (double)_tileSize);
            int endX = _offsetX == 0 ? endX = startX + inViewX + 1 : _tilesX;
            int endY = _offsetY == 0 ? endY = startY + inViewY + 1 : _tilesY;

            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    srcRect = SetSrcRect(_tileGrid[x, y], (int)_tileSize);

                    dstRect.X = _offsetX + (x * (int)_tileSize - viewRect.X);
                    dstRect.Y = _offsetY + (y * (int)_tileSize - viewRect.Y);

                    // Do not render empty tile.
                    if (_tileGrid[x, y] > EMPTY_TILE)
                    {
                        renderer.Copy(_texture, srcRect, dstRect);
                    }
                }
            }
        }

        // Might delete, helps player determine tilemap collision
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
        }

        /* @Pure
        */
        private Rect SetSrcRect(int tile, int tileSize)
        {
            Rect srcRect = new Rect(0, 0, tileSize, tileSize);

            int row = 0;
            int col = 0;
            int currentTile = 0;
            int targetTile = tile;

            while (currentTile < targetTile)
            {
                row += 1;
                if (row >= _tilesX)
                {
                    row = 0;
                    col += 1;
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
            return new Rect((tilePos.X * (int)_tileSize) + _offsetX, 
                            (tilePos.Y * (int)_tileSize) + _offsetY, 
                            (int)_tileSize, (int)_tileSize);
        }

        // Gets the current XY tile from a world position.
        private Point PosToTile(Point pos)
        {
            return new Point() { X = ((pos.X - _offsetX) / (int)_tileSize), Y = ((pos.Y - _offsetY) / (int)_tileSize) };
        }

        // Gets the XY world position from the current XY tile.
        public Point TileToPos(Point tile)
        {
            return new Point()
            {
                X = (tile.X * (int)_tileSize) + _offsetX,
                Y = (tile.Y * (int)_tileSize) + _offsetY
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
