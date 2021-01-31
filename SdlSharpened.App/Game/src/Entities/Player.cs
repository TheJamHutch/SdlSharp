/* Player
** 
** Initial player position should be specified in game level save file. Hardcoded for now.
** Player sprite size/ clipRect size is specified in config.
** Only Player can unlock the camera in a particular direction by moving into center view.
*/
using System;
using System.Collections.Generic;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Player : IMoveable, IRenderable
    {
        private MoveDirection _moveDirection = MoveDirection.None;
        private MoveSpeed _moveSpeed;
        private Point _centerView;
        private Rect _worldRect;
        private ITilemap _tilemap;
        private Camera _camera;
        private Logger _logger;
        private Sprite _sprite;

        public Player(EntitiesConfig config, ITilemap tilemap, Camera camera, Logger logger)
        {
            // Set dependencies
            _tilemap = tilemap;
            _camera = camera;
            _logger = logger;

            _sprite = new Sprite(config.PlayerSheetPath, config.PlayerSpriteSize);
            _moveSpeed = config.PlayerMoveSpeed;

            Game.ReloadEvent += () => Init();
            Init();
        }

        public Rect WorldRect { get { return _worldRect; } }
        public Rect ViewRect { get { return _viewRect; } }
        public MoveDirection Direction { get { return _moveDirection; } set { _moveDirection = value; } }
        public MoveSpeed Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        public void Init() 
        {
            // Calculate where center view for the player sprite would be and assign to Rect.
            int centerX = _camera.ViewRect.X + (_camera.ViewRect.W / 2 - _sprite.ClipRect.W / 2);
            int centerY = _camera.ViewRect.Y + (_camera.ViewRect.H / 2 - _sprite.ClipRect.H / 2);
            _centerView = new Point(centerX, centerY);
            // Get player init position and use to init view and world Rects
            var initPos = new Point(centerX, centerY);
            _worldRect = new Rect(initPos.X - _camera.ViewRect.X, initPos.Y - _camera.ViewRect.Y, _sprite.ClipRect.W, _sprite.ClipRect.H);
            _viewRect = new Rect(initPos.X, initPos.Y, _sprite.ClipRect.W, _sprite.ClipRect.H);

            _logger.Info($"Player - Positioned player sprite on first available tile: {initPos.X}, {initPos.Y}");

            _sprite.SetAnimation("WalkSouth");
        }

        public void Render(Renderer renderer)
        {
            _sprite.Render(renderer);
        }

        public void Update()
        {
            bool collide = Collision();
            _sprite.Animate();
            Move(collide);
        }

        private bool Collision() 
        {
            return ( 
                    MapEdgeCollision() ||
                    TileCollision()

                    ) ? true : false;
        }

        private bool MapEdgeCollision()
        {
            return   (_worldRect.Y <= _tilemap.WorldRect.Y) && (_moveDirection == MoveDirection.North) ||
                     (_worldRect.X <= _tilemap.WorldRect.X) && (_moveDirection == MoveDirection.West) ||
                     // TODO: Get rid of these literals
                    ((_worldRect.Y + _worldRect.H + 20) >= _tilemap.WorldRect.H) && (_moveDirection == MoveDirection.South) ||
                    ((_worldRect.X + _worldRect.W + 10) >= _tilemap.WorldRect.W) && (_moveDirection == MoveDirection.East)

                    ? true : false;
        }

        private bool TileCollision()
        {
        /*
            var localTiles = _tilemap.LocalTiles(new Point(_worldRect.X + 16, _worldRect.Y + 16));
            bool result = false;

            foreach (var tile in localTiles)
            {
                //Console.WriteLine(tile.WorldRect);
            /*
                if (tile.Effect == TileEffect.Solid) 
                {
                    if (_worldRect.IntersectsWith(tile.WorldRect, out var resultRect))
                    {
                        Console.WriteLine("Collsion\n");
                    }
                }
                */
            //}
            //Console.WriteLine();

            return false;
        }

       

        private void Move(bool collide) 
        {
            // Determine whether tilemap is big enough that it needs to scroll, X or Y ways.
            bool scrollsX = (_camera.ViewRect.W < _tilemap.WorldRect.W);
            bool scrollsY = (_camera.ViewRect.H < _tilemap.WorldRect.H);

            if (scrollsX)
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
            }

            if (scrollsY) 
            {
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
