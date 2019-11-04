package minilext.data;

import java.nio.file.Path;
import java.nio.file.Paths;

/** システム設定(他の設定と異なり、ユーザーが変更できないもの) */
public final class SystemSettings {
    /** 一時ファイルフォルダの名前 */
    private static final String TEMPORARY_FOLDER_NAME = "lext";

    /**
     * @return 一時ファイルフォルダのパス名
     */
    public Path getTemporayFileFolderPath() {
	return Paths.get(System.getProperty("user.home"), TEMPORARY_FOLDER_NAME);
    }
}
