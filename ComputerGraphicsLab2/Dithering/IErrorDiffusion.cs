using ComputerGraphicsLab2.ImageParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphicsLab2.Dithering
{
    public interface IErrorDiffusion
    {
        void Diffuse(ArgbColor[] data, ArgbColor original, ArgbColor transformed, int x, int y, int width, int height, int levels, int size);
    }

    public class ErrorDiffusion 
    {
        private Form1 form1;

        public ErrorDiffusion(Form1 form1)
        {
            this.form1 = form1;
        }

        public IErrorDiffusion GetDitheringInstance()
        {
            IErrorDiffusion result;
            
            if (form1.RandomDitheringRadioButton.Checked)
            {
                result = new RandomDithering();
            }
            else if (form1.OrderedDitheringRadioButton.Checked)
            {
                result = new OrderedDithering();
            }
            else
            {
                result = null;
            }

            return result;
        }
    }
}
