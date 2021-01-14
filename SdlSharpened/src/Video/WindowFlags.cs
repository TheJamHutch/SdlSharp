namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of window states.
    /// </summary>
    /// <remarks>
    ///   The 'OpenGL' flag prepares your window for use with OpenGL, but you will still need to create an OpenGL context 
    ///   using SDL_GL_CreateContext() after window /creation, before calling any OpenGL functions.
    /// </remarks>
    /// 
    // TODO: Change reference to SDL_GL_CreateContext() in 'remarks' tag to SdlSharpened version.

    public enum WindowFlags
    {
        /// <summary>
        ///   Fullscreen window.
        /// </summary>
        Fullscreen = 0x00000001,
        /// <summary>
        ///   Fullscreen window at the current desktop resolution.
        /// </summary>
        FullscreenDesktop = 0x00001000,
        /// <summary>
        ///   Window usable with OpenGL context.
        /// </summary>
        OpenGL = 0x00000002,
        /// <summary>
        ///   Window usable with a Vulkan instance.
        /// </summary>
        Vulkan = 0x10000000,
        /// <summary>
        ///   Window usable with a Vulkan instance.
        /// </summary>
        Shown = 0x00000004,
        /// <summary>
        ///   Window is not visible.
        /// </summary>
        Hidden = 0x00000008,
        /// <summary>
        ///   No window decoration.
        /// </summary>
        Borderless = 0x00000010,
        /// <summary>
        ///   Window can be resized.
        /// </summary>
        Resizeable = 0x00000020,
        /// <summary>
        ///   Window is minimized.
        /// </summary>
        Minimized = 0x00000040,
        /// <summary>
        ///   Window is maximized.
        /// </summary>
        Maximized = 0x00000080,
        /// <summary>
        ///   Window has grabbed input focus.
        /// </summary>
        InputGrabbed = 0x00000100,
        /// <summary>
        ///   Window has input focus.
        /// </summary>
        InputFocus = 0x00000200,
        /// <summary>
        ///   Window has mouse focus.
        /// </summary>
        MouseFocus = 0x00000400,
        /// <summary>
        ///   Window not created by SDL.
        /// </summary>
        Foreign = 0x00000800,
        /// <summary>
        ///   Window should be created in high-DPI mode if supported (>= SDL 2.0.1).
        /// </summary>
        AllowHighDPI = 0x00002000,
        /// <summary>
        ///   Window has mouse captured (unrelated to INPUT_GRABBED, >= SDL 2.0.4).
        /// </summary>
        MouseCapture = 0x00004000,
        /// <summary>
        ///   Window should always be above others (X11 only, >= SDL 2.0.5).
        /// </summary>
        AlwaysOnTop = 0x00008000,
        /// <summary>
        ///   Window should not be added to the taskbar (X11 only, >= SDL 2.0.5).
        /// </summary>
        SkipTaskbar = 0x00010000,
        /// <summary>
        ///   Window should be treated as a utility window (X11 only, >= SDL 2.0.5).
        /// </summary>
        Utility = 0x00020000,
        /// <summary>
        ///   Window should be treated as a tooltip (X11 only, >= SDL 2.0.5).
        /// </summary>
        Tooltip = 0x00040000,
        /// <summary>
        ///   Window should be treated as a popup menu (X11 only, >= SDL 2.0.5).
        /// </summary>
        PopupMenu = 0x00080000
    }
}
