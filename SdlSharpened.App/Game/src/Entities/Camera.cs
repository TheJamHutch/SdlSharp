using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Camera : IMoveable
    {
        private Rect _worldRect;
        private Rect _viewRect;

        private MoveSpeed _moveSpeed;
        private MoveDirection _moveDirection = MoveDirection.None;

        private ITilemap _tilemap;

        private Logger _logger;

        public Camera(EntitiesConfig config, ITilemap tilemap, Rect viewRect, Logger logger)
        {
            _tilemap = tilemap;
            _logger = logger;

            // Set camera's init movement speed. Read from config.
            _moveSpeed = config.CameraMoveSpeed;
            _viewRect = viewRect;

            Init();
            Game.ReloadEvent += () => Init();
        }

        public Rect WorldRect { get { return _worldRect; } }
        public Rect ViewRect { get { return _viewRect; } }

        public MoveDirection Direction { get { return _moveDirection; } set { _moveDirection = value; } }
        public MoveSpeed Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        public bool LockN { get; set; } = false;
        public bool LockE { get; set; } = false;
        public bool LockS { get; set; } = false;
        public bool LockW { get; set; } = false;

        public void Init() 
        {
            //int mapX = (_tilemap.ScrollsX) ? _tilemap.WorldRect.X : 0;
            //int mapY = (_tilemap.ScrollsY) ? _tilemap.WorldRect.Y : 0;

            _worldRect = new Rect(0, 0, _viewRect.W, _viewRect.H);

            InitLocks();

            if (AllLocked())
            {
                _logger.Info("Camera locked in all directions.");
            }
        }

        public void Update()
        {
            Collision();
            Move();
        }

        private void Collision() 
        {
            // Stop camera going off edge of tilemap.
            if ((_worldRect.Y <= _tilemap.WorldRect.Y) && (_moveDirection == MoveDirection.North))
            {
                LockN = true;
            }
            else if ((_worldRect.Y + _worldRect.H >= (_tilemap.WorldRect.H - (int)_tilemap.TilePixelSize)) && (_moveDirection == MoveDirection.South))
            {
                LockS = true;
            }

            if (((_worldRect.X <= _tilemap.WorldRect.X) && (_moveDirection == MoveDirection.West)))
            {
               LockW = true;
            }
            else if ((_worldRect.X + _worldRect.W >= (_tilemap.WorldRect.W - (int)_tilemap.TilePixelSize)) && (_moveDirection == MoveDirection.East))
            {
                LockE = true;
            }
        }

        private void Move()
        {
            _moveDirection.SetVelocities(out var xVel, out var yVel);

            if (!LockW && !LockE)
            {
                _worldRect.X += xVel * (int)_moveSpeed;
            }
            if (!LockN && !LockS)
            {
                _worldRect.Y += yVel * (int)_moveSpeed;
            }
        }

        // Init the directional camera locks. Camera is locked in a particular direction if camera
        // position is already beyond bounds of tilemap. Camera is also locked both ways across a particular
        // axis if the tilemap cannot scroll that way.
        private void InitLocks() 
        {
            LockN = (!_tilemap.ScrollsY) || (_worldRect.Y <= _tilemap.WorldRect.Y) ? true : false;
            LockW = (!_tilemap.ScrollsX) || (_worldRect.X <= _tilemap.WorldRect.Y) ? true : false;
            LockE = (!_tilemap.ScrollsX) || (_worldRect.X + _worldRect.W <= _tilemap.WorldRect.Y) ? true : false;
            LockS = (!_tilemap.ScrollsY) || (_worldRect.Y + _worldRect.H <= _tilemap.WorldRect.Y) ? true : false;
        }

        private bool AllLocked() 
        {
            return (LockN && LockE && LockS && LockW);
        }
    }
}