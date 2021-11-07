cd src/CPP_SRC
echo "--- [INFO] Compiling Shared Object ---------------------------------------------"
cmake .
make -j$(grep -c ^processor /proc/cpuinfo)
echo "--- [INFO] Shared Object Built -------------------------------------------------"
echo ""
echo "--- [INFO] Building DOTNET Application -----------------------------------------"
cd ..
dotnet build
echo "--- [INFO] Build Successful ----------------------------------------------------"