package battlecity.model;

import java.nio.file.Paths;

import battlecity.model.util.StageDataLoader;

/**
 * アプリケーション全体のモデル
 */
public final class MainModel {
	// private PlayerData player1Data;

	/** ハイスコア */
	private static final int DEFAULT_HIGH_SCORE = 2000;

	/** プレイヤー1のハイスコア */
	private int player1HighScore = 0;

	/** プレイヤー2のハイスコア */
	private int player2HighScore = -1; // -1はデータなしとして扱う。

	/** 最後のステージの成績(戦績) */
	private int[][] killCount = new int[2][4];

	/** ステージデータのリスト */
	private final StageData[] stageDataList;

	/**
	 * @param baseDirectory
	 *            ?
	 * @throws Exception
	 *             :
	 */
	public MainModel(String baseDirectory) throws Exception {
		String f = Paths.get(baseDirectory, "bcty.stg").toString();
		stageDataList = StageDataLoader.load(f);
	}

	/**
	 * @return プレイヤー1のハイスコア
	 */
	public int getPlayer1HighScore() {
		return player1HighScore;
	}

	/**
	 * @return プレイヤー2のハイスコア
	 */
	public int getPlayer2HighScore() {
		return player2HighScore;
	}

	/**
	 * @return ハイスコア
	 */
	public int getHighScore() {
		return Math.max(Math.max(player1HighScore, player2HighScore), DEFAULT_HIGH_SCORE);
	}

	/**
	 * @return 最大のステージ番号(1～)
	 */
	public int getMaximumStageNumber() {
		return stageDataList.length + 1;
	}

	/**
	 * 
	 * @param playerNumber
	 *            1 or 2
	 * @param tankType
	 *            1..4
	 * @return 倒した数
	 */
	public int getKillCount(int playerNumber, int tankType) {
		return killCount[playerNumber - 1][tankType - 1];
	}
}
