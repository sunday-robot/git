package minilext.device;

/**
 * CB(ControlBox)とのやり取りを行うもの。
 */
public abstract class CB {

	/**
	 * 電文を受信するもの
	 */
	public interface MessageReceiver {

		/**
		 * @param message
		 *            電文
		 */
		void received(String message);
	}

	/**
	 * 画像を受信するもの
	 */
	public interface FrameReceiver {

		/**
		 * @param data
		 *            画像データ
		 */
		void received(byte[] data);
	}

	/**
	 * 画像を受信するもの
	 */
	protected FrameReceiver frameReceiver;

	/**
	 * 電文を受信するもの
	 */
	private MessageReceiver messageReceiver;

	/**
	 * @param messageReceiver
	 *            :
	 * @param frameReceiver
	 *            :
	 */
	public final void initialize(MessageReceiver messageReceiver, FrameReceiver frameReceiver) {
		this.messageReceiver = messageReceiver;
		this.frameReceiver = frameReceiver;
	}

	/**
	 * PCに電文を送信する
	 * 
	 * @param message
	 *            :
	 */
	protected final void send(String message) {
		messageReceiver.received(message);
	}

	/**
	 * PCから電文を受信した際の処理。
	 * 
	 * @param text
	 *            :
	 */
	public abstract void received(String text);

	/**
	 * (デバッグ用)プロパティをコンソールに出力する
	 */
	public abstract void dumpProperties();
}
