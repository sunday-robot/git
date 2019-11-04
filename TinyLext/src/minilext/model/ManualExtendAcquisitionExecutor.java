package minilext.model;

import java.nio.file.Path;

import minilext.data.ApplicationState;
import minilext.log.Log;

/**
 * 手動3D撮影について、入力チェックから撮影までを行うもの。
 */
public final class ManualExtendAcquisitionExecutor extends AcquisitionExecutor {
    /**
     * @param model
     *            M
     */
    public ManualExtendAcquisitionExecutor(Model model) {
	super(model);
    }

    @Override
    public void start() {
	// 入力チェック1(エラーの場合、エラーメッセージを表示して終了)
	if (!check1())
	    return;

	// 入力チェック2(自動保存先フォルダのチェック。設定が必須なのに設定されていない。設定されているが存在しない。存在するが書き込み権限がない場合、その旨報告し、設定を修正してもらう。)
	if (!check2())
	    return;

	// 入力チェック3(テンポラリファイルのドライブ、自動保存先のドライブの空き領域が十分でない場合、エラーメッセージを表示して終了)
	if (!check3())
	    return;

	model.setApplicationState(ApplicationState.ACQUISITIONING);

	model.acquisition.stopLive();

	// TODO 撮影処理
    }

    /**
     * Z範囲、ステップ数のチェックを行う。
     * 
     * @return OKかどうか
     */
    private boolean check1() {
	if (!model.isUpperPositionValid()) {
	    Log.p(this, "上限位置設定に問題があります。");
	    return false;
	}

	if (!model.isULowerPositionValid()) {
	    Log.p(this, "下限位置設定に問題があります。");
	    return false;
	}

	// (ステップモード時のみ)ピッチが適切か

	// ステップ数が適切か

	return true;
    }

    /**
     * 自動保存に関するチェックを行う。
     * 
     * @return 今はboolとしているが、エラーコードのほうがよい？
     */
    private boolean check2() {
	// 自動保存が無効の場合はチェックしない。
	if (!model.isAutoSaveEnabled())
	    return true;

	if (model.getAutoSaveFolderPath() == null) {
	    Log.p(this, "自動保存が有効に設定されていますが、自動保存フォルダが設定されていません。");
	    return false;
	}

	if (!model.getAutoSaveFolderPath().toFile().exists()) {
	    Log.p(this, model.getAutoSaveFolderPath() + " は存在しません。");
	    return false;
	}

	if (!model.getAutoSaveFolderPath().toFile().isDirectory()) {
	    Log.p(this, model.getAutoSaveFolderPath() + " はディレクトリではありません。");
	    return false;
	}

	if (!model.getAutoSaveFolderPath().toFile().canWrite()) {
	    Log.p(this, model.getAutoSaveFolderPath() + " への書き込み権限がありません。");
	    return false;
	}

	return true;
    }

    /**
     * @return ディスクの空き容量が十分かどうか
     */
    private boolean check3() {
	long temporaryFileSize = estimateTemporaryFileSize();

	if (model.isAutoSaveEnabled()) {
	    long resultFileSize = estimeteResultFileSize();
	    Path tempDrive = model.getTemporayFolder().getRoot();
	    Path autoSaveDrive = model.getAutoSaveFolderPath().getRoot();
	    if (tempDrive.equals(autoSaveDrive)) {
		if (model.getTemporayFileDriveSpace() < temporaryFileSize + resultFileSize + Model.DISK_SPACE_MARGIN) {
		    Log.p(this, "一時ファイルおよび自動保存のドライブの空き容量が不足しています。");
		    return false;
		}
	    } else {
		if (model.getTemporayFileDriveSpace() < temporaryFileSize + Model.DISK_SPACE_MARGIN) {
		    Log.p(this, "一時ファイルのドライブの空き容量が不足しています。");
		    return false;
		}
		if (model.getAutoSaveFolderDriveSpace() < resultFileSize + Model.DISK_SPACE_MARGIN) {
		    Log.p(this, "自動保存のドライブの空き容量が不足しています。");
		    return false;
		}
	    }
	} else {
	    if (model.getTemporayFileDriveSpace() < temporaryFileSize + Model.DISK_SPACE_MARGIN) {
		Log.p(this, "一時ファイルのドライブの空き容量が不足しています。");
		return false;
	    }
	}
	return true;
    }

    /**
     * @return 今回の撮影で作成される一時ファイルのサイズの合計
     */
    private long estimateTemporaryFileSize() {
	return 10000; // TODO
    }

    /**
     * @return 今回の撮影結果ファイルのサイズの合計
     */
    private long estimeteResultFileSize() {
	return 10000; // TODO
    }
}
