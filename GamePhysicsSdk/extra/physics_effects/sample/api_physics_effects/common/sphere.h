/*
Physics Effects Copyright(C) 2012 Sony Computer Entertainment Inc.
All rights reserved.

Physics Effects is open software; you can redistribute it and/or
modify it under the terms of the BSD License.

Physics Effects is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
See the BSD License for more details.

A copy of the BSD License is distributed with
Physics Effects under the filename: physics_effects_license.txt
*/

#define NUM_SPHERE_VTX 67
#define NUM_SPHERE_IDX 360
const float sphere_vtx[] = {
	0.000000f,-1.000000f,0.000000f,0.000000f,-1.000000f,0.000000f,
	0.500000f,-0.866025f,0.000000f,0.500000f,-0.866025f,0.000000f,
	0.433013f,-0.866025f,0.250000f,0.433013f,-0.866025f,0.250000f,
	0.250000f,-0.866025f,0.433013f,0.250000f,-0.866025f,0.433013f,
	-0.000000f,-0.866025f,0.500000f,-0.000000f,-0.866025f,0.500000f,
	-0.250000f,-0.866025f,0.433013f,-0.250000f,-0.866025f,0.433013f,
	-0.433013f,-0.866025f,0.250000f,-0.433013f,-0.866025f,0.250000f,
	-0.500000f,-0.866025f,-0.000000f,-0.500000f,-0.866025f,-0.000000f,
	-0.433013f,-0.866025f,-0.250000f,-0.433013f,-0.866025f,-0.250000f,
	-0.250000f,-0.866025f,-0.433013f,-0.250000f,-0.866025f,-0.433013f,
	0.000000f,-0.866025f,-0.500000f,0.000000f,-0.866025f,-0.500000f,
	0.250000f,-0.866025f,-0.433013f,0.250000f,-0.866025f,-0.433013f,
	0.433013f,-0.866025f,-0.250000f,0.433013f,-0.866025f,-0.250000f,
	0.500000f,-0.866025f,0.000000f,0.500000f,-0.866025f,0.000000f,
	0.866025f,-0.500000f,0.000000f,0.866025f,-0.500000f,0.000000f,
	0.750000f,-0.500000f,0.433013f,0.750000f,-0.500000f,0.433013f,
	0.433013f,-0.500000f,0.750000f,0.433013f,-0.500000f,0.750000f,
	-0.000000f,-0.500000f,0.866025f,-0.000000f,-0.500000f,0.866025f,
	-0.433013f,-0.500000f,0.750000f,-0.433013f,-0.500000f,0.750000f,
	-0.750000f,-0.500000f,0.433013f,-0.750000f,-0.500000f,0.433013f,
	-0.866025f,-0.500000f,-0.000000f,-0.866025f,-0.500000f,-0.000000f,
	-0.750000f,-0.500000f,-0.433013f,-0.750000f,-0.500000f,-0.433013f,
	-0.433013f,-0.500000f,-0.750000f,-0.433013f,-0.500000f,-0.750000f,
	0.000000f,-0.500000f,-0.866025f,0.000000f,-0.500000f,-0.866025f,
	0.433013f,-0.500000f,-0.750000f,0.433013f,-0.500000f,-0.750000f,
	0.750000f,-0.500000f,-0.433012f,0.750000f,-0.500000f,-0.433012f,
	0.866025f,-0.500000f,0.000000f,0.866025f,-0.500000f,0.000000f,
	1.000000f,0.000000f,0.000000f,1.000000f,0.000000f,0.000000f,
	0.866025f,0.000000f,0.500000f,0.866025f,0.000000f,0.500000f,
	0.500000f,0.000000f,0.866025f,0.500000f,0.000000f,0.866025f,
	-0.000000f,0.000000f,1.000000f,-0.000000f,0.000000f,1.000000f,
	-0.500000f,0.000000f,0.866025f,-0.500000f,0.000000f,0.866025f,
	-0.866025f,0.000000f,0.500000f,-0.866025f,0.000000f,0.500000f,
	-1.000000f,0.000000f,-0.000000f,-1.000000f,0.000000f,-0.000000f,
	-0.866025f,0.000000f,-0.500000f,-0.866025f,0.000000f,-0.500000f,
	-0.500000f,0.000000f,-0.866025f,-0.500000f,0.000000f,-0.866025f,
	0.000000f,0.000000f,-1.000000f,0.000000f,0.000000f,-1.000000f,
	0.500000f,0.000000f,-0.866025f,0.500000f,0.000000f,-0.866025f,
	0.866026f,0.000000f,-0.500000f,0.866026f,0.000000f,-0.500000f,
	1.000000f,0.000000f,0.000000f,1.000000f,0.000000f,0.000000f,
	0.866025f,0.500000f,0.000000f,0.866025f,0.500000f,0.000000f,
	0.750000f,0.500000f,0.433013f,0.750000f,0.500000f,0.433013f,
	0.433013f,0.500000f,0.750000f,0.433013f,0.500000f,0.750000f,
	-0.000000f,0.500000f,0.866025f,-0.000000f,0.500000f,0.866025f,
	-0.433013f,0.500000f,0.750000f,-0.433013f,0.500000f,0.750000f,
	-0.750000f,0.500000f,0.433013f,-0.750000f,0.500000f,0.433013f,
	-0.866025f,0.500000f,-0.000000f,-0.866025f,0.500000f,-0.000000f,
	-0.750000f,0.500000f,-0.433013f,-0.750000f,0.500000f,-0.433013f,
	-0.433013f,0.500000f,-0.750000f,-0.433013f,0.500000f,-0.750000f,
	0.000000f,0.500000f,-0.866025f,0.000000f,0.500000f,-0.866025f,
	0.433013f,0.500000f,-0.750000f,0.433013f,0.500000f,-0.750000f,
	0.750000f,0.500000f,-0.433012f,0.750000f,0.500000f,-0.433012f,
	0.866025f,0.500000f,0.000000f,0.866025f,0.500000f,0.000000f,
	0.500000f,0.866025f,0.000000f,0.500000f,0.866025f,0.000000f,
	0.433013f,0.866025f,0.250000f,0.433013f,0.866025f,0.250000f,
	0.250000f,0.866025f,0.433013f,0.250000f,0.866025f,0.433013f,
	-0.000000f,0.866025f,0.500000f,-0.000000f,0.866025f,0.500000f,
	-0.250000f,0.866025f,0.433013f,-0.250000f,0.866025f,0.433013f,
	-0.433013f,0.866025f,0.250000f,-0.433013f,0.866025f,0.250000f,
	-0.500000f,0.866025f,-0.000000f,-0.500000f,0.866025f,-0.000000f,
	-0.433013f,0.866025f,-0.250000f,-0.433013f,0.866025f,-0.250000f,
	-0.250000f,0.866025f,-0.433013f,-0.250000f,0.866025f,-0.433013f,
	0.000000f,0.866025f,-0.500000f,0.000000f,0.866025f,-0.500000f,
	0.250000f,0.866025f,-0.433013f,0.250000f,0.866025f,-0.433013f,
	0.433013f,0.866025f,-0.250000f,0.433013f,0.866025f,-0.250000f,
	0.500000f,0.866025f,0.000000f,0.500000f,0.866025f,0.000000f,
	0.000000f,1.000000f,0.000000f,0.000000f,1.000000f,0.000000f,
};
const unsigned short sphere_idx[] = {
	0,1,2,
	0,2,3,
	0,3,4,
	0,4,5,
	0,5,6,
	0,6,7,
	0,7,8,
	0,8,9,
	0,9,10,
	0,10,11,
	0,11,12,
	0,12,13,
	1,14,15,
	15,2,1,
	2,15,16,
	16,3,2,
	3,16,17,
	17,4,3,
	4,17,18,
	18,5,4,
	5,18,19,
	19,6,5,
	6,19,20,
	20,7,6,
	7,20,21,
	21,8,7,
	8,21,22,
	22,9,8,
	9,22,23,
	23,10,9,
	10,23,24,
	24,11,10,
	11,24,25,
	25,12,11,
	12,25,26,
	26,13,12,
	14,27,28,
	28,15,14,
	15,28,29,
	29,16,15,
	16,29,30,
	30,17,16,
	17,30,31,
	31,18,17,
	18,31,32,
	32,19,18,
	19,32,33,
	33,20,19,
	20,33,34,
	34,21,20,
	21,34,35,
	35,22,21,
	22,35,36,
	36,23,22,
	23,36,37,
	37,24,23,
	24,37,38,
	38,25,24,
	25,38,39,
	39,26,25,
	27,40,41,
	41,28,27,
	28,41,42,
	42,29,28,
	29,42,43,
	43,30,29,
	30,43,44,
	44,31,30,
	31,44,45,
	45,32,31,
	32,45,46,
	46,33,32,
	33,46,47,
	47,34,33,
	34,47,48,
	48,35,34,
	35,48,49,
	49,36,35,
	36,49,50,
	50,37,36,
	37,50,51,
	51,38,37,
	38,51,52,
	52,39,38,
	40,53,54,
	54,41,40,
	41,54,55,
	55,42,41,
	42,55,56,
	56,43,42,
	43,56,57,
	57,44,43,
	44,57,58,
	58,45,44,
	45,58,59,
	59,46,45,
	46,59,60,
	60,47,46,
	47,60,61,
	61,48,47,
	48,61,62,
	62,49,48,
	49,62,63,
	63,50,49,
	50,63,64,
	64,51,50,
	51,64,65,
	65,52,51,
	54,53,66,
	55,54,66,
	56,55,66,
	57,56,66,
	58,57,66,
	59,58,66,
	60,59,66,
	61,60,66,
	62,61,66,
	63,62,66,
	64,63,66,
	65,64,66,
};