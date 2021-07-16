using System;
using SDL2;

namespace SdlSharpened
{
    public class MouseButtonEvent
    {
        public int X { get { return Event.SdlEvent.button.x; } }
        public int Y { get { return Event.SdlEvent.button.y; } }
    }
}
