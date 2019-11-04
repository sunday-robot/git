import filter.SaidoKyocho;
import io.Loader;
import io.Saver;

import org.opencv.core.Mat;

public class SaidoKyochoTest {

    public static void execute() {
	Mat m0 = Loader.execute("test8bit.png");
	Mat m1 = SaidoKyocho.execute(m0, 2.0);
	Saver.execute(m1, "test8bitSaidoKyocho.png");
    }

}
