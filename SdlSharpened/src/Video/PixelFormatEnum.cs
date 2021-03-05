using SDL2;

namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of pixel formats.
    /// </summary>
    public enum PixelFormatEnum
    {
        Unknown,
        Index_1LSB,
        Index_1M1SB,
        Index_4LSB,
        Index_4MSB,
        Index_8,
        RGB332,
        RGB444,
        RGB555,
        BGR555,
        ARGB4444,
        RGBA4444,
        ABGR4444,
        BGRA4444,
        ARGB1555,
        RGBA5551,
        ABGR1555,
        BGRA5551,
        RGB565,
        BGR565,
        RGB24,
        BGR24,
        RGB888,
        RGBX8888,
        BGR888,
        BGRX8888,
        ARGB8888,
        RGBA8888,
        ABGR8888,
        BGRA8888,
        ARGB2101010,
        /// <summary>
        ///   Alias for RGBA byte array of color data, for the current platform.
        /// </summary>
        RGBA32,
        /// <summary>
        ///   Alias for ARGB byte array of color data, for the current platform.
        /// </summary>
        ARGB32,
        /// <summary>
        ///   Alias for BGRA byte array of color data, for the current platform.
        /// </summary>
        BGRA32,
        /// <summary>
        ///   Alias for ABGR byte array of color data, for the current platform.
        /// </summary>
        ABGR32,
        /// <summary>
        ///   Planar mode: Y + V + U (3 planes).
        /// </summary>
        YV12,
        /// <summary>
        ///   Planar mode: Y + U + V (3 planes).
        /// </summary>
        IYUV,
        /// <summary>
        ///   Packed mode: Y0+U0+Y1+V0 (1 plane).
        /// </summary>
        YUY2,
        /// <summary>
        ///   Packed mode: U0+Y0+V0+Y1 (1 plane).
        /// </summary>
        UYVY,
        /// <summary>
        ///   Packed mode: Y0+V0+Y1+U0 (1 plane).
        /// </summary>
        YVYU,
        /// <summary>
        ///   Planar mode: Y + U/V interleaved (2 planes).
        /// </summary>
        NV12,
        /// <summary>
        ///   Planar mode: Y + V/U interleaved (2 planes).
        /// </summary>
        NV21
    }
}
