import java.io.IOException
import javax.swing.JOptionPane

/**
 * @param args
 * ZIP化するディレクトリのパス名の配列
 */
fun main(args: Array<String>) {
    if (args.size == 0) {
        printHelp()
        return
    }
    val ioExceptions: MutableList<IOException> = ArrayList()
    for (directoryPath in args) {
        try {
            zipAndRemoveDirectory(directoryPath)
        } catch (e: IOException) {
            ioExceptions.add(e)
        }
    }
    for (e in ioExceptions) {
        val sb = StringBuffer(e.toString() + ":\n")
        for (ste in e.getStackTrace()) {
            sb.append(" " + ste.toString() + "\n")
        }
        JOptionPane.showMessageDialog(null, sb)
    }
}

/**
 * ヘルプメッセージを表示する。
 */
private fun printHelp() {
    JOptionPane.showMessageDialog(null, "Usage:\nZipDir <directory path>...")
}

/**
 * 指定されたディレクトリをZIPファイルにまとめ、その後ディレクトリを削除する。
 *
 * @param directoryPath
 *            ディレクトリ名
 * @throws IOException
 *             IOException
 */
@Throws(IOException::class)
private fun zipAndRemoveDirectory(directoryPath: String) {
    zipDirectory(directoryPath)
    removeDirectory(directoryPath)
}
