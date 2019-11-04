package gps;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;

/**
 */
public final class URLGetContentTest {
    /** */
    private URLGetContentTest() {
    }

    /**
     * @param args
     *                 :
     */
    public static void main(String[] args) {
	try {
	    final var url = new URL("https://www.bing.com/");

	    // 下記URLからは、JPGデータそのものが取得できるわけではない。
	    // よくわからないが、500kbを超える、ほぼJvaScriptのみのHTMLデータが取得できるというものらしい。
	    // final var url = new URL("https://photos.app.goo.gl/URDcZGawedgCR3uBA");
	    final var content = (InputStream) url.getContent();
	    final var bytes = content.readAllBytes();
	    System.out.println(content);
	    System.out.println(bytes.length);
	    final var fos = new FileOutputStream("hima.html");
	    fos.write(bytes);
	    fos.close();
	} catch (IOException e) {
	    e.printStackTrace();
	}
    }
}
