using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TDQS.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
