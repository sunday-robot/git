package orf;

import java.io.IOException;
import java.io.RandomAccessFile;

import tiff.TiffFile;
import tiff.TiffIfd;
import tiff.TiffParser;
import tiff.TiffTag;
import tiff.TiffTagType;
import tiff.TiffUtil;

/**
 * ORFファイル
 */
public final class OrfFile {
	/** */
	private RandomAccessFile randomAccessFile;
	/** */
	private TiffIfd ifd;

	/**
	 * @param filePath
	 *            :
	 * @throws IOException
	 *             :
	 */
	public OrfFile(String filePath) throws IOException {
		randomAccessFile = new RandomAccessFile(filePath, "r");
		TiffFile tiffFile = TiffParser.parse(randomAccessFile, 0);
		ifd = tiffFile.getIfds().get(0);
	}

	/**
	 * 
	 * @throws IOException
	 *             :
	 */
	public void dispose() throws IOException {
		randomAccessFile.close();
		ifd = null;
	}

	/**
	 * @param tiffTagType
	 *            TIFFタグの種類(画像の幅なら0x0100など)
	 * @return タグのデータ
	 * @throws IOException
	 *             :
	 */
	private long getU32Value(int tiffTagType) throws IOException {
		TiffTag tag = ifd.getTagByTagType(tiffTagType);
		long position = tag.getDataPosition();
		randomAccessFile.seek(position);
		long v = TiffUtil.getU32(randomAccessFile);
		return v;
	}

	/**
	 * @return imageWidth
	 * @throws IOException
	 *             :
	 */
	public long getImageWidth() throws IOException {
		return getU32Value(TiffTagType.IMAGE_WIDTH.getID());
	}

	/**
	 * @return imageHeight
	 * @throws IOException
	 *             :
	 */
	public long getImageHeight() throws IOException {
		return getU32Value(TiffTagType.IMAGE_HEIGHT.getID());
	}

	/**
	 * @return 圧縮された状態の画像データ
	 * @throws IOException
	 *             :
	 */
	public byte[] getStrip() throws IOException {
		long stripOffset = getU32Value(TiffTagType.STRIP_OFFSETS.getID());
		long stripByteCount = getU32Value(TiffTagType.STRIP_BYTE_COUNTS.getID());
		byte[] data = new byte[(int) stripByteCount];
		randomAccessFile.seek(stripOffset);
		randomAccessFile.readFully(data);
		return data;
	}
}
