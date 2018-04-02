using ComputerGraphicsLab2.ImageParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphicsLab2.Dithering
{
    [Description("Random")]
    public sealed class RandomDithering : IErrorDiffusion
    {
        private readonly ArgbColor _black;
        private static readonly ArgbColor _blackDefault = new ArgbColor(255, 0, 0, 0);
        private readonly ArgbColor _white;
        private static readonly ArgbColor _whiteDefault = new ArgbColor(255, 255, 255, 255);

        private readonly Random _random;
        
        public RandomDithering() : this(_whiteDefault, _blackDefault)
        {

        }

        public RandomDithering(ArgbColor white, ArgbColor black) : this(Environment.TickCount, white, black)
        {

        }

        public RandomDithering(int seed, ArgbColor white, ArgbColor black)
        {
            _random = new Random(seed);
            _white = white;
            _black = black;
        }

        public RandomDithering(int seed) : this(seed, _whiteDefault, _blackDefault)
        {

        }

        public void Diffuse(ArgbColor[] data, ArgbColor original, ArgbColor transformed, int x, int y, int width, int height, int levels, int size)
        {
            int[] boundries = new int[levels];
            byte channelValue = original.R;
            int gray;

            for(int i = 0; i < levels - 1; i++)
            {
                double startBound = i * 255.0 / (levels - 1);
                double endBound = (i + 1) * 255.0 / (levels - 1);

                boundries[i] = _random.Next((int)startBound, (int)endBound);
            }

            for(int i = 0; i < levels - 1; i++)
            {
                if(channelValue >= boundries[levels - 2])
                {
                    data[y * width + x] = _white;
                    break;
                }
                else if(channelValue < boundries[i])
                {
                    gray = 255 * i / (levels - 1);
                    ArgbColor argb = new ArgbColor(255, gray, gray, gray);
                    data[y * width + x] = argb;
                    break;
                }
            }

            /*gray = (byte)(0.299 * original.R + 0.587 * original.G + 0.114 * original.B);

            if (gray >= _random.Next(0, 255))
            {
                data[y * width + x] = _white;
            }
            else
            {
                data[y * width + x] = _black;
            }*/
        }
    }
}
