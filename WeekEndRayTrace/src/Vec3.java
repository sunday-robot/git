
public class Vec3 {
	public final double x;
	public final double y;
	public final double z;

	public Vec3(double x, double y, double z) {
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public double length() {
		return Math.sqrt(squaredLength());
	}

	public double squaredLength() {
		return x * x + y * y + z * z;
	}

	public Vec3 add(Vec3 v) {
		return new Vec3(x + v.x, y + v.y, z + v.z);
	}

	public Vec3 mul(double s) {
		return new Vec3(x * s, y * s, z * s);
	}

	public Vec3 div(double s) {
		return new Vec3(x / s, y / s, z / s);
	}

	public Vec3 unit() {
		return div(length());
	}

}
