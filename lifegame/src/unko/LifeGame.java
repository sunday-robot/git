package unko;

import java.util.*;
import org.eclipse.swt.SWT;
import org.eclipse.swt.events.*;
import org.eclipse.swt.graphics.*;
import org.eclipse.swt.layout.*;
import org.eclipse.swt.widgets.*;

public class LifeGame extends Canvas {
    private int rows;
    private int columns;
    public int cellSize = 4;
    public int spacing = 0;
    private boolean started;
    private BitSet bitset;

    public LifeGame(Composite parent, int style) {
	this(parent, style, -1, -1);
    }

    public LifeGame(Composite parent, int style, int w, int h) {
	super(parent, style);
	rows = h;
	columns = w;
	if (rows <= 0)
	    rows = 10;
	if (columns <= 0)
	    columns = 10;
	bitset = new BitSet(rows * columns);
	addFocusListener(new FocusAdapter() {
	    public void focusGained(FocusEvent e) {
		traverse(SWT.TRAVERSE_TAB_NEXT);
	    }
	});
	addPaintListener(new PaintListener() {
	    public void paintControl(PaintEvent e) {
		paint(e.gc);
	    }
	});
	MyMouseListener myMouseListener = new MyMouseListener();
	addMouseListener(myMouseListener);
	addMouseMoveListener(myMouseListener);
    }

    public Point computeSize(int wHint, int hHint) {
	int w = wHint, h = hHint;
	if (w == SWT.DEFAULT)
	    w = (cellSize + spacing) * columns - spacing;
	if (h == SWT.DEFAULT)
	    h = (cellSize + spacing) * rows - spacing;
	return new Point(w, h);
    }

    public void randomPut() {
	Random r = new Random();
	int size = rows * columns;
	for (int i = 0; i < size >> 3; i++) {
	    bitset.set(r.nextInt(size));
	}
	redraw();
    }

    public void next() {
	int size = rows * columns;
	int count[] = new int[size];
	for (int i = bitset.nextSetBit(0); i >= 0; i = bitset.nextSetBit(i + 1)) {
	    int x = i % columns;

	    // 上の行
	    int j;
	    j = i - columns - 1 + (x == 0 ? columns : 0);
	    if (j < 0)
		j += size;
	    count[j] += 1;

	    j = i - columns;
	    if (j < 0)
		j += size;
	    count[j] += 1;

	    j = i - columns + 1 - (x == columns - 1 ? columns : 0);
	    if (j < 0)
		j += size;
	    count[j] += 1;

	    // 同じ行
	    j = i - 1 + (x == 0 ? columns : 0);
	    count[j] += 1;

	    j = i + 1 - (x == columns - 1 ? columns : 0);
	    count[j] += 1;

	    // 下の行
	    j = i + columns - 1 + (x == 0 ? columns : 0);
	    if (j >= size)
		j -= size;
	    count[j] += 1;

	    j = i + columns;
	    if (j >= size)
		j -= size;
	    count[j] += 1;

	    j = i + columns + 1 - (x == columns - 1 ? columns : 0);
	    if (j >= size)
		j -= size;
	    count[j] += 1;
	}
	for (int i = 0; i < count.length; ++i) {
	    // 3 => 誕生, 2 => 維持, それ以外 => 死滅
	    if (count[i] == 3)
		bitset.set(i);
	    else if (count[i] != 2)
		bitset.clear(i);
	}
	redraw();
    }

    public void start(int interval) {
	started = true;
	loop(interval);
    }

    public void loop(final int interval) {
	if (isDisposed() || getDisplay().isDisposed())
	    return;
	if (!started)
	    return;
	next();
	getDisplay().timerExec(interval, new Runnable() {
	    public void run() {
		loop(interval);
	    }
	});
    }

    public boolean isStarted() {
	return started;
    }

    public void stop() {
	started = false;
    }

    public void clearAll() {
	bitset.clear();
	redraw();
    }

