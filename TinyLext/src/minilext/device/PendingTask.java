package minilext.device;

/**
 */
public final class PendingTask {

	/***/
	public final int index;
	/***/
	public final String tag;
	/***/
	public final Runnable runnable;

	/**
	 * @param index
	 *            :
	 * @param tag
	 *            :
	 * @param runnable
	 *            :
	 */
	public PendingTask(int index, String tag, Runnable runnable) {
		this.index = index;
		this.tag = tag;
		this.runnable = runnable;
	}
}
