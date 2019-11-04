#if !defined(PC98_H)

void pc98fkeyoff(void);

void DisableKeyBeep(void);
void DisableCtrlC(void);
void EnableKeyBeep(void);
void EnableCtrlC(void);
void _setcursortype(int);
#define _NORMALCURSOR 1
void dos_clear_key_buffer(void);
#define _NOCURSOR 0

#endif
