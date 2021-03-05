using System;

namespace SdlSharpened.App
{
    public class Tilemap
    {
        private const int EMPTY_TILE = -1;
        private const int TILES_X = 10;
        private const int TILES_Y = 10;
        private const int TILE_WIDTH = 32;
        private const double RENDER_ROTATE = 45.0;

        private int[,] _tileGrid = new int[TILES_X, TILES_Y];

        private Texture _sheetTexture;
        private Texture _layerTexture;
        private Texture _mapTexture;
        private Texture _viewTexture;

        private Rect _layerRect;
        private Rect _mapRect;
        private Rect _viewRect;

        public Tilemap()
        {
            Init();
        }

        public void Init() 
        {
            // Calculate X and Y resolution of tilemap.
            int mapResX = TILES_X * TILE_WIDTH;
            int mapResY = TILES_Y * TILE_WIDTH;

            _sheetTexture = new Texture("..\\..\\..\\Game\\img\\basetiles.bmp");
            _layerTexture = new Texture(mapResX, mapResY);
            _mapTexture = new Texture(640, 480);
            _viewTexture = new Texture(100, 480);

            _layerRect = new Rect(0, 0, mapResX, mapResY);
            _mapRect = new Rect(0, 0, mapResX * 2, (mapResY * 2) / 3);
            _viewRect = new Rect(0, 0, 640, 480);
        }

        public void Render(Renderer renderer)
        {
            var srcRect = new Rect(0, 0, TILE_WIDTH, TILE_WIDTH);
            var dstRect = new Rect(_layerRect.X, _layerRect.Y, TILE_WIDTH, TILE_WIDTH);

            int offset = 100;

            renderer.SetTarget(_layerTexture);

            for (int y = 0; y < TILES_Y; y++)
            {
                for (int x = 0; x < TILES_X; x++)
                {
                    srcRect = SetSrcRect(_tileGrid[x, y], TILE_WIDTH);

                    dstRect.X = offset + (x * TILE_WIDTH);
                    dstRect.Y = offset + (y * TILE_WIDTH);
                    renderer.Copy(_sheetTexture, srcRect, dstRect);
                }
            }

            renderer.SetTarget(_mapTexture);
            renderer.CopyEx(_layerTexture, null, _layerRect, RENDER_ROTATE);

            renderer.ResetTarget();
            renderer.Copy(_mapTexture, null, _mapRect);
        }

        /*
        public void Render(Renderer renderer, Camera camera)
        {
            Rect srcRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);
            Rect dstRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);

            // Calculate start and end X and Y indeces for rendering.
            int startX = camera.WorldRect.X / (int)_tileSize;
            int startY = camera.WorldRect.Y / (int)_tileSize;
            // Render whole row/ col if camera size is less than map resolution.
            // Over render by one tile.
            // Calcuate how many tiles in view X and Y ways, always round up.
            int inViewX = (int)Math.Ceiling((double)camera.WorldRect.W / (double)_tileSize);
            int inViewY = (int)Math.Ceiling((double)camera.WorldRect.H / (double)_tileSize);
            // Determine whether map is big enough so that it scrolls X or Y ways.
            bool scrollsX = (camera.ViewRect.W < _worldRect.W);
            bool scrollsY = (camera.ViewRect.H < _worldRect.H);
            int endX = scrollsX ? endX = startX + inViewX + 1 : _tilesX;
            int endY = scrollsY ? endY = startY + inViewY + 1 : _tilesY;

            int offsetX = (!scrollsX) ? camera.ViewRect.X + ((camera.ViewRect.W - _worldRect.W) / 2) : camera.ViewRect.X;
            int offsetY = (!scrollsY) ? camera.ViewRect.Y + ((camera.ViewRect.H - _worldRect.H) / 2) : camera.ViewRect.Y;

           //renderer.SetTarget(_mapTexture);

            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    // TODO: Index OOB exception thrown here when tilemap viewRect is 240x240 and xTiles || yTiles == 8
                    srcRect = SetSrcRect(_tileGrid[x, y], (int)_tileSize);

                    dstRect.X = offsetX + (x * (int)_tileSize - camera.WorldRect.X);
                    dstRect.Y = offsetY + (y * (int)_tileSize - camera.WorldRect.Y);

                    // Do not render empty tile.
                    if (_tileGrid[x, y] > EMPTY_TILE)
                    {
                        renderer.Copy(_sheetTexture, srcRect, dstRect);
                    }
                }
            }

            //renderer.ResetTarget();
            //renderer.Copy(_mapTexture, new Rect(0, 0, 128, 128), camera.ViewRect);
        }*/

        private Rect SetSrcRect(int tile, int tileSize)
        {
            int sheetTilesX = _sheetTexture.Width / tileSize;
            int sheetTilesY = _sheetTexture.Height / tileSize;

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
                        break;
                    }
                }
                currentTile += 1;
            }

            srcRect.X = row * tileSize;
            srcRect.Y = col * tileSize;

            return srcRect;
        }
    }
}
