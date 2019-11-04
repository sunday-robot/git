import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

/**
 * ディレクトリを中身を含めて削除するユーティリティ
 */
public final class DirectoryRemover {
	/** */
	private DirectoryRemover() {
	}

	/**
	 * 指定されたディレクトリを削除する。
	 * 
	 * @param directoryPath
	 *            削除対象のディレクトリ
	 * @throws IOException
	 *             IOException
	 */
	public static void remove(String directoryPath) throws IOException {
		File directory = new File(directoryPath);
		removeFileOrDirectory(directory);
	}

	/**
	 * 指定されたファイルもしくはディレクトリを削除する。
	 * 
	 * @param fileOrDirectory
	 *            ファイルもしくはディレクトリ
	 * @throws IOException
	 *             IOException
	 */
	private static void removeFileOrDirectory(File fileOrDirectory) throws IOException {
		if (fileOrDirectory.isDirectory()) {
			for (File f : Utl.listFiles(fileOrDirectory))
				removeFileOrDirectory(f);
		}
		Path p = fileOrDirectory.toPath();
		Files.delete(p);
	}
}
