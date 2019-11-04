package battlecity.model;

import battlecity.Status;
import battlecity.exp.EndCode;

/**
 * 各ステージの開始から終了までを受け持つクラス。
 * (”ゲームマスター”という言葉は、TRPG用語(もっと広い?)で、ゲームのプレイヤーではなく、進行役のこと。)
 * 
 * @author akiyama
 * 
 */
public class GameMaster {

	/** ゲーム中(startボタンで開始してからゲームオーバーになるまで)保持しておかなければならないデータ */
	private boolean is2pMode; // 2Pモードか否(1Pモード)か

	/** ステージの番号(1～) */
	private int stageNumber;

	/** 1P戦車の残りの数 */
	private int _1pTankCount;

	/** 2P戦車の残りの数 */
	private int _2pTankCount;

	/***/
	private int endFlag;

	/***/
	private int endCount;

	/***/
	private EndCode endCode;

	/** 司令部 */
	private Base base = new Base();

	/** アイテム(TODO:これはプライベートにすること) */
	public Item item = new Item();

	/** プレイヤーの戦車 */
	private PlayerTank[] playerTanks = { new PlayerTank(this), new PlayerTank(this) };

	/** コンピューターの戦車 */
	private ComputerTank[] computerTanks = { new ComputerTank(this), new ComputerTank(this), new ComputerTank(this),
			new ComputerTank(this), new ComputerTank(this), new ComputerTank(this) }; // 2Pゲームモード時に登場するコンピューター戦車の最大数は6

	/** 現在ステージに登場しているコンピューターの戦車の数 */
	private int computerTankCount;

	/** 次に登場するコンピューター戦車のインデックス */
	private int nextComputerTankIndex;

	/** 敵戦車の出現間隔のカウンタ */
	private int compTankGenerateInterval;

	/** 敵戦車の登場スケジュール */
	private int[] compTanks = new int[20];

	public GameMaster() {
	}

	/**
	 * ゲームを開始する
	 * 
	 * @param is2pMode
	 *            2Pモードかどうか
	 * @param stageNumber
	 *            ステージの番号(1～)
	 * @param _1pTankCount
	 *            1P戦車の数
	 * @param _2pTankCount
	 *            2P戦車の数
	 */
	final void initialize(boolean is2pMode, int stageNumber, int _1pTankCount, int _2pTankCount) {
		this.is2pMode = is2pMode;
		this.stageNumber = stageNumber;
		this._1pTankCount = _1pTankCount;
		this._2pTankCount = _2pTankCount;

		if (this.is2pMode) {
			this.playerTanks[0].initialize(true);
			this.playerTanks[1].initialize(true);
			// // set_joy_assign(JA_2P);
		} else {
			this.playerTanks[0].initialize(true);
			this.playerTanks[1].initialize(false); // 2P側をGameOver状態
			// // set_joy_assign(JA_1P);
		}
		computerTankCount = 0;
		nextComputerTankIndex = 0;
		compTankGenerateInterval = Constants.GENERATE_INTERVAL / 2;
		endCode = EndCode.STAGE_CLEAR;
		endFlag = 0;
		endCount = 0;
	}

	/**
	 * 2Pモードかどうかを返す。
	 * 
	 * @return 2Pモードかどうか
	 */
	public final boolean is2pMode() {
		return is2pMode;
	}

	/**
	 * コンピューターの残りの戦車の数を返す(現在ゲーム画面に登場している戦車は含まない)
	 * 
	 * @return コンピューターの残りの戦車の数
	 */
	public final int getLeftComputerTankCount() {
		return 20 - nextComputerTankIndex;
	}

	/**
	 * プレイヤー1の残りの戦車の数を返す(現在ゲーム画面に登場している戦車は含まない)
	 * 
	 * @return プレイヤー1の残りの戦車の数
	 */
	public final int getLeftPlayer1TankCount() {
		return this._1pTankCount - 1;
	}

	/**
	 * プレイヤー2の残りの戦車の数を返す(現在ゲーム画面に登場している戦車は含まない)
	 * 
	 * @return プレイヤー2の残りの戦車の数
	 */
	public final int getLeftPlayer2TankCount() {
		return this._2pTankCount - 1;
	}

	/**
	 * アイテムを登場させる。<br>
	 * アイテムを持っているコンピュータ戦車が最初に撃たれた時(やられた時ではないことに注意)に、本メソッドを呼ぶ。
	 */
	public void spawnItem() {
		// TODO Auto-generated method stub

	}

	/**
	 * 司令部の周囲のレンガブロックを修復するとともに、一定時間コンクリートブロックでガードする
	 */
	public void guardBase() {
		// TODO Auto-generated method stub

	}

	/**
	 * ???
	 * 
	 * @return EndCode
	 */
	final EndCode getEndCode() {
		return endCode;
	}

