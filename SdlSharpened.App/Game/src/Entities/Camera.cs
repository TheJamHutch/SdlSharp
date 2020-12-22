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

        public bool Locked { get { return _locked; } set { _locked = value; } }

        private Rect _worldRect;
        private Rect _viewRect;
        private MoveSpeed _moveSpeed = MoveSpeed.Slow;
        private MoveDirection _moveDirection = MoveDirection.Stopped;
        private bool _locked = false;
        private ITilemap _tilemap;

        public Camera(ITilemap tilemap)
        {
            _worldRect = new Rect(1, 1, Config.WindowXres, Config.WindowYres);
            _viewRect = new Rect(0, 0, Config.WindowXres, Config.WindowYres);
            _tilemap = tilemap;
        }

        public void Update()
        {
            Move();
        }

        void Move() 
        {
            _moveDirection.SetVelocities(out var xVel, out var yVel);

            // Stop camera going off edge of tilemap
            if ( ((_worldRect.Y <= 0) && (_moveDirection == MoveDirection.North)) || 
                 ((_worldRect.Y + _worldRect.H >= _tilemap.Resolution.Y - 32) && (_moveDirection == MoveDirection.South)) )
            {
                yVel = 0;
                _locked = true;
            }
            else if ( ((_worldRect.X <= 0) && (_moveDirection == MoveDirection.West)) || 
                      ((_worldRect.X + _worldRect.W >= _tilemap.Resolution.X - 32) && (_moveDirection == MoveDirection.East)) )
            {
                xVel = 0;
                _locked = true;
            }


            if (!_locked)
            {
                _worldRect.X += xVel * (int)_moveSpeed;
                _worldRect.Y += yVel * (int)_moveSpeed;
            }
        }
    }
}