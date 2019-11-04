#include <string.h>
#include <dir.h>
#include "bgmopn.h"

#if !defined(USEOPNDRV)
int music_load_efs(char *fname)
{
	char buf[MAXPATH];
	char drive[MAXDRIVE], dir[MAXDIR], file[MAXFILE], ext[MAXEXT];

	if (!(fnsplit(fname, drive, dir, file, ext) & EXTENSION))
		strcpy(ext, ".efs");
	fnmerge(buf, drive, dir, file, ext);
	return bgm_read_sdata(buf) == BGM_COMPLETE;
}
#endif
