using System;
using SDL2;

// TODO: Add tag comments from SDL wiki

namespace SdlSharpened
{
    /// <summary>
    ///   An enumeration of the types of events that can be delivered.
    /// </summary>
    public enum EventType
    {
        /// <summary> Do not remove (unused). </summary>
        FirstEvent = 0,
        /// <summary> User-requested quit. </summary>
        Quit = 0x100,
        /// <summary> OS is terminating the application. </summary>
        AppTerminating = 257,
        /// <summary> OS is low on memory; free some. </summary>
        AppLowMemory = 258,
        /// <summary> Application is entering background. </summary>
        AppEnteringBackground = 259,
        /// <summary> Application entered background. </summary>
        AppEnteredBackground = 260,
        /// <summary> Application is entering foreground. </summary>
        AppEnteringForeground = 261,
        /// <summary> Application entered foreground. </summary>
        AppEnteredForeground = 262,
        /// <summary> Window state change. </summary>
        WindowEvent = 0x200,
        /// <summary> System specific event. </summary>
        WindowManagementEvent = 513,
        /// <summary> Key pressed. </summary>
        KeyDown = 0x300,
        /// <summary> Key released. </summary>
        KeyUp = 769,
        /// <summary> Keyboard text editing (composition). </summary>
        TextEditing = 770,
        /// <summary> Keyboard text input. </summary>
        TextInput = 771,
        /// <summary>  
        ///   Keymap changed due to a system event such as an input language or keyboard layout change.
        /// </summary>
        KeyMapChanged = 772,
        /// <summary> Mouse moved. </summary>
        MouseMotion = 0x400,
        /// <summary> Mouse button pressed. </summary>
        MouseButtonDown = 1025,
        /// <summary> Mouse button released. </summary>
        MouseButtonUp = 1026,
        /// <summary> Mouse wheel motion. </summary>
        MouseWheel = 1027,
        /// <summary> Joystick axis motion. </summary>
        JoyAxisMotion = 0x600,
        /// <summary> Joystick trackball motion. </summary>
        JoyBallMotion = 1537,
        /// <summary> Joystick hat position change. </summary>
        JoyHatMotion = 1538,
        /// <summary>  </summary>
        JoyButtonDown = 1539,
        /// <summary>  </summary>
        JoyButtonUp = 1540,
        /// <summary>  </summary>
        JoyDeviceAdded = 1541,
        /// <summary>  </summary>
        JoyDeviceRemoved = 1542,
        /// <summary>  </summary>
        ControllerAxisMotion = 0x650,
        /// <summary>  </summary>
        ControllerButtonDown = 1617,
        /// <summary>  </summary>
        ControllerButtonUp = 1618,
        /// <summary>  </summary>
        ControllerDeviceAdded = 1619,
        /// <summary>  </summary>
        ControllerDeviceRemoved = 1620,
        /// <summary>  </summary>
        ControllerDeviceRemapped = 1621,
        /// <summary>  </summary>
        FingerDown = 0x700,
        /// <summary>  </summary>
        FingerUp = 1793,
        /// <summary>  </summary>
        FingerMotion = 1794,
        /// <summary>  </summary>
        DollarGesture = 0x800,
        /// <summary>  </summary>
        DollarRecord = 2049,
        /// <summary>  </summary>
        MultiGesture = 2050,
        /// <summary>  </summary>
        ClipboardUpdate = 0x900,
        /// <summary>  </summary>
        DropFile = 0x1000,
        /// <summary>  </summary>
        DropText = 4097,
        /// <summary>  </summary>
        DropBegin = 4098,
        /// <summary>  </summary>
        DropComplete = 4099,
        /// <summary>  </summary>
        AudioDeviceAdded = 0x1100,
        /// <summary>  </summary>
        AudioDeviceRemoved = 4353,
        /// <summary>  </summary>
        RenderTargetsReset = 0x2000,
        /// <summary>  </summary>
        RenderDeviceReset = 8193,
        /// <summary>  </summary>
        UserEvent = 0x8000,
        /// <summary>  </summary>
        LastEvent = 0xFFFF
    }
}
