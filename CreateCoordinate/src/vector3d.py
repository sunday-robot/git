# 3�����x�N�g���N���X
# coding:sjis

import math
from operator import __mul__

class Vector3D:
	def __init__(self, x = 0, y = 0, z = 0):
		self.x = x
		self.y = y
		self.z = z

	def __str__(self):
		return "(" + str(self.x) + "," + str(self.y) + "," + str(self.z) + ")"

	# �P�����Z�q"-"
	def __neg__(self):
		return Vector3D(-self.x, -self.y, -self.z)
	
	# ���Z
	def __add__(self, v):
		return Vector3D(self.x + v.x, self.y + v.y, self.z + v.z)

	# ���Z
	def __sub__(self, v):
		return Vector3D(self.x - v.x, self.y - v.y, self.z - v.z)

	# �x�N�g�����m�̏�Z�A���Z�͒�`���Ȃ�
	# (��Z�͊O�ςƓ��ς̗������l�����č�������A���Z�͏�Z���`���Ȃ����Ƃ����R)

	# ��Z(�x�N�g�� * �X�J���[)
	def __mul__(self, s):
		return Vector3D(self.x * s, self.y * s, self.z * s)

	# ��Z(�X�J���[ * �x�N�g��)
	def __��mul__(self, s):
		return __mul__(self, s)

	# ���Z(�x�N�g�� / �X�J���[)
	def __truediv__(self, s):
		return Vector3D(self.x / s, self.y / s, self.z / s)
	
	# ����
	def length(self):
		a = math.sqrt(self.length2())
		return a

	# �����̓��(�����̃x�N�g���̒�����r�������������ꍇ�́A������̂ق��������Ƃ�������)
	def length2(self):
		return self.x * self.x + self.y * self.y + self.z * self.z

	# ����
	def dot(self, v):
		return self.x * v.x +  self.y * v.y + self.z * v.z

	# �O��
	def cross(self, v):
		x = self.y * v.z - self.z * v.y
		y = self.z * v.x - self.x * v.z
		z = self.x * v.y - self.y * v.x
		return Vector3D(x, y, z)

	# �P�ʃx�N�g��(������1�ɂ�������)	
	def unit(self):
		return self / self.length()
