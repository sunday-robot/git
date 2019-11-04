import filter.HSVFilter;
import io.Loader;
import io.Saver;

import org.opencv.core.Mat;

public class HSVFilterTest {
    public static void execute() {
	Mat m0 = Loader.execute("test8bit.png");
	Mat m1 = HSVFilter.execute(m0, 1.5, 2.0, 0.5);
	Saver.execute(m1, "test8bitHSVFilter.png");
    }

}
