using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Ludio.Overlay.Windows
{
    public class TransparentOverlayHandler : OverlayHandler
    {
        private struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string c, string w);
        [DllImport("user32.dll", EntryPoint = "GetActiveWindow")]
        private static extern IntPtr GetActiveWindow();
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
        [DllImport("user32.dll", EntryPoint = "ShowWindowAsync")]
        static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern int SetWindowPos(IntPtr hwnd, int hwndInsertAfter, int x, int y, int cx, int cy, int uFlags);
        [DllImport("Dwmapi.dll")]
        private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

        const int GWL_STYLE = -16;
        const uint WS_POPUP = 0x80000000;
        const uint WS_VISIBLE = 0x10000000;
        const int HWND_TOPMOST = -1;

        private static TransparentOverlayHandler th;

        public static new TransparentOverlayHandler INSTANCE()
        {
            if (th == null) th = new TransparentOverlayHandler();
            return th;
        }

        private TransparentOverlayHandler() : base()
        {
            int fWidth = UnityEngine.Screen.width;
            int fHeight = UnityEngine.Screen.height;
            var margins = new MARGINS() { cxLeftWidth = -1 };
            var hwnd = GetActiveWindow();
            SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, fWidth, fHeight, 32 | 64); //SWP_FRAMECHANGED = 0x0020 (32); //SWP_SHOWWINDOW = 0x0040 (64)
            DwmExtendFrameIntoClientArea(hwnd, ref margins);
        }

        private bool _clickthrough;
        public override bool ClickThrough
        {
            get { return _clickthrough; }
            set
            {
                if (CanToggleClickThrough)
                {

                    _clickthrough = value;
                    var hwnd = FindWindow(null, Application.productName);
                    if (_clickthrough)
                    {
                        SetWindowLong(hwnd, -20, 524288 | 32);//GWL_EXSTYLE=-20; WS_EX_LAYERED=524288=&h80000, WS_EX_TRANSPARENT=32=0x00000020L
                        SetLayeredWindowAttributes(hwnd, 0, 255, 2);// Transparency=51=20%, LWA_ALPHA=2
                    }
                    else
                    {
                        SetWindowLong(hwnd, -20, 32);//GWL_EXSTYLE=-20; WS_EX_LAYERED=524288=&h80000, WS_EX_TRANSPARENT=32=0x00000020L
                    }
                }
            }
        }
    }
}