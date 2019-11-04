package battlecity.model;

import java.awt.Point;

import battlecity.Status;
import battlecity.exp.GunHit;
import battlecity.types.VVramCellType;

/**
 * プレイヤー戦車及び敵戦車クラスの基底クラス
 * 
 * @author akiyama
 * 
 */
public abstract class Tank extends Actor {

	// private Pilot pilot; // 戦車を操縦する関数
	/** ヒットポイント、普通は 1 */
	private int hitPoint;
	/** (*pilot)() から、move_tank() が呼ばれたかどうかのフラグ(???意味不明) */
	private int moveFlag;
	/** ??? */
	private int sripTime;
	/** 次の弾を撃てるまでの待ち時間? */
	private int shootIntervalTime;

	/** 仮想VRAM */
	protected Vvram vvram;
	/** 他の戦車のリスト */
	protected Tank[] tanks;

	/***/
	private TankSpecification tankType;
	/** 位置と向き */
	private int direction;
	/** 登場時間、爆発時間、麻痺時間 */
	protected int miscTime;

	/**
	 * directionのゲッター
	 * 
	 * @return direction
	 */
	public final int getDirection() {
		return direction;
	}

	/**
	 * ゲッター
	 * 
	 * @return TankSpecification
	 */
	public final TankSpecification getTankType() {
		return tankType;
	}

	/**
	 * セッター
	 * 
	 * @param tt
	 *            TankSpecification
	 */
	protected final void setTankType(TankSpecification tt) {
		hitPoint = tt.getHitPoint();
	}

	// public void setPilot(Pilot pilot) {
	// this.pilot = pilot;
	// }

	/**
	 * 戦車を登場させる
	 * 
	 * @param x
	 *            int
	 * @param y
	 *            int
	 * @param dir
	 *            int
	 * @param tankType
	 *            TankSpecification
	 */
	void spawn(int x, int y, int dir, TankSpecification tankType) {
		if ((x < 16 || x > (Constants.STAGE_SIZE - 1 - 2) * 16)
				|| (y < 16 || y > (Constants.STAGE_SIZE - 1 - 2) * 16)
				|| (dir < 0 || dir >= 4)) {
			throw new Error(String.format("座標値が異常。(%d, %d, %d)", x, y, dir));
		}
		// this.pilot = tankType.pilot;
		super.spawn(x, y);
		this.direction = dir;
		setStatus(Status.SPAWNING);
		this.tankType = tankType;
		this.miscTime = Constants.BORN_TIME;
		setTankType(tankType);
	}

	/**
	 * 戦車を殺す???
	 */
	void die() {
		hitPoint = 0;
	}

	/**
	 * 戦車を動かす
	 * 
	 * @param newDir
	 *            　新しい方向(0:下、1:右、2:上、3:左、-1:現在と同じ方向)
	 * @return 方向転換時は常にtrue、何かに衝突することなく動けたらtrue、
	 */
	boolean move(int newDir) {
		if (newDir < -1 || newDir > 3) {
			throw new Error("wrong direction");
		}
		moveFlag = 1;
		if ((newDir != -1) && (this.direction != newDir)) {
			// 方向転換の場合
			if (((newDir ^ this.direction) & 1) != 0) {
				// 現在の向きと９０度違うなら座標を調節する
				if ((newDir & 1) != 0) {
					setY(adjustPotision(getY()));
				} else {
					setX(adjustPotision(getX()));
				}
			}
			this.direction = newDir;
			return true;
		} else {
			// 現在の方向に前進する場合
			int i;
			boolean moved = false; // 動いたかどうかのフラグ
			for (i = tankType.getGunSpeed(); i > 0; i--) {
				moved |= moveSub();
				if (!moved)
					break;
			}
			return moved;
		}
	}

