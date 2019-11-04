package tiff;

import java.util.HashMap;
import java.util.Map;

/**
 *
 */
public enum ExifTagType {
	/** 露出時間(秒) URATIONAL[1]{1/8} */
	EXPOSURE_TIME(33434),

	/** F値 URATIONAL[1](45/10) */
	F_NUMBER(33437),

	/** 露出プログラム USHORT[1](3) */
	EXPOSURE_PROGRAM(34850),

	/** ISOスピードレート USHORT[1](1600) */
	ISO_SPEED_RATIONGS(34855),

	/** ? SHORT[1](1) */
	SENSIVITY_TYPE(34864),

	/** ? UNDEFINED[4](0x30, 0x32, 0x33, 0x30) */
	EXIF_VERSION(36864),

	/** ? ASCII("2015:08:01 20:34:53") */
	DATE_TIME_ORIGINAL(36867),

	/** ? ASCII("2015:08:01 20:34:53") */
	DATE_TIME_DIGITIZED(36868),

	/** 露出補正 SRATIONAL[1](0/10) */
	EXPOSURE_BIAS_VALUE(37380),

	/** ? URATIONAL[1](925/256) */
	MAX_APERTURE_VALUE(37381),

	/** ? ?SHORT[1](5) */
	METERING_MODE(37383),

	/** ? USHORT[1](0) */
	LIGHT_SOURCE(37384),

	/** フラッシュ USHORT[1](24) */
	FLASH(37385),

	/** レンズの焦点距離（mm） URATIONAL[1](24/1) */
	FOCAL_LENGTH(37386),

	/** メーカ固有情報 UNDEFINED[1481740]{?} */
	MAKER_NOTE(37500),

	/** ユーザコメント UNDEFINED[125]{?0x00や0x20ばかり} */
	USER_COMMENT(37510),

	/** 対応FlashPixのバージョン UNDEFINED[4](0x30, 0x31,0x30, 0x30) */
	FLASH_PIX_VERSION(40960),

	/** 色空間情報 USHORT[1]{1(=ｓRGB)} */
	COLOR_SPACE(40961),

	/** 画像入力機器の種類 UNDEFINED[1]{0x03} */
	FILE_SOURCE(41728),

	/** CFAパターン UNDEFINED[8]{0x02, 0x00, 0x02, 0x00, 0x00, 0x01, 0x01, 0x02} */
	CFA_PATTERN(41730),

	/** ? USHORT[1]{0} */
	CUSTOM_RENDERED(41985),

	/** ? USHORT[1]{0} */
	EXPOSURE_MODE(41986),

	/** ? USHORT[1]{1} */
	WHITE_BALANCE(41987),

	/** ? URATIONAL[1]{100/100} */
	DIGITAL_ZOOM_RATIO(41988),

	/** ? USHORT[1]{2} */
	SCENE_CAPTURE_TYPE(41990),

	/** ? USHORT[1]{2} */
	GAIN_CONTROL(41991),

	/** ? USHORT[1]{0} */
	CONTRAST(41992),

	/** ? USHORT[1]{0} */
	SATUATION(41993),

	/** ? USHORT[1]{0} */
	SHARPNESS(41994),

	/** ? URATIONAL[4]{14/1, 42/1, 35/10, 56/10} */
	LENS_SPECIFICATION(42034),

	/** ? ASCII "OLYMPUS M.14-42mm F3.5-5.6 EZ" */
	LENS_MODEL(42036),

	/** ダミー(もういらない?) */
	DUMMY(-1);

	/**  */
	private static Map<Integer, ExifTagType> map; // = new
													// HashMap<Integer,
	/** タグの種類を示すID */
	private int id;

	/**
	 * @param id
	 *            タグの種類を示すID
	 */
	ExifTagType(int id) {
		this.id = id;
		putMap(this);
	}

	/**
	 * 
	 * @param id
	 *            タグの種類を示すID
	 * @return :
	 */
	public static ExifTagType getExifTagType(int id) {
		return map.get(id);
	}

	/**
	 * @return :
	 */
	public int getID() {
		return id;
	}

	/**
	 * @param exifTagType
	 *            EXIFタグの種類
	 */
	private static void putMap(ExifTagType exifTagType) {
		if (map == null) {
			map = new HashMap<Integer, ExifTagType>();
		}
		map.put(exifTagType.id, exifTagType);
	}

	@Override
	public String toString() {
		return name() + "(" + id + ")";
	}
}
