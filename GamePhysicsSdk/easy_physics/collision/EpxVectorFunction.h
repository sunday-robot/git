﻿/*
	Copyright (c) 2012 Hiroshi Matsuike

	This software is provided 'as-is', without any express or implied
	warranty. In no event will the authors be held liable for any damages
	arising from the use of this software.

	Permission is granted to anyone to use this software for any purpose,
	including commercial applications, and to alter it and redistribute it
	freely, subject to the following restrictions:

	1. The origin of this software must not be misrepresented; you must not
	claim that you wrote the original software. If you use this software
	in a product, an acknowledgment in the product documentation would be
	appreciated but is not required.

	2. Altered source versions must be plainly marked as such, and must not be
	misrepresented as being the original software.

	3. This notice may not be removed or altered from any source distribution.
*/

#ifndef EPX_VECTOR_FUNCTION_H
#define EPX_VECTOR_FUNCTION_H

namespace EasyPhysics {

static inline void epxCalcTangentVector(const EpxVector3 &normal,EpxVector3 &tangent1,EpxVector3 &tangent2)
{
	EpxVector3 vec(1.0f,0.0f,0.0f);
	EpxVector3 n(normal);
	n[0] = 0.0f;
	if(lengthSqr(n) < EPX_EPSILON) {
		vec = EpxVector3(0.0f,1.0f,0.0f);
	}
	tangent1 = normalize(cross(normal,vec));
	tangent2 = normalize(cross(tangent1,normal));
}

} // namespace EasyPhysics

#endif // EPX_VECTOR_FUNCTION_H
