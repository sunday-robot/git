/* key.c */
typedef enum {KM_SELECT, KM_GAME} KeyMode;
typedef enum {JA_1P, JA_2P} JoyAssign;

typedef enum {
	K_DOWN = 0, K_RIGHT = 1, K_UP = 2, K_LEFT = 3, K_A = 4, K_B = 5,
	K_Q = 6, K_ESC = 7,
	K_P2 = 8
} KeyCode;

#define get_quit_key() get_button(0, 2)
#define get_esc_key() get_button(0, 3)

int kq_deq(KeyCode *kc);
void set_key_mode(KeyMode km);
void set_joy_assign(JoyAssign ja);
int get_dir(int player);
int check_button(int player, int button);
void reset_button(int player, int button);
int get_button(int player, int button);
void init_key(void);
void finish_key(void);
