package ConditionFile;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Text;
import org.xml.sax.SAXException;

public class ConditionFileLoader {
    /**
     * Condition�t�@�C����ǂ݁A���̓��e��Ԃ��B
     * 
     * @param filePath
     *            Condition�t�@�C���̃p�X��
     * @return List<TableGroupList>
     * @throws Exception
     */
    public static List<TableGroupList> load(final String filePath)
	    throws Exception {
	Document document = readXmlFile(filePath);
	List<TableGroupList> conditionFile = documentToConditionFile(document);
	return conditionFile;
    }

    private static Document readXmlFile(final String filePath)
	    throws SAXException, IOException, ParserConfigurationException {
	File file = new File(filePath);
	DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
	DocumentBuilder builder = factory.newDocumentBuilder();
	Document document = builder.parse(file);
	return document;
    }

    // XML�t�@�C���̓��e���ATableGroupList(1�̕\�ɑΉ�����)�̃I�u�W�F�N�g�̃��X�g�ɕϊ�����B
    private static List<TableGroupList> documentToConditionFile(
	    Document document) throws Exception {
	List<TableGroupList> cf = new ArrayList<TableGroupList>();
	Element element = document.getDocumentElement();
	if (element.getTagName() != "enablermodel:stateConditionTableGroupList") {
	    throw new Error("�ŏ�ʃ��x���̃G�������g��TableGroupList�ł���܂���B");
	}
	List<Node> children = getChildNodeList(element);
	for (int i = 0; i < children.size(); i++) {
	    Node n = children.get(i);
	    TableGroupList tgl = nodeToTableGroupList(n);
	    cf.add(tgl);
	}
	return cf;
    }

    private static boolean isEmptyTextNode(Node node) {
	if (!(node instanceof Text))
	    return false;
	Text t = (Text) node;
	String s = t.getTextContent().trim();
	return s.isEmpty();
    }

    private static List<Node> getChildNodeList(Node node) {
	List<Node> childNodes = new ArrayList<Node>();
	NodeList children = node.getChildNodes();
	for (int i = 0; i < children.getLength(); i++) {
	    Node child = children.item(i);
	    if (isEmptyTextNode(child))
		continue;
	    childNodes.add(child);
	}
	return childNodes;
    }

    // XML�t�@�C������TabGroupList(1�̕\�ɑΉ��������)�G�������g���I�u�W�F�N�g�ɕϊ�����
    private static TableGroupList nodeToTableGroupList(Node node)
	    throws Exception {
	if (!(node instanceof Element)) {
	    throw new Exception("Element�ł͂Ȃ�!");
	}

	Element e = (Element) node;

	if (!e.getNodeName()
		.equals("enablermodel:stateConditionTableGroupList")) {
	    throw new Exception("�^�O�����ُ�ł�!");
	}

	TableGroupList tgl = new TableGroupList();
	assert e.getAttributes().getLength() == 1;
	String s = e.getAttribute("isMainTable");
	boolean b = Boolean.parseBoolean(s);
	tgl.isMainTable = b;
	List<Node> children = getChildNodeList(node);
	for (Node child : children) {
	    StateConditionTableList tl = nodeToStateConditionTableList(child);
	    tgl.stateConditionTableLists.add(tl);
	}
	return tgl;
    }

    // TableList(�\)�̏���
    private static StateConditionTableList nodeToStateConditionTableList(
	    Node node) throws Exception {
	if (!(node instanceof Element)) {
	    throw new Exception("Element�ł͂Ȃ�!");
	}

	Element e = (Element) node;

	if (!e.getNodeName().equals("enablermodel:stateConditionTableList")) {
	    throw new Exception("�^�O�����ُ�ł�!");
	}

	StateConditionTableList tl = new StateConditionTableList();
	List<Node> children = getChildNodeList(node);
	tl.stateId = nodeToStateId(children.get(0));
	for (int i = 1; i < children.size(); i++) {
	    Node child = children.get(i);
	    Column c = nodeToColumn(child);
	    tl.columns.add(c);
	}
	return tl;
    }

    //
    private static String nodeToStateId(Node node) throws Exception {
	if (!(node instanceof Element)) {
	    throw new Exception("Element�ł͂Ȃ�!");
	}

	Element e = (Element) node;

	if (!e.getNodeName().equals("enablermodel:stateId")) {
	    throw new Exception("�^�O�����ُ�ł�!");
	}

	return e.getTextContent();
    }

