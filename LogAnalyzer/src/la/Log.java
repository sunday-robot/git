package la;

/**
 * ログファイルの1行内容を保持するもの
 */
public final class Log {

	/** 日付 */
	public final String date;
	/** 時刻 */
	public final String time;
	/** javaのパッケージ名(C++の場合はソースファイルのディレクトリ名) */
	public final String packageName;
	/** javaのクラス名(C++の場合はソースファイル名) */
	public final String className;
	/** ソースの行番号 */
	public final int lineNumber;
	/** メソッド名 */
	public final String methodName;
	/** スレッド名(スレッド名不明な場合は空文字列) */
	public final String threadName;
	/** レベル(Error,Fatal,Warning,Debugなど) */
	public final String level;
	/** 任意の文字列 */
	public final String text;

	/**
	 * @param date
	 *            :
	 * @param time
	 *            :
	 * @param packageName
	 *            :
	 * @param className
	 *            :
	 * @param lineNumber
	 *            :
	 * @param methodName
	 *            :
	 * @param threadName
	 *            :
	 * @param level
	 *            :
	 * @param text
	 *            :
	 */
	public Log(String date, String time, String packageName, String className, int lineNumber,
			String methodName, String threadName, String level, String text) {
		this.date = s(date);
		this.time = s(time);
		this.packageName = s(packageName);
		this.className = s(className);
		this.lineNumber = lineNumber;
		this.methodName = s(methodName);
		this.threadName = s(threadName);
		this.level = s(level);
		this.text = s(text);
	}

	/**
	 * @param s
	 *            :
	 * @return sがnullの場合は空文字列、そうでない場合はs
	 */
	private static String s(String s) {
		if (s == null) {
			return "";
		}
		return s;
	}

	@Override
	public String toString() {
		return "<date:" + date + ">, "//
				+ "<time:" + time + ">, "//
				+ "<packageName:" + packageName + ">, " //
				+ "<className:" + className + ">, " //
				+ "<lineNumber:" + lineNumber + ">, "//
				+ "<methodName:" + methodName + ">, "//
				+ "<threadName:" + threadName + ">, "//
				+ "<level:" + level + ">, "//
				+ "<text:" + text + ">";
	}
}
