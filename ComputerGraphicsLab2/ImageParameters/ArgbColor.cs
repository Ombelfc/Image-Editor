using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab2.ImageParameters
{
    /// <summary>
    /// Represents an ARGB(alpha, red, green, blue) color
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ArgbColor
    {
        [FieldOffset(0)]
        public byte B;
        [FieldOffset(1)]
        public byte G;
        [FieldOffset(2)]
        public byte R;
        [FieldOffset(3)]
        public byte A;

        public ArgbColor(int alpha, int red, int green, int blue) : this()
        {
            A = (byte)alpha;
            R = (byte)red;
            G = (byte)green;
            B = (byte)blue;
        }

        internal static ArgbColor FromArgb(byte a, byte r, byte g, byte b)
        {
            return new ArgbColor(a, r, g, b);
        }
    }
}
