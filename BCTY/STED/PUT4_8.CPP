// 4*8のサイズの、A-Dのフォントを表示する
// ステージ一覧画面で適戦車のデータを表示するのに使う

#include <gr.h>

static unsigned char font[4][8] = {
	{0x00, 0x40, 0xa0, 0xe0, 0xa0, 0xa0, 0x00, 0x00},
	{0x00, 0xc0, 0xa0, 0xc0, 0xa0, 0xc0, 0x00, 0x00},
	{0x00, 0x40, 0xa0, 0x80, 0xa0, 0x40, 0x00, 0x00},
	{0x00, 0xc0, 0xa0, 0xa0, 0xa0, 0xc0, 0x00, 0x00}
};

void put4_8(int x, int y, int n, int color)
{
	grcgColor(color);
	_asm {
		mov	ax,0xa800
		mov	es,ax
		mov	ax,80
		mul	y
		mov	di,ax
		mov	ax,x
		mov	cx,ax
		shr	ax,3
		add	di,ax
		and	cl,7
		mov	bx,n
		shl	bx,3
		lea	si,[font+bx]
		mov	bx,8
		mov	dx,80
		cld
	}
	l0:
	_asm {
		lodsb
		xor	ah,ah
		ror	ax,cl
		mov	es:[di],ax
		add	di,dx
		dec	bx
		jnz	l0
	}
	grcgOff();
}

/*
#include <iostream.h>

int main(int argc, char *argv[])
{
	int x, y, num, color;
	cin >> x;
	cin >> y;
	cin >> num;
	cin >> color;
	put4_8(x, y, num, color);
	return 0;
}
*/
