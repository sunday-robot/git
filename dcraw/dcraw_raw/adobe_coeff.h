#pragma once

#include "RgbCoefficient.h"

void adobe_coeff(
	const char *model,	// �J�����̐��i��
	struct RgbCoefficient *rgbCoefficient,	// [out] ?
	double rgb_cam[][3]);	// [out] ?
