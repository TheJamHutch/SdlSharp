using System;

namespace SdlSharp
{
    public class KeyPressAction
    {
        private static readonly Action _noop = (() => { });

        public Action DownAction { get; set; }

        public Action UpAction { get; set; }

        public KeyPressAction(Action downAction, Action upAction)
        {
            DownAction = downAction ?? _noop;
            UpAction = upAction ?? _noop;
        }
    }
}