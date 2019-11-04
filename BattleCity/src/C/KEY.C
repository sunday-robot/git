//
// キー、ジョイスティック入力のためのルーチン
//
// 93/5/1 05:07
// タイマー割り込みを使っても結果は同じ。
// むしろvsyncの時より暴走しやすくなった。
// これは、タイマー割り込みの方が呼ばれる間隔が短いためだからだろう。
// 今度はローカルスタックをMS-DOSレジデントプログラム入門を参考に設定してみる。
// ローカルスタックの設定をした場合、その関数からスタックチェックON(BorlandC
// では-N)でコンパイルされた関数を呼ぶと、SPが変わっているためにそのチェックに
// 引っ掛かってしまうため、"stack overflow"エラーが発生してしまう。
// またローカルスタックを設定しなくても、interrupt型の関数は、呼ばれたときに
// DSはきちんと設定されるが、SSやSPの値はそのままなので(考えればあたりまえ)、
// この関数から呼ばれる関数もスタックチェックOFFでコンパイルされていなければな
// らない。
// 今までは安全のためにと思ってこのオプションをONにしていたので、
// このエラーが発生していた。
//
// 93/5/1
// keyspを常駐させていると暴走してしまうことがあることがわかった。
// vsyncを止めてタイマー割り込みをフックしてみようと思う。
// タイマーはbgmlibで使用されていることを前提としているのでbgmlibが動作していな
// いといけない。HOOK_TIMERが定義されていれタイマー割り込みをフックする。
//
// ジョイスティックは、その押下状態のみしか知ることができず、押された、
// 離された、といったことを知ることができないので、vsync 割り込みを使って
// その押下状態をチェックすることで、擬似的に、そういった情報を得られるように
// している。
//
// DEBUGを定義することでvsync割り込みを使わなくなるのでTD.EXEでデバッグが
// 出来る。
// TESTを定義することでテストプログラムが出来上がる。
//
// 良く解らないが、割り込みルーチンsens_key()で、局所変数の宣言の仕方によって
// スタックオーバーフローのエラーが出ることがある。
// この場合、自動変数から静的変数に変える(staticを付ける)事で、
// とりあえず回避できる。
// ↑これもスタックチェックがONになっていたため。
//
// DISKアクセス中に割り込みルーチン内で処理を行うと暴走してしまう(原因は良くわ
// からない)。←これもスタックチェックがONになっていたため。
// DISKアクセスを行う間は処理を行わないように、あらかじめdisable_key()を呼ばな
// ければいけない。enable_key()で再び処理を行うようになる。
// 初期状態では処理を行わない。←これはもう必要ない。
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
	#define HOOK_VECTOR 0x08			// タイマー割り込みをフックする
	#define INTERVAL 20
#else
	#define HOOK_VECTOR 0x0a			// VSYNC割り込みをフックする
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
//	disable();
	key_queue.num = key_queue.head = key_queue.tail = key_queue.time_counter
		= key_queue.repeat_on = 0;
	key_queue.last_kc = -1;
//	enable();
}

void set_key_mode(KeyMode km)
{
/*
	printf("coreleft = %u\n", coreleft());
*/
//	disable();
	key_table.w = 0xff;
	if (km == KM_SELECT) {
		key_mode = KM_SELECT;
		kq_init();
	} else {
		int i;

		key_mode = KM_GAME;
		for (i = 0; i < 2; i++) {
			int j;

			for (j = 0; j < 5; j++)
				key_game[i].cursor[j] = -1;
			for (j = 0; j < 4; j++)
				key_game[i].button[j] = 0;
		}
	}
//	enable();
}

void set_joy_assign(JoyAssign ja)
{
	if (ja == JA_1P)
		joy_assign(JOY_NORMAL);
	else
		joy_assign(JOY_SHIFT);
	set_key_mode(key_mode);
}

