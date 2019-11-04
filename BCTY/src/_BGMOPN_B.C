#include <string.h>
#include <dir.h>
#include "bgmopn.h"

#if !defined(USEOPNDRV)
int music_load_bgm(char *fname)
{
	char buf[MAXPATH];
	char drive[MAXDRIVE], dir[MAXDIR], file[MAXFILE], ext[MAXEXT];

	if (!(fnsplit(fname, drive, dir, file, ext) & EXTENSION))
		strcpy(ext, ".bgm");
	fnmerge(buf, drive, dir, file, ext);
	return bgm_read_data(buf, 0, BGM_MES_OFF) == BGM_COMPLETE;
}
#endif
