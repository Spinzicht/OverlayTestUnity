using System;
using UnityEngine;
using WeakEvent;
using Ludio.ExtensionMethods;

namespace Ludio.Overlay
{
    public abstract class MouseListener
    {
        protected readonly WeakEventSource<MouseMovedArgs> _onMouseMoved = new WeakEventSource<MouseMovedArgs>();
        public event EventHandler<MouseMovedArgs> OnMouseMoved
        {
            add { _onMouseMoved.Subscribe(value); }
            remove { _onMouseMoved.Unsubscribe(value); }
        }

        protected readonly WeakEventSource<MouseClickedArgs> _onMouseClicked = new WeakEventSource<MouseClickedArgs>();
        public event EventHandler<MouseClickedArgs> OnMouseClicked
        {
            add { _onMouseClicked.Subscribe(value); }
            remove { _onMouseClicked.Unsubscribe(value); }
        }
    }

    public enum MOUSEBUTTON
    {
        LEFT,
        RIGHT,
        MIDDLE,
        NONE
    }

    public enum MOUSEACTION
    {
        DOWN,
        UP,
        CLICK,
        NONE
    }

    public class MouseClick
    {
        public MOUSEBUTTON button;
        public MOUSEACTION action;

        public MouseClick(MOUSEBUTTON b, MOUSEACTION a)
        {
            button = b;
            action = a;
        }

        public override string ToString()
        {
            return Enum.GetName(typeof(MOUSEBUTTON), button) + " | " + Enum.GetName(typeof(MOUSEACTION), action);
        }
    }

    public class MouseClickedArgs : EventArgs
    {
        public MouseClick click;

        public MouseClickedArgs(MOUSEBUTTON b, MOUSEACTION a)
        {
            click = new MouseClick(b, a);
        }
    }

    public class MouseMovedArgs : EventArgs
    {
        public Vector2 Position { get; private set; }
        public MouseMovedArgs(Vector2 pos)
        {
#if !UNITY_EDITOR
            Position = pos;
#else
            Position = Input.mousePosition.XY().FlipY();
#endif
        }
    }
}
