package testapp;

import minilext.data.DeviceConfiguration;
import minilext.data.DeviceSettings;
import minilext.device.Device;
import minilext.emulator.CBEmulator;
import minilext.model.Model;
import minilext.type.Lens;
import minilext.type.LensSpecification;
import minilext.type.Magnification;

/**
 * 落ちたり、予期しない動きをしないことなどを見るために、"ちょっと動かしてみる"ためのもの。
 * "テスト"などと書いているが、通常のテストのレベルには全く達していないし、そのレベルまで引き上げるつもりもない。
 */
public final class Test {

    /***/
    private Test() {
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
	testSetZLimit(model);
	// testApplicationStart(model);

	// double xResolution = model.getPixelWidth();
	// Log.p(null, xResolution + "");
	// model.stage.moveToX(120_000_000, 340_000_000);
	// model.acquisition.startCameraLive();
	// model.acquisition.start2ChLive();
	// model.acquisition.startLsmLive();
	// model.acquisition.stopLive();
	// long z = model.z.move(ZDirection.Down, 0);
	// Log.o(null, "Z = " + z);
	// model.end();
    }

    /**
     * アプリ起動のテスト
     * 
     * @param model
     *            :
     */
    @SuppressWarnings("unused")
    private static void testApplicationStart(Model model) {
	model.start();
    }

    /**
     * @param model
     *            :
     */
    @SuppressWarnings("unused")
    private static void testSetZLimit(Model model) {
	model.setZLimitEnabled(true);
	model.setZLimitPosition(4_000_000);
    }

}
