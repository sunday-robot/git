#if !defined(DIR_H)
#define MAXPATH 255
#define MAXDIR 255
#define MAXFILE 8
#define MAXEXT 3
#define MAXDRIVE 1
#define EXTENSION 1

int fnsplit(const char *filePath, char *drive, char *dir, char *fileName, char *extension);
void fnmerge(char *buf, const char *drive, const char *dir, const char *file, const char *ext);

#endif
