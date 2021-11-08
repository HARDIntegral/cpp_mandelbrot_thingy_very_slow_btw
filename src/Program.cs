using System;
using System.Runtime.InteropServices;

namespace src
{
    class Program
    {
        [DllImport(@"./CPP_SRC/libmandelbrot.so")]
        public static extern void CalcMandelbrot(int width, int height, int granularity);

        static void Main(string[] args)
        {
            CalcMandelbrot(600, 400, 50);
        }
    }
}
