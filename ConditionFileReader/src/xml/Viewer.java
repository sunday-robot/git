package xml;
import org.w3c.dom.Attr;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Text;

public class Viewer {
    private Viewer() {
    }

    public static void view(Document document) {
	System.out.printf("Document: [%s]\n", document.toString());
	Element e = document.getDocumentElement();
	viewElement(e, "");
    }

    private static void viewElement(Element element, String indent) {
	System.out.printf("%sElement: [%s]\n", indent, element.getTagName());
	indent = indent + "  ";
	NamedNodeMap nnm = element.getAttributes();
	for (int i = 0; i < nnm.getLength(); i++) {
	    viewAttribute((Attr) nnm.item(i), indent);
	}
	NodeList children = element.getChildNodes();
	for (int i = 0; i < children.getLength(); i++) {
	    Node c = children.item(i);
	    if (c instanceof Element) {
		viewElement((Element) c, indent);
	    } else if (c instanceof Text) {
		viewText((Text) c, indent);
	    } else {
		System.out.println(indent + "<<(unknown)>>");
		System.out.println(indent + c.getClass().toString());
		System.out.printf("%sType:[%s], Name:[%s], Value:[%s]\n",
			indent, c.getNodeType(), c.getNodeName(),
			c.getNodeName());
	    }
	}
    }

    private static void viewAttribute(Attr attribute, String indent) {
	System.out.printf("%sAttr: [%s = %s]\n", indent, attribute.getName(),
		attribute.getValue());
    }

    private static void viewText(Text text, String indent) {
	String s = text.getTextContent().trim();
	if (!s.isEmpty())
	    System.out.printf("%sText: [%s]\n", indent, s);
    }

    // private static void pp(Object o) {
    // if (o == null) {
    // return;
    // }
    // System.out.printf("%s [%s]\n", o.getClass().toString(), o.toString());
    // }

    // private static void cc(Class cls) {
    //
    // }

}
