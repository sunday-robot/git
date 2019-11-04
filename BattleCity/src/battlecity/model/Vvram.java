// TODO 仮想VRAMという考え方はやめたほうがいいような気がする。

package battlecity.model;


/**
 * 仮想VRAM
 * 
 * @author akiyama
 * 
 */
public class Vvram {
    /***/
    private static final int STAGE_SIZE = 1;

    /** セル */
    public final VvramCell[][] cells;
    {
	cells = new VvramCell[STAGE_SIZE][];
	for (int i = 0; i < STAGE_SIZE; i++) {
	    cells[i] = new VvramCell[STAGE_SIZE];
	}
    }
}
