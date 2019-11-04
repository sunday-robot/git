#include <stdio.h>
#include <string.h>
#include <dir.h>
#define USEOPNDRV
#include "bgmopn.h"

int music_load_opn_list(char *fname)
{
	char list_file_name[MAXPATH], opn_file_name[MAXPATH + 1];
	// opn_file_nameのサイズがMAXPATH+1となっているのはファイルからfgets()で
	// 読み込むので改行文字の事も考えてのこと
	char drive[MAXDRIVE], dir[MAXDIR], file[MAXFILE], ext[MAXEXT];
	FILE *fp;

	if (!(fnsplit(fname, drive, dir, file, ext) & EXTENSION))
		strcpy(ext, ".lst");
	fnmerge(list_file_name, drive, dir, file, ext);
	fp = fopen(list_file_name, "r");
	if (fp == NULL)
		return 0;
	while (fgets(opn_file_name, sizeof(opn_file_name), fp) != NULL) {
		int l, flag;
		char opn_drive[MAXDRIVE], opn_dir[MAXDIR], opn_file[MAXFILE];
		l = strlen(opn_file_name);
		if (opn_file_name[l - 1] == '\n')
			opn_file_name[l - 1] = '\0';
		flag = fnsplit(opn_file_name, opn_drive, opn_dir, opn_file, NULL);
		if ((flag & (DRIVE | DIRECTORY)) == 0) {
			// ドライブ、ディレクトリが含まれないならリストファイルのあった
			// ドライブ、ディレクトリを使う
			fnmerge(opn_file_name, drive, dir, opn_file, "");
		} else {
			fnmerge(opn_file_name, opn_drive, opn_dir, opn_file, "");
		}
		fprintf(stderr, "%s\n", opn_file_name);
		if (!opn_opnload(opn_file_name))
			fprintf(stderr, "music_load_opn_list():%s.opnの読み込みに"
					"失敗しました\n", opn_file_name);
	}
	fclose(fp);
	return 1;
}
