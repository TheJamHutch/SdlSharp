using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Camera : IMoveable
    {
        private Rect _worldRect;
        private Rect _viewRect;
        private MoveSpeed _moveSpeed = MoveSpeed.Medium;
        private MoveDirection _moveDirection = MoveDirection.None;
        private ITilemap _tilemap;

        public Camera(ITilemap tilemap, Rect posRect)
        {
            _worldRect = new Rect(posRect);
            _viewRect = new Rect(0, 0, posRect.W, posRect.H);
            _tilemap = tilemap;
        }

        public Rect WorldRect { get { return _worldRect; } }
        public Rect ViewRect { get { return _viewRect; } }
        public MoveDirection Direction { get { return _moveDirection; } set { _moveDirection = value; } }
        public MoveSpeed Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        public bool LockN { get; set; } = true;
        public bool LockE { get; set; } = false;
        public bool LockS { get; set; } = false;
        public bool LockW { get; set; } = true;

        public void Update()
        {
            _moveDirection.SetVelocities(out var xVel, out var yVel);

            if (!_tilemap.ScrollsX)
            {
                xVel = 0;
            }
            if (!_tilemap.ScrollsY)
            {
                yVel = 0;
            }

            Collision(ref xVel, ref yVel);
            Move(xVel, yVel);
        }

        private void Collision(ref int xVel, ref int yVel) 
        {
            // Stop camera going off edge of tilemap.
            if ((_worldRect.Y <= _tilemap.WorldRect.Y) && (_moveDirection == MoveDirection.North))
            {
                LockN = true;
                yVel = 0;
            }
            else if ((_worldRect.Y + _worldRect.H >= (_tilemap.WorldRect.H - (int)_tilemap.TilePixelSize)) && (_moveDirection == MoveDirection.South))
            {
                LockS = true;
                yVel = 0;
            }

            if (((_worldRect.X <= _tilemap.WorldRect.X) && (_moveDirection == MoveDirection.West)))
            {
               LockW = true;
                xVel = 0;
            }
            else if ((_worldRect.X + _worldRect.W >= (_tilemap.WorldRect.W - (int)_tilemap.TilePixelSize)) && (_moveDirection == MoveDirection.East))
            {
                LockE = true;
                xVel = 0;
            }
        }

        void Move(int xVel, int yVel)
        {
            if (!LockW && !LockE)
            {
                _worldRect.X += xVel * (int)_moveSpeed;
            }
            if (!LockN && !LockS)
            {
                _worldRect.Y += yVel * (int)_moveSpeed;
            }
        }
    }
}