using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Enemy : IMoveable, IRenderable
    {
        public Rect WorldRect { get { return _worldRect; } }
        public Rect ViewRect { get { return _viewRect; } }
        public MoveDirection Direction { get { return _moveDirection; } set { _moveDirection = value; } }
        public MoveSpeed Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        private Rect _worldRect;
        private Rect _viewRect;
        private MoveDirection _moveDirection = MoveDirection.None;
        private MoveSpeed _moveSpeed = MoveSpeed.Slow;
        private SpriteSheet _spriteSheet;

        private Point _dstPos;
        private bool _arrived;
        private Camera _camera;
        private ITilemap _tilemap;
        private Random _random;

        public Enemy(ITilemap tilemap, Camera camera)
        {
            _arrived = false;
            _camera = camera;
            _tilemap = tilemap; _worldRect = new Rect(10, 10, 32, 32);
            _viewRect = new Rect(10, 10, 32, 32);
            _spriteSheet = new SpriteSheet(Config.SpritesheetSlime, new Point(32, 32), ColourType.Magenta);
            _random = new Random();
            //_dstPos = RandomPoint();
        }

        public void Update() 
        {
            

            if (_worldRect.X < _dstPos.X)
            {
                _worldRect.X += 2;
            }
            else if (_worldRect.X > _dstPos.X)
            {
                _worldRect.X -= 2;
            }
            else 
            {
                if (_worldRect.Y < _dstPos.Y)
                {
                    _worldRect.Y += 2;
                }
                else if (_worldRect.Y > _dstPos.Y)
                {
                    _worldRect.Y -= 2;
                }
                else
                {
                    _arrived = true;
                }
            }
            /*
            if (_arrived)
            {
                _dstPos = RandomPoint();
                _arrived = false;
            }*/
        }

        public void Render()
        {
            _viewRect.X = _worldRect.X - _camera.WorldRect.X;
            _viewRect.Y = _worldRect.Y - _camera.WorldRect.Y;
            Game.RendererInstance.Copy(_spriteSheet.SheetTexture, _spriteSheet.SheetFrame, _viewRect);
        }

        public void Animate()
        {
            
        }

        public void Move()
        {
            
        }
        /*
        private Point RandomPoint() 
        {
            int x = _random.Next(1, _tilemap.Resolution.X);
            int y = _random.Next(1, _tilemap.Resolution.Y);
            Console.WriteLine($"Random point: {x}, {y}");
            return new Point(x, y);
        }*/
    }
}