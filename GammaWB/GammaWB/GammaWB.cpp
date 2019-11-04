#include "targetver.h"

#include <stdio.h>
#include <tchar.h>
#include <Windows.h>
#include <math.h>
#include <stdlib.h>

BOOL SetGammaAndWhiteBalance(double redGamma, double greenGamma, double blueGamma, double redWeight, double greenWeight, double blueWeight) {
	WORD ramp[256 * 3];
	for (int i = 0; i < 256; i++) {
		double rg = pow(i / 255.0, redGamma) * 65535;
		double gg = pow(i / 255.0, greenGamma) * 65535;
		double bg = pow(i / 255.0, blueGamma) * 65535;
		double red = rg * redWeight + 0.5;
		double green = gg * greenWeight + 0.5;
		double blue = bg * blueWeight + 0.5;
		ramp[i + 0] = (WORD) red;
		ramp[i + 256] = (WORD) green;
		ramp[i + 512] = (WORD) blue;
	}
	return SetDeviceGammaRamp(::GetDC(NULL), ramp);
}

int _tmain(int argc, _TCHAR* argv[]) {
	if (argc != 7) {
		fprintf(stderr, "Usage:%s red-gamma green-gamma blue-gamma red-weight green-weight blue-weight\n", argv[0]);
		return 1;
	}

	double redGamma = _wtof(argv[1]);
	double greenGamma = _wtof(argv[2]);
	double blueGamma = _wtof(argv[3]);
	double redWeight = _wtof(argv[4]);
	double greenWeight = _wtof(argv[5]);
	double blueWeight = _wtof(argv[6]);

	SetGammaAndWhiteBalance(redGamma, greenGamma, blueGamma, redWeight, greenWeight, blueWeight);

	return 0;
}

