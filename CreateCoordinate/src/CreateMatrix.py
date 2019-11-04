# coding:shift_jis
# �I������Ă���3�p�`����A���[�J�����W�n��ݒ肵���V���ȃI�u�W�F�N�g�𐶐�����B
# ��Ԓ����ӂɑ����Ȃ����_�����_�Ƃ���B
# ���_
# ��Z���Ƃ���B���̕ӂ̏I�_�����_�Ƃ��A�n�_��Z���̌����Ƃ���B
# �O�p�`�̖ʂ�XZ���ʂƂ���B�ʂ̕\����Y���̌����ł���B


# �O�p�`�̒��_�̃��X�g����A���[�J�����W�n�̌��_�ƁA�厲�ƕ����̃x�N�g�����擾����
def _getOriginAndVectors(p0, p1, p2):
    # �O�p�`�̊e�ӂ̃x�N�g��
    v20 = p2 - p0
    v12 = p1 - p2
    v01 = p0 - p1

    # �O�p�`�̊e�ӂ̒���(�ǂ̕ӂ��Œ����𒲂ׂ邽�߂Ɏg�p���邾���Ȃ̂ŁA�����̓��ł��悢)
    l20 = v20.length2()
    l12 = v12.length2()
    l01 = v01.length2()

    # ��Ԓ����ӂ𒲂ׁA���_ origin, �厲(Z��)a1�A����(X��)a2����肷��
    if l01 > l12:
        if l01 > l20:
            # l01, (l20 | l12)
            origin = p2
            a1 = v12
            a2 = -v20
        else:
            # l20, (l12 | l20)
            origin = p1
            a1 = v01
            a2 = -v12
    else:
        if l12 > l20:
            # l12, (l01 | l20)
            origin = p0
            a1 = v20
            a2 = -v01
        else:
            # l20, l12, l01
            origin = p1
            a1 = v01
            a2 = -v12
    return (origin, a1, a2)

# ���肳�ꂽ�厲a1�A����a2����A���K�����ꂽZ���AX���AY���𐶐�����
def _calcAxes(a1, a2):
    az = a1.unit()
    ax = (a2 - a1 * a1.dot(a2) / a1.dot(a1)).unit()
    ay = az.cross(ax)
    return (ax, ay, az)

def createMatrix(p0, p1, p2):
    """
    @return: (���_���W, X��, Y��, Z��)
    @param p0: ���_���W1
    @param p1: ���_���W2
    @param p2: ���_���W3
    """
    (origin, a1, a2) = _getOriginAndVectors(p0, p1, p2)
    (ax, ay, az) = _calcAxes(a1, a2)
    return (origin, ax, ay, az)
