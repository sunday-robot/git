import java.io.FileWriter;

public class log {
	public static void write(String msg) {
		try {
			FileWriter fw = new FileWriter("log.txt", true);
			fw.write(msg + "\n");
			fw.close();
		} catch (Exception e) {
			System.err.println(e + "(" + msg + ")");
		}
	}
}
