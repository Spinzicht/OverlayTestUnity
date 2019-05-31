
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using WeakEvent;

namespace Ludio.Overlay.Windows
{
    public class MouseListener : Overlay.MouseListener
    {
        private const int WH_Mouse_LL = 14;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_NCMOUSEMOVE = 0x00A0;

        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_LBUTTONCLICK = 0x0203;

        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;
        private const int WM_RBUTTONCLICK = 0x0206;

        private const int WM_MBUTTONDOWN = 0x0207;
        private const int WM_MBUTTONUP = 0x0208;
        private const int WM_MBUTTONCLICK = 0x0209;

        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int WM_NCLBUTTONUP = 0x00A2;
        private const int WM_NCLBUTTONCLICK = 0x00A3;

        private const int WM_NCRBUTTONDOWN = 0x00A4;
        private const int WM_NCRBUTTONUP = 0x00A5;
        private const int WM_NCRBUTTONCLICK = 0x00A6;

        private const int WM_NCMBUTTONDOWN = 0x00A7;
        private const int WM_NCMBUTTONUP = 0x00A8;
        private const int WM_NCMBUTTONCLICK = 0x00A9;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private LowLevelMouseProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        private static MouseListener ml;

        public static MouseListener INSTANCE
        {
            get
            {
                if (ml == null) ml = new MouseListener();
                return ml;
            }
        }

        private MouseListener()
        {
            _proc = HookCallback;
        }

        public void HookMouse()
        {
            _hookID = SetHook(_proc);
        }

        public void UnHookMouse()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_Mouse_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                if (wParam == (IntPtr)WM_MOUSEMOVE || wParam == (IntPtr)WM_NCMOUSEMOVE)
                {
                    int x = Marshal.ReadInt32(lParam);
                    int y = Marshal.ReadInt32(lParam, 4);
                    if (_onMouseMoved != null) { _onMouseMoved.Raise(this, new MouseMovedArgs(new Vector2(x, y))); }
                }
                else
                {
                    MOUSEACTION action = wParam == (IntPtr)WM_LBUTTONCLICK || wParam == (IntPtr)WM_MBUTTONCLICK || wParam == (IntPtr)WM_RBUTTONCLICK ? MOUSEACTION.CLICK :
                                        (wParam == (IntPtr)WM_LBUTTONDOWN || wParam == (IntPtr)WM_MBUTTONDOWN || wParam == (IntPtr)WM_RBUTTONDOWN ? MOUSEACTION.DOWN :
                                        (wParam == (IntPtr)WM_LBUTTONUP || wParam == (IntPtr)WM_MBUTTONUP || wParam == (IntPtr)WM_RBUTTONUP ? MOUSEACTION.UP : MOUSEACTION.NONE));


                    MOUSEBUTTON button = wParam == (IntPtr)WM_LBUTTONCLICK || wParam == (IntPtr)WM_LBUTTONDOWN || wParam == (IntPtr)WM_LBUTTONUP ? MOUSEBUTTON.LEFT :
                                        (wParam == (IntPtr)WM_MBUTTONCLICK || wParam == (IntPtr)WM_MBUTTONDOWN || wParam == (IntPtr)WM_MBUTTONUP ? MOUSEBUTTON.MIDDLE :
                                        (wParam == (IntPtr)WM_RBUTTONCLICK || wParam == (IntPtr)WM_RBUTTONDOWN || wParam == (IntPtr)WM_RBUTTONUP ? MOUSEBUTTON.RIGHT : MOUSEBUTTON.NONE));

                    if (action != MOUSEACTION.NONE && button != MOUSEBUTTON.NONE)
                    {
                        if (_onMouseClicked != null) { _onMouseClicked.Raise(this, new MouseClickedArgs(button, action)); }
                    }
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }

    

    
}