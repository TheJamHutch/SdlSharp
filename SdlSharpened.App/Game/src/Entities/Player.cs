/* 
**
**
*/
using System;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Animation 
    {
        public Point StartPos { get; }
        public int CellCount { get; }
        public int WaitFrames { get; }

        public Animation(Point startPos, int cellCount, int waitFrames)
        {
            StartPos = startPos;
            CellCount = cellCount;
            WaitFrames = waitFrames;
        }
    }

    public class Player : IMoveable, IRenderable
    {
        private MoveDirection _moveDirection = MoveDirection.None;
        private MoveSpeed _moveSpeed = MoveSpeed.Medium;
        private Point _centerView;
        private Rect _worldRect;
        private Rect _viewRect;
        private Rect _clipRect;
        private ITilemap _tilemap;
        private Camera _camera;
        private Texture _texture;

        private Animation _currentAnimation;

        private Dictionary<string, Animation> _animationDictionary = new Dictionary<string, Animation>()
        {
            { "default", new Animation(new Point(0, 0), 1, 3) },
            { "WalkSouth", new Animation(new Point(0, 0), 5, 3) },
            { "WalkEast", new Animation(new Point(0, 1), 5, 3) },
            { "WalkNorth", new Animation(new Point(0, 2), 5, 3) },
            { "WalkWest", new Animation(new Point(0, 3), 5, 3) }
        };

        // TODO: rename
       // event NewFrameEventHandler _newFrameEventHandler;

        public Player(ITilemap tilemap, Camera camera, Rect spriteRect)
        {
            _tilemap = tilemap;
            _camera = camera;

            int centerX = camera.WorldRect.X + (camera.WorldRect.W / 2 - spriteRect.W / 2);
            int centerY = camera.WorldRect.Y + (camera.WorldRect.H / 2 - spriteRect.H / 2);

            _centerView = new Point(centerX, centerY);

            // Use spriteRect.X/Y to position player. 
            var initPos = new Point(200, 200);

            _texture = new Texture("D:\\Programming\\C#\\Projects\\SdlSharpened\\SdlSharpened.App\\Game\\img\\player.bmp", ColourType.Magenta);
            
            _worldRect = new Rect(initPos.X, initPos.Y, spriteRect.W, spriteRect.H);
            _viewRect = new Rect(initPos.X, initPos.Y, spriteRect.W, spriteRect.H);
            _clipRect = new Rect(0, 0, spriteRect.W, spriteRect.H);
            // Subscribe to game for new frame updates
            //_newFrameEventHandler += Foo;

            _currentAnimation = _animationDictionary["default"];
        }

        public Rect WorldRect { get { return _worldRect; } }
        public Rect ViewRect { get { return _viewRect; } }
        public MoveDirection Direction { get { return _moveDirection; } set { _moveDirection = value; } }
        public MoveSpeed Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        public void Render(Renderer renderer)
        {
            renderer.Copy(_texture, _clipRect, _viewRect);
        }

        public void Update()
        {
            switch (_moveDirection) 
            {
                case MoveDirection.North:
                    _currentAnimation = _animationDictionary["WalkNorth"];
                    break;
                case MoveDirection.East:
                    _currentAnimation = _animationDictionary["WalkEast"];
                    break;
                case MoveDirection.South:
                    _currentAnimation = _animationDictionary["WalkSouth"];
                    break;
                default:
                    _currentAnimation = _animationDictionary["default"];
                    break;
            }

            bool collide = Collision();
            Animate();
            Move(collide);
        }

        private bool Collision() 
        {
            int playerX = _worldRect.X;
            int playerY = _worldRect.Y;

            const int EMPTY_TILE = -1;
            int padX = 16;
            int padY = 16;

            switch (_moveDirection)
            {
                case MoveDirection.North:
                    padY = 32;
                    break;
                case MoveDirection.East:
                    padX = 0;
                    break;
                case MoveDirection.South:
                    padY = 0;
                    break;
                case MoveDirection.West:
                    padX = 32;
                    break;
            }

            //TileEffect[,] localTiles = _tilemap.LocalTiles(new Point(_worldRect.X + padX, _worldRect.Y + padY));

            return ( 
                    // Check player edge of tilemap collision
                    (playerY < 1) && (_moveDirection == MoveDirection.North) ||
                    ((playerX < 1) && (_moveDirection == MoveDirection.West)) ||
                    (((playerY + 32) >= _tilemap.WorldRect.H - 32) && (_moveDirection == MoveDirection.South)) ||
                    (((playerX + 32) >= _tilemap.WorldRect.W - 32) && (_moveDirection == MoveDirection.East))

                    // Check player tilemap collision
                    //(localTiles[1, 0] == TileEffect.Solid && _moveDirection == MoveDirection.North) ||
                    //(localTiles[2, 1] == TileEffect.Solid && _moveDirection == MoveDirection.East) /*||
                    //(localTiles[1, 2] == TileEffect.Solid && _moveDirection == MoveDirection.South) ||
                    //(localTiles[0, 1] == TileEffect.Solid && _moveDirection == MoveDirection.West)*/

                    ) ? true : false;
        }

        private int _frameCounter = 0;
        private int _cellCounter = 0;

        private void Animate() 
        {
            if (Game.NewFrame)
            {
                _frameCounter++;
            }

            // On animation start/ restart
            if (_cellCounter == 0)
            {
                SetFrame(_currentAnimation.StartPos);
                _cellCounter++;
            }

            if (_cellCounter == _currentAnimation.CellCount)
            {
                _cellCounter = 0;
                return;
            }

            if (_frameCounter == _currentAnimation.WaitFrames)
            {
                NextFrame();
                _frameCounter = 0;
                _cellCounter++;

                
            }
        }

        private void Move(bool collide) 
        {
            if (_camera.LockW)
            {
                if (_viewRect.X > _centerView.X)
                {
                    _camera.LockW = false;
                    _viewRect.X = _centerView.X;
                }
            }
            else if (_camera.LockE)
            {
                if (_viewRect.X < _centerView.X)
                {
                    _camera.LockE = false;
                    _viewRect.X = _centerView.X;
                }
            }

            if (_camera.LockN)
            {
                if (_viewRect.Y > _centerView.Y)
                {
                    _camera.LockN = false;
                    _viewRect.Y = _centerView.Y;
                }
            }
            else if (_camera.LockS)
            {
                if (_viewRect.Y < _centerView.Y)
                {
                    _camera.LockS = false;
                    _viewRect.Y = _centerView.Y;
                }
            }

            _moveDirection.SetVelocities(out var xVel, out var yVel);

            if (collide && (_moveDirection == MoveDirection.North || _moveDirection == MoveDirection.South))
            {
                yVel = 0;
            }
            if (collide && (_moveDirection == MoveDirection.West || _moveDirection == MoveDirection.East))
            {
                xVel = 0;
            }

            if (_camera.LockE || _camera.LockW)
            { 
                _viewRect.X += xVel * (int)_moveSpeed;
            }

            if (_camera.LockN || _camera.LockS)
            {
                _viewRect.Y += yVel * (int)_moveSpeed;
            }

            _worldRect.X += xVel * (int)_moveSpeed;
            _worldRect.Y += yVel * (int)_moveSpeed;
        }

        // Advances the srcRect along one position in the spritesheet texture, wraps around.
        private void NextFrame() 
        {
            _clipRect.X += 32;
            if (_clipRect.X + 32 >= _texture.Width)
            {
                _clipRect.X = 0;
                _clipRect.Y += 32;

                if (_clipRect.Y + 32 >= _texture.Height)
                {
                    _clipRect.Y = 0;
                    _clipRect.X = 0;
                }
            }
        }

        private void SetFrame(Point framePos) 
        {
            _clipRect.X = framePos.X * 32;
            _clipRect.Y = framePos.Y * 32;
        }
    }
}
