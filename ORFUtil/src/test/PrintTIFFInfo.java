package test;

import static tiff.TiffUtil.getDataTypeName;
import static tiff.TiffUtil.getU32;

import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import exif.ExifParser;
import tiff.TiffFile;
import tiff.TiffIfd;
import tiff.TiffParser;
import tiff.TiffTag;
import tiff.TiffTagType;

/**
 * ORFファイルフォーマット調査のためのTIFFタグ情報表示プログラム
 */
public final class PrintTIFFInfo {
	/**
	 * TIFFタグ名表
	 */
	@SuppressWarnings("serial")
	private static final HashMap<Integer, String> TAG_TYPE_NAMES = new HashMap<Integer, String>() {
		{
			put(0x100, "ImageWidth");
			put(0x101, "ImageHeight");
			put(0x102, "BitsPerSample");
			put(0x103, "Compression");
			put(0x106, "PhotometricInterpretation");
			put(0x10e, "ImageDescription");
			put(0x10f, "Maker");
			put(0x110, "Model");
			put(0x111, "StripOffsets");
			put(0x112, "Orientation");
			put(0x115, "SamplesPerPixel");
			put(0x116, "RowsPerStrip");
			put(0x117, "StripByteCounts");
			put(0x11a, "XResolusion");
			put(0x11b, "YResolusion");
			put(0x11c, "PlanarConfiguration");
			put(0x128, "ResolusionUnit");
			put(0x131, "SoftWare");
			put(0x132, "DateTime");
			put(0x13B, "Artist");
			put(0x201, "JpegIFOffset");
			put(0x202, "(unknown 0x0202)");
			put(0x8298, "Copyright");
			put(0x8769, "ExifTag");
			put(0x8825, "GPS IFD");
			put(0xc4a5, "ExifImagePrintImageMatching");
		}
	};

	/**
	 * EXIFのタグ
	 */
	@SuppressWarnings("serial")
	private static final Map<Integer, String> EXIF_TAG_TYPE_NAMES = new HashMap<Integer, String>() {
		{
			put(33434, "ExposureTime");
			put(33437, "FNumber");
			put(34850, "ExposureProgram");
			put(34855, "IsoSpeedRatings");
			put(34864, "SensivityType");
			put(36864, "ExifVersion");
			put(36867, "DateTimeOriginal");
			put(36868, "DateTimeDigitized");
			put(37380, "ExposureBiasValue");
			put(37381, "MaxApertureValue");
			put(37383, "MeteringMode");
			put(37384, "LightSource");
			put(37385, "Flash");
			put(37386, "FocalLength");
			put(37500, "MakerNote");
			put(37510, "UserComment");
			put(40960, "FlashPixVersion");
			put(40961, "ColorSpace");
			put(41728, "FileSource");
			put(41730, "CfaPattern");
			put(41985, "CustomRendered");
			put(41986, "ExposureMode");
			put(41987, "WhiteBalance");
			put(41988, "DigitalZoomRatio");
			put(41990, "SceneCaptureType");
			put(41991, "GainControl");
			put(41992, "Contrast");
			put(41993, "Saturation");
			put(41994, "Sharpness");
			put(42034, "LensSpecification");
			put(42036, "LensModel");
		}
	};

	/** */
	private PrintTIFFInfo() {
	}

	/**
	 * @param args
	 *            ORFファイルパスのリスト
	 * @throws IOException
	 *             :
	 */
	public static void main(String[] args) throws IOException {
		for (String filePath : args) {
			printTiffFile(filePath);
		}
	}

	/**
	 * @param filePath
	 *            ORFファイルのパス
	 * @throws IOException
	 *             :
	 */
	private static void printTiffFile(String filePath) throws IOException {
		File file = new File(filePath);
		RandomAccessFile raf = new RandomAccessFile(file, "r");
		TiffFile tiffFile = TiffParser.parse(raf, 0);
		printTiffFile(tiffFile, raf);
		raf.close();
	}

	/**
	 * @param tiffFile
	 *            {@link TiffFile}
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @throws IOException
	 *             :
	 */
	private static void printTiffFile(TiffFile tiffFile, RandomAccessFile raf) throws IOException {
		print(tiffFile, raf, TAG_TYPE_NAMES);

		TiffTag exifTag = tiffFile.getIfds().get(0).getTagByTagType(TiffTagType.EXIFIFD.getID());
		printExif(exifTag, raf);
	}

	/**
	 * @param tiffFile
	 *            {@link TiffFile}
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param tagTypeNames
	 *            タグ名表
	 */
	private static void print(TiffFile tiffFile, RandomAccessFile raf, Map<Integer, String> tagTypeNames) {
		System.out.printf("byteOrder = %04x\n", tiffFile.getByteOrder());
		System.out.printf("version = %04x\n", tiffFile.getVersion());
		print(tiffFile.getIfds(), raf, tagTypeNames);
	}

	/**
	 * @param tiffIFDs
	 *            TIFF IFDのリスト
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param tagTypeNames
	 *            タグ名表
	 */
	private static void print(List<TiffIfd> tiffIFDs, RandomAccessFile raf, Map<Integer, String> tagTypeNames) {
		int index = 0;
		for (TiffIfd tiffIFD : tiffIFDs) {
			System.out.println(index++);
			print(tiffIFD, raf, tagTypeNames);
		}
	}

	/**
	 * @param tiffIFD
	 *            TIFF IFD
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param tagTypeNames
	 *            タグ名表
	 */
	private static void print(TiffIfd tiffIFD, RandomAccessFile raf, Map<Integer, String> tagTypeNames) {
		System.out.println(tiffIFD);
		for (TiffTag tiffTag : tiffIFD) {
			print(tiffTag, raf, tagTypeNames);
		}
	}

	/**
	 * @param tiffTag
	 *            TIFF Tag
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param tagTypeNames
	 *            タグ種類の名前の表
	 */
	private static void print(TiffTag tiffTag, RandomAccessFile raf, Map<Integer, String> tagTypeNames) {
		System.out.printf("  %08x: %s %s[%d]@%08x\n", tiffTag.getPosition(), format(tiffTag.getTagType(), tagTypeNames),
				getDataTypeName(tiffTag.getDataType()), tiffTag.getDataCount(), tiffTag.getDataPosition());
		// System.out.println(" " + tiffTag);
	}

	/**
	 * @param exifTag
	 *            {@link TiffTag}
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @throws IOException
	 *             :
	 */
	private static void printExif(TiffTag exifTag, RandomAccessFile raf) throws IOException {
		long exifIfdPointer = getU32(raf, exifTag.getDataPosition());
		List<TiffIfd> exifIfds = ExifParser.parse2(raf, exifIfdPointer);
		print(exifIfds, raf, EXIF_TAG_TYPE_NAMES);
	}

	/**
	 * @param tagType
	 *            タグの種類
	 * @param tagTypeNames
	 *            タグ種類の名前の表
	 * @return 表示用文字列
	 */
	private static String format(int tagType, Map<Integer, String> tagTypeNames) {
		String name = tagTypeNames.get(tagType);
		if (name == null) {
			return String.format("unknown(%08x(%d))", tagType, tagType);
		}
		return name;
	}

}
