package guiapp;

import org.eclipse.swt.SWT;
import org.eclipse.swt.events.ControlAdapter;
import org.eclipse.swt.events.ControlEvent;
import org.eclipse.swt.events.ModifyEvent;
import org.eclipse.swt.events.ModifyListener;
import org.eclipse.swt.events.MouseAdapter;
import org.eclipse.swt.events.MouseEvent;
import org.eclipse.swt.events.PaintEvent;
import org.eclipse.swt.events.PaintListener;
import org.eclipse.swt.events.SelectionAdapter;
import org.eclipse.swt.events.SelectionEvent;
import org.eclipse.swt.graphics.Color;
import org.eclipse.swt.graphics.GC;
import org.eclipse.swt.graphics.Image;
import org.eclipse.swt.graphics.Point;
import org.eclipse.swt.graphics.Rectangle;
import org.eclipse.swt.layout.FormAttachment;
import org.eclipse.swt.layout.FormData;
import org.eclipse.swt.layout.FormLayout;
import org.eclipse.swt.widgets.Button;
import org.eclipse.swt.widgets.Canvas;
import org.eclipse.swt.widgets.Combo;
import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.FileDialog;
import org.eclipse.swt.widgets.MessageBox;
import org.eclipse.swt.widgets.ScrollBar;
import org.eclipse.swt.widgets.Shell;

import lib.pagecompactor.LoadFromXML;
import lib.pagecompactor.PageLayout;

/**
 * 
 * @author akiyama
 * 
 */
public class GUIShell {
	/***/
	private Shell shell;
	private MessageBox messageBox;
	private Canvas canvas;
	private Combo combo;
	Image image;
	private double zoomRate = 1.5;
	// private PageRegion pageRegion = new PageRegion(100, 100, 100, 100, 100);
	private PageLayout pageLayout;

	private void showMessage(String message) {
		if (messageBox == null)
			messageBox = new MessageBox(shell);
		messageBox.setMessage(message);
		messageBox.open();
	}

