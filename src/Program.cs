using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Drawing;

namespace src
{
    class Program
    {
        [DllImport(@"./CPP_SRC/libmandelbrot.so")]
        public static extern void CalcMandelbrot(int width, int height, int granularity);

        static void Main(string[] args)
        {
            int width = 60, height = 40;
            CalcMandelbrot(width, height, 50);
            string[] raw_buff = File.ReadAllLines("./mandelbrot.txt", Encoding.UTF8);
            byte[] buff = new byte[width * height];
            for (int i = 0; i < width * height; i++)
                buff[i] = byte.Parse(raw_buff[i]);

            Image.FromStream(new MemoryStream(buff));
        }
    }
}
