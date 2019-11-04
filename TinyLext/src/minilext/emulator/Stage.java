package minilext.emulator;

import java.util.Timer;
import java.util.TimerTask;

/** XYGコマンドを実行するもの */
public final class Stage {

    /**
     * ステージ移動の通知を受け取るためのIF
     */
    public interface Listener {

	/**
	 * ステージ位置更新通知
	 * 
	 * @param x
	 *            [nm]
	 * @param y
	 *            [nm]
	 */
	void positionUpdated(int x, int y);

	/**
	 * ステージ移動終了通知
	 * 
	 * @param errorCode
	 *            :
	 */
	void ended(int errorCode);
    }

    /** 定期通知の間隔[ms] */
    private static final int NOTIFICATION_INTERVAL = 500;

    /** 開始時刻[ms] */
    private long startTime;

    /** 終了時間[ms] */
    private long endTime;

    /** 目標位置X[nm] */
    private int targetX = 0;

    /** 目標位置Y[nm] */
    private int targetY = 0;

    /** 移動終了後に通知するタイマー */
    private Timer finishedNotificationTimer = null;

    /** 移動中、定期的に現在位置を通知するタイマー */
    private Timer repeatNotificationTimer = null;

    /** ステージの現在位置X[nm] */
    private int currentX = 0;

    /** ステージの現在位置Y[nm] */
    private int currentY = 0;

    /**
     * ステージ移動状況の通知先
     */
    private final Listener listener;

    /**
     * @param listener
     *            ステージ移動状況の通知先
     */
    public Stage(Listener listener) {
	this.listener = listener;
    }

    /**
     * 現在位置からの相対移動
     * 
     * @param dx
     *            [nm]
     * @param dy
     *            [nm]
     * @param speed
     *            [nm/s]
     */
    public void move(int dx, int dy, int speed) {
	moveTo(currentX + dx, currentY + dy, speed);
    }

    /**
     * 絶対位置移動
     * 
     * @param x
     *            [nm]
     * @param y
     *            [nm]
     * @param speed
     *            [nm/s]
     */
    public synchronized void moveTo(final int x, final int y, int speed) {
	startTime = System.currentTimeMillis();
	targetX = x;
	targetY = y;
	double distance = calcDistance(currentX, currentY, targetX, targetY); // 距離[nm]
	long t = (long) (distance * 1000 / speed); // 時間[ms]
	endTime = startTime + t;
	repeatNotificationTimer = new Timer();
	repeatNotificationTimer.schedule(new TimerTask() {

	    @Override
	    public void run() {
		notifyCurrentPosition();
	    }

	}, NOTIFICATION_INTERVAL, NOTIFICATION_INTERVAL);

	finishedNotificationTimer = new Timer();
	finishedNotificationTimer.schedule(new TimerTask() {

	    @Override
	    public void run() {
		endMoving(targetX, targetY, 0);
	    }
	}, t);
    }

    /**
     * ステージ移動を止め、止まるまで待つ。
     */
    public synchronized void stop() {
	if (finishedNotificationTimer != null) {
	    long tt = System.currentTimeMillis();
	    if (tt < endTime) {
		long t = tt - startTime;
		int x = currentX + (int) ((targetX - currentX) * t / (endTime - startTime));
		int y = currentY + (int) ((targetY - currentY) * t / (endTime - startTime));
		endMoving(x, y, 1);
	    } else {
		endMoving(targetX, targetY, 0);
	    }
	}
    }

    /**
     * 現在位置をリスナーに通知する。
     */
    private synchronized void notifyCurrentPosition() {
	long tt = System.currentTimeMillis();
	if (tt < endTime) {
	    long t = tt - startTime;
	    int x = currentX + (int) ((targetX - currentX) * t / (endTime - startTime));
	    int y = currentY + (int) ((targetY - currentY) * t / (endTime - startTime));
	    listener.positionUpdated(x, y);
	}
    }

    /**
     * ステージ移動処理を終了させ、リスナーに現在位置と、移動終了を通知する。
     * 
     * @param x
     *            [nm]
     * @param y
     *            [nm]
     * @param errorCode
     *            :
     */
    private synchronized void endMoving(int x, int y, int errorCode) {
	finishedNotificationTimer.cancel();
	finishedNotificationTimer = null;
	repeatNotificationTimer.cancel();
	repeatNotificationTimer = null;
	currentX = x;
	currentY = y;
	listener.positionUpdated(x, y);
	listener.ended(errorCode);
    }

    /**
     * @param x0
     *            :
     * @param y0
     *            :
     * @param x1
     *            :
     * @param y1
     *            :
     * @return 2点間の距離
     */
    private static double calcDistance(int x0, int y0, int x1, int y1) {
	long dx = x1 - x0;
	long dy = y1 - y0;
	return Math.sqrt(dx * dx + dy * dy);
    }
}
