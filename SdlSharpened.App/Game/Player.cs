using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Player
    {
        private Texture _texture;
        private Rect _srcRect;
        private Rect _dstRect;

        public Player()
        {
            _texture = new Texture("./img/player.bmp", ColourType.Magenta);
            _srcRect = new Rect(0, 0, 32, 32);
            _dstRect = new Rect(100, 100, 32, 32);
        }

        public void Update()
        {

        }

        public void Render(Renderer renderer)
        {
            renderer.Copy(_texture, _srcRect, _dstRect);
        }

        public void Move(int xv, int yv) 
        {
            _dstRect.X += xv;
            _dstRect.Y += yv;
        }
    }
}
