using System;

namespace SdlSharpened
{
    public struct PressAction
    {
        private static Action _noop = (() => { });

        public Action DownAction { get; set; }

        public Action UpAction { get; set; }

        public PressAction(Action downAction, Action upAction = null)
        {
            DownAction = downAction ?? _noop;
            UpAction = upAction ?? _noop;
        }
    }
}