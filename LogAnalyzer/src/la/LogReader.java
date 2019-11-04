package la;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.regex.Pattern;

/**
 * ログファイルを読むもの。
 * 
 * 通常のテキストファイルと異なるのは、以下の点。<br>
 * ・文字コードがShift-JIS固定である＜br＞
 * ・扱いづらい途中の改行文字を削除する。(行頭が日付、自国になっていない行は、直前の行にappendする。)<br>
 */
public final class LogReader {

	/** 行頭をチェックするための正規表現(日付を示す文字列) */
	private static final Pattern LOG_DATE_PATTERN = Pattern.compile("^[\\d/]{10}");

	/** */
	private final BufferedReader bufferedReader;

	/** 先読みしてある文字列 */
	private String prefetchedString;

	/**
	 * @param path
	 *            ログファイルのパス名
	 * @throws IOException
	 *             :
	 */
	public LogReader(String path) throws IOException {
		this(Paths.get(path));
	}

	/**
	 * @param path
	 *            ログファイルのパス名
	 * @throws IOException
	 *             :
	 */
	public LogReader(Path path) throws IOException {
		bufferedReader = new BufferedReader(new InputStreamReader(
				new FileInputStream(path.toFile()), "Shift-JIS"));
		prefetchedString = bufferedReader.readLine();
	}

	/**
	 * @return ログ文字列またはnull(EOFを示す)
	 * @throws IOException
	 *             :
	 */
	public String read() throws IOException {
		if (prefetchedString == null)
			return null;
		for (;;) {
			String s = bufferedReader.readLine();
			if ((s == null) || LOG_DATE_PATTERN.matcher(s).find()) {
				String r = prefetchedString;
				prefetchedString = s;
				return r;
			}
			prefetchedString += "<br>" + s; // このループは複数回回ることはまれなので、あえてStringBuilder等は使用していない。
		}
	}

	/**
	 * @throws IOException
	 *             :
	 */
	public void close() throws IOException {
		bufferedReader.close();
	}
}