// vsync割り込みで、キー、ジョイスティックの状態を得る
static void /*interrupt*/ sens_key(void)
{
	static flg = 0;

#if defined(LOCAL_STACK)
	static unsigned int old_ss, old_sp;
	static unsigned char local_stack[LOCAL_STACK_SIZE];
#endif

	KeyTable new_key_table;
	int i;

#if defined(HOOK_TIMER)
	// タイマー割り込みの間隔は非常に短いので数回に一回処理を行うようにする。
	// これはそのためのカウンタ。
	static int counter = INTERVAL;	
#endif

//	disable();
	if (flg) {
		return;
//		tvDisp(24, 0, TXT_WHITE, "SENS_KEY() ERROR");
//		exit(1);
	}
	flg = 1;
//	enable();

#if defined(LOCAL_STACK)
	// ローカルスタックの確保
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
			// 新たに押されたキー(ボタン)がない
			if (key_queue.last_kc != -1) {
				// 最後に押されたボタンが、まだ押されているか?
				if (++key_queue.time_counter
					> (key_queue.repeat_on ? KEY_REPEAT : KEY_REPEAT_START)) {
					key_queue.repeat_on = 1;
					key_queue.time_counter = 0;
					kq_enq(key_queue.last_kc);
				}
				if ((~new_key_table.w & key_table.w)
					& (1 << key_queue.last_kc)) {
					key_queue.last_kc = -1;
				}
			}
		} else {
			i = 0;
			do {
				if (kt.w & 1) {
					// kq_enq()はマクロかもしれないので{}は外してはいけない
					kq_enq(i);
				}
				i++;
				kt.w >>= 1;
			} while (kt.w);
			key_queue.last_kc = i - 1;
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
				// 十字ボタンの処理
				KeyCode *kgc;
				if (del_k & 1) {
					// 配列cursorから、新たに離されたキーのコードを取り除く
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
					// 配列cursorの先頭に、新たに押されたキーのコードを挿入する
					kgc = key_game[i].cursor;
					*(kgc + 3) = *(kgc + 2);
					*(kgc + 2) = *(kgc + 1);
					*(kgc + 1) = *kgc;
					*kgc = j;
				}
				// A、B、ESC、QUITボタンの処理
				if (del_k & 16)
					key_game[i].button[j] = 0;
				else if (add_k & 16)
					key_game[i].button[j] = 1;
			}
		}
	}
	key_table.w = new_key_table.w;
	joy_read_info(joy_info);

//sens_key_end:

#if !defined(DEBUG) && !defined(NOT_HOOK)
	// 元のルーチン(Femy氏のbgmlibあるいはTaka氏のvsynctimer)を呼び出す
	org_int();
#endif

#if defined(LOCAL_STACK)
	// ss、spを元に戻す
	disable();
	_SS = old_ss;
	_SP = old_sp;
//	enable();
#endif

	flg = 0;
}

// 十字ボタンのどの方向が押されているかをチェックする
// 下が0で半時計周りに123と割り当てている、何も押されていないなら-1を返す
int get_dir(int player)
{
	return key_game[player].cursor[0];
}

// ボタンが押されているかどうかをチェックする
int check_button(int player, int button)
{
	return key_game[player].button[button];
}

// ボタンが押されたという情報を消す
void reset_button(int player, int button)
{
	key_game[player].button[button] = 0;
}

// ボタンが押されているかどうかをチェックし、その情報を消す
int get_button(int player, int button)
{
	if (key_game[player].button[button]) {
		key_game[player].button[button] = 0;
		return 1;
	}
	return 0;
}

// int 0Ahのフック、JOY.LIB の初期化など
void init_key(void)
{
#if 00
	kinit();
	if (joy_init(JOY_NORMAL) != JOY_COMPLETE)
		fputs("init_key():サウンドボードが無いようです\n", stderr);
	joy_key_2player(JOY_TRUE);
	joy_key_assign(IRST1_1P, 0x00, 0x01);	// ESC キーを割り当てる
	joy_key_assign(TRIG1_2P, 0x0e, 0x01);
	joy_key_assign(TRIG2_2P, 0x0e, 0x10);
	set_key_mode(KM_SELECT);
	set_joy_assign(JA_1P);
	joy_read_info(joy_info);
#if !defined(DEBUG) && !defined(NOT_HOOK)
	if (org_int != NULL) {
		fputs("init_key():既に初期化されています", stderr);
	} else {
		org_int = getvect(HOOK_VECTOR);
		setvect(HOOK_VECTOR, sens_key);
	}
#endif	// DEBUG
#endif
}

// vsync割り込みのフックを解除する
void finish_key(void)
{
#if !defined(DEBUG) && !defined(NOT_HOOK)
	if (org_int == NULL) {
		puts("割り込み 0Ah をフックしていません");
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
	static char *table[5] = {"  ", "↓", "→", "↑", "←"};
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
