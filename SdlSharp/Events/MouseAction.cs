using System;

namespace SdlSharp
{
    public static class MouseAction
    {
        public static Action<int, int> Move { get; set; } = null;

        public static Action<int, int> ButtonDown { get; set; } = null;

        public static Action<int, int> ButtonUp { get; set; } = null;
    }
}