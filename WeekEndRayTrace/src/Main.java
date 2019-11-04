import java.io.FileNotFoundException;
import java.io.PrintStream;

public class Main {
	static Vec3 color(Ray r) {
		Vec3 unit_direction = r.direction.unit();
		double t = 0.5 * (unit_direction.y + 1.0);
		Vec3 v1 = new Vec3(1.0, 1.0, 1.0);
		Vec3 v2 = new Vec3(0.5, 0.7, 1.0);
		return v1.mul(1.0 - t).add(v2.mul(t));
	}

	static void saveAsPNM(int width, int height, Vec3[] pixels, String filePath) throws FileNotFoundException {
		PrintStream ps = new PrintStream(filePath);
		ps.printf("P3\n");
		ps.printf("%d %d\n", width, height);
		ps.printf("255\n");
		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				Vec3 p = pixels[x + y * width];
				int r = (int) (255 * p.x + 0.5);
				int g = (int) (255 * p.y + 0.5);
				int b = (int) (255 * p.z + 0.5);
				ps.printf("%d %d %d\n", r, g, b);
			}
		}
		ps.close();
	}

	private static final int WIDTH = 200;
	private static final int HEIGHT = 100;

	public static void main(String[] args) {
		Vec3[] pixels = new Vec3[WIDTH * HEIGHT];
		Vec3 lower_left_corner = new Vec3(-2.0, -1.0, -1.0);
		Vec3 horizontal = new Vec3(4.0, 0.0, 0.0);
		Vec3 vertical = new Vec3(0.0, 2.0, 0.0);
		Vec3 origin = new Vec3(0.0, 0.0, 0.0);
		for (int y = HEIGHT - 1; y >= 0; y--) {
			for (int x = 0; x < WIDTH; x++) {
				float u = ((float) x) / WIDTH;
				float v = ((float) y) / HEIGHT;
				Ray r = new Ray(origin, lower_left_corner.add(horizontal.mul(u).add(vertical.mul(v))));
				pixels[x + (HEIGHT - 1 - y) * WIDTH] = color(r);
			}
		}

		try {
			saveAsPNM(WIDTH, HEIGHT, pixels, "abc.pnm");
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
