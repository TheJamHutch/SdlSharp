using System;

namespace SdlSharpened
{
    public class PressAction
    {
        private static Action _noop = (() => { });

        public Action DownAction { get; set; }

        public Action UpAction { get; set; }

        public PressAction(Action downAction, Action upAction)
        {
            DownAction = downAction ?? _noop;
            UpAction = upAction ?? _noop;
        }
    }
}