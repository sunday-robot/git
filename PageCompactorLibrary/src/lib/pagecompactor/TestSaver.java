package lib.pagecompactor;

import java.io.IOException;

/**
 * LoadFromXML、SaveAsXMLの動作確認用プログラム
 */
public class TestSaver {

    /**
     * @param args
     *            使用しない
     * @throws IOException
     *             　IOException
     */
    public static void main(String[] args) throws IOException {
	// TestObject obj = new TestObject(1, "abc");
	// Saver.saveAs(obj, "test.xml");
	PageRegion header = new PageRegion(1, 2, 3, 4, 5);
	// SaveAsXML.save(header, "test.xml");
	PageRegion body = null;
	PageRegion footer = null;
	PageLayout pl = new PageLayout(header, body, footer);
	SaveAsXML.save(pl, "test.xml");
	PageLayout pl2 = (PageLayout) LoadFromXML.load("test.xml");
	SaveAsXML.save(pl2, "test2.xml");
    }

    /**  */
    static class TestObject {
	/**  */
	private int a;
	/**  */
	private String b;

	/**  */
	public TestObject() {
	    setA(0);
	    setB("");
	}

	/**
	 * @param a
	 *            int
	 * @param b
	 *            String
	 */
	public TestObject(int a, String b) {
	    this.setA(a);
	    this.setB(b);
	}

	/**
	 * @return int
	 */
	public int getA() {
	    return a;
	}

	/**
	 * @param a
	 *            int
	 */
	public void setA(int a) {
	    this.a = a;
	}

	/**
	 * @return String
	 */
	public String getB() {
	    return b;
	}

	/**
	 * @param b
	 *            String
	 */
	public void setB(String b) {
	    this.b = b;
	}
    }
}