	/**
	 * Launch the application.
	 * 
	 * @param args
	 */
	public static void main(String args[]) {
		try {
			GUIShell window = new GUIShell();
			window.open();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	/**
	 * Open the window.
	 */
	public void open() {
		Display display = Display.getDefault();
		createContents();
		shell.open();
		shell.layout();
		while (!shell.isDisposed()) {
			if (!display.readAndDispatch()) {
				display.sleep();
			}
		}
	}

	/**
	 * Create contents of the shell.
	 */
	protected void createContents() {
		shell = new Shell();
		shell.setSize(798, 504);
		shell.setText("SWT Application");
		shell.setLayout(new FormLayout());

		Button btnLoadSampleImage = new Button(shell, SWT.NONE);
		btnLoadSampleImage.addSelectionListener(new SelectionAdapter() {
			@Override
			public void widgetSelected(SelectionEvent e) {
				GUIShell.this.loadSampleImage();
			}
		});
		FormData fd_btnLoadSampleImage = new FormData();
		fd_btnLoadSampleImage.left = new FormAttachment(0, 10);
		fd_btnLoadSampleImage.top = new FormAttachment(0, 10);
		btnLoadSampleImage.setLayoutData(fd_btnLoadSampleImage);
		btnLoadSampleImage.setText("Load Sample Image");

		canvas = new Canvas(shell, SWT.BORDER | SWT.H_SCROLL | SWT.V_SCROLL);
		canvas.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseDown(MouseEvent e) {
				Point p = getCanvasWindowPosition();
				int x = e.x;
				int y = e.y;
			}
		});
		FormData fd_canvas = new FormData();
		fd_canvas.top = new FormAttachment(btnLoadSampleImage, 2);
		fd_canvas.bottom = new FormAttachment(100, -10);
		fd_canvas.right = new FormAttachment(100, -437);
		fd_canvas.left = new FormAttachment(btnLoadSampleImage, 0, SWT.LEFT);
		canvas.setLayoutData(fd_canvas);

		combo = new Combo(shell, SWT.NONE);
		combo.addModifyListener(new ModifyListener() {
			@Override
			public void modifyText(ModifyEvent e) {
				String item = combo.getText();
				if (item.length() <= 2)
					return;
				String s = item.substring(0, item.length() - 1);
				setZoomRate(Integer.parseInt(s) / 100.0);
			}
		});
		combo.setItems(new String[] { "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%", "110%",
				"120%", "130%", "140%", "150%", "160%", "170%", "180%", "190%", "200%" });
		FormData fd_combo = new FormData();
		fd_combo.bottom = new FormAttachment(btnLoadSampleImage, 0, SWT.BOTTOM);
		fd_combo.left = new FormAttachment(btnLoadSampleImage, 6);
		combo.setLayoutData(fd_combo);

		Button btnLoadLayoutData = new Button(shell, SWT.NONE);
		btnLoadLayoutData.addSelectionListener(new SelectionAdapter() {
			@Override
			public void widgetSelected(SelectionEvent e) {
				FileDialog fd = new FileDialog(shell);
				String filePath = fd.open();
				if (filePath == null)
					return;
				try {
					Object a = LoadFromXML.load(filePath);
				} catch (Exception e1) {
					showMessage(e1.toString());
				}
			}
		});
		FormData fd_btnLoadLayoutData = new FormData();
		fd_btnLoadLayoutData.top = new FormAttachment(btnLoadSampleImage, 0, SWT.TOP);
		fd_btnLoadLayoutData.left = new FormAttachment(combo, 152);
		btnLoadLayoutData.setLayoutData(fd_btnLoadLayoutData);
		btnLoadLayoutData.setText("Load Layout Data");

		Button btnSaveLayoutData = new Button(shell, SWT.NONE);
		FormData fd_btnSaveLayoutData = new FormData();
		fd_btnSaveLayoutData.bottom = new FormAttachment(btnLoadSampleImage, 0, SWT.BOTTOM);
		fd_btnSaveLayoutData.left = new FormAttachment(btnLoadLayoutData, 6);
		btnSaveLayoutData.setLayoutData(fd_btnSaveLayoutData);
		btnSaveLayoutData.setText("Save Layout Data");
		canvas.addPaintListener(new PaintListener() {
			@Override
			public void paintControl(PaintEvent pe) {
				paintCanvas(pe);
			}
		});
		canvas.addControlListener(new ControlAdapter() {
			@Override
			public void controlResized(ControlEvent e) {
				setScrollBarThumSize();
			}
		});
		canvas.getHorizontalBar().addSelectionListener(new SelectionAdapter() {
			@Override
			public void widgetSelected(SelectionEvent e) {
				canvas.redraw();
			}
		});
		canvas.getVerticalBar().addSelectionListener(new SelectionAdapter() {
			@Override
			public void widgetSelected(SelectionEvent e) {
				canvas.redraw();
			}
		});
		unsetSampleImage();
	}

	private void setZoomRate(double zoomRate) {
		this.zoomRate = zoomRate;
		ScrollBar hsb = canvas.getHorizontalBar();
		hsb.setSelection(0);
		ScrollBar vsb = canvas.getVerticalBar();
		vsb.setSelection(0);
		setScrollBarSize();
		setScrollBarThumSize();
		canvas.redraw();
	}

	/**
	 * �g�嗦��K�p�����摜�̃T�C�Y��Ԃ��B
	 * 
	 * @return
	 */
	Point getZoomedCanvasSize() {
		if (image == null)
			return null;
		Rectangle rect = image.getBounds();
		Point size = new Point((int) (rect.width * zoomRate), (int) (rect.height * zoomRate));
		return size;
	}

	protected void loadSampleImage() {
		FileDialog fd = new FileDialog(shell);
		String filePath = fd.open();
		if (filePath == null)
			return;
		setSampleImage(filePath);
	}

	/**
	 * �X�N���[���o�[�̃T�C�Y(�ő�l)��ݒ肷��B
	 * �ő�l�ɃZ�b�g����̂́A�摜�T�C�Y���̂܂܂ł͂Ȃ��A�\���p�̊g�嗥�����������̂���1��������
	 * �l�ł���B
	 */
	private void setScrollBarSize() {
		System.out.println("setScrollBarSize()");
		Point size = getZoomedCanvasSize();
		ScrollBar hsb = canvas.getHorizontalBar();
		hsb.setMaximum(size.x - 1);
		ScrollBar vsb = canvas.getVerticalBar();
		vsb.setMaximum(size.y - 1);
	}

