import java.io.File
import java.io.IOException

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
@Throws(IOException::class)
fun listFiles(directory: File): Array<File> {
    val files = directory.listFiles()
    if (files == null)
        throw IOException()
    return files
}
