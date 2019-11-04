package lib.pagecompactor;

import java.beans.XMLEncoder;
import java.io.FileOutputStream;
import java.io.IOException;

/**
 * �w�肳�ꂽ�I�u�W�F�N�g���w�肳�ꂽ�t�@�C������XML�t�@�C���Ƃ��ďo�͂���B
 * 
 * @author akiyama
 */
public class SaveAsXML {
    /**
     * 
     * @param obj
     *            �o�͂���I�u�W�F�N�g
     * @param filePath
     *            XML�t�@�C���p�X
     * @throws IOException
     *             ���o�̓G���[
     */
    public static void save(Object obj, String filePath) throws IOException {
	FileOutputStream os = new FileOutputStream(filePath);
	XMLEncoder encoder = new XMLEncoder(os);
	encoder.writeObject(obj);
	encoder.close();
    }
}
