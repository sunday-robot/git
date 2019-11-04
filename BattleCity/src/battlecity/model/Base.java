package battlecity.model;

import java.awt.Point;

import battlecity.Status;
import battlecity.types.VVramCellType;

/**
 * 基地(司令部)
 * 
 * @author akiyama
 * 
 */
public class Base extends Actor {
	// 状態遷移：
	// ・生きている
	// ・死んでいる
	//
	// ステージ開始時：
	// 最初から登場する。
	//
	// プレイヤータンクがヘルメット型アイテムをとった場合：
	// 周囲のレンガを修理する。
	// また、一定期間周囲のレンガをコンクリートに変更する。
	//
	// 弾が当たった時：
	// 死ぬ。

	// /** 基地のX座標 */
	// private final int BASE_X = Constants.STAGE_SIZE / 2 - 1;
	// /** 基地のY座標 */
	// private final int BASE_Y = Constants.STAGE_SIZE - 3;
	// 基地の場所は、ゲームマスターが知っておくべきことかな?

	/** 周囲のブロック(レンガ)の座標 */
	private static final Point[] GUARD_BLOCK_POSITIONS = {};

	/** 仮想VRAM */
	private Vvram vvram;

	/** 撃たれたかどうか? */
	private boolean hit = false;

	/** やられた時の燃焼時間 */
	private int burningTimeCounter = 0;

	/** コンクリートブロックの残り時間 */
	private int guardTimeCounter = 0;

	/**
	 * コンストラクタ
	 */
	public Base() {
	}

	/**
	 * 周りの壁の属性を変える
	 * 
	 * @param isConcrete
	 *            コンクリートブロックかどうか
	 */
	public final void setBaseWallType(boolean isConcrete) {
		int i;

		if (isConcrete)
			for (i = 0; i < 8; i++) {
				Point p = GUARD_BLOCK_POSITIONS[i];
				vvram.cells[p.y][p.x].type = VVramCellType.CONCRETE;
			}
		else
			for (i = 0; i < 8; i++) {
				Point p = GUARD_BLOCK_POSITIONS[i];
				vvram.cells[p.y][p.x].type = VVramCellType.RENGA;
				vvram.cells[p.y][p.x].pat = 15;
			}
	}

	// // 司令部の周りの壁の絵を変える
	// static void set_base_wall_pattern(boolean flg) {
	// int pat = flg ? PatternNo.PAT_CONCRETE : PatternNo.PAT_RENGA + 15;
	// int i;
	//
	// for (i = 0; i < 8; i++) {
	// Point p = guardBlockPositions[i];
	// // change_BG(p.x, p.y, 0, pat);
	// }
	// }
	//
	//
	/**
	 * 司令部の周りをガードする
	 */
	public final void guard() {
		guardTimeCounter = Constants.BASE_GUARD_TIME;
		setBaseWallType(true);
		// set_base_wall_pattern(true);
	}

	@Override
	public final Status control() {
		switch (getStatus()) {
		case ALIVE:
			if (guardTimeCounter > 0) {
				guardTimeCounter--;
				if (guardTimeCounter == 0) {
					// 周りの壁をレンガに変える
					setBaseWallType(false);
					// if (guardTimeCounter < Constants.BASE_GUARD_TIME / 4
					// && (guardTimeCounter & 3) == 0) {
					// 残り時間が少なくなったら、適当な間隔で点滅させる
					// set_base_wall_pattern((guard_time & 4) != 0);
				}
			}
			if (hit) {
				// sound_out(EFS_BURST);
				setStatus(Status.BURNING);
				burningTimeCounter = Constants.BURNING_TIME;
			}
			break;
		case BURNING:
			switch (--burningTimeCounter) {
			case 0:
				setStatus(Status.KILLED);
				// BG の変更(降伏の白い旗)
				// change_BG(BASE_X, BASE_Y, 0, PAT_W_FLAG);
				// change_BG(BASE_X + 1, BASE_Y, 0, PAT_W_FLAG + 1);
				// change_BG(BASE_X, BASE_Y + 1, 0, PAT_W_FLAG + 2);
				// change_BG(BASE_X + 1, BASE_Y + 1, 0, PAT_W_FLAG + 3);
				break;
			case Constants.BURNING_TIME * 5 / 6:
			case Constants.BURNING_TIME * 3 / 6:
				// koma++;
			default:
				// // if (!put_sprite(&sprite, (BASE_X - 1) * 16, (BASE_Y - 1) *
				// 16, koma))
				// // puts("control_base(): error on put_sprite()");
				break;
			}
			break;
		case KILLED:
			setStatus(Status.DEAD);
			break;
		default:
			break;
		}
		return getStatus();
	}

}
