using SdlSharpened;

namespace SdlSharpened.App
{
    public class SpriteSheet
    {
        public Texture SheetTexture { get { return _texture; } }

        public Rect SheetFrame { get { return _srcRect; } }

        private Texture _texture;
        private Rect _srcRect;
        private Point _sheetSize;

        public SpriteSheet(string path, Point frameSize)
        {
            _texture = new Texture(path);
            _srcRect = new Rect(0, 0, 32, 32);
            _sheetSize = new Point(_texture.Width, _texture.Height);
        }

        public SpriteSheet(string path, Point frameSize, ColourType tspCol)
        {
            _texture = new Texture(path, tspCol);
            _srcRect = new Rect(0, 0, 32, 32);
            _sheetSize = new Point(_texture.Width, _texture.Height);
        }

        // Sets the SpriteSheet's current frame to the position of one of the X and Y cells
        public void SetFrame(int xcell, int ycell)
        {
            int xCellMax = _sheetSize.X / _srcRect.W;
            int yCellMax = _sheetSize.Y / _srcRect.H;

            if ((xcell < xCellMax) && (ycell < yCellMax))
            {
                _srcRect.X = xcell * _srcRect.W;
                _srcRect.Y = ycell * _srcRect.H;
            }
        }

        public void NextFrame() 
        {
            if (_srcRect.X >= _sheetSize.X - 64)
            {
                _srcRect.X = 0;

                if (_srcRect.Y >= _sheetSize.Y - 64)
                {
                    _srcRect.Y = 0;
                }
                else 
                {
                    _srcRect.Y += 32;
                }
            }
            else 
            {
                _srcRect.X += 32;
            }
        }
    }
}