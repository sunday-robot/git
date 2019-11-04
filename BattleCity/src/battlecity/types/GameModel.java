package battlecity.types;

import battlecity.model.StageGameMaster;

/**
 * GameModelは、以下に示す、プログラムの大枠となる状態を制御する。 <br>
 * ・プログラム起動時の初期化処理<br>
 * ・タイトル画面<br>
 * ・ステージセレクト画面<br>
 * ・ステージプレイ画面<br>
 * ・ゲームオーバー画面<br>
 * ・ハイスコア画面<br>
 * GameModelは、UIは持たない。UIを担当するのは本クラスのユーザーであるGameViewが担当する。
 * 
 * 本クラス(オブジェクト)で保持するのは、上記画面間をまたがって必要となるものだけである。
 * 
 * @author akiyama
 */
public class GameModel {
    /** 現在進行中のゲームでの各プレイヤーのスコア */
    private int[] scores = new int[2];

    /** 各プレイヤーのハイスコア */
    private int[] highestScores = new int[2];

    /** 現在の状態(=何画面を表示中か) */
    private GameState gameState;

    /** ゲーム中(startボタンで開始してからゲームオーバーになるまで)保持しておかなければならないデータ */
    private boolean is2pMode; // 2Pモードか否(1Pモード)か

    /** ステージ画面を司るモデル */
    private StageGameMaster stageGameMaster = new StageGameMaster();

    /**
     * コンストラクタ
     */
    public GameModel() {
	gameState = GameState.Stage;
    }

    /**
     * ハイスコアを返す
     * 
     * @return ハイスコア
     */
    public final int getHighestScore() {
	return Math.max(highestScores[0], highestScores[1]);
    }

    // ステージ開始時の処理の一部
    // // 戦車のリセット（みんな死んだ状態にする）
    // reset_tanks();

    // ゲーム開始時の処理の一部
    // // 撃墜数の初期化
    // for (i = 0; i < 2; i++)
    // for (j = 0; j < 5; j ++)
    // hits[i].num[j] = 0;

}
