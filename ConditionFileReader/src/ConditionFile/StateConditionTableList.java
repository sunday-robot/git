package ConditionFile;

import java.util.ArrayList;
import java.util.List;

/**
 * ���O���킩��ɂ������A1�̕\��1�s�ɑΉ�����B
 * 
 * @author akiyama
 * 
 */
public class StateConditionTableList extends Condition {
    String stateId;
    List<Column> columns = new ArrayList<Column>(); // ���ۂɂ�Column�ł͂Ȃ�condition�Ȃ̂����A���O�����Ԃ��Ă��Ĕ��ɂ킩��ɂ����̂ŁA�ύX�����B
}
