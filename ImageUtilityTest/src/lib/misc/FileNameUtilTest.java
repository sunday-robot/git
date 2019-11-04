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
     *            �t�@�C���p�X
     * @param postFix
     *            �|�X�g�t�B�b�N�X
     * @param expected
     *            ���Ғl
     */
    private static void addPostFixTestSub(String filePath, String postFix,
	    String expected) {
	String actual = FileNameUtil.addPostFix(filePath, postFix);
	assertEquals(expected, actual);
    }
}
