package lib.pagecompactor;

/**
 */
public final class TestObject {
	/**  */
	private int a;
	/**  */
	private String b;

	/**
	 * 
	 */
	public TestObject() {
		setA(0);
		setB("");
	}

	/**
	 * 
	 * @param a
	 *            :
	 * @param b
	 *            :
	 */
	public TestObject(int a, String b) {
		this.setA(a);
		this.setB(b);
	}

	/**
	 * 
	 * @return :
	 */
	public int getA() {
		return a;
	}

	/**
	 * 
	 * @param a
	 *            :
	 */
	public void setA(int a) {
		this.a = a;
	}

	/**
	 * 
	 * @return :
	 */
	public String getB() {
		return b;
	}

	/**
	 * 
	 * @param b
	 *            :
	 */
	public void setB(String b) {
		this.b = b;
	}
}