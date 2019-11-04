package lib.misc;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

/**
 */
public class FileNameUtilTest {
    /**
     */
    @Test
    public static void addPostFixTest() {
	addPostFixTestSub("a\\b.c", "d", "a\\bd.c");
	addPostFixTestSub("b.c", "d", "bd.c");
    }

    /**
     * 
     * @param filePath
     *            ファイルパス
     * @param postFix
     *            ポストフィックス
     * @param expected
     *            期待値
     */
    private static void addPostFixTestSub(String filePath, String postFix,
	    String expected) {
	String actual = FileNameUtil.addPostFix(filePath, postFix);
	assertEquals(expected, actual);
    }
}
