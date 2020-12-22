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
        private MoveDirection _moveDirection = MoveDirection.Stopped;
        private MoveSpeed _moveSpeed = MoveSpeed.Slow;
        private SpriteSheet _spriteSheet;
        private ITilemap _tilemap;
        private Camera _camera;

        public Player(ITilemap tilemap, Camera camera)
        {
            // Get player sprite pixel size from config
            int pixelSize = Config.PlayerSpriteSize;
            // Calculate to place player in center of camera
            int centerX = camera.WorldRect.X + (camera.WorldRect.W / 2 - pixelSize / 2);
            int centerY = camera.WorldRect.Y + (camera.WorldRect.H / 2 - pixelSize / 2);

            _spriteSheet = new SpriteSheet(Config.SpritesheetPlayer, new Point(pixelSize, pixelSize), Config.TransparentColour);
            _worldRect = new Rect(304, 224, pixelSize, pixelSize);
            _viewRect = new Rect(304, 224, pixelSize, pixelSize);
            _tilemap = tilemap;
            _camera = camera;
        }

        public void Update()
        {
            Collision();
            Animate();
            Move();
        }

        public void Render()
        {
            Game.RendererInstance.Copy(_spriteSheet.SheetTexture, _spriteSheet.SheetFrame, _worldRect);
        }

        private void Collision() 
        {
        
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
                case MoveDirection.Stopped:
                    break;
            }
        }

        private void Move() 
        {
            _moveDirection.SetVelocities(out var xVel, out var yVel);

            int playerX = _viewRect.X;
            int playerY = _viewRect.Y;

            // Stop player going off edge of tilemap
            if ( ((playerY < 0) && (_moveDirection == MoveDirection.North)) || 
                 ((playerY + 32 >= _tilemap.Resolution.Y - 32) && (_moveDirection == MoveDirection.South)) )
            {
                yVel = 0;
            }
            else if ( ((playerX < 0) && (_moveDirection == MoveDirection.West)) || 
                      ((playerX > _tilemap.Resolution.X) && (_moveDirection == MoveDirection.East)) )
            {
                xVel = 0;
            }

            if (_camera.Locked)
            {
                if ((playerX >= (640 / 2)) || playerY >= (480 / 2))
                {
                    _camera.Locked = false;
                }
            }

            if (_camera.Locked)
            {
                if (!_tilemap.Collision(_camera, this))
                {
                    _viewRect.X += xVel * (int)_moveSpeed;
                    _viewRect.Y += yVel * (int)_moveSpeed;
                }
            }
        }
    }
}
