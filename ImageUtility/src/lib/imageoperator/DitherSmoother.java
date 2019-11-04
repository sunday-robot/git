package lib.imageoperator;

import java.awt.image.BufferedImage;

/**
 */
public final class DitherSmoother {
	/**
	 */
	private DitherSmoother() {
	}

	/**
	 * ��������X�L���������摜�Ȃǂ̃f�B�U�[�摜���ł��邾���{���̃X���[�Y�ȉ摜�ɕϊ�����B
	 * (�ϊ���̉摜�̂ق����AJPEG��PNG���k�������₷���͂��B)
	 * 
	 * @param image
	 *            ���͉摜
	 * @return �ϊ���̉摜
	 */
	public static BufferedImage execute(BufferedImage image) {
		// �e��f���Ɏ��ӂ̕��ϔZ�x�l�ƁA���U���v�Z����B(���U��RGB���ꂼ��ŋ��߂�BRGB�܂Ƃ߂����̂ƂȂ�ƁA�����U�ȂǓ���Ȃ��̂��o�Ă��邪�A���̂悤�Ȃ��̂������o���K�v�͑����Ȃ��B�j

		// �e��f�̃f�B�U�[�̈�炵�����v�Z����B

		// �e��f�̔Z�x�l���A�f�B�U�[�̈�炵���ɉ����Čv�Z����
		BufferedImage outImage = new BufferedImage(image.getWidth(),
				image.getHeight(), image.getType());
		return outImage;
	}
}
