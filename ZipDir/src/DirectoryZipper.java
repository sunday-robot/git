import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.charset.Charset;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

/**
 * ディレクトリに対応するZIPファイルを作成するユーティリティ
 */
public final class DirectoryZipper {
	/** */
	private DirectoryZipper() {
	}

	/**
	 * 指定されたディレクトリの内容を含むZIPファイルを作成する。
	 * 
	 * @param directoryPath
	 *            ディレクトリのパス名
	 * @throws IOException
	 *             IOException
	 */
	public static void zip(String directoryPath) throws IOException {
		File targetDirectory = new File(directoryPath);
		if (!targetDirectory.isDirectory()) {
			throw new IOException(directoryPath + " is not directory.");
		}
		ZipOutputStream zos = createZipOutputStream(targetDirectory.getCanonicalPath() + ".zip");
		zipFileOrDirectory(zos, targetDirectory, targetDirectory);
		zos.close();
	}

	/**
	 * ZipOutputStreamを生成する。
	 * 
	 * @param fileName
	 *            ZIPファイル名
	 * @return ZipOutputStream
	 * @throws FileNotFoundException
	 *             FileNotFoundException
	 */
	private static ZipOutputStream createZipOutputStream(String fileName) throws FileNotFoundException {
		FileOutputStream fos = new FileOutputStream(fileName);
		BufferedOutputStream bos = new BufferedOutputStream(fos);
		ZipOutputStream zos = new ZipOutputStream(bos, Charset.defaultCharset());
		// ↑CharSetを指定しないとファイル名がUTF-8で登録されるとのことだが、WindowsのZIPフォルダでは文字化けしてしまう。
		return zos;
	}

	/**
	 * 指定されたファイルあるいはディレクトリの内容をZipOutputStreamに追加する
	 * 
	 * @param zos
	 *            ZipOutputStream
	 * @param baseDirectory
	 *            起点となるディレクトリ
	 * @param fileOrDirectory
	 *            ファイルまたはディレクトリ
	 * @throws IOException
	 *             IOException
	 */
	private static void zipFileOrDirectory(ZipOutputStream zos, File baseDirectory, File fileOrDirectory)
			throws IOException {
		if (fileOrDirectory.isDirectory()) {
			zipDirectory(zos, baseDirectory, fileOrDirectory);
		} else {
			byte[] buffer = new byte[0x10000];
			zipFile(zos, baseDirectory, fileOrDirectory, buffer);
		}
	}

	/**
	 * 指定されたディレクトリの内容をZipOutputStreamに追加する
	 * 
	 * @param zos
	 *            ZipOutputStream
	 * @param baseDirectory
	 *            起点となるディレクトリ
	 * @param directory
	 *            ディレクトリ
	 * @throws IOException
	 *             IOException
	 */
	private static void zipDirectory(ZipOutputStream zos, File baseDirectory, File directory) throws IOException {
		for (File file : Utl.listFiles(directory))
			zipFileOrDirectory(zos, baseDirectory, file);
	}

	/**
	 * 指定されたファイルをZipOutputStreamに追加する
	 * 
	 * @param zos
	 *            ZipOutputStream
	 * @param baseDirectory
	 *            起点となるディレクトリ
	 * @param file
	 *            ファイル
	 * @param buffer
	 *            バッファ
	 * @throws IOException
	 *             IOException
	 */
	private static void zipFile(ZipOutputStream zos, File baseDirectory, File file, byte[] buffer) throws IOException {
		ZipEntry ze = new ZipEntry(createEntryName(baseDirectory, file));
		ze.setTime(file.lastModified());
		zos.putNextEntry(ze);
		writeFileContents(zos, file, buffer);
		zos.closeEntry();
	}

	/**
	 * 指定されたファイル及び起点となるディレクトリから、ZIPファイルに登録するパス名を生成する。 <br/>
	 * (ファイルが"a/b/c.txt"で、起点となるディレクトリが"a/"なら、"b/c.txt"を生成する。)
	 * 
	 * @param baseDirectory
	 *            起点となるディレクトリ
	 * @param file
	 *            ファイル
	 * @return ZIPファイルに登録するパス名
	 * @throws IOException
	 *             IOException
	 */
	private static String createEntryName(File baseDirectory, File file) throws IOException {
		String bdcp = baseDirectory.getCanonicalPath();
		String fcp = file.getCanonicalPath();
		String name = fcp.substring(bdcp.length() + 1);
		return name;
	}

	/**
	 * ファイルの内容を出力ストリームに出力する。
	 * 
	 * @param os
	 *            出力ストリーム
	 * @param file
	 *            ファイル
	 * @param buffer
	 *            バッファ
	 * @throws IOException
	 *             IOException
	 */
	private static void writeFileContents(OutputStream os, File file, byte[] buffer) throws IOException {
		FileInputStream fis = new FileInputStream(file.getAbsolutePath());
		BufferedInputStream bis = new BufferedInputStream(fis);

		for (;;) {
			int length = bis.read(buffer);
			if (length == -1)
				break;
			os.write(buffer, 0, length);
		}

		fis.close();
	}
}