	/**
	 * 戦車を現在向いている方向に１ドット進める、動けなかったら０を返す。<br/>
	 * (move()から呼ばれる。)
	 * 
	 * @return 壁や他の戦車に衝突することなく動けたかどうか
	 */
	protected boolean moveSub() {
		Point[] newPositionInVVRAM = { new Point(), new Point() };
		int newX;
		int newY;

		switch (this.direction) {
		case 0: // 下
			newX = getX();
			newY = getY() + 1;
			// 外接矩形左下の点(1ドット下に進めたあとの座標)の仮想vramでの位置
			newPositionInVVRAM[0].x = getX() / 16;
			newPositionInVVRAM[0].y = (getY() + 32) / 16;
			// 外接矩形右下の点(1ドット下に進めたあとの座標)の仮想vramでの位置
			newPositionInVVRAM[1].x = (getX() + 31) / 16;
			newPositionInVVRAM[1].y = newPositionInVVRAM[0].y;
			break;
		case 1: // 右
			newX = getX() + 1;
			newY = getY();
			newPositionInVVRAM[0].x = newPositionInVVRAM[1].x = (getX() + 32) / 16;
			newPositionInVVRAM[0].y = getY() / 16;
			newPositionInVVRAM[1].y = (getY() + 31) / 16;
			break;
		case 2: // 上
			newX = getX();
			newY = getY() - 1;
			newPositionInVVRAM[0].x = getX() / 16;
			newPositionInVVRAM[1].x = (getX() + 31) / 16;
			newPositionInVVRAM[0].y = newPositionInVVRAM[1].y = (getY() - 1) / 16;
			break;
		default: // case 3: // 左
			newX = getX() - 1;
			newY = getY();
			newPositionInVVRAM[0].x = newPositionInVVRAM[1].x = (getX() - 1) / 16;
			newPositionInVVRAM[0].y = getY() / 16;
			newPositionInVVRAM[1].y = (getY() + 31) / 16;
			break;
		}

		{ // 地形をチェック
			int i;
			for (i = 0; i < 2; i++) {
				switch (vvram.cells[newPositionInVVRAM[i].y][newPositionInVVRAM[i].x].type) {
				case ROAD:
					// case WOOD:
				case ICE:
					break;
				default:
					return false;
				}
			}
		}

		{
			// ほかの戦車との接触チェック
			// 方向転換時の座標調整(16の倍数にすること)の結果や、
			// spawn位置に既に他の戦車がいた場合、戦車と戦車が重なってしまうことになる。
			// この場合は接触判定を行わないようにしないと、重なった状態になってしまった場合どちらも身動きがとれない事になってしまう。
			for (Tank t2 : tanks) {
				if (t2.getStatus() != Status.ALIVE || t2 == this) {
					// その戦車が生きていない、或は自分自身なら何もしない
					continue;
				}
				int distX = Math.abs(newX - t2.getX());
				int distY = Math.abs(newY - t2.getY());
				if (distX < 32 && distY < 32) {
					// その戦車と接している
					int ox;
					int oy;
					ox = Math.abs(getX() - t2.getX());
					oy = Math.abs(getY() - t2.getY());
					if (distX + distY < ox + oy) {
						// 現在よりも更に近づくことは出来ない
						return false;
					}
				}
			}
		}
		setX(newX);
		setY(newY);
		return true;
	}

	/**
	 * 戦車が氷の上にいるかどうかをチェックする
	 * 
	 * @return 氷の上にいるかどうか
	 */
	final boolean isOnIce() {
		int cx1 = (getX() + 15) / 16;
		int cy1 = (getY() + 15) / 16;
		int cx2 = (getX() + 16) / 16;
		int cy2 = (getY() + 16) / 16;

		if (vvram.cells[cy1][cx1].type == VVramCellType.ICE
				&& vvram.cells[cy1][cx2].type == VVramCellType.ICE
				&& vvram.cells[cy2][cx1].type == VVramCellType.ICE
				&& vvram.cells[cy2][cx2].type == VVramCellType.ICE)
			return true;
		else
			return false;
	}

	/**
	 * 戦車にダメージを与える 敵戦車同士の相打ちならこれは呼ばれない
	 * 
	 * @param isPlayerBullet
	 *            プレイヤー戦車の砲弾かどうか
	 * @return GunHit
	 */
	abstract GunHit beShot(boolean isPlayerBullet);

	/**
	 * ヒットポイントを減らす
	 * 
	 * @return 減らした後のヒットポイント
	 */
	final int decreaseHitPoint() {
		hitPoint--;
		return hitPoint;
	}

	// void control_gun() {
	// for (int i = 0; i < num_of_gun; i++) {
	// gun[i].control();
	// }
	// }

