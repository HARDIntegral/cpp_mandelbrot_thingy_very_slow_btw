cmake_minimum_required(VERSION 3.0)
project(mandelbrot)
add_library(mandelbrot SHARED 
    mandelbrot.cpp mandelbrot.h 
    progress_bar.cpp progress_bar.h
)