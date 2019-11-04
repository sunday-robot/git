package battlecity.model;

import battlecity.types.VVramCellType;

/**
 * 仮想VRAMのセル
 */
public class VvramCell {
    /***/
    public VVramCellType type;
    /***/
    public byte pat; // レンガ特有のものである。レンガの場合、戦車の砲弾で破壊することができるが、1つの塊(16x16ドット)が一度に壊れるのではなく、その1/4の更に小さな塊(8x8ドット)が壊れる単位になっている。この小さな塊がどの程度残っているのかを示すビットマップになっている。左上が1、右上が2、左下が4、右下が8である。
};
