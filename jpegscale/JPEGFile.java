import java.awt.image.BufferedImage;
import java.io.FileInputStream;
import java.io.FileOutputStream;

import com.sun.image.codec.jpeg.JPEGCodec;
import com.sun.image.codec.jpeg.JPEGEncodeParam;
import com.sun.image.codec.jpeg.JPEGImageDecoder;
import com.sun.image.codec.jpeg.JPEGImageEncoder;

public class JPEGFile {
	public static BufferedImage load(String fname) throws Exception {
		FileInputStream fis = new FileInputStream(fname);
		JPEGImageDecoder jid = JPEGCodec.createJPEGDecoder(fis);
		BufferedImage img = jid.decodeAsBufferedImage();
		fis.close();
		return img;
	}

	public static void save(BufferedImage img, String fname) throws Exception {
		FileOutputStream fos = new FileOutputStream(fname);
		JPEGImageEncoder jie = JPEGCodec.createJPEGEncoder(fos);
		JPEGEncodeParam jep = jie.getDefaultJPEGEncodeParam(img);
		jep.setQuality(0.8f, true);
		jie.setJPEGEncodeParam(jep);
		jie.encode(img);
		fos.close();
	}
}
