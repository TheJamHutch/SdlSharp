namespace SdlSharpened.App
{
    public interface IMoveable
    {
        Rect WorldRect { get; }
        Rect ViewRect { get; }
        MoveDirection Direction { get; set; }
        MoveSpeed Speed { get; set; }
    }
}
