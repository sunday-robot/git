package battlecity;

/**
 * 仮想VRAMのセル(各マス)のタイプ
 * 
 * @author akiyama
 * 
 */
public enum VVramCellType {
    /** 通常の地面 */
    ROAD,
    /** レンガブロック */
    RENGA,
    /** 森 */
    WOOD,
    /** 凍った地面 */
    ICE,
    /** コンクリートブロック */
    CONCRETE,
    /** 川 */
    RIVER,
    /** 周囲の枠 */
    FRAME,
    /** 基地??? */
    BASE
}
