#include <fstream>
#include <complex>
#include "mandelbrot.h"

int Mandelbrot(std::complex<double> c, int granularity) {
    int val = 0;
    for (std::complex<double> z = 0; abs(z)<2 && val < granularity; val++)
        z = std::pow(z, 2) + c;
    return val;
}

void CalcMandelbrot(int width, int height, int granularity) {
    std::ofstream bitmap ("mandelbrot.txt", std::ios::trunc);
    if(!bitmap.is_open()) 
        return;

    std::complex<double> comp;
    for (double x = 0; x < width; x++) {
        for (double y = 0; y < height; y++) {
            comp = std::complex<double>(-2 + (x / width) * 3, -1 + (y / height) * 2);
            bitmap << 255 - (Mandelbrot(comp, granularity) * 5) % 255  << std::endl;
        }
    }
    bitmap.close();
}