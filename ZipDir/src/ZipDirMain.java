import java.io.IOException;

import javax.swing.JOptionPane;

/**
 */
public final class ZipDirMain {
	/** */
	private ZipDirMain() {
	}

	/**
	 * @param args
	 *            ZIP化するディレクトリのパス名の配列
	 */
	public static void main(String[] args) {
		if (args.length == 0) {
			printHelp();
			return;
		}
		for (String directoryPath : args) {
			try {
				zipAndRemoveDirectory(directoryPath);
			} catch (IOException e) {
				StringBuffer sb = new StringBuffer(e.toString() + ":\n");
				for (StackTraceElement ste : e.getStackTrace()) {
					sb.append("  " + ste.toString() + "\n");
				}
				JOptionPane.showMessageDialog(null, sb);
			}
		}
	}

	/**
	 * ヘルプメッセージを表示する。
	 */
	private static void printHelp() {
		JOptionPane.showMessageDialog(null, "Usage:\nZipDir <directory path>...");
	}

	/**
	 * 指定されたディレクトリをZIPファイルにまとめ、その後ディレクトリを削除する。
	 * 
	 * @param directoryPath
	 *            ディレクトリ名
	 * @throws IOException
	 *             IOException
	 */
	private static void zipAndRemoveDirectory(String directoryPath) throws IOException {
		DirectoryZipper.zip(directoryPath);
		DirectoryRemover.remove(directoryPath);
	}

}
