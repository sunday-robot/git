import java.io.BufferedInputStream
import java.io.BufferedOutputStream
import java.io.File
import java.io.FileInputStream
import java.io.FileNotFoundException
import java.io.FileOutputStream
import java.io.IOException
import java.io.OutputStream
import java.nio.charset.Charset
import java.util.zip.ZipEntry
import java.util.zip.ZipOutputStream

/**
 * 指定されたディレクトリの内容を含むZIPファイルを作成する。
 *
 * @param directoryPath
 *            ディレクトリのパス名
 * @throws IOException
 *             IOException
 */
@Throws(IOException::class)
fun zipDirectory(directoryPath: String) {
    val targetDirectory = File(directoryPath)
    if (!targetDirectory.isDirectory()) {
        throw IOException(directoryPath + " is not directory.")
    }
    val zos = createZipOutputStream(targetDirectory.getCanonicalPath() + ".zip")
    zipFileOrDirectory(zos, targetDirectory, targetDirectory)
    zos.close()
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
@Throws(FileNotFoundException::class)
private fun createZipOutputStream(fileName: String): ZipOutputStream {
    val fos = FileOutputStream(fileName)
    val bos = BufferedOutputStream(fos)
    val zos = ZipOutputStream(bos, Charset.defaultCharset())
    // ↑CharSetを指定しないとファイル名がUTF-8で登録されるとのことだが、WindowsのZIPフォルダでは文字化けしてしまう。
    return zos
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
@Throws(IOException::class)
private fun zipFileOrDirectory(zos: ZipOutputStream, baseDirectory: File, fileOrDirectory: File) {
    if (fileOrDirectory.isDirectory()) {
        zipDirectory(zos, baseDirectory, fileOrDirectory)
    } else {
        val buffer = ByteArray(0x10000)
        zipFile(zos, baseDirectory, fileOrDirectory, buffer)
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
@Throws(IOException::class)
private fun zipDirectory(zos: ZipOutputStream, baseDirectory: File, directory: File) {
    for (file in listFiles(directory))
        zipFileOrDirectory(zos, baseDirectory, file)
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
@Throws(IOException::class)
private fun zipFile(zos: ZipOutputStream, baseDirectory: File, file: File, buffer: ByteArray) {
    val ze = ZipEntry(createEntryName(baseDirectory, file))
    ze.setTime(file.lastModified())
    zos.putNextEntry(ze)
    writeFileContents(zos, file, buffer)
    zos.closeEntry()
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
@Throws(IOException::class)
private fun createEntryName(baseDirectory: File, file: File): String {
    val bdcp = baseDirectory.getCanonicalPath()
    val fcp = file.getCanonicalPath()
    val name = fcp.substring(bdcp.length + 1)
    return name
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
@Throws(IOException::class)
private fun writeFileContents(os: OutputStream, file: File, buffer: ByteArray) {
    val fis = FileInputStream(file.getAbsolutePath())
    val bis = BufferedInputStream(fis)
    while (true) {
        val length = bis.read(buffer)
        if (length == -1)
            break
        os.write(buffer, 0, length)
    }
    fis.close()
}
