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

        public Player(ITilemap tilemap, Camera camera)
        {
            // Get player sprite pixel size from config
            int pixelSize = Config.PlayerSpriteSize;
            // Calculate to place player in center of camera
            int centerX = 304; //camera.WorldRect.X + (camera.WorldRect.W / 2 - pixelSize / 2);
            int centerY = 224; //camera.WorldRect.Y + (camera.WorldRect.H / 2 - pixelSize / 2);

            _spriteSheet = new SpriteSheet(Config.SpritesheetPlayer, new Point(pixelSize, pixelSize), Config.TransparentColour);
            _worldRect = new Rect(centerX, centerY, pixelSize, pixelSize);
            _viewRect = new Rect(centerX, centerY, pixelSize, pixelSize);
            _tilemap = tilemap;
            _camera = camera;
        }

        public void Render()
        {
            Game.RendererInstance.Copy(_spriteSheet.SheetTexture, _spriteSheet.SheetFrame, _viewRect);
        }

        public void Update()
        {
            _moveDirection.SetVelocities(out var xVel, out var yVel);

            Collision(ref xVel, ref yVel);
            Animate();
            Move(xVel, yVel);
        }

        private void Collision(ref int xVel, ref int yVel) 
        {
            int playerX = _worldRect.X;
            int playerY = _worldRect.Y;

            // Stop player going off edge of tilemap
            if (((playerY < 0) && (_moveDirection == MoveDirection.North)) ||
                 ((playerY + 32 >= _tilemap.Resolution.Y - 32) && (_moveDirection == MoveDirection.South)))
            {
                yVel = 0;
            }
            else if (((playerX < 0) && (_moveDirection == MoveDirection.West)) ||
                      ((playerX > _tilemap.Resolution.X) && (_moveDirection == MoveDirection.East)))
            {
                xVel = 0;
            }

            // Check collisions with solid tiles
            //_tilemap.Collision()
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
        }

        private void Move(int xVel, int yVel) 
        {
            if (_camera.LockW)
            {
                if (_viewRect.X > 304)
                {
                    _camera.LockW = false;
                    _viewRect.X = 304;
                }
            }
            else if (_camera.LockE)
            {
                if (_viewRect.X < _camera.WorldRect.X + 304)
                {
                    _camera.LockE = false;
                    _viewRect.X = _camera.WorldRect.X + 304;
                }
            }

            if (_camera.LockN)
            {
                if (_viewRect.Y > 224)
                {
                    _camera.LockN = false;
                    _viewRect.Y = 224;
                }
            }
            else if (_camera.LockS)
            {
                if (_viewRect.Y < _camera.WorldRect.Y + 224)
                {
                    _camera.LockS = false;
                    _viewRect.Y = _camera.WorldRect.Y + 224;
                }
            }


            if (_camera.LockE)
            { 
                _viewRect.X += xVel * (int)_moveSpeed;
            }
            else if (_camera.LockW)
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

        private Rect WorldToView(Rect worldRect, Rect camRect) 
        {
            Rect viewRect = new Rect(0, 0, worldRect.X, worldRect.Y);

            viewRect.X = worldRect.X - _camera.ViewRect.X;
            viewRect.Y = worldRect.Y - _camera.ViewRect.Y;

            return viewRect;
        }
    }
}
