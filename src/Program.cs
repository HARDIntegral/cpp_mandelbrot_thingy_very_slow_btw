using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace src
{
    class Program
    {
        [DllImport(@"./CPP_SRC/libmandelbrot.so")]
        public static extern void CalcMandelbrot(int width, int height, int granularity);

        static void Main(string[] args)
        {
            int width = 300, height = 200;
            Bitmap image = new Bitmap(width, height);

            // calculate the Mandelbrot set
            CalcMandelbrot(width, height, 50);
            string[] raw_buff = File.ReadAllLines("./mandelbrot.txt", Encoding.UTF8);

            // convert the raw bitmap to a BMP image
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int color = Int32.Parse(raw_buff[height * x + y]);
                    image.SetPixel(x, y, Color.FromArgb(color, color, color));
                }
            }
            image.Save("mandelbrot.png", ImageFormat.Png);
        }
    }
}
