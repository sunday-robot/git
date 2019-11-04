package la.apps;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;

import la.Log;
import la.LogParser;
import la.LogReader;

/**
 *
 */
public final class LogToCsv {

	/** */
	private LogToCsv() {
	}

	/**
	 * @param args
	 *            ログファイルパス名のリスト
	 */
	public static void main(String[] args) {
		try {
			for (String arg : args) {
				LogReader lr = new LogReader(arg);
				PrintWriter pw = new PrintWriter(
						new OutputStreamWriter(new FileOutputStream(arg + ".csv"), "Shift-JIS"));
				pw.printf("date\ttime\tpackageName\tclassName\tlineNumber\tmethodName\tthreadName\tlevel\ttext\n");
				for (;;) {
					String s = lr.read();
					if (s == null) {
						break;
					}
					Log log = LogParser.parse(s);
					pw.printf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\n", //
							log.date, log.time, log.packageName, log.className, log.lineNumber, log.methodName,
							log.threadName, log.level, log.text);
				}
				pw.close();
				lr.close();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
