using System;
using System.Runtime.InteropServices;

namespace CppBind
{
    class Program
    {
        [DllImport(@"./CPP_SRC/libmandelbrot.so")]
        public static extern IntPtr CalcMandelbrot(int width, int height, int granularity);
        [DllImport(@"./CPP_SRC/libmandelbrot.so")]
        public static extern void DeleteMandelbrot(IntPtr array);

        public static void Wrapper(int width, int height, int granularity)
        {
            // create a bitmap of the mandelbrot set
            IntPtr raw_buff = CalcMandelbrot(width, height, granularity);

            // convert C++ array
            int[] buff = new int[width * height];
            Marshal.Copy(raw_buff, buff, 0, width * height);
            DeleteMandelbrot(raw_buff);

            foreach (int i in buff)
                Console.WriteLine(i);

        }

        public static void Main(string[] args)
        {
            Wrapper(60, 40, 60);
        }
    }
}
