package minilext.log;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/** ログ出力を行うもの */
public final class Log {

    /**  */
    private static final SimpleDateFormat DATE_FORMAT = new SimpleDateFormat("HH:mm:ss.SSS");

    /**  */
    private static final Object SYNC_OBJECT = new Object();

    /** */
    private Log() {
    }

    /**
     * コールスタックの深さに応じた字下げをしないもの。
     * 
     * @param caller
     *                   呼び出し元
     * @param format
     *                   :
     * @param args
     *                   :
     */
    public static void o(Object caller, String format, Object... args) {
	StackTraceElement[] sts = Thread.currentThread().getStackTrace();
	p(caller, 2, -1, sts, format, args);
    }

    /**
     * @param caller
     *                   呼び出し元
     * @param format
     *                   フォーマット文字列
     * @param args
     *                   フォーマットの引数
     */
    public static void p(Object caller, String format, Object... args) {
	StackTraceElement[] sts = Thread.currentThread().getStackTrace();
	p(caller, 2, 0, sts, format, args);
    }

    /**
     * @param caller
     *                   呼び出し元
     * @param depth
     *                   呼び出し元のさらに呼び出し元を何段階までさかのぼるか(0ならさかのぼらない)
     * @param format
     *                   フォーマット文字列
     * @param args
     *                   フォーマットの引数
     */
    public static void p(Object caller, int depth, String format, Object args) {
	StackTraceElement[] sts = Thread.currentThread().getStackTrace();
	p(caller, 2, depth, sts, format, args);
    }

    /**
     * @param caller
     *                         :
     * @param callersIndex
     *                         :
     * @param depth
     *                         呼び出し元のさらに呼び出し元を何段階までさかのぼるか(0ならさかのぼらない)
     * @param sts
     *                         :
     * @param format
     *                         フォーマット文字列
     * @param args
     *                         フォーマットの引数
     */
    private static void p(Object caller, int callersIndex, int depth, StackTraceElement[] sts, String format,
	    Object... args) {
	String date = DATE_FORMAT.format(Calendar.getInstance().getTime()); // 時刻はできるだけ早めに取得する
	long tid = Thread.currentThread().getId();
	String threadName = String.format("%10s", Thread.currentThread().getName());

	synchronized (SYNC_OBJECT) {
	    // 呼び出し元の呼び出し元の出力(日付、インスタンスのハッシュコードは不明なので"-"を出力する。
	    if (depth > 0) {
		int index = Math.min(callersIndex + depth, sts.length - 1);
		for (; index > callersIndex; index--) {
		    int indentLevel = sts.length - 1 - index;
		    StackTraceElement ste = sts[index];
		    String className = getShortClassName(ste.getClassName());
		    String methodName = ste.getMethodName();
		    int lineNumber = ste.getLineNumber();
		    String s = String.format("------------ (%5d(%s), --------):%s%s#%s(%d)", tid, threadName,
			    getIndentString(indentLevel), className, methodName, lineNumber);
		    System.out.println(s);
		}
	    }

	    // 呼び出し元の出力
	    long hashCode = System.identityHashCode(caller);
	    StackTraceElement st = sts[callersIndex]; // 0:getStackTrace()の情報、1:本メソッドp()の情報、2:p()の呼び出し元の情報
	    String className = getShortClassName(st.getClassName());
	    String methodName = st.getMethodName();
	    int lineNumber = st.getLineNumber();
	    String indent;

	    if (depth >= 0) {
		indent = getIndentString(sts.length - callersIndex);
	    } else {
		indent = "";
	    }
	    String msg = String.format(format, args);
	    String s = String.format("%s (%5d(%s), %8x):%s%s#%s(%d) %s", date, tid, threadName, hashCode, indent,
		    className, methodName, lineNumber, msg);
	    System.out.println(s);
	}
    }

    /**
     * クラスのフルネームでは長すぎ、Class#getSimpleName()では、匿名クラスの名前が、が分かりにくいので、ちょうどよい短い名前を返す。
     * 
     * @param fullName
     *                     クラスのフルネーム
     * @return クラスの短い名前
     */
    private static String getShortClassName(String fullName) {
	Pattern pattern = Pattern.compile("[A-Z]");
	Matcher m = pattern.matcher(fullName);
	if (!m.find()) {
	    return fullName;
	}
	m.start();
	return fullName.substring(m.start());
    }

    /**
     * @param depth
     *                  字下げの深さ
     * @return 字下げ用の空白文字列
     */
    private static String getIndentString(int depth) {
	StringBuffer indent = new StringBuffer();
	for (int i = 0; i < depth; i++) {
	    indent.append(" ");
	}
	return indent.toString();
    }

    /**
     * @param array
     *                  :
     * @return :
     */
    public static String arrayToString(int[] array) {
	StringBuffer sb = new StringBuffer("{");
	for (int e : array)
	    sb.append(e + ",");
	sb.append("}");
	return sb.toString();
    }
}
