package ConditionFile;

import java.util.ArrayList;
import java.util.List;

/**
 * 名前がわかりにくいが、1つの表の1行に対応する。
 * 
 * @author akiyama
 * 
 */
public class StateConditionTableList extends Condition {
    String stateId;
    List<Column> columns = new ArrayList<Column>(); // 実際にはColumnではなくconditionなのだが、名前がかぶっていて非常にわかりにくいので、変更した。
}
