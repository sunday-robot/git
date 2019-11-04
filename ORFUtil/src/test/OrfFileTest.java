package test;

import java.io.IOException;

import orf.OrfFile;

public class OrfFileTest {
	public static void main(String[] args) {
		try {
			OrfFile orfFile = new OrfFile(args[0]);
			long width = orfFile.getImageWidth();
			long height = orfFile.getImageHeight();
			byte[] data = orfFile.getStrip();
			System.out.printf("%d x %d, %d bytes\n", width, height, data.length);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
