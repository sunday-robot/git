package battlecity.model;

public enum GameState {
    /** タイトル画面 */
    Title,
    /** ステージ選択画面 */
    StageSelect,
    /** ステージ画面(ゲーム画面) */
    Stage,
    /** ステージ結果画面(ステージ終了後の成績表示画面) */
    StageResult,
    /** ゲームオーバー画面 */
    GameOver
}
