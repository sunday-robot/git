import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class jpegscale {
	/** 画像の高さの最大値 */
	static final int MAX_HEIGHT = 800;
	/** ファイルサイズの最大値 */
	static final int MAX_FILE_SIZE = 200000;

	public static void main(String[] args) throws Exception {
		if (args.length == 0) {
			usage();
		}
		for (int i = 0; i < args.length; i++) {
			process_directory(new File(args[i]));
		}
		System.exit(0);
	}

	static void process_directory(File directory) throws Exception {
		System.out.println("process_directory(" + directory.getCanonicalPath()
				+ ")");
		if (directory.getName().compareToIgnoreCase("org") == 0) {
			return;
		}
		File[] files = directory.listFiles();
		for (int i = 0; i < files.length; i++) {
			File f = files[i];
			if (f.isDirectory()) {
				process_directory(f);
				continue;
			}

			String name = f.getName();
			int periodIndex = name.lastIndexOf('.');
			if (periodIndex == -1)
				continue;
			if (name.substring(periodIndex).compareToIgnoreCase(".jpg") != 0)
				continue;
			if ((periodIndex > 4)
					&& (name.substring(periodIndex - 4, periodIndex)
							.compareToIgnoreCase(".org") == 0))
				continue;

			process_file(f);
		}
	}

	static void process_file(File file) throws Exception {
		System.out.println("process_file(" + file + ")");

		BufferedImage src;

		try {
			src = JPEGFile.load(file.getCanonicalPath());
		} catch (Exception e) {
			log.write(file.toString());
			log.write(e.toString());
			return;
		}

		if ((file.length() <= MAX_FILE_SIZE) && (src.getHeight() <= MAX_HEIGHT)) {
			System.out.println(file.getCanonicalPath() + " is not so big.\n");
			return;
		}

		int dest_width = src.getWidth() * MAX_HEIGHT / src.getHeight();
		BufferedImage dest;
		if (dest_width < src.getWidth()) {
			dest = ImageScaler.scale(src, dest_width, MAX_HEIGHT);
		} else {
			dest = src;
		}
		File tmp_file = new File(file.getParent(), "tmpfile");
		JPEGFile.save(dest, tmp_file.getPath());

		if (tmp_file.length() >= file.length()) {
			System.out.println("縮小画像のほうがファイルサイズが大きくなってしまったので、元に戻します。");
			tmp_file.delete();
			return;
		}

		moveOriginalFileToOrgDirectory(file);

		tmp_file.renameTo(file);
	}

	static void rename_back_up_original_file(File file) throws Exception {
		String base_name = file.getCanonicalPath();
		base_name = base_name.substring(0, base_name.length() - 4);
		String ext = ".jpg";
		File new_file;
		do {
			ext = ".org" + ext;
			new_file = new File(base_name + ext);
		} while (new_file.exists());
		if (!file.renameTo(new_file)) {
			throw new IOException("rename failed(" + file.getPath() + "->"
					+ new_file.getPath());
		}
	}

	static void moveOriginalFileToOrgDirectory(File file) throws Exception {
		File org_dir = new File(file.getParent(), "org");
		if (!org_dir.exists()) {
			if (!org_dir.mkdir()) {
				throw new IOException("mkdir failed.(" + org_dir + ")");
			}
		}
		File new_file = new File(org_dir, file.getName());
		if (new_file.exists()) {
			throw new IOException("original file exists in org dir.("
					+ new_file + ")");
		}
		if (!file.renameTo(new_file)) {
			throw new IOException("rename failed(" + file.getPath() + "->"
					+ new_file.getPath());
		}
	}

	static void usage() throws Exception {
		System.out.println("USAGE:jpegscale <directory>");
	}
}
