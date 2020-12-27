using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Camera : IMoveable
    {
        public Rect WorldRect { get { return _worldRect; } }
        public Rect ViewRect { get { return _viewRect; } }
        public MoveDirection Direction { get { return _moveDirection; } set { _moveDirection = value; } }
        public MoveSpeed Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        public bool LockN { get; set; } = false;
        public bool LockE { get; set; } = false; 
        public bool LockS { get; set; } = false; 
        public bool LockW { get; set; } = false;

        private Rect _worldRect;
        private Rect _viewRect;
        private MoveSpeed _moveSpeed = MoveSpeed.Slow;
        private MoveDirection _moveDirection = MoveDirection.None;
        private ITilemap _tilemap;

        public Camera(ITilemap tilemap)
        {
            _worldRect = new Rect(1, 1, Config.WindowXres, Config.WindowYres);
            _viewRect = new Rect(0, 0, Config.WindowXres, Config.WindowYres);
            _tilemap = tilemap;
        }

        public void Update()
        {
            _moveDirection.SetVelocities(out var xVel, out var yVel);
            Collision(ref xVel, ref yVel);
            Move(xVel, yVel);
        }

        private void Collision(ref int xVel, ref int yVel) 
        {
            // Stop camera going off edge of tilemap
            if ((_worldRect.Y <= 0) && (_moveDirection == MoveDirection.North))
            {
                LockN = true;
                yVel = 0;
            }
            else if ((_worldRect.Y + _worldRect.H >= (_tilemap.Resolution.Y - (int)Config.TilemapTileSize)) && (_moveDirection == MoveDirection.South))
            {
                LockS = true;
                yVel = 0;
            }
            if (((_worldRect.X <= 0) && (_moveDirection == MoveDirection.West)))
            {
                LockW = true; Console.WriteLine("CAMERA COLLIDED WEST");
                xVel = 0;
            }
            else if ((_worldRect.X + _worldRect.W >= (_tilemap.Resolution.X - (int)Config.TilemapTileSize)) && (_moveDirection == MoveDirection.East))
            {
                LockE = true;
                xVel = 0;
            }
        }

        void Move(int xVel, int yVel)
        {
            if (!LockW)
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