#include <stdio.h>

#include "md5.h"

int main(int argc, char *argv[]) {
	FILE *fp;
	fp = fopen(argv[1], "rb");
	if (fp == NULL) {
		return 1;
	}
	MD5_CTX md5ctx;
	MD5Init(&md5ctx);
	do {
		unsigned char buf[65536];
		int len;
		len = fread(buf, 1, sizeof(buf), fp);
		MD5Update(&md5ctx, buf, len);
	} while (!feof(fp));
	fclose(fp);
	MD5Final(&md5ctx);

	int i;
	for (i = 0; i < 16; i++) {
		printf("%02X", md5ctx.digest[i]);
	}
	printf("\n");
	getchar();

	return 0;
}
