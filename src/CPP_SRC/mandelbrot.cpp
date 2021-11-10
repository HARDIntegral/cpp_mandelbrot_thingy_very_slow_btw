#include <fstream>
#include <complex>
#include <chrono>
#include <iostream>
#include "mandelbrot.h"

#define PBSTR "============================================================"
#define PBWIDTH 60

void print(int current_iter, int iter) {
    int lpad = ((double)current_iter/iter)*PBWIDTH; 
    printf("\rProgress: [%.*s%*s] Iterations:%d/%d", lpad, PBSTR, PBWIDTH-lpad, "", current_iter, iter);
    fflush(stdout);
}

int Mandelbrot(std::complex<double> c, int granularity) {
    int val = 0;
    for (std::complex<double> z = 0; abs(z)<2 && val < granularity; val++)
        z = std::pow(z, 2) + c;
    return val;
}

void CalcMandelbrot(int width, int height, int granularity) {
    std::chrono::steady_clock::time_point begin = std::chrono::steady_clock::now();
    std::ofstream bitmap ("mandelbrot.txt", std::ios::trunc);
    if(!bitmap.is_open()) 
        return;

    std::complex<double> comp;
    for (double x = 0; x < width; x++) {
        print(x + 1, width);
        for (double y = 0; y < height; y++) {
            comp = std::complex<double>(-2 + (x / width) * 3, -1 + (y / height) * 2);
            bitmap << 255 - (Mandelbrot(comp, granularity) * 5) % 255  << std::endl;
        }
    }
    bitmap.close();
    std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();

    std::cout << "\nElapsed Time: " 
        << std::chrono::duration_cast<std::chrono::seconds>(end - begin).count() 
        << " seconds" << std::endl;
}