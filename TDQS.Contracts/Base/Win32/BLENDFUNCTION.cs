using System;
using System.Runtime.InteropServices;

namespace TDQS.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BLENDFUNCTION
    {
        public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
        {
            BlendOp = op;
            BlendFlags = flags;
            SourceConstantAlpha = alpha;
            AlphaFormat = format;
        }

        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
    }
}
