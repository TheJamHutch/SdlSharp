using System;
using SDL2;

namespace SdlSharp
{
    public static class Global
    {
        public static IntPtr WindowPointer { get; set; }

        public static IntPtr RendererPointer { get; set; }
    }
}
