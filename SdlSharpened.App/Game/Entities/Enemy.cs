using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Enemy : IRenderable
    {
        public MoveDirection Direction { get; set; }

        private bool _arrived;
        private Random _random;

        private Texture _texture;
        private Rect _srcRect;
        private Rect _dstRect;

        private int targetX;
        private int targetY;

        public Enemy()
        {
            Direction = MoveDirection.Stopped;

            _arrived = false;
            _random = new Random();

            _texture = new Texture("./img/player2.bmp", ColourType.Magenta);
            _srcRect = new Rect(0, 0, 32, 32);
            _dstRect = new Rect(10, 10, 32, 32);

            targetX = 200;
            targetY = 200;    
        }

        public void Update() 
        {
            if (!_arrived)
            {
                if (_dstRect.X == targetX)
                {
                    if (_dstRect.Y == targetY)
                    {
                        _arrived = true;
                    }
                    else
                    {
                        if (_dstRect.Y < targetY)
                        {
                            _dstRect.Y += 1;
                        }
                        else if (_dstRect.Y > targetY)
                        {
                            _dstRect.Y -= 1;
                        }
                    }
                }
                else
                {
                    if (_dstRect.X < targetX)
                    {
                        _dstRect.X += 1;
                    }
                    else if (_dstRect.X > targetX)
                    {
                        _dstRect.X -= 1;
                    }
                }
            }
            else 
            {
                targetX = _random.Next(1, 640);
                targetY = _random.Next(1, 480);
                _arrived = false;
            }
        }

        void IRenderable.Render(Renderer renderer, Camera camera)
        {
            renderer.Copy(_texture, _srcRect, _dstRect);
        }
    }
}
