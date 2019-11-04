package lib.pagecompactor;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

/**
 */
public final class PageCompactorParamsLoader {
	/***/
	private PageCompactorParamsLoader() {
	}

	/**
	 * プロパティファイルをロードし、PageCompactorParamsを生成する。
	 * 
	 * @param filePath
	 *            プロパティファイルのパス名
	 * @return PageCompactorParams
	 * @throws Exception
	 *             プロパティファイルにエラーがある（未知のキーなど）
	 */
	public static PageCompactorParams load(String filePath) throws Exception {
		Properties props = loadPropertiesFile(filePath);
		PageCompactorParams params = new PageCompactorParams();
		params.setRightToLeft(getBooleanProperty(props, "RightToLeft"));
		params.setImageConvertOption(getImageConvertOptionFromProperties(props));
		params.setPageLayout(getPageLayoutFromProperties(props));
		if (!props.isEmpty()) {
			StringBuffer sb = new StringBuffer();
			for (Object key : props.keySet()) {
				sb.append((String) key);
				sb.append("\n");
			}
			String unexpectedKeys = "unexpected keys = " + sb.toString();
			throw new Exception(unexpectedKeys);
		}
		return params;
	}

	/**
	 * プロパティファイルをロードする。
	 * 
	 * @param filePath
	 *            プロパティファイルのパス名
	 * @return Properties
	 * @throws IOException
	 *             入出力エラー
	 */
	private static Properties loadPropertiesFile(String filePath)
			throws IOException {
		Properties props = new Properties();
		InputStream is = new FileInputStream(filePath);
		props.load(is);
		is.close();
		return props;
	}

	/**
	 * Propertiesから、ImageConvertOptionを生成する。
	 * 副作用として、propertiesから、ImageConvertOptionに関するものは削除される。
	 * 
	 * @param properties
	 *            プロパティ
	 * @return ImageConvertOption
	 */
	private static ImageConvertOption getImageConvertOptionFromProperties(
			Properties properties) {
		ImageConvertOption ico = new ImageConvertOption();
		int[] emphasizeRange = getIntegerArray(properties, "EmphasizeRange");
		if (emphasizeRange != null)
			ico.setEmphasizeRange(emphasizeRange[0], emphasizeRange[1]);
		int[] size = getIntegerArray(properties, "Size");
		if (size != null)
			ico.setSize(size[0], size[1]);
		boolean sonyReaderSize = getBooleanProperty(properties,
				"SonyReaderSize");
		if (sonyReaderSize)
			ico.setSize(584, 754);
		ico.setKeepAspectRatio(getBooleanProperty(properties,
				"KeepAspectRatio", true));
		ico.setGamma(getDoubleProperty(properties, "Gamma"));
		ico.setJpegOutput(getBooleanProperty(properties, "JpegOutput"));
		ico.setThicken(getBooleanProperty(properties, "Thicken"));
		ico.setZoomRate(getDoubleProperty(properties, "ZoomRate"));
		return ico;
	}

	/**
	 * Propertiesから、PageLayoutを生成する。 副作用として、propertiesから、PageLayoutに関するものは削除される。
	 * 
	 * @param properties
	 *            プロパティ
	 * @return PageLayout
	 * @throws WrongPageLayoutException
	 *             WrongPageLayoutException
	 */
	private static PageLayout getPageLayoutFromProperties(Properties properties)
			throws WrongPageLayoutException {
		PageLayout pl = new PageLayout();
		pl.setHeader(getPageRegionFromProperties(properties, "Header"));
		pl.setBody(getPageRegionFromProperties(properties, "Body"));
		pl.setFooter(getPageRegionFromProperties(properties, "Footer"));
		return pl;
	}

	/**
	 * Propertiesから、指定されたプレフィックスのPageRegionを生成する。
	 * 副作用として、propertiesから、PageRegionに関するものは削除される。
	 * 
	 * @param properties
	 *            プロパティ
	 * @param keyPrefix
	 *            プレフィックス
	 * @return PageRegion
	 */
	private static PageRegion getPageRegionFromProperties(
			Properties properties, String keyPrefix) {
		PageRegion pr = new PageRegion();
		pr.setLeftPageSideMargin(getIntegerProperty(properties, keyPrefix
				+ ".LeftPageSideMargin"));
		pr.setRightPageSideMargin(getIntegerProperty(properties, keyPrefix
				+ ".RightPageSideMargin"));
		pr.setY(getIntegerProperty(properties, keyPrefix + ".Y"));
		pr.setWidth(getIntegerProperty(properties, keyPrefix + ".Width"));
		pr.setHeight(getIntegerProperty(properties, keyPrefix + ".Height"));
		return pr;
	}

	/**
	 * booleanプロパティを取得する。
	 * 
	 * @param properties
	 *            プロパティ
	 * @param key
	 *            キー
	 * @param defaultValue
	 *            デフォルト値
	 * @return boolean
	 */
	private static boolean getBooleanProperty(Properties properties,
			String key, boolean defaultValue) {
		String s = getAndRemoveProperty(properties, key);
		if (s == null)
			return defaultValue;
		return Boolean.parseBoolean(s);
	}

	/**
	 * booleanプロパティを取得する。
	 * 
	 * @param properties
	 *            プロパティ
	 * @param key
	 *            キー
	 * @return boolean
	 */
	private static boolean getBooleanProperty(Properties properties, String key) {
		return getBooleanProperty(properties, key, false);
	}

	/**
	 * integerプロパティを取得する。
	 * 
	 * @param properties
	 *            プロパティ
	 * @param key
	 *            キー
	 * @return int
	 */
	private static int getIntegerProperty(Properties properties, String key) {
		String s = getAndRemoveProperty(properties, key);
		if (s == null)
			return 0;
		return Integer.parseInt(s);
	}

	/**
	 * doubleプロパティを取得する。
	 * 
	 * @param properties
	 *            プロパティ
	 * @param key
	 *            キー
	 * @return double
	 */
	private static double getDoubleProperty(Properties properties, String key) {
		String s = getAndRemoveProperty(properties, key);
		if (s == null)
			return 0;
		return Double.parseDouble(s);
	}

	/**
	 * integer配列プロパティを取得する。
	 * 
	 * @param properties
	 *            プロパティ
	 * @param key
	 *            キー
	 * @return int配列
	 */
	private static int[] getIntegerArray(Properties properties, String key) {
		String s = getAndRemoveProperty(properties, key);
		if (s == null)
			return null;
		String[] fs = s.split(" *, *");
		int[] is = new int[fs.length];
		for (int i = 0; i < fs.length; i++) {
			is[i] = Integer.parseInt(fs[i]);
		}
		return is;
	}

	/**
	 * プロパティから指定されたキーに対応する値を返すとともに、そのキーをプロパティから削除する。
	 * 
	 * @param properties
	 *            Properties
	 * @param key
	 *            キー
	 * @return キーに対応する値（なければnull)
	 */
	private static String getAndRemoveProperty(Properties properties, String key) {
		String s = properties.getProperty(key);
		if (s != null)
			properties.remove(key);
		return s;
	}
}
