package minilext.emulator.test;

import minilext.emulator.Stage;
import minilext.log.Log;

/**
 * ステージエミュレータのテストアプリ
 */
public final class StageTest {

    /***/
    private StageTest() {
    }

    /**
     * @param args
     *            :
     */
    public static void main(String[] args) {
	try {
	    final Object end = new Object();

	    Stage stage = createStage(end);
	    Log.o(null, "ステージを移動させます。");
	    stage.moveTo(10_000_000, 10_000_000, 1066 * 10_000 / 5);
	    Log.o(null, "ステージの移動が終了するまで待ちます。");
	    synchronized (end) {
		end.wait();
	    }
	    Log.o(null, "ステージの移動が終了しました。");
	    Log.o(null, "ステージを移動させます。");
	    stage.moveTo(0, 0, 1066 * 10_000 / 5);
	    Log.o(null, "3秒待ちます。");
	    Thread.sleep(3_000);
	    Log.o(null, "ステージの移動を止めます。");
	    stage.stop();
	    Log.o(null, "ステージの移動を止めます。");
	    stage.stop();
	} catch (InterruptedException e) {
	    e.printStackTrace();
	}
    }

    /**
     * 
     * @param end
     *            :
     * @return :
     */
    private static Stage createStage(final Object end) {
	Stage stage = new Stage(new Stage.Listener() {

	    @Override
	    public void positionUpdated(int x, int y) {
		Log.p(this, "ステージの現在位置は、(%d, %d)です。", x, y);
	    }

	    @Override
	    public void ended(int errorCode) {
		Log.p(this, "ステージの移動が終了しました。終了コードは %d です。", errorCode);
		synchronized (end) {
		    end.notify();
		}
	    }
	});
	return stage;
    }
}
