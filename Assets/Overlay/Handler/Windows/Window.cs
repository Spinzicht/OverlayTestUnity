using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using System.Drawing.Imaging;
using System.IO;

namespace Ludio.Overlay.Windows
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;        // x position of upper-left corner
        public int top;         // y position of upper-left corner
        public int right;       // x position of lower-right corner
        public int bottom;      // y position of lower-right corner
    }

    public class Window : Overlay.Window
    {
        private Window() { }
        private static Window _instance;
        public static Window INSTANCE
        {
            get
            {
                if (_instance == null) _instance = new Window();
                return _instance;
            }
        }


        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        public override string GetTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);

            if (GetWindowText(GetForegroundWindow(), Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public override Rect GetBounds()
        {
            RECT r = new RECT();
            GetWindowRect(GetForegroundWindow(), out r);
            //needs to be tested, used to work with system.drawing dll
            Rect bounds = new Rect(r.left, r.top, Math.Abs(r.right - r.left), Math.Abs(r.top-r.bottom));
            return bounds;
        }

        public override Texture2D GetActiveWindowCapture()
        {
            var image = new Bitmap(Screen.width, Screen.height, PixelFormat.Format32bppArgb);
            var gfx = System.Drawing.Graphics.FromImage(image);

            Size s = new Size(Screen.width * 4, Screen.height);

            gfx.CopyFromScreen(0, 0, 0, 0, s, CopyPixelOperation.SourceCopy);
            Texture2D tex = new Texture2D(image.Width / 2, image.Height / 2, TextureFormat.ARGB32, true);

            MemoryStream stream = new MemoryStream();
            image.Save(stream, image.RawFormat);
            var data = stream.ToArray();

            Debug.Log(image.Width);
            Debug.Log(tex.width);

            tex.LoadRawTextureData(data.Reverse().ToArray());
            tex.Apply();
            return tex;
        }
    }
}
