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
	// 共有メモリを、名前、サイズを指定して生成する
	HANDLE h = CreateFileMapping(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, MEMORY_SIZE_H, MEMORY_SIZE_L, MEMORY_NAME);
	int e = GetLastError();
	switch (e) {
	case 0:
		break;
	case ERROR_ALREADY_EXISTS:
		printf("既に同名のメモリが確保されています。\n");
		return 1;
	default:
		reportError();
		return 1;
	}

	// 通常のメモリにマッピングする(マッピングする範囲を、開始位置(64bit)と長さ(32bit)で指定する)
	unsigned char *p = (unsigned char *) MapViewOfFile(h, FILE_MAP_WRITE, 0, 0, 0);

	// 試しにデータを書き込む
	for (int i = 0; i < MEMORY_SIZE_L; i++) {
		p[i] = i & 0xff;
	}

	// 待つ（この間にクライアントが共有メモリにアクセスする。）
	printf("press enter to exit.");
	getchar();

	// マッピングを解除
	if (!UnmapViewOfFile(p)) {
		reportError();
		return 1;
	}

	// 共有メモリを閉じる(開放する)
	if (!CloseHandle(h)) {
		reportError();
		return 1;
	}

	return 0;
}
