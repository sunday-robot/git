//
// �L�[�A�W���C�X�e�B�b�N���͂̂��߂̃��[�`��
//
// 93/5/1 05:07
// �^�C�}�[���荞�݂��g���Ă����ʂ͓����B
// �ނ���vsync�̎����\�����₷���Ȃ����B
// ����́A�^�C�}�[���荞�݂̕����Ă΂��Ԋu���Z�����߂����炾�낤�B
// ���x�̓��[�J���X�^�b�N��MS-DOS���W�f���g�v���O����������Q�l�ɐݒ肵�Ă݂�B
// ���[�J���X�^�b�N�̐ݒ�������ꍇ�A���̊֐�����X�^�b�N�`�F�b�NON(BorlandC
// �ł�-N)�ŃR���p�C�����ꂽ�֐����ĂԂƁASP���ς���Ă��邽�߂ɂ��̃`�F�b�N��
// �����|�����Ă��܂����߁A"stack overflow"�G���[���������Ă��܂��B
// �܂����[�J���X�^�b�N��ݒ肵�Ȃ��Ă��Ainterrupt�^�̊֐��́A�Ă΂ꂽ�Ƃ���
// DS�͂�����Ɛݒ肳��邪�ASS��SP�̒l�͂��̂܂܂Ȃ̂�(�l����΂�����܂�)�A
// ���̊֐�����Ă΂��֐����X�^�b�N�`�F�b�NOFF�ŃR���p�C������Ă��Ȃ���΂�
// ��Ȃ��B
// ���܂ł͈��S�̂��߂ɂƎv���Ă��̃I�v�V������ON�ɂ��Ă����̂ŁA
// ���̃G���[���������Ă����B
//
// 93/5/1
// keysp���풓�����Ă���Ɩ\�����Ă��܂����Ƃ����邱�Ƃ��킩�����B
// vsync���~�߂ă^�C�}�[���荞�݂��t�b�N���Ă݂悤�Ǝv���B
// �^�C�}�[��bgmlib�Ŏg�p����Ă��邱�Ƃ�O��Ƃ��Ă���̂�bgmlib�����삵�Ă���
// ���Ƃ����Ȃ��BHOOK_TIMER����`����Ă���^�C�}�[���荞�݂��t�b�N����B
//
// �W���C�X�e�B�b�N�́A���̉�����Ԃ݂̂����m�邱�Ƃ��ł����A�����ꂽ�A
// �����ꂽ�A�Ƃ��������Ƃ�m�邱�Ƃ��ł��Ȃ��̂ŁAvsync ���荞�݂��g����
// ���̉�����Ԃ��`�F�b�N���邱�ƂŁA�[���I�ɁA�������������𓾂���悤��
// ���Ă���B
//
// DEBUG���`���邱�Ƃ�vsync���荞�݂��g��Ȃ��Ȃ�̂�TD.EXE�Ńf�o�b�O��
// �o����B
// TEST���`���邱�ƂŃe�X�g�v���O�������o���オ��B
//
// �ǂ�����Ȃ����A���荞�݃��[�`��sens_key()�ŁA�Ǐ��ϐ��̐錾�̎d���ɂ����
// �X�^�b�N�I�[�o�[�t���[�̃G���[���o�邱�Ƃ�����B
// ���̏ꍇ�A�����ϐ�����ÓI�ϐ��ɕς���(static��t����)���ŁA
// �Ƃ肠��������ł���B
// ��������X�^�b�N�`�F�b�N��ON�ɂȂ��Ă������߁B
//
// DISK�A�N�Z�X���Ɋ��荞�݃��[�`�����ŏ������s���Ɩ\�����Ă��܂�(�����͗ǂ���
// ����Ȃ�)�B��������X�^�b�N�`�F�b�N��ON�ɂȂ��Ă������߁B
// DISK�A�N�Z�X���s���Ԃ͏������s��Ȃ��悤�ɁA���炩����disable_key()���Ă΂�
// ����΂����Ȃ��Benable_key()�ōĂя������s���悤�ɂȂ�B
// ������Ԃł͏������s��Ȃ��B������͂����K�v�Ȃ��B
//
#include <stdio.h>
#include <stdlib.h>
////#include <alloc.h>
#include <dos.h>
#include <joy.h>
#include <key.h>
#include <gr.h>
#include <mylib.h>
#include "key.h"

