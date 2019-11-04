package hello;

import static hello.P.p;

/***/
public final class TestP {
    /***/
    private TestP() {
    }

    /**
     * @param args
     *            :
     */
    public static void main(String[] args) {
	p();
	p("abc");
	sub();
    }

    /***/
    private static void sub() {
	p();
	p("<%d>", 3);
    }
}
