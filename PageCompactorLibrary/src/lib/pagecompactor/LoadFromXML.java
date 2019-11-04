package lib.pagecompactor;

import java.beans.XMLDecoder;
import java.io.FileInputStream;
import java.io.IOException;

/**
 * @author akiyama
 */
public class LoadFromXML {
    /**
     * XMLファイルとしてエンコードされているJavaオブジェクトをロードする。
     * 
     * @param filePath
     *            ファイルパス
     * @return Javaオブジェクト
     * @throws IOException
     *             ファイル入出力エラー
     * @throws ArrayIndexOutOfBoundsException
     *             デコードエラー
     */
    public static Object load(String filePath) throws IOException,
	    ArrayIndexOutOfBoundsException {
	FileInputStream is = new FileInputStream(filePath);
	XMLDecoder decoder = new XMLDecoder(is);
	Object obj = decoder.readObject();
	decoder.close();
	is.close();
	return obj;
    }
}
