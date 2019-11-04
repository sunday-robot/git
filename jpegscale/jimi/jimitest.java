import com.sun.jimi.core.Jimi;
import com.sun.jimi.core.JimiWriter;
import com.sun.jimi.core.options.JPGOptions;
import com.sun.jimi.core.raster.JimiRasterImage;
import com.sun.jimi.core.filters.ReplicatingScaleFilter;
import com.sun.jimi.core.filters.AreaAverageScaleFilter;
//import java.awt.Image;
import java.awt.image.ImageProducer;
import java.awt.image.FilteredImageSource;

public class jimitest {
    static final double MAX_IMAGE_WIDTH = 640;
    static final double MAX_IMAGE_HEIGHT = 480;

    static void main(String args[]) throws Exception {
	JimiRasterImage img = Jimi.getRasterImage("test.jpg");
	System.out.println("size=(" + img.getWidth() + ","
			   + img.getHeight() + ")");

	Jimi.putImage(img, "out.bmp");
	Jimi.putImage(img, "out.jpg");

	double zoom;
	{
	    double zoom_x = MAX_IMAGE_WIDTH / img.getWidth();
	    double zoom_y = MAX_IMAGE_HEIGHT / img.getHeight();
	    
	    if ((zoom_x > 1) && (zoom_y > 1)) {
		System.out.println("This image is not large.");
		System.exit(0);
	    }
	    
	    zoom = (zoom_x < zoom_y) ? zoom_x : zoom_y;
	}

	ImageProducer ip = img.getImageProducer();

	ReplicatingScaleFilter filter
	    = new AreaAverageScaleFilter((int) (img.getWidth() * zoom),
					 (int) (img.getHeight() * zoom));
//	    = new ReplicatingScaleFilter((int) (img.getWidth() * zoom),
//					 (int) (img.getHeight() * zoom));

	FilteredImageSource fis = new FilteredImageSource(ip, filter);

//	Jimi.putImage(fis, "out.jpg");
	JimiWriter jw = Jimi.createJimiWriter("mini.jpg");
	
	JPGOptions jo = new JPGOptions();
	System.out.println(jo.getQuality());
	jo.setQuality(100);
	jw.setOptions(jo);
	jw.setSource(fis);
	jw.putImage("mini.jpg");

	JimiRasterImage img2 = Jimi.getRasterImage(fis);
	Jimi.putImage(img2, "mini.bmp");

	System.exit(0);
    }
}
