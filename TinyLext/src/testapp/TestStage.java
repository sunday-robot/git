package testapp;

import minilext.data.DeviceConfiguration;
import minilext.data.DeviceSettings;
import minilext.device.Device;
import minilext.emulator.CBEmulator;
import minilext.model.Model;
import minilext.model.Model.StateListener;
import minilext.type.Lens;
import minilext.type.LensSpecification;
import minilext.type.Magnification;

/**
 * 落ちたり、予期しない動きをしないことなどを見るために、"ちょっと動かしてみる"ためのもの。
 * "テスト"などと書いているが、通常のテストのレベルには全く達していないし、そのレベルまで引き上げるつもりもない。
 */
public final class TestStage {

    /***/
    private TestStage() {
    }

    /**
     * @return :
     */
    private static Lens[] loadLens() {
	return new Lens[] { //
		new Lens(new LensSpecification("(DUMMY 1)", "(DUMMY 1)", "(DUMMY 1)", new Magnification(5, 0), 10), 1.0,
			1.0), //
		new Lens(new LensSpecification("(DUMMY 2)", "(DUMMY 2)", "(DUMMY 2)", new Magnification(10, 0), 10),
			1.0, 1.0), //
		new Lens(new LensSpecification("(DUMMY 3)", "(DUMMY 3)", "(DUMMY 3)", new Magnification(10, 0), 10),
			1.0, 1.0), //
		new Lens(new LensSpecification("(DUMMY 4)", "(DUMMY 4)", "(DUMMY 4)", new Magnification(50, 0), 10),
			1.0, 1.0), //
		new Lens(new LensSpecification("(DUMMY 5)", "(DUMMY 5)", "(DUMMY 5)", new Magnification(100, 0), 10),
			1.0, 1.0), //
		new Lens(new LensSpecification("(DUMMY 6)", "(DUMMY 6)", "(DUMMY 6)", new Magnification(50, 0), 10),
			1.0, 1.0), //
	};
    }

    /**
     * @param args
     *            :
     */
    public static void main(String[] args) {
	DeviceConfiguration deviceConfiguration = new DeviceConfiguration(loadLens());
	DeviceSettings deviceSettings = new DeviceSettings();
	Model model = new Model(new Device(new CBEmulator()), deviceConfiguration, deviceSettings);
	testStage(model);
    }

    /**
     * ステージ移動のテスト
     * 
     * @param model
     *            :
     */
    private static void testStage(Model model) {
	final Object o = new Object();
	StateListener stateListener = new Model.StateListener() {

	    @Override
	    public void taskStarted() {
	    }

	    @Override
	    public void taskEnd() {
		synchronized (o) {
		    o.notify();
		}
	    }

	};
	model.addStateListner(stateListener);
	model.stage.pullToCenter(500, 600);
	synchronized (o) {
	    try {
		o.wait();
	    } catch (InterruptedException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	    }
	}
	model.stage.pullToCenter(200, 300);
	try {
	    o.wait();
	} catch (InterruptedException e) {
	    // TODO Auto-generated catch block
	    e.printStackTrace();
	}
	model.removeStateListener(stateListener);
    }
}
