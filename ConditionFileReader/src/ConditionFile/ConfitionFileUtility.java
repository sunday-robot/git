package ConditionFile;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class ConfitionFileUtility {
    /**
     * FunctionIDをひと通り列挙する。
     * 
     * @param tableGroupLists
     * @return FunctionIDのリスト
     */
    public static List<String> getAllFunctionIDs(
	    List<TableGroupList> tableGroupLists) {
	Set<String> functionIDSet = new HashSet<>();
	for (TableGroupList tgl : tableGroupLists) {
	    for (StateConditionTableList sctl : tgl.stateConditionTableLists) {
		for (Column column : sctl.columns) {
		    functionIDSet.add(column.functionId);
		}
	    }
	}
	List<String> functionIDs = new ArrayList<>(functionIDSet);
	Collections.sort(functionIDs);
	return functionIDs;
    }

    /**
     * 
     * @param stateConditionTableLists
     * @param stateIDGroupSet
     */
    private static void gatherStateIDGroups(
	    List<StateConditionTableList> stateConditionTableLists,
	    Set<List<String>> stateIDGroupSet) {
	List<String> stateIDGroup = new ArrayList<>();
	for (StateConditionTableList sctl : stateConditionTableLists) {
	    stateIDGroup.add(sctl.stateId);
	    for (Column column : sctl.columns) {
		if (column.condition instanceof TableCondition) {
		    TableCondition tc = (TableCondition) column.condition;
		    gatherStateIDGroups(tc.stateConditionTableLists,
			    stateIDGroupSet);
		}
	    }
	}
	Collections.sort(stateIDGroup);
	stateIDGroupSet.add(stateIDGroup);
    }

    /**
     * StateIDのグループをひと通り列挙する。 (作っては見たが、多分使い道なし。)
     * 
     * @param tableGroupLists
     * @return StatteIDのグループのリスト
     */
    public static List<List<String>> getStateIDGroups(
	    List<TableGroupList> tableGroupLists) {
	Set<List<String>> stateIDGroupSet = new HashSet<>();
	for (TableGroupList tgl : tableGroupLists) {
	    gatherStateIDGroups(tgl.stateConditionTableLists, stateIDGroupSet);
	}
	List<List<String>> stateIDGroupList = new ArrayList<>(stateIDGroupSet);
	Collections.sort(stateIDGroupList, new MyComparator());
	return stateIDGroupList;
    }

    /**
     * 機能の有効/無効に関わるStateIDのグループのみを列挙する。
     * 
     * @param tableGroupLists
     * @return StatteIDのグループのリスト
     */
    public static List<List<String>> getEnablerStateIDGroups(
	    List<TableGroupList> tableGroupLists) {
	Set<List<String>> stateIDGroupSet = new HashSet<>();
	for (TableGroupList tgl : tableGroupLists) {
	    gatherEnablerStateIDGroups(tgl.stateConditionTableLists,
		    stateIDGroupSet);
	}
	List<List<String>> stateIDGroupList = new ArrayList<>(stateIDGroupSet);
	Collections.sort(stateIDGroupList, new MyComparator());
	return stateIDGroupList;
    }

    /**
     * 
     * @param stateConditionTableLists
     * @param stateIDGroupSet
     */
    private static void gatherEnablerStateIDGroups(
	    List<StateConditionTableList> stateConditionTableLists,
	    Set<List<String>> stateIDGroupSet) {
	List<String> stateIDGroup = new ArrayList<>();
	for (StateConditionTableList sctl : stateConditionTableLists) {
	    stateIDGroup.add(sctl.stateId);
	    for (Column column : sctl.columns) {
		if (column.condition instanceof TableCondition) {
		    TableCondition tc = (TableCondition) column.condition;
		    gatherStateIDGroups(tc.stateConditionTableLists,
			    stateIDGroupSet);
		}
	    }
	}
	Collections.sort(stateIDGroup);
	stateIDGroupSet.add(stateIDGroup);
    }

    private static void getFunctionCondition(
	    List<TableGroupList> tableGroupLists, String functionID) {

    }
}
