ImageCommand�ł�肽������
�X�N���v�ghosei.txt���쐬���Ă����A�J�����g�t�H���_���̂��ׂẲ摜��␳����B
ImageCommand hosei.txt *.jpg

hosei.txt�̓��e�F
---
# "#"����s���܂ł��R�����g�Ƃ���B
saidoKyocho 1.5
whiteBalance 1 2 4
resize 100 200	# �ǂ�ȃT�C�Y�ł����Ă��A100x200�ɂ���B
resizeByHeight 100	# ������100�ɂȂ�悤�Ƀ��T�C�Y����B���͏c���䂪�ς��Ȃ��悤�ɂ���B
trim�@10 100 299 399 # �摜��(10, 100)����A(299, 399)�܂ł̉摜��؂�o���B
let A currentImage	# ���݂̉摜��A�Ƃ����ϐ��ɃZ�b�g����B
let B A resize 20 40	# �摜A��20x40�Ƀ��T�C�Y�������̂�B�Ƃ����ϐ��ɃZ�b�g����B�摜A�͌��̂܂�
let C originalImage	# ���摜��C�Ƃ����ϐ��ɃZ�b�g����B
A save	# �摜A��ۑ�����B�t�@�C�����́A���摜�̊g���q�̎�O��"_A"��}���������̂��ݒ肳��Ă�B�t�H���_�͌��摜�̏o�̓t�H���_�Ɠ����B(���摜�̃t�H���_�ł͂Ȃ��B)
A savePng	# ��Ɠ��l�����APNG�`���ŃZ�[�u����B
A savePng16	# ��Ɠ��l�����A�r�b�g�[�x16��PNG�`���ŃZ�[�u����B
A toGray	# RGB[A]�摜���A�O���[�X�P�[���摜�ɕϊ�����B��f�l�́A(R+G+B)/3�Ƃ���B(HSV��V�́Amax(R, G, B)�Ȃ̂ŁA�����Ԃ��������邳�ɂȂ��Ă��܂��̂œK�؂ł͂Ȃ��Ǝv����B)
A enableAlpha	# �A���t�@�`�����l����L���ɂ���B�A���t�@�`�����l���̉�f�l��1.0(�s����)�ɂ���B
A disableAlpha
A toRGB
A toRGBA


---

ImageCommand gosei.txt 0.5 image1.jpg image2.jpg 

gosei.txt�̓��e�F
---
disableEnumeration	# �X�N���v�g�t�@�C���ȍ~�̈����ɑ΂��A�J��Ԃ�����������Ƃ����f�t�H���g�̋����𖳌��ɂ���B
let MixRatio = arg 1
let Image1 = arg 2
let Image2 = arg 3

let mixedImage = add image1 image2	# ��̉摜�̊e��f�l��P���ɑ�����

---

��{���j
�I���W�i���摜�͏��������Ȃ��B
PNG�̈��k�I�v�V�����͕ύX�ł��Ȃ��B
�@PNG�͉t���k�Ȃ̂ŁA�I�v�V������ݒ�ł��Ȃ��Ă����܂荢��Ȃ��B
�����ŏ������̉�f�l�͂��ׂ�double�Ƃ���B
�X�N���v�g����ɂ͂��Ȃ��B
�@����\����ϐ����g�p���č��x�ȏ���������̂ł���΁AJava�ARuby�ȂǊ����̌��ꂩ��AOpenCV���Ăяo���ق����ǂ�����B
�@(�ϐ��̊T�O�͎������Ă��邪�A�摜��p�B)
�@