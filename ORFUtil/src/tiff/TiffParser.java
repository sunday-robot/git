package tiff;

import static tiff.TiffUtil.getU16;
import static tiff.TiffUtil.getU32;

import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.ArrayList;
import java.util.List;

/** TIFFファイルパーサー */
public final class TiffParser {
	/** TIFFタグのサイズ */
	private static final long TIFF_TAG_SIZE = 12;

	/** */
	private TiffParser() {
	}

	/**
	 * @param filePath
	 *            TIFFファイルパス
	 * @return {@link TiffFile}
	 * @throws IOException
	 *             :
	 */
	public static TiffFile parse(String filePath) throws IOException {
		File file = new File(filePath);
		return parse(file);
	}

	/**
	 * @param file
	 *            TIFFファイル
	 * @return {@link TiffFile}
	 * @throws IOException
	 *             :
	 */
	public static TiffFile parse(File file) throws IOException {
		RandomAccessFile raf = new RandomAccessFile(file, "r");
		TiffFile tiffFile = parse(raf, 0);
		raf.close();
		return tiffFile;
	}

	/**
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param tiffHeaderPointer
	 *            TIFFヘッダーの位置
	 * @return {@link TiffFile}
	 * @throws IOException
	 *             :
	 */
	public static TiffFile parse(RandomAccessFile raf, long tiffHeaderPointer) throws IOException {
		raf.seek(tiffHeaderPointer);
		int byteOrder = getU16(raf);
		int version = getU16(raf);
		long ifdPointer = getU32(raf);
		List<TiffIfd> ifds = parseIfds(raf, ifdPointer);
		TiffFile tiffFile = new TiffFile(byteOrder, version, ifds);
		return tiffFile;
	}

	/**
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param firstTiffIfdPosition
	 *            最初のTIFF IFD位置
	 * @return List<{@link TIFFIFD}>}
	 * @throws IOException
	 *             :
	 */
	public static List<TiffIfd> parseIfds(RandomAccessFile raf, long firstTiffIfdPosition) throws IOException {
		List<TiffIfd> tiffIFDs = new ArrayList<>();
		long tiffIfdPointer = firstTiffIfdPosition;
		while (tiffIfdPointer != 0) {
			TiffIfd ifd = parseIfd(raf, tiffIfdPointer);
			tiffIFDs.add(ifd);
			tiffIfdPointer = ifd.getNextIfdPosition();
		}
		return tiffIFDs;
	}

	/**
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @param ifdPosition
	 *            IFDの開始位置
	 * @return {@link TIFFIFD}
	 * @throws IOException
	 *             :
	 */
	private static TiffIfd parseIfd(RandomAccessFile raf, long ifdPosition) throws IOException {
		raf.seek(ifdPosition);
		int tagCount = getU16(raf);
		ArrayList<TiffTag> tags = new ArrayList<>(tagCount);
		long nextTagPosition = raf.getFilePointer();
		for (int i = 0; i < tagCount; i++, nextTagPosition += TIFF_TAG_SIZE) {
			raf.seek(nextTagPosition);
			TiffTag tiffTag = parseTiffTag(raf);
			tags.add(tiffTag);
		}
		long nextIfdPosition = getU32(raf);
		TiffIfd tiffIFD = new TiffIfd(ifdPosition, tags, nextIfdPosition);
		return tiffIFD;
	}

	/**
	 * @param raf
	 *            {@link RandomAccessFile}
	 * @return [@link TIFFTag}
	 * @throws IOException
	 *             :
	 */
	private static TiffTag parseTiffTag(RandomAccessFile raf) throws IOException {
		long position = raf.getFilePointer();
		int tagType = getU16(raf);
		int dataType = getU16(raf);
		int dataCount = (int) getU32(raf);
		long dataPosition;
		int dataElementSize = TIFFDataType.get(dataType).getSize();
		if (dataElementSize * dataCount <= 4)
			dataPosition = raf.getFilePointer();
		else
			dataPosition = getU32(raf);
		TiffTag tiffTag = new TiffTag(position, tagType, dataType, dataCount, dataPosition);
		return tiffTag;
	}
}
