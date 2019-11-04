package battlecity.exp;

/**
 * パターン番号(スプライトといった方がいいかも?)
 * 
 * @author akiyama
 * 
 */
public class PatternNo {

    /***/
    public static final int PAT_16 = 0;
    /***/
    public static final int PAT_32_1 = 53;
    /***/
    public static final int PAT_32_2 = (PAT_32_1 + 64);
    /***/
    public static final int PAT_64 = (PAT_32_2 + 30);

    /***/
    public static final int PAT_ROAD = PAT_16;
    /***/
    public static final int PAT_RENGA = PAT_ROAD;
    /***/
    public static final int PAT_WOOD = (PAT_16 + 16);
    /***/
    public static final int PAT_ICE = (PAT_16 + 17);
    /***/
    public static final int PAT_CONCRETE = (PAT_16 + 18);
    /***/
    public static final int PAT_RIVER = (PAT_16 + 19);
    /***/
    public static final int PAT_FRAME_H = (PAT_16 + 32);
    /***/
    public static final int PAT_FRAME_V = (PAT_16 + 33);
    /***/
    public static final int PAT_FRAME_UL = (PAT_16 + 34);
    /***/
    public static final int PAT_FRAME_UR = (PAT_16 + 35);
    /***/
    public static final int PAT_FRAME_LL = (PAT_16 + 36);
    /***/
    public static final int PAT_FRAME_LR = (PAT_16 + 37);

    /***/
    public static final int PAT_INFO_BOX_1 = (PAT_16 + 38);
    /***/
    public static final int PAT_INFO_BOX_2 = (PAT_16 + 39);
    /***/
    public static final int PAT_INFO_BOX_2U = (PAT_16 + 40);
    /***/
    public static final int PAT_INFO_BOX_2D = (PAT_16 + 41);
    /***/
    public static final int PAT_INFO_BOX_2L = (PAT_16 + 42);
    /***/
    public static final int PAT_INFO_BOX_2R = (PAT_16 + 43);
    /***/
    public static final int PAT_INFO_BOX_2UL = (PAT_16 + 44);
    /***/
    public static final int PAT_INFO_BOX_2UR = (PAT_16 + 45);
    /***/
    public static final int PAT_INFO_BOX_2DL = (PAT_16 + 46);
    /***/
    public static final int PAT_INFO_BOX_2DR = (PAT_16 + 47);
    /***/
    public static final int PAT_COM_ICON = (PAT_16 + 48);
    /***/
    public static final int PAT_PLAYER_1_ICON = (PAT_16 + 49);
    /***/
    public static final int PAT_PLAYER_2_ICON = (PAT_16 + 50);
    /***/
    public static final int PAT_STAGE_ICON = (PAT_16 + 51);

    /***/
    public static final int PAT_GUN = (PAT_16 + 20);
    /***/
    public static final int PAT_BASE = (PAT_16 + 24);
    /***/
    public static final int PAT_W_FLAG = (PAT_16 + 28);
    /***/
    public static final int PAT_BATU = (PAT_16 + 52);
    /***/

    /***/
    public static final int PAT_PLAYER1_TANK = PAT_32_1;
    /***/
    public static final int PAT_PLAYER2_TANK = (PAT_PLAYER1_TANK + 4 * 4);
    /***/
    public static final int PAT_COMP_TANK = (PAT_PLAYER2_TANK + 4 * 4);

    /***/
    public static final int PAT_BARRIER = (PAT_32_2 + 12);
    /***/
    public static final int PAT_BORN = (PAT_BARRIER + 2);

    /***/
    public static final int PAT_BURST2 = (PAT_BORN + 3);
    /***/
    public static final int PAT_ITEM = (PAT_BURST2 + 2);

    /***/
    public static final int PAT_POINT = (PAT_32_2 + 25);

    /***/
    public static final int PAT_BURST = PAT_64;

}