	/**
	 * �X�N���[���o�[�̃T��(�c�}�~�j�̃T�C�Y(�h�b�g���ł͂Ȃ��A�ő�l)��ݒ肷��B
	 * �ő�l�ɃZ�b�g����̂́A�摜�T�C�Y���̂܂܂ł͂Ȃ��A�\���p�̊g�嗥�����������̂���1��������
	 * �l�ł���B
	 */
	private void setScrollBarThumSize() {
		System.out.println("setScrollBarThumbSize()");
		Rectangle ca = canvas.getClientArea();
		ScrollBar hsb = canvas.getHorizontalBar();
		ScrollBar vsb = canvas.getVerticalBar();
		hsb.setThumb(ca.width);
		vsb.setThumb(ca.height);
		System.out.printf("w = %d, h = %d\n", ca.width, ca.height);
		System.out.printf("w = %d, h = %d\n", hsb.getThumb(), vsb.getThumb());
	}

	private void setSampleImage(String filePath) {
		image = new Image(shell.getDisplay(), filePath);

		ScrollBar hsb = canvas.getHorizontalBar();
		hsb.setEnabled(true);
		hsb.setSelection(0);

		ScrollBar vsb = canvas.getVerticalBar();
		vsb.setEnabled(true);
		vsb.setSelection(0);

		setScrollBarSize();
		setScrollBarThumSize();

		canvas.redraw();
	}

	private void unsetSampleImage() {
		image = null;
		ScrollBar hsb = canvas.getHorizontalBar();
		hsb.setEnabled(false);

		ScrollBar vsb = canvas.getVerticalBar();
		vsb.setEnabled(false);

		canvas.redraw();
	}

	private void paintCanvas(PaintEvent pe) {
		if (image == null)
			return;

		drawImage(pe.gc, image);
		// RegionDrawer.draw(pageRegion, pe.gc);
		Color color = new Color(pe.gc.getDevice(), 255, 0, 0);
		drawRectangle(pe.gc, 100, 150, 100, 150, color);
	}

	Point getCanvasWindowPosition() {
		ScrollBar hsb = canvas.getHorizontalBar();
		ScrollBar vsb = canvas.getVerticalBar();
		return new Point(hsb.getSelection(), vsb.getSelection());
	}

	public void drawImage(GC gc, Image image) {
		Rectangle imageRect = image.getBounds();
		int sw = imageRect.width;
		int sh = imageRect.height;

		Point dp = getCanvasWindowPosition();
		Point destSize = getZoomedCanvasSize();

		gc.drawImage(image, 0, 0, sw, sh, -dp.x, -dp.y, destSize.x, destSize.y);

		PageLayoutDrawer.draw(pageLayout, gc, true);
	}

	/**
	 * 
	 * @param gc
	 *            GC
	 * @param x
	 *            �_�����WX
	 * @param y
	 *            �_�����WY
	 * @param w
	 *            �_�����W��
	 * @param h
	 *            �_�����W����
	 * @param color
	 *            �F
	 */
	public void drawRectangle(GC gc, int x, int y, int w, int h, Color color) {
		gc.setForeground(color);
		Point p = getPhysicalPosition(x, y);
		Point s = getPhysicalSize(w, h);
		Rectangle rectangle = new Rectangle(p.x, p.y, s.x, s.y);
		gc.drawRectangle(rectangle);
	}

	/**
	 * �摜���W�l���A��ʂ̕\����ł̍��W�l�ɕϊ�����B
	 * 
	 * @param x
	 *            �摜���W�nX
	 * @param y
	 *            �摜���W�nY
	 * @return ��ʂ̕\������W�n�̍��W�l
	 */
	public Point getPhysicalPosition(int x, int y) {
		Rectangle imageRect = image.getBounds();
		int sw = imageRect.width;
		int sh = imageRect.height;

		Point dp = getCanvasWindowPosition();
		Point size = getZoomedCanvasSize();

		int px = (x * size.x + size.x / 2) / sw - dp.x;
		int py = (y * size.y + size.y / 2) / sh - dp.y;
		return new Point(px, py);
	}

	/**
	 * 
	 * @param w
	 * @param h
	 * @return
	 */
	public Point getPhysicalSize(int w, int h) {
		Rectangle imageRect = image.getBounds();
		int sw = imageRect.width;
		int sh = imageRect.height;

		Point size = getZoomedCanvasSize();

		int pw = w * size.x / sw;
		int ph = h * size.y / sh;
		return new Point(pw, ph);
	}
}
