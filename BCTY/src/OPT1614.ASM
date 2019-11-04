;座標は16*14ドット単位、サイズも16*14に固定したもの
	.286

	model	small,C

	extrn	super_patdata:word

DISP	MACRO	vram_seg
	mov	ax,vram_seg
	mov	es,ax
	REPT	13
		movsw
		add	di,dx
	ENDM
	movsw
	add	si,bx
ENDM

.code
	public	over_put_1614
over_put_1614	proc
arg	x:word,y:word,num:word
uses	si,di,ds
	mov	di,y
	mov	ax,di
	shl	ax,1
	add	di,ax			; di=y*3
	shl	ax,4
	add	di,ax			; di=y*35
	shl	di,5			; di=y*35*32=y*80*14
	mov	ax,x
	shl	ax,1
	add	di,ax			; di : GVRAM offset address
	mov	cx,di

	mov	bx,num
	shl	bx,1
	mov	si,32			;skip mask data
	mov	ds,super_patdata[bx]	;pattern data segment address

	mov	bx,4
	mov	dx,78

	DISP	0a800h

	mov	di,cx
	DISP	0b000h

	mov	di,cx
	DISP	0b800h

	mov	di,cx
	DISP	0e000h

	ret
over_put_1614	endp

	end
