using System;
using SDL2;

namespace SdlSharpened
{
    internal class MouseWheelEvent
    {
        private uint _type;
        private uint _timestamp;
        private uint _windowId;
        private uint _which;
        private int _x;
        private int _y;
        private uint _direction;

        internal MouseWheelEvent()
        {

        }
    }
}
