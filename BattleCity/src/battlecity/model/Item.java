package battlecity.model;

import battlecity.Rand;
import battlecity.Status;
import battlecity.exp.ItemType;

/**
 * アイテム(同時にはひとつしか存在し得ない)
 * 
 * @author akiyama
 * 
 */
public class Item extends Actor {
	/** アイテムの種類(FIXME:サブクラス化したほうがいいかも) */
	private ItemType type;

	/** 得点表示時間管理用のタイマー */
	private int time;

	/** 点滅アニメーション用のタイマー */
	// private int time2;

	/**
	 * typeのゲッターではない。FIXME:本メソッドは再考が必要
	 * 
	 * @param tx
	 *            int
	 * @param ty
	 *            int
	 * @return type
	 */
	public final ItemType getItemType(int tx, int ty) {
		if (getStatus() != Status.ALIVE) {
			return ItemType.NONE;
		}
		if ((Math.abs(getX() - tx) >= 32) || (Math.abs(getX() - ty) >= 32)) {
			return ItemType.NONE;
		}
		return type;
	}

	@Override
	public final Status control() {
		switch (getStatus()) {
		case ALIVE:
			// if (!(time2 & 4)) // アイテムを点滅させるため
			// if (!put_sprite(&sprite, x, y, type))
			// puts("control_item(): error on put_sprite()");
			break;
		case DISP_POINT:
			if (--time == 0)
				setStatus(Status.DEAD);
			// if (!put_sprite(&sprite, x, y, type))
			// puts("control_item(): error on put_sprite()");
			break;
		default:
			break;
		}
		// time2++;
		return getStatus();
	}

	/**
	 * timeのセッター
	 * 
	 * @param t
	 *            int
	 */
	public final void setTimer(int t) {
		time = t;
	}

	/**
	 * セッター
	 * 
	 * @param t
	 *            ItemType
	 */
	final void setType(ItemType t) {
		type = t;
	}

	/**
	 * ステージに登場させる
	 */
	final void spawn() {
		setStatus(Status.ALIVE);
		setX(Rand.get((Constants.STAGE_SIZE - 4) * 16) + 16);
		setY(Rand.get((Constants.STAGE_SIZE - 4) * 16) + 16);
		type = getItemNumber();
		// change_pattern(&sprite, PAT_ITEM, 2);
	}

	/**
	 * アイテムの番号を返す
	 * 
	 * @return アイテムの番号
	 */
	static ItemType getItemNumber() {
		return ItemType.selectRandomly();
	}

}
