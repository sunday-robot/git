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
public final class LogParserTest2 {

	/** */
	private LogParserTest2() {
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
						new OutputStreamWriter(new FileOutputStream(arg + ".txt"), "Shift-JIS"));
				for (;;) {
					String s = lr.read();
					if (s == null) {
						break;
					}
					Log log = LogParser.parse(s);
					String text = log.text.replaceAll("<br>", "\n");
					if (log.className.length() == 0) {
						if (log.methodName.length() == 0) {
							// Logging
							pw.println(log.date + " " + log.time + "," + log.level + "," + text);
						} else {
							// 後処理
							pw.println(log.date + " " + log.time + "," + log.methodName + ",(" + log.lineNumber + "),"
									+ log.level + "," + text);
						}
					} else {
						if (log.level.length() == 0) {
							// eclipse
							pw.println(log.date + " " + log.time + "," + log.packageName + "." + log.className + "("
									+ log.lineNumber + ")," + text);

						} else if (log.methodName.length() == 0) {
							// C++
							String fullName;
							if (log.packageName.length() == 0) {
								fullName = log.className;
							} else {
								fullName = log.packageName + "\\" + log.className;
							}
							pw.println(log.date + " " + log.time + "," + fullName + "(" + log.lineNumber + "),"
									+ log.level + "," + text);
						} else {
							// Java
							String methodAndThread;
							if (log.threadName.length() == 0) {
								methodAndThread = log.methodName;
							} else {
								methodAndThread = log.methodName + "@" + log.threadName;
							}
							pw.println(log.date + " " + log.time + "," + log.packageName + "." + log.className + "("
									+ log.lineNumber + ")," + methodAndThread + "," + log.level + "," + text);
						}
					}
				}
				pw.close();
				lr.close();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
