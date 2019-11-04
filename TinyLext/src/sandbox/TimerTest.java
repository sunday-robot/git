package sandbox;

import java.util.Timer;
import java.util.TimerTask;

/**  */
public final class TimerTest {

	/***/
	private TimerTest() {
	}

	/**
	 * @param args
	 *            :
	 */
	public static void main(String[] args) {
		final Timer t = new Timer();
		TimerTask tt = new TimerTask() {

			int count = 0;

			@Override
			public void run() {
				System.out.println(System.currentTimeMillis());
				count++;
				if (count > 10) {
					t.cancel();
				}
			}

		};
		t.schedule(tt, 1000, 1000);
	}
}
