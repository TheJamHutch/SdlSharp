using System;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Player : IMoveable, IRenderable
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
        private ITilemap _tilemap;
        private Camera _camera;

        private Point _centerView;

        public Player(ITilemap tilemap, Camera camera)
        {
            // Get player sprite pixel size from config
            int pixelSize = Config.PlayerSpriteSize;
            // Calculate the point where the center of the player is in center view
            int centerX = camera.WorldRect.X + (camera.WorldRect.W / 2 - pixelSize / 2);
            int centerY = camera.WorldRect.Y + (camera.WorldRect.H / 2 - pixelSize / 2);

            _centerView = new Point(centerX, centerY);

            _spriteSheet = new SpriteSheet(Config.SpritesheetPlayer, new Point(pixelSize, pixelSize), Config.TransparentColour);
            _worldRect = new Rect(_centerView.X, _centerView.Y, pixelSize, pixelSize);
            _viewRect = new Rect(_centerView.X, _centerView.Y, pixelSize, pixelSize);
            _tilemap = tilemap;
            _camera = camera;
        }

        public void Render()
        {
            Game.RendererInstance.Copy(_spriteSheet.SheetTexture, _spriteSheet.SheetFrame, _viewRect);
        }

        public void Update()
        {

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

            int[,] localTiles = _tilemap.LocalTiles(new Point(_worldRect.X + padX, _worldRect.Y + padY));

            return ( 
                    // Check player edge of tilemap collision
                    (playerY < 1) && (_moveDirection == MoveDirection.North) ||
                    ((playerX < 1) && (_moveDirection == MoveDirection.West)) ||
                    ((playerY >= _tilemap.Resolution.Y - 64) && (_moveDirection == MoveDirection.South)) ||
                    ((playerX > _tilemap.Resolution.X - 64) && (_moveDirection == MoveDirection.East)) ||

                    // Check player tilemap collision
                    (localTiles[1, 0] > EMPTY_TILE && _moveDirection == MoveDirection.North) ||
                    /*(localTiles[2, 1] > EMPTY_TILE && _moveDirection == MoveDirection.East) ||*/
                    (localTiles[1, 2] > EMPTY_TILE && _moveDirection == MoveDirection.South)// ||
                    //(localTiles[0, 1] > EMPTY_TILE && _moveDirection == MoveDirection.West)

                    ) ? true : false;
        }

        private void Animate() 
        {
            switch (_moveDirection)
            {
                case MoveDirection.South:
                    _spriteSheet.SetFrame(0, 0);
                    break;
                case MoveDirection.East:
                    _spriteSheet.SetFrame(0, 1);
                    break;
                case MoveDirection.North:
                    _spriteSheet.SetFrame(0, 2);
                    break;
                case MoveDirection.West:
                    _spriteSheet.SetFrame(0, 3);
                    break;
                case MoveDirection.None:
                    break;
            }

            if (_moveDirection != MoveDirection.None)
            {
                _spriteSheet._srcRect.X = 32 * (int)((Timing.Ticks() / 60) % 5);
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
    }
}
