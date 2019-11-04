package tiff;

import java.util.HashMap;
import java.util.Map;

/**
 *
 */
public enum TiffTagType {
	/** 幅 */
	IMAGE_WIDTH(0x100),

	/** 高さ */
	IMAGE_HEIGHT(0x101),

	BITS_PER_SAMPLE(0x102),

	COMPRESSION(0x103),

	PHOTOMETRIC_INTERPRETATION(0x106),

	IMAGE_DESCRIPTION(0x10e),

	MAKER(0x10f),

	MODEL(0x110),

	STRIP_OFFSETS(0x111),

	ORIENTATION(0x112),

	SAMPLES_PER_PIXEL(0x115),

	ROWS_PER_STRIP(0x116),

	STRIP_BYTE_COUNTS(0x117),

	X_RESOLUTION(0x11a),

	Y_RESOLUTION(0x11b),

	PLANARCONFIG(0x11c),

	RESOLUTION_UNIT(0x128),

	SOFTWARE(0x131),

	DATE_TIME(0x132),

	ARTIST(0x13b),

	COPYRIGHT(0x8298),

	EXIFIFD(0x8769),

	GPSIFD(0x8825),

	EXIF_IMAGE_PRINT_IMAGE_MATCHING(0xc4a5),

	DUMMY(-1);

	/**  */
	private static Map<Integer, TiffTagType> MAP;

	/**  */
	private int id;

	private TiffTagType(int id) {
		this.id = id;
		putMap(this);
	}

	public static TiffTagType get(int id) {
		return MAP.get(id);
	}

	/**
	 * @return :
	 */
	public int getID() {
		return id;
	}

	private static void putMap(TiffTagType tiffTagType) {
		if (MAP == null) {
			MAP = new HashMap<Integer, TiffTagType>();
		}
		MAP.put(tiffTagType.id, tiffTagType);
	}

	@Override
	public String toString() {
		return name() + "(" + id + ")";
	}
}
