using ComputerGraphicsLab2.ImageParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab2.Utilities
{
    public static class PixelUtilities
    {
        public static ArgbColor TransformPixel(ArgbColor pixel, Form1 form1)
        {
            byte gray;

            gray = (byte)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);

            //return gray < (byte)form1.NumericThreshold.Value ? new ArgbColor(pixel.A, 0, 0, 0) : new ArgbColor(pixel.A, 255, 255, 255);
            return new ArgbColor(pixel.A, gray, gray, gray);
        }
    }
}
