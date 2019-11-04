#include <tchar.h>
#include <Windows.h>
#include <stdio.h>

const wchar_t *MEMORY_NAME = L"ShareMemory";

const DWORD32 MEMORY_SIZE_L = 0x00001000;
const DWORD32 MEMORY_SIZE_H = 0x00000000;

void reportError() {
	DWORD errorCode = GetLastError();
	printf("GetLastError() = %08x\n", errorCode);
	getchar();
}

int _tmain(int argc, _TCHAR* argv[]) {
	// ���L���������A���O�A�T�C�Y���w�肵�Đ�������
	HANDLE h = CreateFileMapping(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, MEMORY_SIZE_H, MEMORY_SIZE_L, MEMORY_NAME);
	int e = GetLastError();
	switch (e) {
	case 0:
		break;
	case ERROR_ALREADY_EXISTS:
		printf("���ɓ����̃��������m�ۂ���Ă��܂��B\n");
		return 1;
	default:
		reportError();
		return 1;
	}

	// �ʏ�̃������Ƀ}�b�s���O����(�}�b�s���O����͈͂��A�J�n�ʒu(64bit)�ƒ���(32bit)�Ŏw�肷��)
	unsigned char *p = (unsigned char *) MapViewOfFile(h, FILE_MAP_WRITE, 0, 0, 0);

	// �����Ƀf�[�^����������
	for (int i = 0; i < MEMORY_SIZE_L; i++) {
		p[i] = i & 0xff;
	}

	// �҂i���̊ԂɃN���C�A���g�����L�������ɃA�N�Z�X����B�j
	printf("press enter to exit.");
	getchar();

	// �}�b�s���O������
	if (!UnmapViewOfFile(p)) {
		reportError();
		return 1;
	}

	// ���L�����������(�J������)
	if (!CloseHandle(h)) {
		reportError();
		return 1;
	}

	return 0;
}
