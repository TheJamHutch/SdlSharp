using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Enemy : IMoveable, IRenderable
    {
        Rect IMoveable.WorldRect { get { return _worldRect; } }
        Rect IMoveable.ViewRect { get { return _viewRect; } }
        MoveDirection IMoveable.Direction { get { return _moveDirection; } set { _moveDirection = value; } }
        MoveSpeed IMoveable.Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        private Rect _worldRect;
        private Rect _viewRect;
        private MoveDirection _moveDirection = MoveDirection.Stopped;
        private MoveSpeed _moveSpeed = MoveSpeed.Slow;
        private SpriteSheet _spriteSheet;

        public Enemy()
        {

        }

        void Update() 
        {

        }

        void IRenderable.Render()
        {

        }

        void Animate()
        {
            
        }

        void Move()
        {
            
        }
    }
}