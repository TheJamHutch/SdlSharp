﻿using System;

namespace SdlSharpened
{
    public class MouseHandler : IHandler
    {
        //
        private static readonly Action<int, int> noop = (x, y) => { };

        private Action<int, int> _buttonDownAction = noop;
        private Action<int, int> _buttonUpAction = noop;
        private Action<int, int> _moveAction = noop;

        public MouseHandler()
        {
            Eventing.MouseHandlerInstance = this;
        }

        /// <summary>
        ///   Registers the action to invoke when a mouse button down event occurs, to the event handler.
        /// </summary>
        /// <param name="action"></param>
        public void OnButtonDown(Action<int, int> action)
        {
            _buttonDownAction = action;
        }

        /// <summary>
        ///   Registers the action to invoke when a mouse button up event occurs, to the event handler.
        /// </summary>
        /// <param name="action"></param>
        public void OnButtonUp(Action<int, int> action)
        {
            _buttonDownAction = action;
        }

        /// <summary>
        ///   Registers the action to invoke when a mouse move event occurs, to the event handler.
        /// </summary>
        /// <param name="action"></param>
        public void OnMove(Action<int, int> action)
        {
            _moveAction = action;
        }

        internal void InvokeButtonDownAction(int mx, int my) 
        {
            _buttonDownAction?.Invoke(mx, my);
        }

        internal void InvokeButtonUpAction(int mx, int my) 
        {
            _buttonUpAction?.Invoke(mx, my);
        }

        internal void InvokeMoveAction(int mx, int my) 
        {
            _moveAction?.Invoke(mx, my);
        }
    }
}
