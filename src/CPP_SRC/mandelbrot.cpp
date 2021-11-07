#include <iostream>
#include <cstdlib>
#include <complex>
#include <malloc.h>
#include "mandelbrot.h"

int Mandelbrot(std::complex<double> c, int granularity) {
    int val = 0;
    std::complex<double> z = 0;
    while (abs(z)>0 && val < granularity) {
        z = (z*z) + c;
        val++;
    }
    return val;
}

int* CalcMandelbrot(int width, int height, int granularity) {
    int* bitmap = (int*)malloc(width*height*sizeof(int));

    std::complex<double> comp;
    int res, color;
    for (int x = 0; x < width; x++) {
        for (int y = 0; y < height; y++) {
            comp =  (-2 + (x / width) * 3, -1 + (y / height) * 2);
            res = Mandelbrot(comp, granularity);
            color = 255 - (res * 255) % granularity;
            bitmap[x*y] = color;
        }
    }

    return bitmap;
}

void DeleteMandelbrot(int* array) {
    delete[] array;
}