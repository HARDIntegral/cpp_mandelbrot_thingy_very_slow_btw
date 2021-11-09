#include <iostream>
#include "progress_bar.h"

ProgressBar::ProgressBar(int iterations, int size) {
    this->iterations = iterations;
    this->size = size;
    this->step = iterations/size;
    this->current_iteration = 0;
}

ProgressBar::~ProgressBar() {
    delete this;
}

void ProgressBar::print() {}

void ProgressBar::iterate() {
    this->print();
}

