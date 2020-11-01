using System;
using SdlSharpened;

namespace SdlSharpened.App
{
    public class Player : IRenderable
    {
        public MoveDirection Direction { get; set; }

        private Texture _texture;
        private Rect _srcRect;
        private Rect _dstRect;

        public Player()
        {
            Direction = MoveDirection.Stopped;

            _texture = new Texture("./img/player.bmp", ColourType.Magenta);
            _srcRect = new Rect(0, 0, 32, 32);
            _dstRect = new Rect(320, 240, 32, 32);
        }

        public void Update(Rect mapArea)
        {
            Move(mapArea);
        }

        public void Attack() 
        {
            Console.WriteLine("Player Attacked.");
        }

        void IRenderable.Render(Renderer renderer, Camera camera)
        {
            renderer.Copy(_texture, _srcRect, _dstRect);
        }

        private void Move(Rect mapArea) 
        {
            int xVel = 0;
            int yVel = 0;

            Direction.SetVelocities(out xVel, out yVel);

            // Map edge
            if ((_dstRect.X < 0) && (Direction == MoveDirection.West))
            {
                xVel = 0;
            }
            else if ((_dstRect.Y < 0) && (Direction == MoveDirection.North))
            {
                yVel = 0;
            }
            else if ((_dstRect.X + _dstRect.W >= mapArea.W - 30) && (Direction == MoveDirection.East))
            {
                xVel = 0;
            }
            else if ((_dstRect.Y + _dstRect.H >= mapArea.H) && (Direction == MoveDirection.South))
            {
                yVel = 0;
            }

            // Enemy collision

            _dstRect.X += xVel * 2;
            _dstRect.Y += yVel * 2;
        }
    }
}