    private void paint(GC gc) {
	gc.fillRectangle(getBounds());
	Rectangle r = new Rectangle(0, 0, cellSize, cellSize);
	Color bg = gc.getBackground();
	gc.setBackground(gc.getForeground());
	for (int y = 0; y < rows; ++y, r.y += cellSize + spacing) {
	    r.x = 0;
	    for (int x = 0; x < columns; ++x, r.x += cellSize + spacing) {
		if (bitset.get(y * columns + x))
		    gc.fillRectangle(r);
	    }
	}
	gc.setForeground(gc.getBackground());
	gc.setBackground(bg);
    }

    private void put(int x, int y) {
	bitset.set(y * columns + x);
	redraw((cellSize + spacing) * x, (cellSize + spacing) * y, cellSize,
		cellSize, false);
    }

    public class MyMouseListener extends MouseAdapter implements
	    MouseMoveListener {
	private boolean b = false;
	private int lastX = -1;
	private int lastY = -1;

	public void mouseDown(MouseEvent e) {
	    b = true;
	    unko(e);
	}

	public void mouseUp(MouseEvent e) {
	    b = false;
	    lastX = lastY = -1;
	}

	public void mouseMove(MouseEvent e) {
	    if (!b)
		return;
	    unko(e);
	}

	private void unko(MouseEvent e) {
	    int x = e.x / (cellSize + spacing);
	    int y = e.y / (cellSize + spacing);
	    if (x < 0 || y < 0 || x >= columns || y >= rows)
		return;
	    if (lastX == x || lastY == y)
		return;
	    lastX = x;
	    lastY = y;
	    put(x, y);
	}

    }

