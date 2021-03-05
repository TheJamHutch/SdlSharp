namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of flags used when creating a rendering context.
    /// </summary>
    public enum RendererFlags 
    {
        /// <summary>
        ///   The renderer is a software fallback.
        /// </summary>
        Software = 0x00000001,
        /// <summary>
        ///   The renderer uses hardware acceleration.
        /// </summary>
        Accelerated = 0x00000002,
        /// <summary>
        ///   Present is synchronized with the refresh rate.
        /// </summary>
        PresentVSync = 0x00000004,
        /// <summary>
        ///   The renderer supports rendering to texture.
        /// </summary>
        TargetTexture = 0x00000008,
    }
}
