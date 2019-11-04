package xmltest;

import java.io.IOException;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import org.w3c.dom.Attr;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Text;
import org.xml.sax.SAXException;

public final class Main {

	public static void main(String[] args) {
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db;
		try {
			db = dbf.newDocumentBuilder();
			Document doc = db.parse(args[0]);
			Element rootElement = doc.getDocumentElement();
			// printElement(rootElement, 0);
			printProgressInformation(rootElement);
		} catch (ParserConfigurationException e) {
			e.printStackTrace();
		} catch (SAXException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	private static void printProgressInformation(Element root) {
		NodeList infos = root.getElementsByTagName("lextSupportlist:objectiveLensData"); // ChildNodes();
		for (int i = 0; i < infos.getLength(); i++) {
			Element e = (Element) infos.item(i);

			String lensTypeId = e.getAttribute("lensTypeId");
			Element ep = (Element) e.getElementsByTagName("lextSupportlist:extendParam").item(0);
			Element lpp = (Element) ep.getElementsByTagName("lextSupportlist:lsmProgressParam")
					.item(0);
			String lsmBaseSecond = lpp.getElementsByTagName("lextSupportlist:baseSecond").item(0)
					.getTextContent().trim();
			String lsmBaseStep = lpp.getElementsByTagName("lextSupportlist:baseStep").item(0)
					.getTextContent().trim();
			Element cpp = (Element) ep.getElementsByTagName("lextSupportlist:ccdProgressParam")
					.item(0);
			String cameraBaseSecond = cpp.getElementsByTagName("lextSupportlist:baseSecond")
					.item(0).getTextContent().trim();
			String cameraBaseStep = cpp.getElementsByTagName("lextSupportlist:baseStep").item(0)
					.getTextContent().trim();
			System.out.println(lensTypeId + "," + lsmBaseSecond + "," + lsmBaseStep + ","
					+ cameraBaseSecond + "," + cameraBaseStep);
		}
	}

	static void indent(int indent) {
		for (int i = 0; i < indent; i++) {
			System.out.print(" ");
		}
	}

	private static void printElement(Element e, int indent) {
		indent(indent);
		System.out.println(e.getTagName());
		NamedNodeMap attributes = e.getAttributes();
		for (int i = 0; i < attributes.getLength(); i++) {
			Attr attr = (Attr) attributes.item(i);
			printAttribute(attr, indent);
		}
		NodeList children = e.getChildNodes();
		for (int i = 0; i < children.getLength(); i++) {
			Node n = children.item(i);
			if (n instanceof Text) {
				String textData = ((Text) n).getData().trim();
				if (textData.length() != 0) {
					indent(indent);
					System.out.println("[" + textData + "]");
				}
			} else if (n instanceof Element) {
				printElement((Element) n, indent + 2);
			}
		}
	}

	private static void printAttribute(Attr attribute, int indent) {
		indent(indent);
		System.out.println("@" + attribute.getName() + "=" + attribute.getValue());
	}
}
