#include <dummy_library.h>
#include <stdlib.h>
#include <dir.h>
#include <bgmlib.h>
#include <joy.h>

int int_char_p(char *a) {
	return *a;
}

int int_int(int a) {
	return a;
}

int int_void() {
	return 0;
}

void void_void() {
	return;
}

void void_int(int a) {
	return;
}

int bgm_read_status(BSTAT *bstat) {
	bstat->play = 0;
	return 0;
}

int fnsplit(const char *filePath, char *drive, char *dir, char *fileName, char *extension) {
	return 0;
}

void fnmerge(char *buf, const char *drive, const char *dir, const char *file, const char *ext) {
}

void getdate(struct date *date) {
	date = NULL;
}

void gettime(struct time *time) {
	time = NULL;
}

void joy_read_info(JOY_INFO a[]) {
	return;
}
void joy_read_info2(JOY_INFO a[]) {
	return;
}

int super_entry_pat(int patsize, void *image, int clear_color) {
	return patsize + clear_color;
}

void super_put_1614(int x, int y, int pat_num) {
}

void over_put_1614(int x, int y, int pat_num) {
}
