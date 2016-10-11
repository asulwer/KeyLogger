using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Intercept
{    
    public static class Intercept
    {
        public static Stream KeyboardStream { get; set; }
        public static Stream MouseStream { get; set; }

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [StructLayout(LayoutKind.Sequential)]
        private struct Point
        {
            public int X;
            public int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MouseHookStructure
        {
            public Point pt;
            public IntPtr hwnd;
            public uint wHitTestCode;
            public IntPtr dwExtraInfo;
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WH_MOUSE_LL = 14;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_MOUSEMOVE = 0x0200;

        private static IntPtr _keyboardHookID = IntPtr.Zero;
        private static IntPtr _mouseHookID = IntPtr.Zero;

        public static IntPtr SetKeyboardHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        public static IntPtr SetMouseHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        public static IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN && (KeyboardStream != null && KeyboardStream.CanWrite))
            {
                int vkCode = Marshal.ReadInt32(lParam);

                string sBuf = $"{DateTime.Now.Ticks} : {(Keys)vkCode}";

                StreamWriter sw = new StreamWriter(KeyboardStream);
                sw.AutoFlush = true;
                sw.WriteLine(sBuf);

                Debug.WriteLine(sBuf);
            }
            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }
        public static IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (MouseStream != null && MouseStream.CanWrite))
            {
                MouseHookStructure mhs = (MouseHookStructure)Marshal.PtrToStructure(lParam, typeof(MouseHookStructure));

                string sBuf = string.Empty;

                if (wParam == (IntPtr)WM_LBUTTONDOWN)
                    sBuf = $"{DateTime.Now.Ticks} : LMB x{mhs.pt.X}, y{mhs.pt.Y}";
                else if (wParam == (IntPtr)WM_RBUTTONDOWN)
                    sBuf = $"{DateTime.Now.Ticks} : RMB x{mhs.pt.X}, y{mhs.pt.Y}";
                else
                    sBuf = $"{DateTime.Now.Ticks} : Unknown x{mhs.pt.X}, y{mhs.pt.Y}";

                StreamWriter sw = new StreamWriter(MouseStream);
                sw.AutoFlush = true;
                sw.WriteLine(sBuf);
                
                Debug.WriteLine(sBuf);
            }

            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }
    }
}
