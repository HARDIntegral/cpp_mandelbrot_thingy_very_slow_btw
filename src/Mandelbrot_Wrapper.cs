using System;
using System.Runtime.InteropServices;

namespace CppBind
{
    public class Mandelbrot_Wrapper
    {
        [DllImport(@"./CPP_SRC/libmandelbrot.so")]
        public static extern IntPtr Mandelbrot(int granularity);

        public static void Wrapper(int granularity)
        {
            // create a bitmap of the mandelbrot set
            IntPtr raw_buff = Mandelbrot(granularity);

            // convert C++ array
            int buff_len = Marshal.ReadInt32(raw_buff);
            IntPtr buff_start = IntPtr.Add(raw_buff, 4);
            int[] buff = new int[buff_len];
            Marshal.Copy(buff_start, buff, 0, buff_len);

            foreach (int i in buff)
                Console.WriteLine(i);
        }
    }
}