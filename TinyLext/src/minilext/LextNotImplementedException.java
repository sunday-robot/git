package minilext;

/**
 * 未実装機能用の例外(例外の名前は.Netから拝借したもの。Javaに同様なものがあればいらないのだが、それらしいのがなさそう。)
 */
@SuppressWarnings("serial")
public final class LextNotImplementedException extends RuntimeException {

	/**
	 * @param s
	 *            :
	 */
	public LextNotImplementedException(String s) {
		super(s);
	}

	/**
	 */
	public LextNotImplementedException() {
		this(null);
	}
}
