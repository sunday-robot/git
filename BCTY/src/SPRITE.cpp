#include <stdio.h>
#include <stdlib.h>
#include <stdarg.h>
#include <mem.h>

#include "gr.h"
#include "super.h"

#include "super_bc.h"
#include "sprite_t.h"

#define MAX_BG_LEVEL 2					// �n�ʁA�X�� 2 ���x��
#define MAX_BG_X 64						// (640 / 16) �v�Z�𑬂����邽��
#define MAX_BG_Y 32						// (400 / 14)
#define MAX_BG_RESTORE_INFO 150			// BG�̕������̍ő吔

#define MAX_REQUEST 30	// ���N�G�X�g�̍ő吔(=��x�ɕ\���ł���L�����N�^�[��)
#define MAX_SPRITE_LEVEL 3				// ��ԁA���� & �e�A�A�C�e�� & �_��

typedef struct {
	int pat_num;
	int pat_size;
	int x, y;
} Request;

typedef struct {
	int num_of_request;
	Request request[MAX_REQUEST];
} RequestBuffer;

// �L�����N�^�\���v�������߂Ă����o�b�t�@
static RequestBuffer request_buffer[MAX_SPRITE_LEVEL];

typedef struct {
	int bg[MAX_BG_Y][MAX_BG_X];
} BgVram;

// BG �p�� VRAM
static BgVram bg_vram[MAX_BG_LEVEL];

typedef struct {
	int x, y;
} BgRestoreInfo;

typedef struct {
	BgRestoreInfo bri[MAX_BG_RESTORE_INFO];
	int num_of_info;
	unsigned char set_table[MAX_BG_Y][MAX_BG_X];
} BgRestoreInfoBuffer;

// BG �����������߂Ă����o�b�t�@
static BgRestoreInfoBuffer bg_restore_info_buffer[2 /* �y�[�W�� */][MAX_BG_LEVEL];
static BgRestoreInfoBuffer *current_brib;

// ���ݏ������ݑΏۂƂȂ��Ă��� VRAM �̃y�[�W
static int page;

// �o�^����Ă���p�^�[���̐�
static int num_of_pat;

// �L�����N�^�̕\���v�����o�b�t�@�ɂ��߂�
int put_sprite(Sprite *sp, int x, int y, int koma)
{
	RequestBuffer *rb = &request_buffer[sp->level];
	Request *r = &rb->request[rb->num_of_request++];

	if (rb->num_of_request > MAX_REQUEST) {
		puts("put_sprite: request buffer is full");
		rb->num_of_request = MAX_REQUEST;
		return 0;
	}
	r->pat_num = sp->pat_num + koma;
	r->pat_size = super_getsize_pat_x(r->pat_num) >> 4;
	r->x = x;
	r->y = y;
	if (r->pat_num >= num_of_pat
		|| r->x < 0 || r->x + r->pat_size * 16 > 640
		|| r->y < 0 || r->y + r->pat_size * 16 > MAX_BG_Y * 16) {
		printf("put_sprite():�l���͈͂��z���Ă��܂� pat_num = %d,"
			   "pat_size = %d, x = %d, y = %d\n", r->pat_num, r->pat_size,
			   r->x, r->y);
		printf("num_of_pat = %d\n", num_of_pat);
		rb->num_of_request--;
		return 0;
	} else
		return 1;
}

// �w�i���Z�b�g����
// �X�v���C�g�̕\�����J�n����O�ɂ���Ŕw�i���Z�b�g���Ă���
void set_BG(int x, int y, int level, int pat_num)
{
	BgVram *bv = &bg_vram[level];
	void (*put_proc)(int, int, int);

	bv->bg[y][x] = pat_num;
	if (level > 0)
		put_proc = super_put_1614;
	else
		put_proc = over_put_1614;
	grAPage(0);	put_proc(x, y, pat_num);
	grAPage(1);	put_proc(x, y, pat_num);
}

