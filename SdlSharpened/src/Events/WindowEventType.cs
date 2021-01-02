namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of window events.
    /// </summary>
    public enum WindowEventType
    {
        /// <summary> Never used. </summary>
        None = 0,
        /// <summary> window has been shown. </summary>
        Shown = 1,
        /// <summary> window has been hidden. </summary>+
        Hidden = 2,
        /// <summary> window has been exposed and should be redrawn. </summary>
        Exposed = 3,
        /// <summary> window has been moved to data1, data2. </summary>
        Moved = 4,
        /// <summary> Window has been resized to data1xdata2. </summary>
        /// <remarks> This event is always preceded by SizeChanged. </remarks>
        Resized = 5,
        /// <summary> . </summary>
        SizeChanged = 6,
        /// <summary> . </summary>
        Minimized = 7,
        /// <summary> . </summary>
        Maximized = 8,
        /// <summary> . </summary>
        Restored = 9,
        /// <summary> . </summary>
        Enter = 10,
        /// <summary> . </summary>
        Leave = 11,
        /// <summary> . </summary>
        FocusGained = 12,
        /// <summary> . </summary>
        FocusLost = 13,
        /// <summary> . </summary>
        Close = 14,
        /// <summary> . </summary>
        TakeFocus = 15,
        /// <summary> . </summary>
        HitTest = 16
        /// <summary> . </summary>
    }
}
