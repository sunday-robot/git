package la.apps;

import java.io.IOException;

import la.Log;
import la.LogParser;
import la.LogReader;

/**
 * 
 */
public final class LogParserTest {
	/** */
	private LogParserTest() {
	}

	/**
	 * @param args
	 *            ログファイルパス名のリスト
	 */
	public static void main(String[] args) {
		try {
			for (String arg : args) {
				LogReader lr = new LogReader(arg);
				for (;;) {
					String s = lr.read();
					if (s == null) {
						break;
					}
					Log log = LogParser.parse(s);
					System.out.println(log);
				}
				lr.close();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
