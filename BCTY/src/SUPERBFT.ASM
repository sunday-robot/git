;
;$Id: superbft.asm 0.01 92/05/29 20:20:37 Kazumi Rel $
;
CPUi286		EQU	0

INCLUDE		super.inc

		.MODEL	SMALL, C

		.DATA
header		bfnt_header	<>
_id		DB	'BFNT',1ah
bytes		DB	8,4,2,2,1,1,1,1

		.CODE
super_entry_bfnt	PROC	NEAR
ARG	filename:PTR, font:WORD, palette:WORD
USES	BP, SI, DI
EXTRN	fontfile_open:PROC, bfnt_header_read:PROC,\
	bfnt_extend_header_skip:PROC, bfnt_palette_set:PROC,\
	bfnt_palette_skip:PROC, bfnt_entry_pat:PROC,\
	fontfile_close:PROC

		mov	ax,filename
		push	ax
		call	fontfile_open
		add	sp,2
		cmp	ax,FILE_NOT_FOUND
		jnz	open_ok
		ret
		ALIGN
open_ok:	mov	bx,ax			;file handle
		mov	cx,offset header
		ALIGN
retry:		push	cx
		push	bx
		call	bfnt_header_read
		pop	bx
		pop	cx
		cmp	ax,FILE_ILLIGAL
		jnz	file_ok
		ret
		ALIGN
file_ok:	mov	al,header.num
		xor	ah,ah
		cmp	ax,font
		jz	entry
		mov	ax,header.hdrSize
		or	ax,ax
		jz	no_exthdr1
		push	cx
		push	bx
		call	bfnt_extend_header_skip
		pop	bx
		pop	cx
		ALIGN
no_exthdr1:	mov	al,header.col
		and	al,080h
		jz	no_palette
		push	cx
		push	bx
		call	bfnt_palette_skip
		pop	bx
		pop	cx
		ALIGN
no_palette:	mov	ax,header.Xdots
		mov	dx,header.Ydots
		mul	dx
		mov	dl,header.col
		xor	dh,dh
		mov	si,dx
		mov	di,cx			;save cx
		mov	cl,BYTE PTR bytes[si]
		shr	ax,cl
		mov	dx,ax
		xor	cx,cx
		mov	ax,4201h
		int	21h
		mov	cx,di
		jmp	retry
		ALIGN
entry:		mov	ax,header.hdrSize
		or	ax,ax
		jz	no_exthdr2
		push	cx
		push	bx
		call	bfnt_extend_header_skip
		pop	bx
		pop	cx
		ALIGN
no_exthdr2:	mov	al,header.col
		and	al,080h			;palette table check
		jz	palette_end
		mov	ax,palette
		cmp	ax,SET
		jnz	palette_skip
		push	cx
		push	bx
		call	bfnt_palette_set
		pop	bx
		pop	cx
		cmp	ax,OK
		jz	palette_end
		ret
		ALIGN
palette_skip:	push	cx
		push	bx
		call	bfnt_palette_skip
		pop	bx
		pop	cx
		ALIGN
palette_end:	push	cx
		push	bx
		call	bfnt_entry_pat
		pop	bx
		pop	cx
		or	ax,ax
		js	l_end
		push	bx
		call	fontfile_close
		add	sp,2
		mov	ax,header.END_
		sub	ax,header.START
		inc	ax
l_end:		ret
super_entry_bfnt	ENDP
		END
