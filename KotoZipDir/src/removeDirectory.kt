import java.io.File
import java.io.IOException
import java.nio.file.Files
import java.nio.file.Path

/**
 * 指定されたディレクトリとその中身を削除する。
 *
 * @param directoryPath
 *            削除対象のディレクトリ
 * @throws IOException
 *             IOException
 */
@Throws(IOException::class)
fun removeDirectory(directoryPath: String) {
    val directory = File(directoryPath)
    removeFileOrDirectory(directory)
}

/**
 * 指定されたファイルもしくはディレクトリを削除する。
 *
 * @param fileOrDirectory
 *            ファイルもしくはディレクトリ
 * @throws IOException
 *             IOException
 */
@Throws(IOException::class)
private fun removeFileOrDirectory(fileOrDirectory: File) {
    if (fileOrDirectory.isDirectory()) {
        for (f in listFiles(fileOrDirectory))
            removeFileOrDirectory(f)
    }
    val p = fileOrDirectory.toPath()
    Files.delete(p)
}
