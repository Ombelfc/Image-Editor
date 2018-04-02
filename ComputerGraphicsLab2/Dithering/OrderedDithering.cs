using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerGraphicsLab2.ImageParameters;

namespace ComputerGraphicsLab2.Dithering
{
    public class OrderedDithering : IErrorDiffusion
    {
        private int[,] dither2Matrix = 
        { 
            { 1, 3 }, 
            { 4, 2 }
        };

        private int[,] dither3Matrix = 
        { 
            { 3, 7, 4 }, 
            { 6, 1, 9 }, 
            { 2, 8, 5 }
        };

        private int[,] dither4Matrix = 
        { 
            { 1, 3, 9, 11 }, 
            { 4, 2, 12, 10 }, 
            { 13, 15, 5, 7 }, 
            { 16, 14, 8, 6 }
        };

        private int[,] dither6Matrix = 
        { 
            { 9, 11, 25, 27, 13, 15 }, 
            { 12, 10, 28, 26, 16, 14 }, 
            { 21, 23, 1, 3, 33, 35 }, 
            { 24, 22, 4, 2, 36, 34 }, 
            { 5, 7, 29, 31, 17, 19 }, 
            { 8, 6, 31, 30, 20, 18 }
        };

        private int[,] dither8Matrix = 
        { 
            { 1 ,49 ,13 ,61 ,4 ,52 ,16 ,64 },
            { 33 ,17 ,45 ,29 ,36 ,20 ,48 ,32 }, 
            { 9 ,57 ,5 ,53 ,12 ,60 ,8 ,56 },
            { 41 ,25 ,37 ,21 ,44 ,28 ,40 ,24},
            {3 ,51 ,15 ,63 ,2 ,50 ,14 ,62},
            {35 ,19 ,47 ,31 ,34 ,18 ,46 ,30},
            {11 ,59 ,7 ,55 ,10 ,58 ,6 ,54},
            {43 ,27 ,39 ,23 ,42 ,26 ,38 ,22}
        };

        public OrderedDithering() { }

        public void Diffuse(ArgbColor[] data, ArgbColor original, ArgbColor transformed, int x, int y, int width, int height, int levels, int size)
        {
            int[] boundries = new int[levels];
            for (int i = 0; i < levels; i++)
            {
                boundries[i] = i * 255 / (levels - 1);
            }

            int[,] matrix;

            if (size == 3)
            {
                matrix = dither3Matrix;
            }
            else if(size == 4)
            {
                matrix = dither4Matrix;
            }
            else if(size == 6)
            {
                matrix = dither6Matrix;
            }
            else if(size == 8)
            {
                matrix = dither8Matrix;
            }
            else
            {
                matrix = dither2Matrix;
            }

            var gray = matrix[x % size, y % size];
            double threshold = gray / ((size * size) + 1d);
            var pixelIntensity = original.R / 255.0;

            var color = Math.Floor((levels - 1) * pixelIntensity);
            var reminder = (levels - 1) * pixelIntensity - color;

            if (reminder >= threshold) ++color;

            var channelValue = boundries[(int)color];

            data[y * width + x] = new ArgbColor(original.A, (int)channelValue, (int)channelValue, (int)channelValue);
        }
    }
}
