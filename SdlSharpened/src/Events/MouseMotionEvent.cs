using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   A structure that contains mouse motion event information.
    /// </summary>
    public class MouseMotionEvent
    {
        public int X { get { return Event.SdlEvent.motion.x; } }
        public int Y { get { return Event.SdlEvent.motion.y; } }
    }
}
