using System;

namespace SdlSharpened
{
    public class KeyboardAction
    {
        private static Action _noop = (() => { });

        public Action DownAction { get; set; }

        public Action UpAction { get; set; }

        public KeyboardAction(Action downAction, Action upAction)
        {
            DownAction = downAction ?? _noop;
            UpAction = upAction ?? _noop;
        }
    }
}