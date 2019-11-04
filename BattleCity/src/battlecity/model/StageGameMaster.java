package battlecity.model;

import battlecity.exp.EndCode;
import battlecity.model.actor.Base;
import battlecity.model.actor.ComputerTank;
import battlecity.model.actor.Item;
import battlecity.model.actor.PlayerTank;
import battlecity.model.exp.Status;

/**
 * 各ステージの開始から終了までを受け持つクラス。
 * (”ゲームマスター”という言葉は、TRPG用語(もっと広い?)で、ゲームのプレイヤーではなく、進行役のこと。)
 */
public final class StageGameMaster {

	/** ゲーム中(startボタンで開始してからゲームオーバーになるまで)保持しておかなければならないデータ */
	private boolean is2pMode; // 2Pモードか否(1Pモード)か

	/** ステージのデータ(地形データ、コンピューター戦車の出現順序等) */
	private StageData stageData;

	/** プレイヤー1のデータ */
	private PlayerData player1Data;

	/** プレイヤー2のデータ */
	private PlayerData player2Data;

	/***/
	private int endFlag;

	/***/
	private int endCount;

	/***/
	private EndCode endCode;

	/** 司令部 */
	private Base base = new Base();

	/** アイテム */
	private Item item = new Item();

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

	/**
	 */
	public StageGameMaster() {
	}

	/**
	 * 初期化する。ステージ開始時に呼ばれる。
	 * 
	 * @param is2pMode
	 *            2Pモードかどうか
	 * @param stageData
	 *            ステージデータ
	 * @param player1Data
	 *            プレイヤー1のデータ
	 * @param player2Data
	 *            プレイヤー2のデータ
	 */
	public void initialize(boolean is2pMode, StageData stageData, PlayerData player1Data, PlayerData player2Data) {
		this.is2pMode = is2pMode;
		this.stageData = stageData;
		this.player1Data = player1Data;
		this.player2Data = player2Data;

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
	 * 時間を一刻み進める(60FPSで回るゲームのメインループの内部処理)
	 * 
	 * @return ???
	 */
	public boolean tick() {
		int i;

		// キーボード、ジョイスティックの状態を取得

		// プレイヤー戦車
		for (i = 0; i < playerTanks.length; i++) {
			PlayerTank t = playerTanks[i];
			if (t.getStatus() != Status.DEAD) {
				t.control();
			} else {
				// 死んでいて、残りがあるなら、戦車を登場させる
				if (t.leftTankCount > 0) {
					t.spawn(Constants.INITIAL_PLAYER_TANK_POSITIONS[i].x, Constants.INITIAL_PLAYER_TANK_POSITIONS[i].y,
							2, t.getTankSpecification());
					t.leftTankCount--;
				}
			}
		}
		if ((playerTanks[0].getStatus() == Status.DEAD) && (playerTanks[1].getStatus() == Status.DEAD)) {
			endCode = EndCode.GAME_OVER;
			endCount++;
		}

		// コンピューター戦車
		for (i = 0; i < getMaximumComputerTankCount(); i++) {
			ComputerTank t = computerTanks[i];
			if (t.getStatus() != Status.DEAD)
				t.control();
			else {
				if (nextComputerTankIndex < 20 && compTankGenerateInterval >= Constants.GENERATE_INTERVAL) {
					// 死んでいて、控えの戦車があり、前のを登場させてから
					// 充分な時間が経っていたら、登場させる
					ComputerTankSpecification ctt = stageData.enemyTankSequence[nextComputerTankIndex];
					boolean hasItem = stageData.enemyTankHasItemSequence[nextComputerTankIndex];
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
	 * 2Pモードかどうかを返す。
	 * 
	 * @return 2Pモードかどうか
	 */
	public boolean is2pMode() {
		return is2pMode;
	}

	/**
	 * コンピューターの残りの戦車の数を返す(現在ゲーム画面に登場している戦車は含まない)
	 * 
	 * @return コンピューターの残りの戦車の数
	 */
	public int getLeftComputerTankCount() {
		return 20 - nextComputerTankIndex;
	}

	/**
	 * プレイヤー1の残りの戦車の数を返す(現在ゲーム画面に登場している戦車は含まない)
	 * 
	 * @return プレイヤー1の残りの戦車の数
	 */
	public int getLeftPlayer1TankCount() {
		return player1Data.getLeftTankCount();
	}

	/**
	 * プレイヤー2の残りの戦車の数を返す(現在ゲーム画面に登場している戦車は含まない)
	 * 
	 * @return プレイヤー2の残りの戦車の数
	 */
	public int getLeftPlayer2TankCount() {
		return player2Data.getLeftTankCount();
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
	private void guardBase() {
		// TODO Auto-generated method stub

	}

	/**
	 * ???
	 * 
	 * @return EndCode
	 */
	public EndCode getEndCode() {
		return endCode;
	}

	/**
	 * ステージ上に登場するコンピューター戦車の最大数(1Pモードと2Pモードで異なっている。)
	 * 
	 * @return コンピューター戦車の数
	 */
	private int getMaximumComputerTankCount() {
		if (is2pMode)
			return 4;
		else
			return 6;
	}

}
