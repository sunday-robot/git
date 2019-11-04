package lib.misc;

import java.io.File;

/**
 */
public final class FileNameUtil {
	/**
	 * 
	 */
	private FileNameUtil() {
	}

	/**
	 * �t�@�C�����̊g���q��O�ɁA�w�肳�ꂽ�������}������B
	 * 
	 * @param filePath
	 *            �t�@�C���p�X��
	 * @param postFix
	 *            �}�����镶����
	 * @return �V�����t�@�C���p�X��
	 */
	public static String addPostFix(String filePath, String postFix) {
		String[] elements = splitFilePath(filePath);
		String newFileName = elements[1] + postFix + elements[2];
		if (elements[0] == null) {
			return newFileName;
		} else {
			File newFilePath = new File(elements[0], elements[1] + postFix
					+ elements[2]);
			return newFilePath.toString();
		}
	}

	/**
	 * �t�@�C���p�X�����\���v�f�ɕ�������
	 * 
	 * @param filePath
	 *            �t�@�C���p�X��
	 * @return �t�@�C���p�X���̍\���v�f�̔z��
	 */
	private static String[] splitFilePath(String filePath) {
		File file = new File(filePath);
		String directoryName;
		File parent = file.getParentFile();
		if (parent == null) {
			directoryName = null;
		} else {
			directoryName = parent.toString();
		}
		String fileName = file.getName();
		String baseName;
		String extension;
		int index = fileName.lastIndexOf('.');
		if (index > 0) {
			baseName = fileName.substring(0, index);
			extension = fileName.substring(index);
		} else {
			baseName = "";
			extension = fileName;
		}
		return new String[] { directoryName, baseName, extension };
	}
}
