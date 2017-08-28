using System.Runtime.InteropServices;

namespace TDQS.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public SIZE(int cx, int cy)
        {
            this.cx = cx; this.cy = cy;
        }

        public int cx;
        public int cy;
    }
}
