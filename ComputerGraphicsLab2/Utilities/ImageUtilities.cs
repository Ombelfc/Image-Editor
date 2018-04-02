using ComputerGraphicsLab2.ImageParameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab2.ImageUtilities
{
    public static class ImageUtilities
    {
        /// <summary>
        /// Unsafe code requires a 32bit ARGB image, and this method returns it
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        internal static Bitmap Copy(this Bitmap bitmap)
        {
            Bitmap copy;

            copy = new Bitmap(bitmap.Size.Width, bitmap.Size.Height, PixelFormat.Format32bppArgb);

            using(Graphics graphics = Graphics.FromImage(copy))
            {
                graphics.Clear(Color.Transparent);
                graphics.PageUnit = GraphicsUnit.Pixel;
                graphics.DrawImage(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            }

            return copy;
        }

        internal static ArgbColor[] GetPixelsFrom32BitArgbImage(this Bitmap bitmap)
        {
            int width;
            int height;
            BitmapData bitmapData;
            ArgbColor[] results;

            width = bitmap.Width;
            height = bitmap.Height;
            results = new ArgbColor[width * height];
            bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                ArgbColor* pixel;
                pixel = (ArgbColor*)bitmapData.Scan0;

                for(int row = 0; row < height; row++)
                {
                    for(int col = 0; col < width; col++)
                    {
                        results[row * width + col] = *pixel;
                        pixel++;
                    }
                }
            }

            bitmap.UnlockBits(bitmapData);

            return results;
        }

        internal static Bitmap ToBitmap(this ArgbColor[] data, Size size)
        {
            int height;
            int width;
            BitmapData bitmapData;
            Bitmap result;

            result = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            width = result.Width;
            height = result.Height;


            bitmapData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            unsafe
            {
                ArgbColor* pixelPtr;

                // Get a pointer to the beginning of the pixel data region
                // The upper-left corner
                pixelPtr = (ArgbColor*)bitmapData.Scan0;

                // Iterate through rows and columns
                for (int row = 0; row < size.Height; row++)
                {
                    for (int col = 0; col < size.Width; col++)
                    {
                        int index;
                        ArgbColor color;

                        index = row * size.Width + col;
                        color = data[index];

                        // Set the pixel (fast!)
                        *pixelPtr = color;

                        // Update the pointer
                        pixelPtr++;
                    }
                }
            }

            result.UnlockBits(bitmapData);

            return result;
        }
    }
}
