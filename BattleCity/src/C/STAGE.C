// ステージファイルの構造：
// ステージデータの集合
// ステージデータの構造：
// 地形データが２６バイト＊２６行あり、その後、敵戦車のデータ２０台分

// 指定したステージのデータを読み込み、表示する
void read_stage_data(int comp_tanks[20])
{
	static char stage_char[] = ".#*%$~";
	int x, y;
	int i;

	fseek(fp, stage_number * STAGE_DATA_SIZE, SEEK_SET);

	// 周囲の枠をセットする。(FRAMEは、周囲の枠の画像番号で、FRAMEが水平の棒、FRAME+1が垂直の棒、以降左上、右上、左下、右下となっている)
	set_stage_char(0, 0, FRAME + 2);
	set_stage_char(STAGE_SIZE - 1, 0, FRAME + 3);
	set_stage_char(0, STAGE_SIZE - 1, FRAME + 4);
	set_stage_char(STAGE_SIZE - 1, STAGE_SIZE - 1, FRAME + 5);
	for (i = 1; i < STAGE_SIZE - 1; i++) {
		set_stage_char(i, 0, FRAME);					// 左端の縦棒
		set_stage_char(i, STAGE_SIZE - 1, FRAME);		// 右端の縦棒
		set_stage_char(0, i, FRAME + 1);				// 上の横棒
		set_stage_char(STAGE_SIZE - 1, i, FRAME + 1);	// 下の横棒
	}
	
	// ファイルから1バイトずつ読み、対応する背景(レンガや森など)をセットする
	for (y = 1; y < STAGE_SIZE - 1; y++) {
		for (x = 1; x < STAGE_SIZE - 1; x++) {
			char c = fgetc(fp);
			int type = (int)strchr(stage_char, c);
			if (type == 0) {
				fprintf(stderr, "stage.c, read_stage_data(): "
					   "ステージファイル %d 行 %d 桁に異常な文字('%c', %02x)が"
					   "あります。\n", stage_number * 27 + 2 + y - 1, x, c, c);
				type = 0;
			} else
				type -= (int)stage_char;
			set_stage_char(x, y, type);
		}
		fgetc(fp);	// 改行コードを読み飛ばす
	}

	// 敵戦車の登場順序をファイルから読み込む
	// 敵戦車は1ステージで20台登場する。敵戦車はA-D、a-dで示され、大文字が???を示す。
	for (x = 0; x < 20; x++) {
		char c = fgetc(fp);
		int ct = (toupper(c) - 'A') * 2 + (isupper(c) ? 1 : 0);
		if (ct < 0 || ct > 7) {
			fprintf(stderr, "read_stage(): illegal tank type '%c'\n", c);
			ct = 0;
		}
		comp_tanks[x] = ct;
//		printf("%d ", ct);
	}
}

// ステージの選択を行う
void select_stage(void)
{
	static char s[] = "STAGE";
	static add_value[] = {-1, -10, 1, 10};
	char buf[3];

	txtCls();
	change_tone(0);
	grAPage(0);
	grVPage(0);
	grCls();
	gfDisp(25 / 2, (80 - sizeof(s) - 3) / 2, TXT_WHITE, s);
	sprintf(buf, "%02d", stage_number + 1);
	gfDisp(25 / 2, 40 + (sizeof(s) + 1), TXT_WHITE, buf);

	set_key_mode(KM_SELECT);
	while (1) {
		KeyCode key;

		while (!kq_deq(&key))
			;
		key &= ~K_P2;
		if (key <= K_LEFT) {
			int new_sn = stage_number + add_value[key];
			if (new_sn >= 0 && new_sn < num_of_stages) {
#if !defined(PROF)
				sound_out(EFS_S_SELECT);
#endif
				stage_number = new_sn;
				sprintf(buf, "%02d", stage_number + 1);
				gfDisp(25 / 2, 40 + (sizeof(s) + 1), TXT_WHITE, buf);
			}
		} else if (key <= K_B)
			break;
	}
#if !defined(PROF)
	sound_out(EFS_DETERM);
#endif
}
