package lib.pagecompactor;

import java.beans.XMLEncoder;
import java.io.FileOutputStream;
import java.io.IOException;

/**
 * 指定されたオブジェクトを指定されたファイル名のXMLファイルとして出力する。
 * 
 * @author akiyama
 */
public class SaveAsXML {
    /**
     * 
     * @param obj
     *            出力するオブジェクト
     * @param filePath
     *            XMLファイルパス
     * @throws IOException
     *             入出力エラー
     */
    public static void save(Object obj, String filePath) throws IOException {
	FileOutputStream os = new FileOutputStream(filePath);
	XMLEncoder encoder = new XMLEncoder(os);
	encoder.writeObject(obj);
	encoder.close();
    }
}