#if defined(LOCAL_STACK)
	#define LOCAL_STACK_SIZE 0x1000
#endif

#if defined(HOOK_TIMER)
	#define HOOK_VECTOR 0x08			// �^�C�}�[���荞�݂��t�b�N����
	#define INTERVAL 20
#else
	#define HOOK_VECTOR 0x0a			// VSYNC���荞�݂��t�b�N����
#endif

#define KEY_QUEUE_SIZE 16
#define KEY_REPEAT_START 20
#define KEY_REPEAT 2

enum {
	KT_DOWN = 1, KT_RIGHT = 2, KT_UP = 4, KT_LEFT = 8, KT_A = 16, KT_B = 32,
	KT_Q = 64, KT_ESC = 128
};

typedef union {
	unsigned int w;
	unsigned char b[2];
} KeyTable;

#if !defined(DEBUG) && !defined(NOT_HOOK)
static void /*interrupt*/ (*org_int)(void) = NULL;
#endif

static JOY_INFO joy_info[2];

static KeyMode key_mode;

static struct {
	KeyCode queue[KEY_QUEUE_SIZE];
	int head;
	int tail;
	int num;
	KeyCode last_kc;
	int time_counter;
	int repeat_on;
} key_queue;

static KeyTable key_table = {0xffff};

static struct {
	KeyCode cursor[5];
	int button[4];
} key_game[2];

#if 0
#define kq_enq(kc)\
{\
	disable();\
	if (key_queue.num < KEY_QUEUE_SIZE) {\
		key_queue.num++;\
		key_queue.queue[key_queue.tail] = kc;\
		if (++key_queue.tail >= KEY_QUEUE_SIZE)\
			key_queue.tail = 0;\
	}\
	enable();\
}
#else
static void kq_enq(KeyCode kc)
{
//	disable();
	if (key_queue.num < KEY_QUEUE_SIZE) {
		key_queue.num++;
		key_queue.queue[key_queue.tail] = kc;
		if (++key_queue.tail >= KEY_QUEUE_SIZE)
			key_queue.tail = 0;
	}
//	enable();
}
#endif

int kq_deq(KeyCode *kc)
{
#if 0
	disable();
	if (key_queue.num > 0) {
		key_queue.num--;
		*kc = key_queue.queue[key_queue.head];
		if (++key_queue.head >= KEY_QUEUE_SIZE)
			key_queue.head = 0;
		_AX = 1;
	} else
		_AX = 0;
	enable();
	return _AX;
#else
	return 0;
#endif
}

static void kq_init(void)
{
	key_queue.num = key_queue.head = key_queue.tail = key_queue.time_counter
		= key_queue.repeat_on = 0;
////	key_queue.last_kc = -1;
}

void set_key_mode(KeyMode km)
{
	key_table.w = 0xff;
	if (km == KM_SELECT) {
		key_mode = KM_SELECT;
		kq_init();
	} else {
		int i;

		key_mode = KM_GAME;
		for (i = 0; i < 2; i++) {
			int j;

////			for (j = 0; j < 5; j++)
////				key_game[i].cursor[j] = -1;
			for (j = 0; j < 4; j++)
				key_game[i].button[j] = 0;
		}
	}
}

void set_joy_assign(JoyAssign ja)
{
	if (ja == JA_1P)
		joy_assign(JOY_NORMAL);
	else
		joy_assign(JOY_SHIFT);
	set_key_mode(key_mode);
}

