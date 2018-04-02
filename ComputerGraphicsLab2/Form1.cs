using ComputerGraphicsLab2.Dithering;
using ComputerGraphicsLab2.ImageParameters;
using ComputerGraphicsLab2.ImageUtilities;
using ComputerGraphicsLab2.Quantization;
using ComputerGraphicsLab2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphicsLab2
{
    public partial class Form1 : Form
    {
        private Form1 form1;
        private ErrorDiffusion errorDiffusion;

        private OctreeQuantizer parent = new OctreeQuantizer();
        private List<Color> limitedPalette = new List<Color>();
        private List<Color> originalPalette = new List<Color>();

        private Bitmap _image;
        private Bitmap _transformed;

        private int currentValue = 0;
        private float contrast = 0;

        public Form1()
        {
            InitializeComponent();
            form1 = this;
            errorDiffusion = new ErrorDiffusion(form1);
        }

        #region Open and Load

        private void OpenPicture_Click(object sender, EventArgs e)
        {
            using(FileDialog dialog = new OpenFileDialog
            {
                Title = "Open Image",
                DefaultExt = "png",
                Filter = "All Pictures (*.emf;*.wmf;*.jpg;*.jpeg;*.jfif;*.jpe;*.png;*.bmp;*.dib;*.rle;*.gif;*.tif;*.tiff)|*.emf;*.wmf;*.jpg;*.jpeg;*.jfif;*.jpe;*.png;*.bmp;*.dib;*.rle;*.gif;*.tif;*.tiff|Windows Enhanced Metafile (*.emf)|*.emf|Windows Metafile (*.wmf)|*.wmf|JPEG File Interchange Format (*.jpg;*.jpeg;*.jfif;*.jpe)|*.jpg;*.jpeg;*.jfif;*.jpe|Portable Networks Graphic (*.png)|*.png|Windows Bitmap (*.bmp;*.dib;*.rle)|*.bmp;*.dib;*.rle|Graphics Interchange Format (*.gif)|*.gif|Tagged Image File Format (*.tif;*.tiff)|*.tif;*.tiff|All files (*.*)|*.*"
            })
            {
                if(dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.OpenImage(dialog.FileName);
                }
            }
        }

        private void OpenImage(string fileName)
        {
            try
            {
                using(Bitmap image = (Bitmap)Image.FromFile(fileName))
                {
                    this.OpenImage(image);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OpenImage(Bitmap bitmap)
        {
            this.CleanUpOriginal();

            _image = bitmap.Copy();

            OriginalPicture.Image = _image;

            // Filling the octree initially
            for(int y = 0; y < _image.Height; y++)
            {
                for(int x = 0; x < _image.Width; x++)
                {
                    Color c = _image.GetPixel(x, y);
                    parent.AddColor(c);
                }
            }

            this.CreateTransformedImage();
        }

        private void CleanUpOriginal()
        {
            OriginalPicture.Image = null;

            if(_image != null)
            {
                _image.Dispose();
                _image = null;
            }
        }

        private void CleanUpTransformed()
        {
            WorkedPicture.Image = null;

            if(_transformed != null)
            {
                _transformed.Dispose();
                _transformed = null;
            }
        }

        #endregion

        #region Dithering and Grayscale

        private void CreateTransformedImage()
        {
            Bitmap bitmap;
            ArgbColor[] originalData;
            Size size;
            IErrorDiffusion dither;

            this.CleanUpTransformed();

            if (_image == null) return;

            bitmap = _image;
            size = bitmap.Size;

            int levels = (int)GrayscaleLevel.Value;
            int matrix = (int)ditherMatrix.Value;
            originalData = bitmap.GetPixelsFrom32BitArgbImage();

            dither = errorDiffusion.GetDitheringInstance();

            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    int index;
                    ArgbColor current;
                    ArgbColor transformed;

                    index = row * size.Width + col;

                    current = originalData[index];

                    // transform the pixel - normally this would be some form of color
                    // reduction. For this sample it's simple threshold based
                    // monochrome conversion
                    transformed = PixelUtilities.TransformPixel(current, form1);
                    originalData[index] = transformed;

                    // apply a dither algorithm to this pixel
                    if (dither != null)
                    {
                        dither.Diffuse(originalData, current, transformed, col, row, size.Width, size.Height, levels, matrix);
                    }
                }
            }

            _transformed = originalData.ToBitmap(size);
            WorkedPicture.Image = _transformed;
        }

        private void DitherCheckBoxCheckedHandler(object sender, EventArgs e)
        {
            this.CreateTransformedImage();
        }

        #endregion

        #region Uniform quantization

        private void uniform_CheckedChanged(object sender, EventArgs e)
        {
            WorkedPicture.Image = _image;
            Bitmap bitmap = _image;

            // Creates intervals with subdivision values
            List<int> listOfRIntervals = CreateInervals(Int32.Parse(subdivision_kr.Text));
            List<int> listOfGIntervals = CreateInervals(Int32.Parse(subdivision_kg.Text));
            List<int> listOfBIntervals = CreateInervals(Int32.Parse(subdivision_kb.Text));

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    int[] rgb = new int[3];

                    // Gets the channel value for each ARGB color
                    rgb[0] = GetChannelValue(listOfRIntervals, pixel.R);
                    rgb[1] = GetChannelValue(listOfGIntervals, pixel.G);
                    rgb[2] = GetChannelValue(listOfBIntervals, pixel.B);

                    bitmap.SetPixel(x, y, Color.FromArgb(pixel.A, rgb[0], rgb[1], rgb[2]));
                }
            }

            WorkedPicture.Image = bitmap;
        }

        private int GetChannelValue(List<int> listIntervals, int pixelRGBValue)
        {
            int r = 0;

            foreach (var interval in listIntervals)
            {
                if (pixelRGBValue > listIntervals.ElementAt(listIntervals.Count - 1))
                {
                    r = (listIntervals.ElementAt(listIntervals.Count - 1) + listIntervals.ElementAt(listIntervals.Count - 2)) / 2;
                    break;
                }
                else if (pixelRGBValue < interval)
                {
                    var it = listIntervals.IndexOf(interval);
                    r = (listIntervals[it] + listIntervals[it - 1]) / 2;
                    break;
                }
            }

            return r;
        }

        private List<int> CreateInervals(int v)
        {
            List<int> list = new List<int>();

            for (int i = 0; i <= v; i++)
            {
                list.Add(((255 * i) / v));
            }

            return list;
        }

        #endregion

        #region Octree Quantization

        private void octree_CheckedChanged(object sender, EventArgs e)
        {
            WorkedPicture.Image = _image;
            Bitmap bitmap = _image;
            Color color;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    color = bitmap.GetPixel(x, y);
                    parent.AddColor(color);
                }
            }

            int limit = Int32.Parse(kmax.Text);
            
            limitedPalette = parent.GetPalette(limit);

            Bitmap quantizedImage = new Bitmap(bitmap.Width, bitmap.Height);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    quantizedImage.SetPixel(x, y, limitedPalette[parent.GetPaletteIndex(_image.GetPixel(x, y))]);
                }
            }

            WorkedPicture.Image = quantizedImage;
        }

        #endregion

        private void Reset_Click(object sender, EventArgs e)
        {
            this.CreateTransformedImage();
        }

        private void Apply_Click(object sender, EventArgs e)
        {

        }

        private void OrderedDitheringRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.CreateTransformedImage();
        }

        #region Brightness and Contrast

        private void BrightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            BValue.Text = BrightnessTrackBar.Value.ToString();
            WorkedPicture.Image = AdjustBrightness(BrightnessTrackBar.Value);
        }

        private Bitmap AdjustBrightness(int value)
        {
            Bitmap temp = _image;

            for (int x = 0; x < temp.Width; x++)
            {
                for (int y = 0; y < temp.Height; y++)
                {
                    Color pixel = temp.GetPixel(x, y);

                    int red = 0; int green = 0; int blue = 0;

                    if (currentValue > value)
                    {
                        red = pixel.R - value;
                        green = pixel.G - value;
                        blue = pixel.B - value;
                    }
                    else if(currentValue < value)
                    {
                        red = pixel.R + value;
                        green = pixel.G + value;
                        blue = pixel.B + value;
                    }
                    else
                    {
                        red = pixel.R;
                        green = pixel.G;
                        blue = pixel.B;
                    }

                    if (red < 0) red = 0;
                    if (red > 255) red = 255;

                    if (green < 0) green = 0;
                    if (green > 255) green = 255;

                    if (blue < 0) blue = 0;
                    if (blue > 255) blue = 255;

                    temp.SetPixel(x, y, Color.FromArgb((byte)red, (byte)green, (byte)blue));
                }
            }

            currentValue = value;

            return temp;
        }

        private void ContrastTrackBar_Scroll(object sender, EventArgs e)
        {
            CVal.Text = ContrastTrackBar.Value.ToString();

            contrast = ContrastTrackBar.Value;

            Bitmap bmp = _image;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    var r = (Enhance((double)pixel.R, contrast) < 0) ? 0 :
                        (Enhance((double)pixel.R, contrast) < 255.0) ? (int)Enhance((double)pixel.R, contrast) : 255;

                    var g = (Enhance((double)pixel.G, contrast) < 0) ? 0 :
                        (Enhance((double)pixel.G, contrast) < 255.0) ? (int)Enhance((double)pixel.G, contrast) : 255;

                    var b = (Enhance((double)pixel.B, contrast) < 0) ? 0 :
                        (Enhance((double)pixel.B, contrast) < 255.0) ? (int)Enhance((double)pixel.B, contrast) : 255;

                    bmp.SetPixel(x, y, Color.FromArgb(pixel.A, r, g, b));
                }
            }

            WorkedPicture.Image = bmp;
        }

        private double Enhance(double channelValue, double contrastCoefficient)
        {
            return ((((channelValue / 255.0) - 0.5) * contrastCoefficient) + 0.5) * 255.0;
        }

        #endregion

        #region Inversion and Grayscale

        private void Inversion_Click(object sender, EventArgs e)
        {
            Bitmap temp = _image;

            for (int x = 0; x < temp.Width; x++)
            {
                for (int y = 0; y < temp.Height; y++)
                {
                    Color pixel = temp.GetPixel(x, y);

                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    temp.SetPixel(x, y, Color.FromArgb(255 - red, 255 - green, 255 - blue));
                }
            }

            _transformed = temp;
            WorkedPicture.Image = _transformed;
        }

        private void Grayscale_Click(object sender, EventArgs e)
        {
            Bitmap temp = _image;

            for (int x = 0; x < temp.Width; x++)
            {
                for (int y = 0; y < temp.Height; y++)
                {
                    Color pixel = temp.GetPixel(x, y);

                    int grayscale = (int)((pixel.R * .3) + (pixel.G * .59) + (pixel.B * .11));

                    Color newColor = Color.FromArgb(grayscale, grayscale, grayscale);

                    temp.SetPixel(x, y, newColor);
                }
            }

            _transformed = temp;
            WorkedPicture.Image = _transformed;
        }

        #endregion

        private void Dilating_Click(object sender, EventArgs e)
        {
            Bitmap temp = _image;
            int matrixSize = 3;

            for (int x = 0; x < temp.Width; x++)
            {
                for (int y = 0; y < temp.Height; y++)
                {
                    Color pixel = temp.GetPixel(x, y);

                    int grayscale = (int)((pixel.R * .3) + (pixel.G * .59) + (pixel.B * .11));

                    Color newColor = Color.FromArgb(grayscale, grayscale, grayscale);

                    temp.SetPixel(x, y, newColor);
                }
            }

            WorkedPicture.Image = temp;

            BitmapData sourceData =
                       temp.LockBits(new Rectangle(0, 0,
                       temp.Width, temp.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            temp.UnlockBits(sourceData);

            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            byte blue = 0;
            byte green = 0;
            byte red = 0;

            byte morphResetValue = 0;

            for (int offsetY = filterOffset; offsetY <
                temp.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    temp.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    blue = morphResetValue;
                    green = morphResetValue;
                    red = morphResetValue;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                            (filterY * sourceData.Stride);

                            if (pixelBuffer[calcOffset] > blue)
                            {
                                blue = pixelBuffer[calcOffset];
                            }

                            if (pixelBuffer[calcOffset + 1] > green)
                            {
                                green = pixelBuffer[calcOffset + 1];
                            }

                            if (pixelBuffer[calcOffset + 2] > red)
                            {
                                red = pixelBuffer[calcOffset + 2];
                            }
                        }
                    }



                    //    blue = pixelBuffer[byteOffset];


                    //if (applyGreen == false)
                    //{
                    //    green = pixelBuffer[byteOffset + 1];
                    //}

                    //if (applyRed == false)
                    //{
                    //    red = pixelBuffer[byteOffset + 2];
                    //}

                    resultBuffer[byteOffset] = blue;
                    resultBuffer[byteOffset + 1] = green;
                    resultBuffer[byteOffset + 2] = red;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap _tranformed = new Bitmap(temp.Width,
                                             temp.Height);

            BitmapData resultData =
                       _tranformed.LockBits(new Rectangle(0, 0,
                       _tranformed.Width, _tranformed.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            _tranformed.UnlockBits(resultData);

            WorkedPicture.Image = _tranformed;
        }

        private void Erosing_Click(object sender, EventArgs e)
        {
            Bitmap temp = _image;
            int matrixSize = 3;

            for (int x = 0; x < temp.Width; x++)
            {
                for (int y = 0; y < temp.Height; y++)
                {
                    Color pixel = temp.GetPixel(x, y);

                    int grayscale = (int)((pixel.R * .3) + (pixel.G * .59) + (pixel.B * .11));

                    Color newColor = Color.FromArgb(grayscale, grayscale, grayscale);

                    temp.SetPixel(x, y, newColor);
                }
            }

            WorkedPicture.Image = temp;

            BitmapData sourceData =
                       temp.LockBits(new Rectangle(0, 0,
                       temp.Width, temp.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            temp.UnlockBits(sourceData);

            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            byte blue = 0;
            byte green = 0;
            byte red = 0;

            byte morphResetValue = 0;

            morphResetValue = 255;

            for (int offsetY = filterOffset; offsetY <
                temp.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    temp.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    blue = morphResetValue;
                    green = morphResetValue;
                    red = morphResetValue;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 4) +
                            (filterY * sourceData.Stride);

                            if (pixelBuffer[calcOffset] < blue)
                            {
                                blue = pixelBuffer[calcOffset];
                            }

                            if (pixelBuffer[calcOffset + 1] < green)
                            {
                                green = pixelBuffer[calcOffset + 1];
                            }

                            if (pixelBuffer[calcOffset + 2] < red)
                            {
                                red = pixelBuffer[calcOffset + 2];
                            }
                        }
                    }

                    //blue = pixelBuffer[byteOffset];


                    //green = pixelBuffer[byteOffset + 1];


                    //red = pixelBuffer[byteOffset + 2];

                    resultBuffer[byteOffset] = blue;
                    resultBuffer[byteOffset + 1] = green;
                    resultBuffer[byteOffset + 2] = red;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap _transformed = new Bitmap(temp.Width,
                                             temp.Height);

            BitmapData resultData =
                       _transformed.LockBits(new Rectangle(0, 0,
                       _transformed.Width, _transformed.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            _transformed.UnlockBits(resultData);

            WorkedPicture.Image = _transformed;
        }
    }
}
