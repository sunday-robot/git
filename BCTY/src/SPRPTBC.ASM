;super_put をサイズ2,4,8 専用にしたもの
	.286

	model	small,C

	include	struc240.inc

	extrn	super_patsize:word,super_patdata:word

.data

mask1	dw	000ffh,0807fh,0c03fh,0e01fh,0f00fh,0f807h,0fc03h,0fe01h

.code

disp_addr	dw	?

	public	super_put_bc
super_put_bc	proc
arg	x:word,y:word,num:word
uses	bp,si,di,ds
	mov	di,y
	mov	ax,di
	shl	ax,2
	add	di,ax
	shl	di,4			; di=y*80

	mov	cx,x
	mov	ax,cx
	shr	ax,3			;ax=x/8
	add	di,ax			;GVRAM offset address

	mov	bx,num
	shl	bx,1
	and	cx,7h			;cl=x%8(shift dot counter)
	mov	si,cx
	shl	si,1
	mov	dx,mask1[si]

	mov	ax,super_patsize[bx]
	xor	si,si
	mov	ds,super_patdata[bx]	;pattern data segment address
	_if <<al e 16>>
		mov	CS:[disp_proc],offset disp_s2
		mov	bp,78
	_elseif <<al e 32>>
		mov	CS:[disp_proc],offset disp_s4
		mov	bp,76
	_else
		mov	CS:[disp_proc],offset disp_s8
		mov	bp,72
	_endif

	cld
	mov	ax,0c0h		;RMW mode
	out	7ch,al
	mov	al,ah
	out	7eh,al
	out	7eh,al
	out	7eh,al
	out	7eh,al

	mov	ax,0a800h
	mov	es,ax
	mov	cs:disp_addr,di
	call	cs:[disp_proc]		;originally cls_loop

	mov	ax,0ff00h + 11001110b
	out	7ch,al		;RMW mode
	mov	al,ah		;al==0ffh
	out	7eh,al
	out	7eh,al
	out	7eh,al
	out	7eh,al
	mov	di,cs:disp_addr
	call	cs:[disp_proc]

	mov	al,11001101b
	out	7ch,al		;RMW mode
	mov	di,disp_addr
	call	cs:[disp_proc]

	mov	al,11001011b
	out	7ch,al		;RMW mode
	mov	di,disp_addr
	call	cs:[disp_proc]

	mov	al,11000111b
	out	7ch,al		;RMW mode
	mov	di,disp_addr
	call	cs:[disp_proc]

	xor	al,al
	out	7ch,al		;grcg stop

	ret
super_put_bc	endp

even
disp_proc	dw	?

;サイズ2(16*16)の1プレーンのパターン表示ルーチン
;si:データ、di:表示開始番地、cl:ビットアドレス
;dl:1バイトめ用のマスク、dh:3バイトめ用のマスク
;bp:次のラインへのアドレスの差
even
disp_s2:
	REPT	13
		lodsw		;データを読みだして
		ror	ax,cl	;ローテートシフト
		mov	ch,al	;3バイトめをCHへ
		and	al,dl	;3バイトめに表示すべきデータはマスクで消してしまう
		stosw
		and	ch,dh
		mov	es:[di],ch
		add	di,bp
	ENDM
	lodsw		;データを読みだして
	ror	ax,cl	;ローテートシフト
	mov	ch,al	;3バイトめをCHへ
	and	al,dl	;3バイトめに表示すべきデータはマスクで消してしまう
	stosw
	and	ch,dh
	mov	es:[di],ch
	add	si,4
	ret	;add di,bp は必要無いのでREPTマクロから外に出した

;サイズ4(32*32)偶数番地への1プレーンのパターン表示ルーチン
;si:データ、di:表示開始番地、cl:ビットアドレス
;dl:1バイトめ用のマスク、dh:3バイトめ用のマスク
;bx:作業変数として使用
;bp:次のラインへのアドレスの差
even
disp_s4:
	REPT	27
		lodsw		;データを読みだして
		ror	ax,cl	;ローテートシフト
		mov	bl,al	;3バイトめをblへ
		and	al,dl	;余分なデータはマスクで消してしまう
		stosw		;最初の2バイト
		lodsw		;更にデータを読む
		ror	ax,cl
		mov	bh,al
		and	al,dl
		and	bl,dh
		or	al,bl
		stosw		;3、4バイトめ
		and	bh,dh
		mov	es:[di],bh
		add	di,bp
	ENDM
	lodsw		;データを読みだして
	ror	ax,cl	;ローテートシフト
	mov	bl,al	;3バイトめをblへ
	and	al,dl	;余分なデータはマスクで消してしまう
	stosw		;最初の2バイト
	lodsw
	ror	ax,cl
	mov	bh,al
	and	al,dl
	and	bl,dh
	or	al,bl
	stosw
	and	bh,dh
	mov	es:[di],bh
	add	si,16
	ret	;add di,bp は必要無いのでREPTマクロから外に出した

;サイズ8(64*64)の1プレーンのパターン表示ルーチン
;si:データ、di:表示開始番地、cl:ビットアドレス
;dl:1バイトめ用のマスク、dh:3バイトめ用のマスク
;bx:作業変数として使用
;bp:次のラインへのアドレスの差
even
disp_s8:
	REPT	55
		lodsw		;データを読みだして
		ror	ax,cl	;ローテートシフト
		mov	bl,al	;3バイトめをblへ
		and	al,dl	;余分なデータはマスクで消してしまう
		stosw		;最初の2バイト
		lodsw		;更にデータを読む
		ror	ax,cl
		mov	bh,al
		and	al,dl
		and	bl,dh
		or	al,bl
		stosw		;3、4バイトめ
		lodsw
		ror	ax,cl
		mov	bl,al
		and	al,dl
		and	bh,dh
		or	al,bh
		stosw
		lodsw
		ror	ax,cl
		mov	bh,al
		and	al,dl
		and	bl,dh
		or	al,bl
		stosw
		and	bh,dh
		mov	es:[di],bh
		add	di,bp
	ENDM
	lodsw		;データを読みだして
	ror	ax,cl	;ローテートシフト
	mov	bl,al	;3バイトめをblへ
	and	al,dl	;余分なデータはマスクで消してしまう
	stosw		;最初の2バイト
	lodsw		;更にデータを読む
	ror	ax,cl
	mov	bh,al
	and	al,dl
	and	bl,dh
	or	al,bl
	stosw		;3、4バイトめ
	lodsw
	ror	ax,cl
	mov	bl,al
	and	al,dl
	and	bh,dh
	or	al,bh
	stosw
	lodsw
	ror	ax,cl
	mov	bh,al
	and	al,dl
	and	bl,dh
	or	al,bl
	stosw
	and	bh,dh
	mov	es:[di],bh
	add	si,64
	ret	;add di,bp は必要無いのでREPTマクロから外に出した

	end