// vsync���荞�݂ŁA�L�[�A�W���C�X�e�B�b�N�̏�Ԃ𓾂�
static void /*interrupt*/ sens_key(void)
{
	static int flg = 0;

#if defined(LOCAL_STACK)
	static unsigned int old_ss, old_sp;
	static unsigned char local_stack[LOCAL_STACK_SIZE];
#endif

	KeyTable new_key_table;
	int i;

#if defined(HOOK_TIMER)
	// �^�C�}�[���荞�݂̊Ԋu�͔��ɒZ���̂Ő���Ɉ�񏈗����s���悤�ɂ���B
	// ����͂��̂��߂̃J�E���^�B
	static int counter = INTERVAL;	
#endif

	if (flg) {
		return;
	}
	flg = 1;

#if defined(LOCAL_STACK)
	// ���[�J���X�^�b�N�̊m��
	disable();
	old_ss = _SS;
	old_sp = _SP;
	_SS = _DS;
	_SP = (unsigned int) &local_stack[LOCAL_STACK_SIZE];
	enable();
#endif

#if defined(HOOK_TIMER)
	if (--counter > 0)
		goto sens_key_end;
	counter = INTERVAL;
#endif

	joy_read_info2(joy_info);
	for (i = 0; i < 2; i++) {
		JOY_INFO *j;
//		unsigned char new_kt;

		j = &joy_info[i];
#if 00
		if (j->down)	new_kt = KT_DOWN;
		else			new_kt = 0;
		if (j->right)	new_kt |= KT_RIGHT;
		if (j->up)		new_kt |= KT_UP;
		if (j->left)	new_kt |= KT_LEFT;
		if (j->trig1)	new_kt |= KT_A;
		if (j->trig2)	new_kt |= KT_B;
		if (j->irst0)	new_kt |= KT_Q;
		if (j->irst1)	new_kt |= KT_ESC;
		new_key_table.b[i] = new_kt;
#endif
	}
	if (key_mode == KM_SELECT) {
		KeyTable kt;

		kt.w = new_key_table.w & ~key_table.w;
		if (kt.w == 0) {
			// �V���ɉ����ꂽ�L�[(�{�^��)���Ȃ�
			if (key_queue.last_kc != -1) {
				// �Ō�ɉ����ꂽ�{�^�����A�܂�������Ă��邩?
				if (++key_queue.time_counter
					> (key_queue.repeat_on ? KEY_REPEAT : KEY_REPEAT_START)) {
					key_queue.repeat_on = 1;
					key_queue.time_counter = 0;
					kq_enq(key_queue.last_kc);
				}
				if ((~new_key_table.w & key_table.w)
					& (1 << key_queue.last_kc)) {
////					key_queue.last_kc = -1;
				}
			}
		} else {
			i = 0;
			do {
				if (kt.w & 1) {
					// kq_enq()�̓}�N����������Ȃ��̂�{}�͊O���Ă͂����Ȃ�
////					kq_enq(i);
				}
				i++;
				kt.w >>= 1;
			} while (kt.w);
////			key_queue.last_kc = i - 1;
			key_queue.repeat_on = 0;
			key_queue.time_counter = 0;
		}
	} else {	// KM_GAME
		for (i = 0; i < 2; i++) {
			unsigned char add_k;
			unsigned char del_k;
			int j;

			add_k = new_key_table.b[i] & ~key_table.b[i];
			del_k = ~new_key_table.b[i] & key_table.b[i];
			for (j = 0; j < 4; j++, add_k >>= 1, del_k >>= 1) {
				// �\���{�^���̏���
				KeyCode *kgc;
				if (del_k & 1) {
					// �z��cursor����A�V���ɗ����ꂽ�L�[�̃R�[�h����菜��
					kgc = key_game[i].cursor;
					while (*kgc != -1) {
						if (*kgc == j) {
							while ((*kgc = *(kgc + 1)) != -1)
								kgc++;
							break;
						}
						kgc++;
					}
				} else if (add_k & 1) {
					// �z��cursor�̐擪�ɁA�V���ɉ����ꂽ�L�[�̃R�[�h��}������
					kgc = key_game[i].cursor;
					*(kgc + 3) = *(kgc + 2);
					*(kgc + 2) = *(kgc + 1);
					*(kgc + 1) = *kgc;
////					*kgc = j;
				}
				// A�AB�AESC�AQUIT�{�^���̏���
				if (del_k & 16)
					key_game[i].button[j] = 0;
				else if (add_k & 16)
					key_game[i].button[j] = 1;
			}
		}
	}
	key_table.w = new_key_table.w;
	joy_read_info(joy_info);

#if !defined(DEBUG) && !defined(NOT_HOOK)
	// ���̃��[�`��(Femy����bgmlib���邢��Taka����vsynctimer)���Ăяo��
	org_int();
#endif

#if defined(LOCAL_STACK)
	// ss�Asp�����ɖ߂�
	disable();
	_SS = old_ss;
	_SP = old_sp;
#endif

	flg = 0;
}

