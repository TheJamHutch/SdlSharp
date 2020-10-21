using System;
using SDL2;

namespace SdlSharpened
{
    internal static class Global
    {
        internal static IntPtr WindowPointer { get; set; }

        internal static IntPtr RendererPointer { get; set; }
    }
}
