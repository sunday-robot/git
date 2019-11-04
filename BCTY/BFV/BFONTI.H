typedef struct {
	FILE *fp;
	unsigned char col;	// 最上位ビットがパレット情報の有無で、下位7ビットが色深度-1を示している。(例：モノクロなら0x00、16色なら0x03)
	int ncolor;
	unsigned char ttl, num;
	int Xdots, Ydots;
	int START, END;	// 開始、終了文字コード?
	char font_name[9];
	unsigned char time[4];
} BFontInfo;
