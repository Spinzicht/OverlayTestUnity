using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Ludio.ExtensionMethods;

namespace Ludio.Overlay
{
    public class OverlayHandler
    {
        public KeyboardListener KeyboardTracker { get; protected set; }
        public MouseListener MouseTracker { get; protected set; }
        public Window ActiveWindow { get; protected set; }

        public MouseClick MouseClick { get; protected set; }
        public Vector2 MousePosition { get; protected set; }

        public virtual bool CanToggleClickThrough { get; set; }

        public virtual bool ClickThrough
        {
            get { return false; }
            set { }
        }

        public OverlayHandler()
        {
            CanToggleClickThrough = true;
        }
    }
}
