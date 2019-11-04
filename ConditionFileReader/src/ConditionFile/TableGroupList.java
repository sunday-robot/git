package ConditionFile;

import java.util.ArrayList;
import java.util.List;

/**
 * 名前がわかりにくいが、一つの表に対応するクラスである。
 * 
 * @author akiyama
 * 
 */
public class TableGroupList {
    boolean isMainTable;
    List<StateConditionTableList> stateConditionTableLists = new ArrayList<StateConditionTableList>();
}