	/**
	 * 文字をコンピュータ戦車の種類に変換する。 TODO:このクラスのものではないかなあ
	 * 
	 * @param c
	 *            コンピュータ戦車の種類を表すアルファベット
	 * @return コンピュータ戦車の種類
	 */
	private static ComputerTankSpecification getComputerTankTypeFromCharacter(int c) {
		switch (Character.toLowerCase(c)) {
		case 'a':
			return ComputerTankTypes.A;
		case 'b':
			return ComputerTankTypes.B;
		case 'c':
			return ComputerTankTypes.C;
		default:
			return ComputerTankTypes.D;
		}
	}

	/**
	 * 時間を一刻み進める(60FPSで回るゲームのメインループの内部処理)
	 * 
	 * @return ???
	 */
	public final boolean tick() {
		int i;

		// プレイヤー戦車
		for (i = 0; i < playerTanks.length; i++) {
			PlayerTank t = playerTanks[i];
			if (t.getStatus() != Status.DEAD) {
				t.control();
			} else {
				// 死んでいて、残りがあるなら、戦車を登場させる
				if (t.leftTankCount > 0) {
					t.spawn(Constants.INITIAL_PLAYER_TANK_POSITIONS[i].x, Constants.INITIAL_PLAYER_TANK_POSITIONS[i].y,
							2, t.getTankType());
					t.leftTankCount--;
				}
			}
		}
		if ((playerTanks[0].getStatus() == Status.DEAD) && (playerTanks[1].getStatus() == Status.DEAD)) {
			endCode = EndCode.GAME_OVER;
			endCount++;
		}

		// コンピューター戦車
		for (i = 0; i < maximumComputerTankCount(); i++) {
			ComputerTank t = computerTanks[i];
			if (t.getStatus() != Status.DEAD)
				t.control();
			else {
				if (nextComputerTankIndex < 20 && compTankGenerateInterval >= Constants.GENERATE_INTERVAL) {
					// 死んでいて、控えの戦車があり、前のを登場させてから
					// 充分な時間が経っていたら、登場させる
					int c = compTanks[nextComputerTankIndex];
					ComputerTankSpecification ctt = getComputerTankTypeFromCharacter(c);
					boolean hasItem = Character.isUpperCase(c);
					t.spawn(Constants.INITIAL_COMPUTER_TANK_POSITIONS[nextComputerTankIndex % 3].x,
							Constants.INITIAL_COMPUTER_TANK_POSITIONS[nextComputerTankIndex % 3].y, 0, ctt, hasItem);
					nextComputerTankIndex++;
					// print_rest_comp_tank(20 - ++comp_tank_index);
					compTankGenerateInterval = 0;
				}
			}
		}

		for (ComputerTank t : computerTanks) {
			Status r = t.control();
			switch (r) {
			case SPAWNING:
			case ALIVE:
			case BURNING:
			case DISP_POINT:
			case DEAD2:
				break;
			case DEAD:
				// コンピューターの戦車の場合
				break;
			case KILLED: // 今死んだところ
				if (--computerTankCount == 0) {
					if (nextComputerTankIndex == 20) {
						// 終了カウンタをスタートさせる
						endCount++;
					}
				}
				break;
			default: // その他
				throw new Error("game(): control_tank()の戻り値が異常です" /* i, r */);
			}
		}
		compTankGenerateInterval++;
		ComputerTank.controlPararizeTimer();

		// アイテムの処理
		item.control();

		// 司令部の処理
		if (base.control() == Status.KILLED) {
			// // game_over_message(3);
			endCode = EndCode.GAME_OVER;
			endCount++;
		}
		// // ctrl_game_over_message();

		// ゲームオーバー後の一定時間の待ち(←もっと適切な言葉があると思うのだが…)
		if (endCount > 0) {
			if (++endCount > Constants.MAX_END_COUNT)
				endFlag = 1;
		}
		// PAUSE の処理
		// if (get_esc_key()) {
		// // sound_out(EFS_PAUSE);
		// pause_message(1);
		// while (1) {
		// if (get_esc_key()) {
		// // sound_out(EFS_PAUSE);
		// break;
		// } else if (get_quit_key()) { // 'q'キーが押されたら強制終了
		// end_flg = 1;
		// end_code = EXIT_GAME;
		// break;
		// }
		// }
		// pause_message(0);
		// }
		return endFlag != 0;
	}

	/**
	 * 残りのプレーヤー戦車の数
	 * 
	 * @param playerIndex
	 *            プレイヤーが1P/2Pのどちらか
	 * @return 残りのプレーヤー戦車の数
	 */
	public final int getLeftTankCount(int playerIndex) {
		return this.playerTanks[playerIndex].leftTankCount;
	}

	// ComputerTankAppearanceOrder

	/**
	 * ステージ上に登場するコンピューター戦車の最大数(1Pモードと2Pモードで異なっている。)
	 * 
	 * @return コンピューター戦車の数
	 */
	final int maximumComputerTankCount() {
		if (is2pMode)
			return 4;
		else
			return 6;
	}

}