	@Override
	public Status control() {
		// 状態遷移は、プレイヤー戦車とコンピューター戦車で少し異なるので、基底クラスのTankではなく、各派生クラスで実装したほうが良い?
		// この場合、状態を表すStateも派生させたほうが良い???
		switch (getStatus()) {
		case SPAWNING:
			// spawnして間もない状態(spawnしてから一定の時間、バリアで守られている)
			if (--miscTime == 0) {
				setStatus(Status.ALIVE);
				// // barrier_time = (flg == PLAYER) ? BARRIER_TIME2 : 0; //
				// プレイヤー戦車固有の処理
				// // change_pattern(&sprite, tank_type[type].pattern_num
				// // + (hit_point - 1) * 4, 0);
			}
			break;
		case ALIVE:
			if (hitPoint <= 0) {
				// 死んでしまった
				setStatus(Status.BURNING);
				miscTime = Constants.BURNING_TIME;
				// 爆発の絵は、戦車の2倍大きいので、座標をずらしていたが、モデルの仕事ではなかった。
				// x -= 16;
				// y -= 16;
			} else {
				moveFlag = 0;
				// if (flg == PLAYER) {
				// if (base.status == LIVE) {
				// // 味方基地がやられていたら動かない
				// if (misc_time) // この場合のmisc_timeは麻痺状態の
				// misc_time--; // 時間を表している
				// else
				// pilot(tn);
				// }
				// } else if (comp_tank_pararize_time == 0)
				// pilot(tn);
				if (isOnIce()) {
					if (moveFlag != 0)
						sripTime = Constants.SRIP_TIME;
					else if (sripTime > 0) {
						sripTime--;
						move(direction);
					}
				}
				// // バリア
				// if (barrier_time) {
				// barrier_time--;
				// if (!put_sprite(&barrier_sprite, x, y, barrier_time
				// & 1))
				// puts("control_tank(): error on put_sprite() barrier");
				// }
				// if (item && (item.time2 & 3))
				// koma = dir + 4;
				// else
				// koma = dir;
			}
			break;
		case BURNING:
			miscTime--;
			switch (miscTime) {
			case 0:
				// if (disp_point_flg) {
				// status = DISP_POINT;
				// x += 16;
				// y += 16;
				// misc_time = DISP_POINT_TIME;
				// koma = tank_type[type].option.point;
				// change_pattern(&sprite, PAT_POINT, 2);
				// } else {
				// status = DEAD3;
				// }
				break;
			case Constants.BURNING_TIME * 5 / 6:
			case Constants.BURNING_TIME * 3 / 6:
				// koma++;
				break;
			}
			break;
		// case DISP_POINT:
		// if (--misc_time == 0) {
		// status = DEAD3;
		// }
		// break;
		case KILLED:
			setStatus(Status.DEAD2);
			break;
		case DEAD2:
			// if (gun[0].status == DEAD && gun[1].status == DEAD)
			// status = DEAD;
			break;
		default:
			break;
		}
		if (getStatus() != Status.DEAD) {
			if (shootIntervalTime > 0)
				shootIntervalTime--;
			// // control_gun();
		}
		// if (status > DEAD3) {
		// if (status != ALIVE || ((misc_time & 4) == 0))
		// if (!put_sprite(&sprite, x, y, koma))
		// puts("control_tank(): error on put_sprite()");
		// }
		return getStatus();
	}

	/**
	 * 弾が撃てるかどうかを返す
	 * 
	 * @return 弾が撃てるかどうか
	 */
	final boolean canShootGun() {
		return shootIntervalTime == 0;
	}

	/**
	 * 指定された座標値を、16の倍数になるように、7捨8入する。
	 * 
	 * @param p
	 *            　調整前の座標値
	 * @return 調整後の座標値
	 */
	static int adjustPotision(int p) {
		return (p + 8) & ~15; // 8を足して、下位4ビットを0クリア
	}

	/**
	 * 砲弾を撃つ
	 * 
	 * @return 撃てたかどうか
	 */
	boolean shootGun() {
		// 念のためチェック
		if (shootIntervalTime > 0)
			return false;

		// static int g_x[4] = {8, 16, 8, 0};
		// static int g_y[4] = {16, 8, 0, 8};
		//
		// Gun.spawn(x + g_x[dir], g_y[dir], dir, this);
		// shoot_interval_time = SHOOT_INTERVAL_TIME;
		// if (flg == PLAYER) {
		// sound_out(EFS_SHOOT);
		// }
		return true;
	}
};
