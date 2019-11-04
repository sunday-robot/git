;座標は16*14ドット単位、サイズも16*14に固定したもの
	.286

	model	small,C

	extrn	super_patdata:word

DISP	MACRO
	REPT	13
		movsw
		add	di,dx
	ENDM
	movsw
	add	si,bx
ENDM

.code
	public	super_put_1614
super_put_1614	proc
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
	xor	si,si
	mov	ds,super_patdata[bx]	;pattern data segment address

	mov	ax,0a800h
	mov	es,ax
	mov	bx,4
	mov	dx,78

	mov	ax,0c0h		;RMW mode
	out	7ch,al
	mov	al,ah
	out	7eh,al
	out	7eh,al
	out	7eh,al
	out	7eh,al
	DISP			;cls

	mov	ax,0ff00h + 11001110b
	out	7ch,al		;RMW mode
	mov	al,ah		;al==0ffh
	out	7eh,al
	out	7eh,al
	out	7eh,al
	out	7eh,al
	mov	di,cx
	DISP

	mov	al,11001101b
	out	7ch,al		;RMW mode
	mov	di,cx
	DISP

	mov	al,11001011b
	out	7ch,al		;RMW mode
	mov	di,cx
	DISP

	mov	al,11000111b
	out	7ch,al		;RMW mode
	mov	di,cx
	DISP

	xor	al,al
	out	7ch,al		;grcg stop
	ret
super_put_1614	endp

	end
