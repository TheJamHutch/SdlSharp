namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of window events.
    /// </summary>
    public enum WindowEventType
    {
        /// <summary> 
        ///   Never used. 
        /// </summary>
        None = 0,
        /// <summary> Window has been shown. </summary>
        Shown = 1,
        /// <summary> Window has been hidden. </summary>+
        Hidden = 2,
        /// <summary> Window has been exposed and should be redrawn. </summary>
        Exposed = 3,
        /// <summary> Window has been moved to data1, data2. </summary>
        Moved = 4,
        /// <summary> Window has been resized to data1xdata2. </summary>
        /// <remarks> This event is always preceded by SizeChanged. </remarks>
        Resized = 5,
        /// <summary> Window size has changed, either as a result of an API call or through the system or user changing the window size. </summary>
        /// <remarks> This event is followed by WindowEventType.Resized if the size was changed by an external event, i.e. the user or the window manager. </remarks>
        SizeChanged = 6,
        /// <summary> Window has been minimized. </summary>
        Minimized = 7,
        /// <summary> Window has been maximized. </summary>
        Maximized = 8,
        /// <summary> Window has been restored to normal size and position. </summary>
        Restored = 9,
        /// <summary> Window has gained mouse focus. </summary>
        Enter = 10,
        /// <summary> Window has lost mouse focus. </summary>
        Leave = 11,
        /// <summary> Window has gained keyboard focus. </summary>
        FocusGained = 12,
        /// <summary> Window has lost keyboard focus. </summary>
        FocusLost = 13,
        /// <summary> The window manager requests that the window be closed. </summary>
        Close = 14,
        /// <summary> Window is being offered a focus. </summary>
        /// <remarks> Should SDL_SetWindowInputFocus() on itself or a subwindow, or ignore) (>= SDL 2.0.5)</remarks>
        TakeFocus = 15,
        /// <summary> Window had a hit test that wasn't SDL_HITTEST_NORMAL (>= SDL 2.0.5). </summary>
        HitTest = 16
    }
}
