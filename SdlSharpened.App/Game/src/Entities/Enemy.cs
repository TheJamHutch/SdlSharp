using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Enemy : IMoveable, IRenderable
    {
        private Rect _worldRect;
        private Rect _viewRect;
        private MoveDirection _moveDirection = MoveDirection.None;
        private MoveSpeed _moveSpeed = MoveSpeed.Slow;
        private Texture _texture;
        private Rect _srcRect;
        

        private Point _dstPos;
        private bool _arrived;
        private Camera _camera;
        private ITilemap _tilemap;
        private Random _random;
        private int _waitFrames = 0;

        public Enemy(ITilemap tilemap, Camera camera)
        {
            _arrived = false;
            _camera = camera;
            _tilemap = tilemap; 
            _worldRect = new Rect(10, 10, 32, 32);
            _viewRect = new Rect(10, 10, 32, 32);
            _texture = new Texture("D:\\Programming\\C#\\Projects\\SdlSharpened\\SdlSharpened.App\\Game\\img\\slime.bmp", ColourType.Magenta);
            _srcRect = new Rect(0, 0, 32, 32);
            _random = new Random();
            _dstPos = new Point(300, 300);
        }

        public Rect WorldRect { get { return _worldRect; } }
        public Rect ViewRect { get { return _viewRect; } }
        public MoveDirection Direction { get { return _moveDirection; } set { _moveDirection = value; } }
        public MoveSpeed Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        public void Update() 
        {
            if (_worldRect.X < _dstPos.X)
            {
                _worldRect.X += 4;
            }
            else if (_worldRect.X > _dstPos.X)
            {
                _worldRect.X -= 4;
            }
            else 
            {
                if (_worldRect.Y < _dstPos.Y)
                {
                    _worldRect.Y += 4;
                }
                else if (_worldRect.Y > _dstPos.Y)
                {
                    _worldRect.Y -= 4;
                }
                else
                {
                    _arrived = true;
                }
            }
            if (_arrived)
            {
                _waitFrames += 1;
                if (_waitFrames > 30)
                {
                    _dstPos = RandomPoint(new Point(600, 440));
                    _arrived = false;
                    _waitFrames = 0;
                }
            }
        }

        public void Render(Renderer renderer)
        {
            _viewRect.X = _worldRect.X - _camera.WorldRect.X;
            _viewRect.Y = _worldRect.Y - _camera.WorldRect.Y;
            renderer.Copy(_texture, _srcRect, _viewRect);
        }

        public void Animate()
        {
            
        }

        public void Move()
        {
            
        }

        private Point RandomPoint(Point max) 
        {
            Random rng = new Random();

            int x = rng.Next(1, max.X);
            int y = rng.Next(1, max.Y);
            return new Point(x, y);
        }
    }
}