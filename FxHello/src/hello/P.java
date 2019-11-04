package hello;

/**
 * 簡易デバッグログ出力
 */
public final class P {
    /***/
    private P() {
    }

    /**
     */
    public static void p() {
	System.out.println(h());
    }

    /**
     * @param format
     *            :
     * @param args
     *            :
     */
    public static void p(String format, Object... args) {
	System.out.println(h() + String.format(format, args));
    }

    /**
     * @return :
     */
    private static String h() {
	StackTraceElement[] stes = Thread.currentThread().getStackTrace();
	StackTraceElement ste = stes[3];
	String className = getSimpleName(ste.getClassName());
	String methodName = ste.getMethodName();
	int lineNumebr = ste.getLineNumber();
	String s = className + " # " + methodName + "(" + lineNumebr + ") : ";
	return s;
    }

    /**
     * @param className
     *            :
     * @return :
     */
    private static String getSimpleName(String className) {
	int index = className.lastIndexOf('.');
	if (index < 0) {
	    return className;
	}
	return className.substring(index + 1);
    }
}
