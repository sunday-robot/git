# coding:sjis
# Vector3D�ɁA�ȉ��̊g�����������
# �EMQPoint�������Ƃ���R���X�g���N�^��ǉ�
# �EMQPoint�𐶐����郁�\�b�h��ǉ�

from vector3d import Vector3D

def fromMQPoint(mqpoint):
	return Vector3D(mqpoint.x, mqpoint.y, mqpoint.z)

def toMQPoint(v):
	return MQSystem.newPoint(v.x, v.y, v.z)

Vector3D.fromMQPoint = fromMQPoint
Vector3D.toMQPoint = toMQPoint
