using System;
using System.Runtime.InteropServices;

namespace TDQS
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;
    }
}
