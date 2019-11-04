package app;

import org.eclipse.swt.SWT;
import org.eclipse.swt.widgets.Composite;
import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Scale;
import org.eclipse.swt.widgets.Shell;

import customcontrol.ZoomSlider;

/**
 */
public final class ZoomSliderTest {
	/**
	 */
	private ZoomSliderTest() {
	}

	/**
	 * @param args
	 *            :
	 */
	public static void main(String[] args) {
		Display display = Display.getDefault();
		Shell shell = createShell();
		shell.open();
		shell.layout();
		while (!shell.isDisposed()) {
			if (!display.readAndDispatch()) {
				display.sleep();
			}
		}
	}

	/**
	 * @return shell
	 */
	private static Shell createShell() {
		Shell shell = new Shell();
		shell.setSize(450, 300);
		shell.setText("SWT Application");

		ZoomSlider zoomSlider = createZoomSlider(shell);
		zoomSlider.setBounds(10, 10, 200, 50);

		Scale scale = new Scale(shell, SWT.NONE);
		scale.setBounds(0, 100, 100, 40);

		zoomSlider.setSelectedValue(3.1);

		return shell;
	}

	/**
	 * @param parent
	 *            親コンポジット
	 * @return ZoomSlider
	 */
	private static ZoomSlider createZoomSlider(Composite parent) {
		ZoomSlider zoomSlider = new ZoomSlider(parent, SWT.NONE);
		zoomSlider.addDivision(1.0, 0);
		zoomSlider.addDivision(1.1, 1);
		zoomSlider.addDivision(1.2, 2);
		zoomSlider.addDivision(1.3, 3);
		zoomSlider.addDivision(1.4, 4);
		zoomSlider.addDivision(1.5, 5);
		zoomSlider.addDivision(1.6, 6);
		zoomSlider.addDivision(1.7, 7);
		zoomSlider.addDivision(1.8, 8);
		zoomSlider.addDivision(1.9, 9);
		zoomSlider.addDivision(2.0, 10);
		zoomSlider.addDivision(3.0, 12);
		zoomSlider.addDivision(4.0, 14);
		zoomSlider.addDivision(5.0, 16);
		zoomSlider.addDivision(6.0, 18);
		zoomSlider.addDivision(7.0, 20);
		zoomSlider.addDivision(8.0, 22);
		return zoomSlider;
	}
}