    /**
     * @param args
     */
    public static void main(String[] args) {
	Display display = new Display();

	// create icon
	Image icon = new Image(display, 32, 32);
	GC gc = new GC(icon);
	gc.setBackground(display.getSystemColor(SWT.COLOR_GRAY));
	icon.setBackground(gc.getBackground());
	gc.fillRectangle(icon.getBounds());
	gc.setForeground(display.getSystemColor(SWT.COLOR_DARK_GRAY));
	for (int i = 3; i < 32; i += 8) {
	    gc.drawLine(i, 0, i, 32);
	    gc.drawLine(0, i, 32, i);
	}
	gc.setBackground(display.getSystemColor(SWT.COLOR_BLACK));
	int[] xx = { 12, 20, 4, 12, 20 };
	int[] yy = { 4, 12, 20, 20, 20 };
	for (int i = 0; i < xx.length; ++i) {
	    gc.fillRectangle(xx[i], yy[i], 7, 7);
	}
	gc.dispose();

	final Shell shell = new Shell(display);
	shell.setImage(icon);
	shell.setText("Life");

	// add controls
	final LifeGame lg = new LifeGame(shell, SWT.BORDER, 160, 120);
	lg.cellSize = 4;
	lg.spacing = 0;
	final Text interval = new Text(shell, 0);
	interval.setText("100");
	int buttonStyle = SWT.FLAT;
	Button start = new Button(shell, buttonStyle);
	start.setText("&start/stop");
	Button next = new Button(shell, buttonStyle);
	next.setText("&next");
	Button random = new Button(shell, buttonStyle);
	random.setText("&random");
	Button clear = new Button(shell, buttonStyle);
	clear.setText("&clear");
	Button zoomIn = new Button(shell, buttonStyle);
	zoomIn.setText("&+");
	Button zoomOut = new Button(shell, buttonStyle);
	zoomOut.setText("&-");
	Button exit = new Button(shell, buttonStyle);
	exit.setText("e&xit");
	shell.setDefaultButton(start);

	// layout
	FormLayout layout = new FormLayout();
	// layout.marginHeight = layout.marginWidth = 5;
	layout.spacing = 5;
	shell.setLayout(layout);

	FormData formData;

	Point p = lg.computeSize(SWT.DEFAULT, SWT.DEFAULT);
	formData = new FormData(p.x, p.y);
	formData.top = formData.left = new FormAttachment(0);
	formData.right = new FormAttachment(100);
	formData.bottom = new FormAttachment(start);
	lg.setLayoutData(formData);

	formData = new FormData();
	formData.width = 24;
	formData.left = new FormAttachment(0);
	formData.bottom = new FormAttachment(start, 0, SWT.CENTER);
	interval.setLayoutData(formData);

	formData = new FormData();
	formData.left = new FormAttachment(interval);
	formData.bottom = new FormAttachment(100);
	start.setLayoutData(formData);

	formData = new FormData();
	formData.left = new FormAttachment(start);
	formData.bottom = new FormAttachment(start, 0, SWT.BOTTOM);
	next.setLayoutData(formData);

	formData = new FormData();
	formData.left = new FormAttachment(next);
	formData.bottom = new FormAttachment(start, 0, SWT.BOTTOM);
	random.setLayoutData(formData);

	formData = new FormData();
	formData.left = new FormAttachment(random);
	formData.bottom = new FormAttachment(start, 0, SWT.BOTTOM);
	clear.setLayoutData(formData);

	formData = new FormData();
	formData.left = new FormAttachment(clear);
	formData.bottom = new FormAttachment(start, 0, SWT.BOTTOM);
	zoomIn.setLayoutData(formData);

	formData = new FormData();
	// formData.width = zoomIn.getSize().x;
	formData.left = new FormAttachment(zoomIn);
	formData.bottom = new FormAttachment(start, 0, SWT.BOTTOM);
	zoomOut.setLayoutData(formData);

	formData = new FormData();
	formData.right = new FormAttachment(100);
	formData.bottom = new FormAttachment(start, 0, SWT.BOTTOM);
	exit.setLayoutData(formData);

	// events
	KeyListener escPressedLitener = new KeyAdapter() {
	    public void keyPressed(KeyEvent e) {
		if (e.keyCode == SWT.ESC)
		    shell.close();
	    }
	};
	for (int i = 0; i < shell.getChildren().length; i++) {
	    shell.getChildren()[i].addKeyListener(escPressedLitener);
	}

	interval.addFocusListener(new FocusAdapter() {
	    public void focusGained(FocusEvent e) {
		((Text) e.widget).selectAll();
	    }
	});
	interval.addVerifyListener(new VerifyListener() {
	    public void verifyText(VerifyEvent e) {
		for (int i = 0; i < e.text.length(); i++) {
		    if (!Character.isDigit(e.text.charAt(i))) {
			e.doit = false;
			return;
		    }
		}
	    }
	});
	start.addSelectionListener(new SelectionAdapter() {
	    public void widgetSelected(SelectionEvent arg0) {
		if (lg.isStarted())
		    lg.stop();
		else
		    lg.start(Integer.parseInt(interval.getText()));
	    }
	});
	next.addSelectionListener(new SelectionAdapter() {
	    public void widgetSelected(SelectionEvent arg0) {
		lg.stop();
		lg.next();
	    }
	});
	random.addSelectionListener(new SelectionAdapter() {
	    public void widgetSelected(SelectionEvent arg0) {
		lg.randomPut();
	    }
	});
	clear.addSelectionListener(new SelectionAdapter() {
	    public void widgetSelected(SelectionEvent arg0) {
		lg.clearAll();
	    }
	});
	zoomIn.addSelectionListener(new SelectionAdapter() {
	    public void widgetSelected(SelectionEvent arg0) {
		lg.cellSize <<= 1;
		lg.redraw();
	    }
	});
	zoomOut.addSelectionListener(new SelectionAdapter() {
	    public void widgetSelected(SelectionEvent arg0) {
		if (lg.cellSize == 1)
		    return;
		lg.cellSize >>= 1;
		lg.redraw();
	    }
	});
	exit.addSelectionListener(new SelectionAdapter() {
	    public void widgetSelected(SelectionEvent arg0) {
		shell.close();
	    }
	});

	// open
	lg.randomPut();
	shell.setSize(shell.computeSize(SWT.DEFAULT, SWT.DEFAULT));
	shell.open();

	while (!shell.isDisposed()) {
	    if (!display.readAndDispatch())
		display.sleep();
	}
	display.dispose();
    }
}
