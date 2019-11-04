package minilext.data;

import java.nio.file.Path;

/** アプリケーションの設定(撮影結果データには影響を与えないもの) */
public final class ApplicationSettings {
    /**
     * 自動保存に関する設定<br>
     * 自動保存を有効にするには、フォルダも設定しなければならない。<br>
     * (enable=trueなのに、folderPath=nullはNG)
     */
    public final class AutoSave {
	/** 有効/無効 */
	public boolean enabled;

	/** フォルダ */
	public Path folderPath;

	/** ベースネーム(ファイル名の先頭部分で、ファイル名はベースネーム + 通し番号 + 拡張子となる */
	public String baseName;
    }

    /** 自動保存に関する設定 */
    public final AutoSave autoSave = new AutoSave();

    /** 撮影終了時、撮影結果を表示せずにライブを再開するかどうか */
    public boolean startLiveAfterAcquisition;
}
