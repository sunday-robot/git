#include <tchar.h>
#include <Windows.h>
#include <stdio.h>

const wchar_t *MEMORY_NAME = L"ShareMemory";
const DWORD MEMORY_SIZE = 1000;


void reportError() {
	DWORD errorCode = GetLastError();
	wchar_t buf[1000];
	FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, NULL, errorCode, 0, buf, sizeof(buf), NULL);
	wprintf(L"GetLastError() = %d, %s\n", errorCode, buf);
	getchar();
}

int _tmain(int argc, _TCHAR* argv[]) {
	//HANDLE h = OpenFileMapping(PAGE_READWRITE, true, MEMORY_NAME);
	HANDLE h = CreateFileMapping(INVALID_HANDLE_VALUE, NULL, PAGE_READWRITE, 0, MEMORY_SIZE, MEMORY_NAME);
	if (h == NULL) {
		int e = GetLastError();
		switch (e) {
		case 0:
			break;
		default:
			reportError();
			return 1;
		}
	}
	unsigned char  *p = (unsigned char *) MapViewOfFile(h, FILE_MAP_WRITE, 0, 0, 0);
	if (p == NULL) {
		reportError();
		return 1;
	}

	for (int i = 0; i < 1000; i++) {
		unsigned char uc = p[i];
		printf("%02X ", uc);
		if ((i & 0x0f) == 0xf)
			putchar('\n');
	}

	printf("press enter to exit.");
	getchar();

	if (!UnmapViewOfFile(p)) {
		reportError();
	}

	if (!CloseHandle(h)) {
		reportError();
	}

	return 0;
}
