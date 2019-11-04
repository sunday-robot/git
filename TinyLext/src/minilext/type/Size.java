package minilext.type;

/**
 * (Immutable)<br>
 * int型の幅と高さ(単位については規定しない)
 */
public final class Size {
	/** */
	public final int width;

	/** */
	public final int height;

	/**
	 * @param width
	 *            :
	 * @param height
	 *            :
	 */
	public Size(int width, int height) {
		this.width = width;
		this.height = height;
	}
}
