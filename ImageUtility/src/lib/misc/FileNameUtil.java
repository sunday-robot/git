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
	 * ファイル名の拡張子手前に、指定された文字列を挿入する。
	 * 
	 * @param filePath
	 *            ファイルパス名
	 * @param postFix
	 *            挿入する文字列
	 * @return 新しいファイルパス名
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
	 * ファイルパス名を構成要素に分解する
	 * 
	 * @param filePath
	 *            ファイルパス名
	 * @return ファイルパス名の構成要素の配列
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
