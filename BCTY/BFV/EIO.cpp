#include <stdio.h>
#include <stdlib.h>

// �t�@�C���G���h�Ȃ̂ɍX�ɓǂ����Ƃ����ꍇ�͋����I��
int egetc(FILE *fp)
{
	int r;

	r = getc(fp);
	if (feof(fp)) {
		fprintf(stderr,"Short file\n");
		exit(1);
	}
	return r;
}

int egetw(FILE *fp)
{
	int r;

	r = _getw(fp);
	if (feof(fp)) {
		fprintf(stderr,"Short file\n");
		exit(1);
	}
	return r;
}

FILE *efopen(char *fname, char *mode)
{
	FILE *fp;
	if ((fp = fopen(fname, mode)) == NULL) {
		fprintf(stderr, "efopen():%s was not found\n", fname);
		exit(1);
	}
	return fp;
}

void efread(void *ptr, size_t size, size_t n, FILE *fp)
{
	if (fread(ptr, size, n, fp) != n) {
		fprintf(stderr, "efread():read error\n");
		exit(1);
	}
}
