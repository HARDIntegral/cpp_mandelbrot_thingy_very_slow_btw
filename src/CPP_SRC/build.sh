cmake .
make -j$(grep -c ^processor /proc/cpuinfo)
