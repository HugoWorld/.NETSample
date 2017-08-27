using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace GoSun.WPFTest.Common
{
    public class WindowHelper
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public static void MoveWindowTest(Window win,int X,int Y,int width,int height)
        {
            WindowInteropHelper helper = new WindowInteropHelper(win);
            IntPtr handle = helper.Handle;
            MoveWindow(handle, X, Y, width, height, true);
        }
    }
}
