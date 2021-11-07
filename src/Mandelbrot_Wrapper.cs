using System;
using System.Runtime.InteropServices;

namespace CppBind
{
    public class Mandelbrot_Wrapper
    {
        [DllImport(@"./CPP_SRC/libmandelbrot.so")]
        public static extern IntPtr CalcMandelbrot(int width, int height, int granularity);
        [DllImport(@"./CPP_SRC/libmandelbrot.so")]
        public static extern void DeleteMandelbrot(IntPtr array);

        public static void Wrapper(int granularity)
        {
            // create a bitmap of the mandelbrot set
            int width = 10, height = 40;
            IntPtr raw_buff = CalcMandelbrot(width, height, granularity);

            // convert C++ array
            try
            {
                int[] buff = new int[width * height];
                Marshal.Copy(raw_buff, buff, 0, width * height);
                DeleteMandelbrot(raw_buff);

                foreach (int i in buff)
                    Console.WriteLine(i);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}