using SdlSharpened;

namespace SdlSharpened.App
{
    public class Camera
    {
        public Rect DstRect { get; set; }

        public MoveDirection Direction { get; set; }

        public Camera(int width, int height)
        {
            DstRect = new Rect(1, 1, width, height);
            Direction = MoveDirection.Stopped;
        }

        public void Update(Rect mapArea) 
        {
            int xVel = 0;
            int yVel = 0;

            Direction.SetVelocities(out xVel, out yVel);

            // Stop camera going off edge of tilemap
            if ((DstRect.X <= 0) && (Direction == MoveDirection.West))
            {
                xVel = 0;
            }
            else if ((DstRect.Y < 0) && (Direction == MoveDirection.North))
            {
                yVel = 0;
            }
            else if ((DstRect.X + DstRect.W >= mapArea.W - 32) && (Direction == MoveDirection.East))
            {
                xVel = 0;
            }
            else if ((DstRect.Y + DstRect.H >= mapArea.H - 32) && (Direction == MoveDirection.South))
            {
                yVel = 0;
            }

            DstRect.X += xVel * 3;
            DstRect.Y += yVel * 3;
        }
    }
}
