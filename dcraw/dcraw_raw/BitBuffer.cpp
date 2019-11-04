#include "BitBuffer.h"

BitBuffer::BitBuffer(
	const unsigned char *bytes,
	int size)
	:
	bytes(bytes),
	size(size)
{
	this->bitPosition = 0;
	this->bytePosition = 0;
}

// �w�肳�ꂽ�r�b�g���̃f�[�^���擾���A�Ԃ��B
unsigned int BitBuffer::peekBits(	// 0...65535
	int bitCount) const				// �r�b�g��(1...16)
{
	int x = bitPosition + bitCount;

	if (x <= 8) {
		// ���݂̃o�C�g�ʒu�Ɏ��܂�ꍇ
		unsigned char b0 = bytes[bytePosition] & (0xff >> bitPosition);
		return b0 >> (8 - x);
	}
	if (x <= 16) {
		// 2�o�C�g�ɂ܂�����ꍇ
		unsigned char b0 = bytes[bytePosition] & (0xff >> bitPosition);
		unsigned char b1 = bytes[bytePosition + 1];
		return ((b0 << 8) | b1) >> (16 - x);
	}
	// 3�o�C�g�ɂ܂�����ꍇ
	unsigned char b0 = bytes[bytePosition] & (0xff >> bitPosition);
	unsigned char b1 = bytes[bytePosition + 1];
	unsigned char b2 = bytes[bytePosition + 2];
	return ((b0 << 16) | (b1 << 8) | b2) >> (24 - x);
}

// 1�r�b�g�̃f�[�^�����o���A�r�b�g�ʒu��i�߂�B
unsigned int BitBuffer::getBit()
{
	unsigned int r = (bytes[bytePosition] >> (7 - bitPosition)) & 1;
	bytePosition += (bitPosition + 1) / 8;
	bitPosition = (bitPosition + 1) & 7;
	return r;
}

// 2�r�b�g�̃f�[�^�����o���A�r�b�g�ʒu��i�߂�B
unsigned int BitBuffer::getBits2()
{
	unsigned int r;
	if (bitPosition <= 6) {
		// ���݂̃o�C�g�ʒu�Ɏ��܂�ꍇ
		r = (bytes[bytePosition] >> (6 - bitPosition)) & 3;
	} else {
		// 2�o�C�g�ɂ܂�����ꍇ
		r = (((bytes[bytePosition] << 8) | bytes[bytePosition + 1]) >> 7) & 3;
	}
	bytePosition += (bitPosition + 2) / 8;
	bitPosition = (bitPosition + 2) & 7;
	return r;
}

// 3�r�b�g�̃f�[�^�����o���A�r�b�g�ʒu��i�߂�B
unsigned int BitBuffer::getBits3()
{
	unsigned int r;
	if (bitPosition <= 5) {
		// ���݂̃o�C�g�ʒu�Ɏ��܂�ꍇ
		r = (bytes[bytePosition] >> (5 - bitPosition)) & 0b111;
	} else {
		// 2�o�C�g�ɂ܂�����ꍇ
		r = (((bytes[bytePosition] << 8) | bytes[bytePosition + 1]) >> (13 - bitPosition)) & 0b111;
	}
	bytePosition += (bitPosition + 3) / 8;
	bitPosition = (bitPosition + 3) & 7;
	return r;
}

// 12�r�b�g�̃f�[�^�����o���A�r�b�g�ʒu��i�߂�B
unsigned int BitBuffer::peekBits12() const
{
	int x = bitPosition + 12;

	if (x <= 16) {
		// 2�o�C�g�ɂ܂�����ꍇ
		unsigned char b0 = bytes[bytePosition];
		unsigned char b1 = bytes[bytePosition + 1];
		return (((b0 << 8) | b1) >> (16 - x)) & 0xfff;
	}
	// 3�o�C�g�ɂ܂�����ꍇ
	unsigned char b0 = bytes[bytePosition];
	unsigned char b1 = bytes[bytePosition + 1];
	unsigned char b2 = bytes[bytePosition + 2];
	return (((b0 << 16) | (b1 << 8) | b2) >> (24 - x)) & 0xfff;
}

// �w�肳�ꂽ�r�b�g���̃f�[�^�����o���A�r�b�g�ʒu��i�߂�B
unsigned int BitBuffer::getBits(
	int bitCount)	// �r�b�g��(1...16)
{
	const int bits = peekBits(bitCount);
	progress(bitCount);
	return bits;
}
