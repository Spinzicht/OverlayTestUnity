using Ludio.Overlay.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Ludio.Overlay
{
    public abstract class Window
    {
        public abstract string GetTitle();
        public abstract Rect GetBounds();

        public abstract Texture2D GetActiveWindowCapture();
    }
}
