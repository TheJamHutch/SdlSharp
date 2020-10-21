using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Enemy : IRenderable
    {
        public MoveDirection Direction { get; set; }

        private bool _arrived;
        private Random _random;
        private int _xPos;
        private int _xVel;

        private Texture _texture;
        private Rect _srcRect;
        private Rect _dstRect;

        public Enemy()
        {
            Direction = MoveDirection.Stopped;

            _arrived = false;
            _random = new Random();
            _xPos = _random.Next(1, 640);
            _xVel = 0;

            _texture = new Texture("./img/player2.bmp", ColourType.Magenta);
            _srcRect = new Rect(0, 0, 32, 32);
            _dstRect = new Rect(_random.Next(1, 640), _random.Next(1, 480), 32, 32);
        }

        public void Update() 
        {
            if (_arrived == true)
            {
                Console.WriteLine("Arrived at destinastion");
                _arrived = false;
                _xPos = _random.Next(1, 640);
            }
            else 
            {
                if (_dstRect.X < _xPos)
                {
                    _xVel = 1;
                }
                else if (_dstRect.X > _xPos)
                {
                    _xVel = -1;
                }
                else 
                {
                    _arrived = true;
                }

                _dstRect.X += _xVel;
            }
        }

        void IRenderable.Render(Renderer renderer, Camera camera)
        {
            renderer.Copy(_texture, _srcRect, _dstRect);
        }
    }
}
