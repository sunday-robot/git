package battlecity.view;

import org.eclipse.swt.events.PaintEvent;
import org.eclipse.swt.events.PaintListener;
import org.eclipse.swt.graphics.GC;

import battlecity.view.resource.Font;

/**
 * �`������̂��߂̂��́B
 */
public class ExperimentPainter implements PaintListener {

    @Override
    public void paintControl(PaintEvent e) {
	GC gc = e.gc;
	gc.getDevice();
	gc.drawLine(0, 0, 100, 100);
	gc.drawLine(255, 0, 0, 239);
	Font.drawString(gc, 0, 0, "Battle");
	Font.drawString(gc, 0, 128, "City");
    }

}
