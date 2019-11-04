package exif;

import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.List;

import tiff.TiffIfd;
import tiff.TiffParser;

public class ExifParser {

	public static List<TiffIfd> parse2(RandomAccessFile raf, long exifIfdPointer) throws IOException {
		List<TiffIfd> tiffIfds = TiffParser.parseIfds(raf, exifIfdPointer);
		return tiffIfds;
	}

}
