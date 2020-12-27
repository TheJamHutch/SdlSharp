using System;
using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of texture access patterns;
    /// </summary>
    public enum TextureAccess
    {
        /// <summary> Changes rarely, not lockable. </summary>
        Static = 0,
        /// <summary> Changes frequently, lockable. </summary>
        Streaming = 1,
        /// <summary> Can be used as a render target. </summary>
        Target = 2
    }
}