// �\���{�^���̂ǂ̕�����������Ă��邩���`�F�b�N����
// ����0�Ŕ����v�����123�Ɗ��蓖�ĂĂ���A����������Ă��Ȃ��Ȃ�-1��Ԃ�
int get_dir(int player)
{
	return key_game[player].cursor[0];
}

// �{�^����������Ă��邩�ǂ������`�F�b�N����
int check_button(int player, int button)
{
	return key_game[player].button[button];
}

// �{�^���������ꂽ�Ƃ�����������
void reset_button(int player, int button)
{
	key_game[player].button[button] = 0;
}

// �{�^����������Ă��邩�ǂ������`�F�b�N���A���̏�������
int get_button(int player, int button)
{
	if (key_game[player].button[button]) {
		key_game[player].button[button] = 0;
		return 1;
	}
	return 0;
}

// int 0Ah�̃t�b�N�AJOY.LIB �̏������Ȃ�
void init_key(void)
{
#if 00
	kinit();
	if (joy_init(JOY_NORMAL) != JOY_COMPLETE)
		fputs("init_key():�T�E���h�{�[�h�������悤�ł�\n", stderr);
	joy_key_2player(JOY_TRUE);
	joy_key_assign(IRST1_1P, 0x00, 0x01);	// ESC �L�[�����蓖�Ă�
	joy_key_assign(TRIG1_2P, 0x0e, 0x01);
	joy_key_assign(TRIG2_2P, 0x0e, 0x10);
	set_key_mode(KM_SELECT);
	set_joy_assign(JA_1P);
	joy_read_info(joy_info);
#if !defined(DEBUG) && !defined(NOT_HOOK)
	if (org_int != NULL) {
		fputs("init_key():���ɏ���������Ă��܂�", stderr);
	} else {
		org_int = getvect(HOOK_VECTOR);
		setvect(HOOK_VECTOR, sens_key);
	}
#endif	// DEBUG
#endif
}

// vsync���荞�݂̃t�b�N����������
void finish_key(void)
{
#if !defined(DEBUG) && !defined(NOT_HOOK)
	if (org_int == NULL) {
		puts("���荞�� 0Ah ���t�b�N���Ă��܂���");
	} else {
////		setvect(HOOK_VECTOR, org_int);
		org_int = NULL;
	}
#endif DEBUG
//	kinit();
}

//#define TEST
#if defined (TEST)
#include <conio.h>

int print_key(int player)
{
	static char *table[5] = {"  ", "��", "��", "��", "��"};
	int i, r = 0;

	for (i = 0; i < 5; i++)
		printf("%s", table[key_game[player].cursor[i] + 1]);
	printf(", ");
	for (i = 0; i < 4; i++) {
		int b = get_button(player, i);

		if (i == 3 && b)
			r = 1;
		printf("%d", b);
	}
	printf(", %02x", key_table.b[player]);
	return r;
}

void main(void)
{
	int end;
	KeyCode kc;

#if defined(PROF)
	profinit("main", main);
#endif
	DisableCtrlC();
	DisableKeyBeep();
#if !defined(DEBUG)
	timeStart();
#endif
	init_key();
    set_key_mode(KM_SELECT);
	end = 0;
	while (!end) {
#if !defined(DEBUG) && !defined(NOT_HOOK)
		while (!kq_deq(&kc))
			;
		printf("%d\n", kc);
		if (kc == K_ESC)
			end = 1;
#else
		sens_key();
		while (kq_deq(&kc)) {
			printf("%d\n", kc);
			if (kc == K_ESC)
				end = 1;
		}
#endif
	}
	set_key_mode(KM_GAME);
	end = 0;
	while (!end) {
#if !defined(DEBUG) && !defined(NOT_HOOK)
		while (timeSpent() < 2)
			;
		timeReset();
#else
		sens_key();
#endif
		end |= print_key(0);
		printf("|");
		end |= print_key(1);
		putchar('\n');
	}
	finish_key();
#if !defined(DEBUG)
	timeStop();
#endif
	EnableKeyBeep();
	EnableCtrlC();
	while (kbhit())
		(void)getch();
	exit(0);
}

#endif