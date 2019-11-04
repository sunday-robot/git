ImageCommandでやりたいこと
スクリプトhosei.txtを作成しておき、カレントフォルダ内のすべての画像を補正する。
ImageCommand hosei.txt *.jpg

hosei.txtの内容：
---
# "#"から行末までをコメントとする。
saidoKyocho 1.5
whiteBalance 1 2 4
resize 100 200	# どんなサイズであっても、100x200にする。
resizeByHeight 100	# 高さが100になるようにリサイズする。幅は縦横比が変わらないようにする。
trim　10 100 299 399 # 画像の(10, 100)から、(299, 399)までの画像を切り出す。
let A currentImage	# 現在の画像をAという変数にセットする。
let B A resize 20 40	# 画像Aを20x40にリサイズしたものをBという変数にセットする。画像Aは元のまま
let C originalImage	# 原画像をCという変数にセットする。
A save	# 画像Aを保存する。ファイル名は、原画像の拡張子の手前に"_A"を挿入したものが設定されてる。フォルダは原画像の出力フォルダと同じ。(原画像のフォルダではない。)
A savePng	# 上と同様だが、PNG形式でセーブする。
A savePng16	# 上と同様だが、ビット深度16のPNG形式でセーブする。
A toGray	# RGB[A]画像を、グレースケール画像に変換する。画素値は、(R+G+B)/3とする。(HSVのVは、max(R, G, B)なので、白も赤も同じ明るさになってしまうので適切ではないと思われる。)
A enableAlpha	# アルファチャンネルを有効にする。アルファチャンネルの画素値は1.0(不透明)にする。
A disableAlpha
A toRGB
A toRGBA


---

ImageCommand gosei.txt 0.5 image1.jpg image2.jpg 

gosei.txtの内容：
---
disableEnumeration	# スクリプトファイル以降の引数に対し、繰り返し処理をするというデフォルトの挙動を無効にする。
let MixRatio = arg 1
let Image1 = arg 2
let Image2 = arg 3

let mixedImage = add image1 image2	# 二つの画像の各画素値を単純に足した

---

基本方針
オリジナル画像は書き換えない。
PNGの圧縮オプションは変更できない。
　PNGは可逆圧縮なので、オプションを設定できなくてもあまり困らない。
内部で処理中の画素値はすべてdoubleとする。
スクリプト言語にはしない。
　制御構造や変数を使用して高度な処理をするのであれば、Java、Rubyなど既存の言語から、OpenCVを呼び出すほうが良いから。
　(変数の概念は持たせているが、画像専用。)
　