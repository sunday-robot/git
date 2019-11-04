package lib.pagecompactor;

import java.beans.XMLDecoder;
import java.io.FileInputStream;
import java.io.IOException;

/**
 * @author akiyama
 */
public class LoadFromXML {
    /**
     * XML�t�@�C���Ƃ��ăG���R�[�h����Ă���Java�I�u�W�F�N�g�����[�h����B
     * 
     * @param filePath
     *            �t�@�C���p�X
     * @return Java�I�u�W�F�N�g
     * @throws IOException
     *             �t�@�C�����o�̓G���[
     * @throws ArrayIndexOutOfBoundsException
     *             �f�R�[�h�G���[
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
