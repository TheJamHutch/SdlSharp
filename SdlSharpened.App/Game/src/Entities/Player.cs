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
    public class Animation 
    {
        // The X, Y cell position that the animation should start from on the tilesheet.
        public Point StartPos { get; }
        // The number of cells in the animation. One frame of animation is a still image. Need two for it to be animated. Zero will play all animation cells, never use.
        public int CellCount { get; }
        // The number of frames to wait for before progressing to the next animation cell.
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
        private MoveSpeed _moveSpeed;
        private Point _centerView;
        private Rect _worldRect;
        private Rect _viewRect;
        private Rect _clipRect;
        private ITilemap _tilemap;
        private Camera _camera;
        private Texture _texture;

        private Point _spriteSize;

        private Logger _logger;

        private Animation _currentAnimation;

        private Dictionary<string, Animation> _animationDictionary = new Dictionary<string, Animation>()
        {
            // Directional idle animations
            { "IdleSouth", new Animation(new Point(0, 0), 1, 3) },
            { "IdleEast", new Animation(new Point(0, 1), 1, 3) },
            { "IdleNorth", new Animation(new Point(0, 2), 1, 3) },
            { "IdleWest", new Animation(new Point(0, 3), 1, 3) },
            // Directional walking animations
            { "WalkSouth", new Animation(new Point(0, 0), 0, 8) },
            { "WalkEast", new Animation(new Point(0, 1), 5, 3) },
            { "WalkNorth", new Animation(new Point(0, 2), 5, 3) },
            { "WalkWest", new Animation(new Point(0, 3), 5, 3) }
        };

        public Player(EntitiesConfig config, ITilemap tilemap, Camera camera, Logger logger)
        {
            // Set dependencies
            _tilemap = tilemap;
            _camera = camera;
            _logger = logger;

            // Set values from config
            _texture = new Texture(config.PlayerSheetPath, ColourType.Magenta);
            _spriteSize = new Point(config.PlayerSpriteSize);
            _clipRect = new Rect(0, 0, _spriteSize.X, _spriteSize.Y);
            _moveSpeed = config.PlayerMoveSpeed;

            Init();
            Game.ReloadEvent += () => Init();
        }

        public Rect WorldRect { get { return _worldRect; } }
        public Rect ViewRect { get { return _viewRect; } }
        public MoveDirection Direction { get { return _moveDirection; } set { _moveDirection = value; } }
        public MoveSpeed Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        public void Init() 
        {
            // Calculate where center view for the player sprite would be and assign to Rect.
            int centerX = _camera.ViewRect.X + (_camera.ViewRect.W / 2 - _spriteSize.X / 2);
            int centerY = _camera.ViewRect.Y + (_camera.ViewRect.H / 2 - _spriteSize.Y / 2);
            _centerView = new Point(centerX, centerY);
            // Get player init position and use to init view and world Rect's
            var initPos = new Point(centerX, centerY);
            _worldRect = new Rect(initPos.X - _camera.ViewRect.X, initPos.Y - _camera.ViewRect.Y, _spriteSize.X, _spriteSize.Y);
            _viewRect = new Rect(initPos.X, initPos.Y, _spriteSize.X, _spriteSize.Y);

            _logger.Info($"Player - Positioned player sprite on first available tile: {initPos.X}, {initPos.Y}");

            _currentAnimation = _animationDictionary["WalkSouth"];
        }

        public void Render(Renderer renderer)
        {
            renderer.Copy(_texture, _clipRect, _viewRect);
        }

        public void Update()
        {

            /*
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
                    case MoveDirection.West:
                        _currentAnimation = _animationDictionary["WalkWest"];
                        break;
                    default:
                        _currentAnimation = _animationDictionary["default"];
                        break;
                }*/

            bool collide = Collision();

            Animate();
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

        private int _frameCounter = 0;
        private int _cellCounter = 0;

        private void Animate() 
        {
            // By my calculations, this will take ~ 2.2 years to overflow
            _frameCounter++;

            // On animation start/ restart
            if (_cellCounter == 0)
            {
                SetFrame(_currentAnimation.StartPos);
               //_cellCounter++;
            }

            if (_frameCounter % _currentAnimation.WaitFrames == 0)
            {
                _cellCounter++;
                if (_cellCounter == _currentAnimation.CellCount)
                {
                    _cellCounter = 0;
                }
                else 
                {
                    NextFrame();
                }

                
            }

            

            
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
