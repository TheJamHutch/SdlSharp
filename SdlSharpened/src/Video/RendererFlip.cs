namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of flags that can be used in the flip parameter for Renderer.CopyEx.
    /// </summary>
    /// <remarks>
    ///   If you want to do a diagonal flip (both horizontal and vertical), use bitwise or ('|' operator).
    /// </remarks>
    public enum RendererFlip
    {
        /// <summary>
        ///   Do not flip.
        /// </summary>
        FlipNone = 0x00000000,
        /// <summary>
        ///   Flip horizontally.
        /// </summary>
        FlipHorizontal = 0x00000001,
        /// <summary>
        ///   Flip vertically.
        /// </summary>
        FlipVertical = 0x00000002
    }
}
