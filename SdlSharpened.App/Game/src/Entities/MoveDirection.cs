namespace SdlSharpened.App
{
    public enum MoveDirection
    {
        Stopped = 0,
        North,
        East,
        South,
        West
    }

    public static class MoveDirectionExtension
    {
        public static void SetVelocities(this MoveDirection moveDirection, out int xVel, out int yVel)
        {
            switch (moveDirection)
            {
                case MoveDirection.Stopped:
                    xVel = 0;
                    yVel = 0;
                    break;
                case MoveDirection.North:
                    xVel = 0;
                    yVel = -1;
                    break;
                case MoveDirection.East:
                    xVel = 1;
                    yVel = 0;
                    break;
                case MoveDirection.South:
                    xVel = 0;
                    yVel = 1;
                    break;
                case MoveDirection.West:
                    xVel = -1;
                    yVel = 0;
                    break;
                default:
                    xVel = 0;
                    yVel = 0;
                    break;
            }
        }
    }
}
