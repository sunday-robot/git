typedef struct {
	FILE *fp;
	unsigned char col;	// �ŏ�ʃr�b�g���p���b�g���̗L���ŁA����7�r�b�g���F�[�x-1�������Ă���B(��F���m�N���Ȃ�0x00�A16�F�Ȃ�0x03)
	int ncolor;
	unsigned char ttl, num;
	int Xdots, Ydots;
	int START, END;	// �J�n�A�I�������R�[�h?
	char font_name[9];
	unsigned char time[4];
} BFontInfo;