    private static Column nodeToColumn(Node node) throws Exception {
	assert node.getNodeName() == "condition";
	Column c = new Column();
	List<Node> children = getChildNodeList(node);
	c.functionId = children.get(0).getTextContent();
	c.condition = nodeToConditon(children.get(1));
	return c;
    }

    private static List<Node> getSubList(List<Node> list, int fromIndex,
	    int toIndex) {
	List<Node> subList = new ArrayList<Node>();
	if (toIndex < 0) {
	    toIndex = list.size() - 1;
	}
	for (int i = fromIndex; i <= toIndex; i++) {
	    subList.add(list.get(i));
	}
	return subList;
    }

    private static Condition nodeToConditon(Node node) throws Exception {
	assert node.getNodeName() == "Condition";
	List<Node> children = getChildNodeList(node);
	String conditionType = children.get(0).getTextContent();
	// List<Node> conditionParameters = children.subList(1, children.size()
	// - 1);
	List<Node> conditionParameters = getSubList(children, 1, -1);
	if (conditionType.equals("EnableCondition")) {
	    return nodesToEnableCondition(conditionParameters);
	} else if (conditionType.equals("TableCondition")) {
	    return nodesToTableCondition(conditionParameters);
	} else if (conditionType.equals("NumberList")) {
	    return nodesToNumberListCondition(conditionParameters);
	} else if (conditionType.equals("DoubleRange")) {
	    return nodesToDoubleRangeCondition(conditionParameters);
	} else {
	    throw new Error("���m��conditionType(" + conditionType + ")�ł��B");
	}
    }

    private static Condition nodesToTableCondition(List<Node> nodes)
	    throws Exception {
	TableCondition tc = new TableCondition();
	for (Node node : nodes) {
	    StateConditionTableList sctl = nodeToStateConditionTableList(node);
	    tc.stateConditionTableLists.add(sctl);
	}
	return tc;
    }

    private static String checkElementNameAndGetTextContent(Node node,
	    String tagName) throws Exception {
	if (!(node instanceof Element)) {
	    throw new Exception("Element Node�ł͂Ȃ��B");
	}
	Element element = (Element) node;
	if (!element.getTagName().equals(tagName)) {
	    throw new Exception("�^�O����\"" + tagName + "\"�ł͂���܂���B");
	}
	return element.getTextContent();
    }

    private static Condition nodesToDoubleRangeCondition(List<Node> nodes)
	    throws Exception {
	if (nodes.size() != 3) {
	    throw new Exception("DoubleRangeCondition�̃p�����[�^����3�ł͂Ȃ��B");
	}
	DoubleRangeCondition drc = new DoubleRangeCondition();

	drc.max = Double.parseDouble(checkElementNameAndGetTextContent(
		nodes.get(0), "enablermodel:maxValue"));
	drc.min = Double.parseDouble(checkElementNameAndGetTextContent(
		nodes.get(1), "enablermodel:minValue"));
	drc.step = Double.parseDouble(checkElementNameAndGetTextContent(
		nodes.get(2), "enablermodel:stepValue"));

	return drc;
    }

    private static Number nodeToNumberElement(Node node) throws Exception {
	if (!(node instanceof Element)) {
	    throw new Exception("Element�ł͂Ȃ�!");
	}

	Element e = (Element) node;

	if (!e.getTagName().equals("enablermodel:numberElement")) {
	    throw new Exception("�^�O�����ُ�ł�!");
	}

	List<Node> children = getChildNodeList(node);
	String type = children.get(0).getTextContent();
	String value = children.get(1).getTextContent();
	if (type.equals("int")) {
	    return new Integer(value);
	} else if (type.equals("double")) {
	    return new Double(value);
	}
	throw new Exception("���m�̐��l�^�ł��B(" + type + ")");
    }

    private static Condition nodesToNumberListCondition(List<Node> nodes)
	    throws Exception {
	NumberListCondition nlc = new NumberListCondition();
	for (Node node : nodes) {
	    Number number = nodeToNumberElement(node);
	    nlc.numbers.add(number);
	}
	return nlc;
    }

    private static Condition nodesToEnableCondition(List<Node> nodes)
	    throws Exception {
	if (nodes.size() != 1) {
	    throw new Exception("EnableCondition�̃p�����[�^����1�ł͂Ȃ��B");
	}
	String s = nodes.get(0).getTextContent();
	boolean b = Boolean.parseBoolean(s);
	EnableCondition c = new EnableCondition();
	c.value = b;
	return c;
    }

}
