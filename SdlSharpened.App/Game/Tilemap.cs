using SdlSharpened;

namespace SdlSharpened.App
{
    public enum TileSize 
    {
        Tiny = 8,
        Small = 16,
        Medium = 32,
        Large = 64
    };

    public class Tilemap : IRenderable
    {
        public Rect MapArea { get; set; }

        private int[ , ] _tile;
        private int _xCells;
        private int _yCells;
        private TileSize _tileSize;
        private Texture _texture;

        public Tilemap(string path, int xCells, int yCells, TileSize tileSize)
        {
            _xCells = xCells;
            _yCells = yCells;
            _tileSize = tileSize;

            int mapW = _xCells * (int)_tileSize;
            int mapH = _yCells * (int)_tileSize;
            MapArea = new Rect(0, 0, mapW, mapH);

            _texture = new Texture(path, 0);

            _tile = new int[_xCells, _yCells];

            _tile[5, 2] = 2;
        }

        void IRenderable.Render(Renderer renderer, Camera camera)
        {
            Rect srcRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);
            Rect dstRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);
            
            int startX = camera.DstRect.X / (int)_tileSize;
            int startY = camera.DstRect.Y / (int)_tileSize;
            int endX = startX + (camera.DstRect.W / (int)_tileSize) + 1;
            int endY = startY + (camera.DstRect.H / (int)_tileSize) + 1;

            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    srcRect = SetFrame(_tile[x, y]);

                    dstRect.X = x * (int)_tileSize - camera.DstRect.X;
                    dstRect.Y = y * (int)_tileSize - camera.DstRect.Y;

                    renderer.Copy(_texture, srcRect, dstRect);
                }
            }
        }

        public void Save()
        {

        }

        public void Load()
        {
        
        }

        private Rect SetFrame(int tile)
        {
            Rect srcRect = new Rect(0, 0, (int)_tileSize, (int)_tileSize);

            int row = 0;
            int col = 0;
            int currentTile = 0;
            int targetTile = tile;

            while (currentTile < targetTile)
            {
                row += 1;
                if (row >= _xCells)
                {
                    row = 0;
                    col += 1;
                }
                currentTile += 1;
            }

            srcRect.X = row * (int)_tileSize;
            srcRect.Y = col * (int)_tileSize;

            return srcRect;
        }
    }
}
