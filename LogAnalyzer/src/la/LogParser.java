package la;

/**
 * ログファイルの1行をパースする。
 */
public final class LogParser {

	/***/
	private LogParser() {
	}

	/**
	 * @param s
	 *            :
	 * @return :
	 */
	public static Log parse(String s) {
		final String date;
		final String time;
		final String packageName;
		final String className;
		final int lineNumber;
		final String methodName;
		final String threadName;
		final String level;
		final String text;

		final String[] columns = s.split(",", 4);
		String[] c;

		c = columns[0].split(" ");
		date = c[0]; // yyyy/mm/ddではなく、mm/dd/yyyyだったりするので注意。
		time = c[1];

		// Logging Application
		// [0]:<日付> <時刻>
		// [1]:<レベル>
		// [2]:<テキスト>

		// eclipse
		// [0]:<日付> <時刻>
		// [1]:<パッケージ名>.<クラス名>(<行番号>)
		// [2]:<テキスト>

		// Java
		// [0]:<日付> <時刻>
		// [1]:<パッケージ名>.<クラス名>(<行番号>)
		// [2]:<メソッド名>@<スレッド名>
		// [3]:<レベル>
		// [4]:<テキスト>

		// C++
		// [0]:<日付> <時刻>
		// [1]:<ディレクトリ名>\<ファイル名>(<行番号>)
		// [2]:<レベル>
		// [3]:<テキスト>

		// 後処理(C#)
		// [0]:<日付> <時刻>
		// [1]:<メソッドシグニチャ?>
		// [2]:(<行番号?(常に0なのでよくわからない)>)
		// [3]:<レベル>
		// [4]:<テキスト>

		if (columns[1].charAt(0) == '[') {
			// Logging Application起動時のログ?
			packageName = null;
			className = null;
			lineNumber = 0;
			methodName = null;
			threadName = null;
			level = columns[1];
			text = columns[2] + "," + columns[3];
		} else if (columns[1].startsWith("org.eclipse")) {
			// eclipseのログ
			c = columns[1].split("[()]");
			String fullName = c[0];
			int lastPeriod = fullName.lastIndexOf('.');
			packageName = fullName.substring(0, lastPeriod);
			className = fullName.substring(lastPeriod + 1);
			lineNumber = Integer.parseInt(c[1]);
			methodName = null;
			threadName = null;
			level = null;
			text = columns[2] + "," + columns[3];
		} else {
			switch (columns[2].charAt(0)) {
			case '[' :
				// C++のログ
				c = columns[1].split("[()]");
				String pathName = c[0];

				int lastBackSlash = pathName.lastIndexOf('\\');
				if (lastBackSlash == -1) {
					packageName = null;
					className = pathName;
				} else {
					packageName = pathName.substring(0, lastBackSlash);
					className = pathName.substring(lastBackSlash + 1);
				}
				lineNumber = Integer.parseInt(c[1]);
				methodName = null;
				threadName = null;
				level = columns[2];
				text = columns[3];
			break;
			case '(' :
				// 後処理(C#)のログ
				packageName = null;
				className = null;
				lineNumber = Integer.parseInt(columns[2].split("[()]")[1]);
				methodName = columns[1];
				threadName = null;

				c = columns[3].split(",", 2);
				level = c[0];
				text = c[1];
			break;
			default :
				// Javaのログ
				c = columns[1].split("[()]");
				String fullName = c[0];
				int lastPeriod = fullName.lastIndexOf('.');
				packageName = fullName.substring(0, lastPeriod);
				className = fullName.substring(lastPeriod + 1);
				lineNumber = Integer.parseInt(c[1]);

				c = columns[2].split("@");
				methodName = c[0];
				if (c.length == 1) {
					threadName = null;
				} else {
					threadName = c[1];
				}

				c = columns[3].split(",", 2);
				level = c[0];
				if (c.length == 1) {
					text = null;
				} else {
					text = c[1];
				}
			}
		}

		return new Log(date, time, packageName, className, lineNumber, methodName, threadName,
				level, text);
	}
}
