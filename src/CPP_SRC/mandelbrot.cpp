#include <iostream>
#include <malloc.h>
#include "mandelbrot.h"

int* Mandelbrot(int granularity) {
    std::cout << "Mandelbrot!" << std::endl;

    int len = 1;
    int* yes = (int*)malloc(sizeof(int)* len + 1);
    yes[0] = len;
    yes[1] = granularity;
    return yes;
}