// ���^�ɔw�i���Z�b�g����
void set_BG_box(int x, int y, int width, int height, int level, int pat_num)
{
	int xx, x2 = x + width, y2 = y + height;
	for (; y < y2; y++)
		for (xx = x; xx < x2; xx++)
			set_BG(xx, y, level, pat_num);
}

// BG �̕��A����������
static void add_BG_restore_info(int x, int y, int level)
{
//	BgRestoreInfoBuffer *brib = &bg_restore_info_buffer[page][level];
	BgRestoreInfoBuffer *brib = current_brib + level;
	BgRestoreInfo *bri;

	if (bg_vram[level].bg[y][x] == -1)
		return;							// ���̏ꏊ����Ȃ牽�����Ȃ�
	if (brib->set_table[y][x])
		return;		// ���̏ꏊ�̕��A��񂪊��ɃZ�b�g����Ă���Ȃ牽�����Ȃ�
	if (brib->num_of_info >= MAX_BG_RESTORE_INFO) {
		// BG ���A���o�b�t�@����t�Ȃ牽���o���Ȃ�
		printf("BG restore info buffer is full"
			   "(level = %d, num_of_info = %d)\n", level, brib->num_of_info);
		return;
	}
	brib->set_table[y][x] = 1;
	bri = &brib->bri[brib->num_of_info++];
	bri->x = x;
	bri->y = y;
}

static void __change_page(void)
{
	page ^= 1;
	current_brib = bg_restore_info_buffer[page];
}

// �w�i�̕ύX
// �X�v���C�g�̕\���J�n��ɔw�i��ύX����Ƃ��Ɏg��
void change_BG(int x, int y, int level, int pat_num)
{
	bg_vram[level].bg[y][x] = pat_num;
	add_BG_restore_info(x, y, 0);
	__change_page();
	add_BG_restore_info(x, y, 0);
	__change_page();
}

// �w�肳�ꂽ���x���� BG �𕜌�����
static void restore_BG(int level)
{
//	BgRestoreInfoBuffer *brib = &bg_restore_info_buffer[page][level];
	BgRestoreInfoBuffer *brib = current_brib + level;
	BgRestoreInfo *bri = brib->bri;
	void (*put_proc)(int, int, int);
	int n = brib->num_of_info;
	int i;

	if (level == 0)
		put_proc = over_put_1614;
	else
		put_proc = super_put_1614;
	if (level != MAX_BG_LEVEL - 1) {
		int upper_level = level + 1;
		for (i = 0; i < n; i++, bri++) {
			put_proc(bri->x, bri->y, bg_vram[level].bg[bri->y][bri->x]);
			add_BG_restore_info(bri->x, bri->y, upper_level);
		}
	} else
		for (i = 0; i < n; i++, bri++)
			put_proc(bri->x, bri->y, bg_vram[level].bg[bri->y][bri->x]);
	memset(brib->set_table, 0, MAX_BG_Y * MAX_BG_X);
	brib->num_of_info = 0;
}

// �w�肳�ꂽ���x���̃L�����N�^��\������
static void put_characters(int level)
{
	RequestBuffer *rb = &request_buffer[level];
	Request *r = rb->request;
	int i, n = rb->num_of_request;

	for (i = 0; i < n; i++, r++) {
		int pat_size = r->pat_size;
		int x = r->x, y = r->y;
		int bg_x = x / 16, bg_y = y / 16;
		int bg_x2 = bg_x + pat_size, bg_y2 = bg_y + pat_size;

		if (x & 15)
			bg_x2++;
		if (y & 15)
			bg_y2++;
		for (; bg_y < bg_y2; bg_y++) {
			int x;
			for (x = bg_x; x < bg_x2; x++) {
				int i;
				for (i = 0; i < MAX_BG_LEVEL; i++)
					add_BG_restore_info(x, bg_y, i);
			}
		}
		super_put_bc(x, y * 7 / 8, r->pat_num);	// �����W�̒���
	}
	rb->num_of_request = 0;
}

// ���ۂɃL�����N�^�� VRAM �ɏ�������
void update_screen(void)
{
	restore_BG(0);						// �n��
	put_characters(0);					// ��ԂȂ�
	put_characters(1);					// �����A�e�Ȃ�
	restore_BG(1);						// �X
	put_characters(2);					// �A�C�e���A���_�Ȃ�
}

