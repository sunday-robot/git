#include <stdio.h>
#include <mem.h>
#include <dos.h>
#include <alloc.h>
#include "image.h"

//#define TEST

static unsigned int vram[] = {0xa800, 0xb000, 0xb800, 0xe000};

int Image::get(int x, int y, int _width, int _height)
{
	int size = _width * _height * 4;
	if (data)
		farfree(data);
	if ((data = (unsigned char far *)farmalloc(size)) == NULL)
		return 0;
	width = _width;
	height = _height;
	unsigned char far *d = data;
	int max_y = y + height;
	for (int plane = 0; plane < 4; plane++) {
		unsigned int seg = vram[plane];
		for (int yy = y; yy < max_y; yy++) {
			movedata(seg, x + yy * 80, FP_SEG(d), FP_OFF(d), width);
			d += width;
		}
	}
	return 1;
}

static void put_odd_size(unsigned seg, unsigned off, int width,
	unsigned s_addr, unsigned e_addr)
{
	asm {
		push ds;
		mov dx, width;
		mov ax, 80;	sub	ax, dx;
		xor	bx, bx;
		shr dx, 1;
		mov ds, seg;	mov si, off;
	}
l0:
	asm {
		mov es, ss:[offset vram + bx];
		mov di, s_addr;
	}
l1:
	asm {
		mov cx, dx;	rep movsw;	movsb;
		add di, ax;
		cmp di, e_addr;	jl l1
		add bx, 2
		cmp bx, 8;	jl l0
		pop ds
	}
}

static void put_even_size(unsigned seg, unsigned off, int width,
	unsigned s_addr, unsigned e_addr)
{
	asm {
		push ds
		mov dx, width;
		mov ax, 80;	sub	ax, dx;
		xor	bx, bx;
		shr dx, 1;
		mov ds, seg;	mov si, off;
	}
l0:
	asm {
		mov es, ss:[offset vram + bx];
		mov di, s_addr;
	}
l1:
	asm {
		mov cx, dx;	rep movsw
		add di, ax;
		cmp di, e_addr;	jl l1
		add bx, 2
		cmp bx, 8;	jl l0
		pop ds
	}
}

void Image::put(int x, int y)
{
	if (data == NULL)
		return;
	unsigned int s_addr = x + y * 80;
	unsigned int e_addr = s_addr + height * 80;
	if (width & 1)
		put_odd_size(FP_SEG(data), FP_OFF(data), width, s_addr, e_addr);
	else
		put_even_size(FP_SEG(data), FP_OFF(data), width, s_addr, e_addr);
}

#ifdef TEST
void main()
{
	Image image;
	printf("%d\n", image.get(40, 200, 8, 80));
	int x, y;
	for (y = 0; y < 400; y += 80)
		for (x = 0;x < 80; x += 8)
			image.put(x, y);
	printf("%d\n", image.get(40, 200, 7, 80));
	for (y = 0; y < 400; y += 80)
		for (x = 0;x < 80; x += 7)
			image.put(x, y);
}
#endif
