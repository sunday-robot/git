package battlecity.gomi;

import org.eclipse.swt.SWT;
import org.eclipse.swt.events.PaintEvent;
import org.eclipse.swt.events.PaintListener;
import org.eclipse.swt.graphics.GC;
import org.eclipse.swt.graphics.Point;
import org.eclipse.swt.widgets.Canvas;
import org.eclipse.swt.widgets.Composite;

/**
 * ゲームのViewクラス(???)
 * 
 * @author akiyama
 * 
 */
public class GameView extends Canvas {
    /** フォントデータ */
    private Characters characters;

    /**
     * コンストラクタ
     * 
     * @param parent
     *            Composite
     */
    public GameView(Composite parent) {
	super(parent, SWT.BORDER);

	// setSize(256, 240);
	// setBounds(0, 0, 20, 20);
	addPaintListener(new PaintListener() {
	    @Override
	    public void paintControl(PaintEvent e) {
		paint(e.gc);
	    }
	});
    }

    /**
     * paint
     * 
     * @param gc
     *            GC
     */
    private void paint(GC gc) {
	if (characters == null)
	    characters = new Characters(gc.getDevice(), "graphics/BCTY_.png");

	gc.getDevice();
	gc.drawLine(0, 0, 100, 100);
	gc.drawLine(255, 0, 0, 239);
	characters.drawString(gc, 0, 0, "Battle");
	characters.drawString(gc, 0, 128, "City");
    }

    @Override
    public final Point computeSize(int w, int h) {
	return new Point(256, 240);
    }
}
