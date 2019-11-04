package la.apps;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.nio.file.Path;
import java.nio.file.Paths;
import la.Log;
import la.LogParser;
import la.LogReader;

/**
 *
 */
public final class LogsToCsv {

	/** */
	private LogsToCsv() {
	}

	/**
	 * @param args
	 *            ログファイルパス名のリスト
	 */
	public static void main(String[] args) {
		if (args.length == 0) {
			System.err.println("Usage:LogsToCsv <log files>...");
			System.exit(1);
		}

		try {
			Path csvFilePath = Paths.get(args[0]).toAbsolutePath().getParent().resolve("log.csv");
			PrintWriter pw = new PrintWriter(new OutputStreamWriter(new FileOutputStream(
					csvFilePath.toFile()), "Shift-JIS"));

			for (String arg : args) {
				LogReader lr = new LogReader(arg);
				pw.printf("date\ttime\tpackageName\tclassName\tlineNumber\tmethodName\tthreadName\tlevel\ttext\n");
				for (;;) {
					String s = lr.read();
					if (s == null) {
						break;
					}
					Log log = LogParser.parse(s);
					pw.printf(
							"%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\n", //
							log.date, log.time, log.packageName, log.className, log.lineNumber,
							log.methodName, log.threadName, log.level, log.text);
				}
				lr.close();
			}
			pw.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
