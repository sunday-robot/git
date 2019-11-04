package battlecity.model;

import battlecity.Status;

/**
 * 戦車、弾、アイテム、司令部のクラスの親クラス。
 * 
 * @author akiyama
 */
public abstract class Actor {
	/** X座標 */
	private int x;

	/** Y座標 */
	private int y;

	/** 状態(TODO 状態というのはプレイヤー戦車や、コンピューター戦車固有のものがあるので、あまりよい設計ではないと思う。) */
	private Status status = Status.DEAD;

	/**
	 * @param x
	 *            int
	 */
	public final void setX(int x) {
		this.x = x;
	}

	/**
	 * @return X
	 */
	public final int getX() {
		return x;
	}

	/**
	 * @param y
	 *            int
	 */
	public final void setY(int y) {
		this.y = y;
	}

	/**
	 * @return Y
	 */
	public final int getY() {
		return y;
	}

	/**
	 * 
	 * @return status
	 */
	public final Status getStatus() {
		return status;
	}

	/**
	 * 
	 * @param status
	 *            Status
	 */
	protected final void setStatus(Status status) {
		this.status = status;
	}

	/**
	 * 画面(ステージ)に登場させる
	 * 
	 * @param x
	 *            int
	 * @param y
	 *            int
	 */
	public final void spawn(int x, int y) {
		this.x = x;
		this.y = y;
	}

	// TODO これも多分良い設計ではない。
	/**
	 * 
	 * @return Staus
	 */
	public abstract Status control();
}
