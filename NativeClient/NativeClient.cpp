// NativeClient.cpp : Defines the exported functions for the DLL.
//

#include "framework.h"
#include "NativeClient.h"


const int PRECISION = 10000000;

// This is the constructor of a class that has been exported.
CNativeClient::CNativeClient()
{
    return;
}

int CNativeClient::Multiply(int x, int y)
{
    return x * y;
}

double getPI(int decimals) {
    double pi = 1.0, p;
    for (int i = 1; i <= PRECISION; ++i) {
        if (i % 2 == 0) {
            p = 1.0;
        }
        else {
            p = -1.0;
        }
        // This is going to check wether it should be a + or - since the Leibniz formula is once: minus, then plus, etc.
        pi += p / (2 * i + 1);
    }
    return 4 * pi;
}

double CNativeClient::PI(int digit)
{
    ::Sleep(1000 * 20);

    return (getPI(digit));

}