void change_page(void)
{
	WaitVsync();
//	while(!(inp(0x60)&0x20));
	grVPage(page);
	__change_page();
	grAPage(page);
}

// �X�v���C�g�̃p�^�[����ύX����
void change_pattern(Sprite *spr, int pat_num, int level)
{
	if (pat_num >= num_of_pat || pat_num < 0) {
		printf("change_pattern(): pat_num is out of range (%d)\n", pat_num);
		exit(1);
	}
	if (level >= MAX_SPRITE_LEVEL || level < 0) {
		printf("change_pattern(): level is out of range (%d)\n", level);
		exit(1);
	}
	spr->pat_num = pat_num;
	spr->level = level;
}

// ���������K�v�ȕϐ�������������
void reset_sprite(void)
{
	int i, j;

	page = 1;
	__change_page();
	for (i = 0; i < MAX_SPRITE_LEVEL; i++)
		request_buffer[i].num_of_request = 0;
	for (i = 0; i < 2; i++) {
		for (j = 0; j < MAX_BG_LEVEL; j++) {
			bg_restore_info_buffer[i][j].num_of_info = 0;
			memset(bg_restore_info_buffer[i][j].set_table, 0, MAX_BG_X * MAX_BG_Y);
		}
	}
	// BG VRAM �����x�� 0 �ȊO�̓N���A����
	for (i = 1; i < MAX_BG_LEVEL; i++)
		memset(bg_vram[i].bg, 0xff, 2 * MAX_BG_X * MAX_BG_Y);
}

int read_bfnt(char *fname, ...)
{
	va_list argptr;
	char *fn = fname;

	va_start(argptr, fname);
	num_of_pat = 0;
	do {
		int r;

		fprintf(stderr, "reading %s\n", fn);
		if ((r = super_entry_bfnt(fn)) <= 0) {
			char *s;
			switch (r) {
			case InsufficientMemory:
				s = "not enough memory";
				break;
			case FileNotFound:
				s = "file not found";
				break;
			case InvalidData:
				s = "file illegal";
				break;
			case GeneralFailure:
				s = "too many";
				break;
			default:
				s = "unknown error";
			};
			fprintf(stderr, "Error: %s(%s)\n", s, fn);
			exit(1);
		}
//		printf("%d\n", r);
		num_of_pat += r;
		fn = (char *)va_arg(argptr, char *);
	} while (fn != NULL);

	va_end(argptr);
	return num_of_pat;
}

// �L�����N�^�R�[�h���p�^�[���i���o�[�̃e�[�u��
// �p�^�[�������o�^�̏ꍇ-1�������Ă���
static int c2pat_table[255];

// �t�H���g���p�^�[���Ƃ��ēo�^����Ƃ��̐F
static int font_pat_color = 7;

void set_font_color(int color)
{
	font_pat_color = color;
}

void BG_putc(int x, int y, int level, int c)
{
	extern unsigned int grFontSeg;

	if (c2pat_table[c] == -1) {
		unsigned char buf[4][2 * 16];
		int i, pat_num;
		for (i = 0; i < 4; i++) {
			if (font_pat_color & (1 << i))
				_fmemcpy(MK_FP(_SS, &buf[i]), MK_FP(grFontSeg, c * 2 * 16),
					2 * 16);
			else
				_fmemset(MK_FP(_SS, &buf[i]), 0, 2 * 16);
		}
		if ((pat_num = super_entry_pat(SIZE16x16, MK_FP(_SS, buf), 0)) < 0)
			return;
		num_of_pat++;
		c2pat_table[c] = pat_num;
	}
	change_BG(x, y, level, c2pat_table[c]);
}

void BG_puts(int x, int y, int level, char *s)
{
	while (*s)
		BG_putc(x++, y, level, *s++);
}

void init_sprite(void)
{
	int i;
	for (i = 0; i < 255; i++)
		c2pat_table[i] = -1;
}
