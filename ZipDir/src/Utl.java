import java.io.File;
import java.io.IOException;

/**
 */
public final class Utl {
	/**
	 */
	private Utl() {
	}

	/**
	 * File#listFiles()の仕様がバカ(例外を投げずにnullを返すことがある)で、
	 * findBugs警告の原因となってしまうため仕方なく作成したくだらないメソッド。
	 * 
	 * @param directory
	 *            ディレクトリ
	 * @return ディレクトリ内に含まれるファイルの配列
	 * @throws IOException
	 *             :
	 */
	public static File[] listFiles(File directory) throws IOException {
		File[] files = directory.listFiles();
		if (files == null)
			throw new IOException();
		return files;
	}

}
