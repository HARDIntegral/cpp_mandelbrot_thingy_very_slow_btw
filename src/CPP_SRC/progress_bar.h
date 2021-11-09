#pragma once

class ProgressBar {
private:
    int iterations;
    int size;
    int step;
    int current_iteration;
    void print();
public:
    ProgressBar(int iterations, int size);
    ~ProgressBar();
    void iterate();
};