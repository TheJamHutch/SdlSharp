namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of blend modes used in Renderer.Copy() and drawing operations.
    /// </summary>
    public enum BlendMode
    {
        /// <summary>
        ///   No blending.
        /// </summary>
        None = 0x00000000,
        /// <summary>
        ///   Alpha blending.
        /// </summary>
        Blend = 0x00000001,
        /// <summary>
        ///   Additive blending.
        /// </summary>
        Add = 0x00000002,
        /// <summary>
        ///   Color modulate.
        /// </summary>
        Mod = 0x00000004,
        /// <summary>
        ///   Multiply.
        /// </summary>
        Mul = 0x000000048,
        /// <summary>
        ///   Invalid blending.
        /// </summary>
        Invalid = 0x7FFFFFFF,
    }
}
