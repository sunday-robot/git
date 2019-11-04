package customcontrol;

import java.util.ArrayList;
import java.util.List;

import org.eclipse.swt.SWT;
import org.eclipse.swt.events.ControlEvent;
import org.eclipse.swt.events.ControlListener;
import org.eclipse.swt.events.DragDetectEvent;
import org.eclipse.swt.events.DragDetectListener;
import org.eclipse.swt.events.MouseEvent;
import org.eclipse.swt.events.MouseListener;
import org.eclipse.swt.events.MouseMoveListener;
import org.eclipse.swt.events.MouseTrackListener;
import org.eclipse.swt.events.PaintEvent;
import org.eclipse.swt.events.PaintListener;
import org.eclipse.swt.graphics.Rectangle;
import org.eclipse.swt.widgets.Composite;

/**
 * Compositeベースの独自のスライダー
 */
public final class ZoomSlider extends Composite {
	/**
	 * 目盛りの値と、その位置
	 */
	private static class Division {
		/** 目盛りの値 */
		final double value;

		/** 目盛りの位置(相対位置) */
		final double position;

		/**
		 * @param value
		 *            目盛りの値
		 * @param position
		 *            目盛りの位置
		 */
		Division(double value, double position) {
			this.value = value;
			this.position = position;
		}
	}

	// /** 目盛の定義 */
	// private ScaleDefinition scaleDefinition = new ScaleDefinition();

	/** 目盛り定義 */
	private final List<Division> divisions = new ArrayList<>();

	/** 現在のつまみが位置する目盛りの位置(0, 1, 2, ...) */
	private int currentThumbIndex = 0;

	/**
	 * @remark 目盛の定義が初期状態では空なので、必ずaddDivision()で、目盛の定義情報を追加してください。
	 * 
	 * @param parent
	 *            親コンポジット
	 * @param style
	 *            スタイル(使用しない)
	 */
	public ZoomSlider(Composite parent, int style) {
		super(parent, style);

		// ペイントイベントリスナーを登録
		addPaintListener(new PaintListener() {
			@Override
			public void paintControl(PaintEvent e) {
				ZoomSlider.this.paint(e);
			}
		});

		// コントロールのリサイズ、移動イベントリスナーを登録
		addControlListener(new ControlListener() {

			@Override
			public void controlMoved(ControlEvent e) {
				// 移動時にやることはない
			}

			@Override
			public void controlResized(ControlEvent e) {
				redraw();
			}

		});

		addMouseTrackListener(new MouseTrackListener() {
			@Override
			public void mouseEnter(MouseEvent e) {
			}

			@Override
			public void mouseExit(MouseEvent e) {
			}

			@Override
			public void mouseHover(MouseEvent e) {
			}
		});

		addMouseMoveListener(new MouseMoveListener() {

			@Override
			public void mouseMove(MouseEvent e) {
				System.out.println("mouseMove." + e.x + "," + e.y);
			}
		});

		// ?とりあえず機能しない。多分何らかの判定処理を行うための処理を登録してやらなければならないと思われる。
		addDragDetectListener(new DragDetectListener() {

			@Override
			public void dragDetected(DragDetectEvent e) {
				System.out.println("dragDetected." + e.x + "," + e.y);
			}
		});

		addMouseListener(new MouseListener() {

			@Override
			public void mouseDoubleClick(MouseEvent e) {
			}

			@Override
			public void mouseDown(MouseEvent e) {
			}

			@Override
			public void mouseUp(MouseEvent e) {
				// 以下は、スライダーのつまみがない部分がクリックされた場合の処理で、
				// スライダーのつまみを1目盛り分クリックされた位置に近づける。
				double mp = e.x * divisions.get(divisions.size() - 1).position / (getBounds().width - 1);
				double cp = divisions.get(currentThumbIndex).position;
				if (mp > cp) {
					if (mp > divisions.get(currentThumbIndex + 1).position) {
						currentThumbIndex++;
						redraw();
					}
				} else {
					if (mp < divisions.get(currentThumbIndex - 1).position) {
						currentThumbIndex--;
						redraw();
					}
				}
			}
		});
	}

	/**
	 * 目盛りを追加する。
	 * 
	 * @param value
	 *            目盛りの示す値
	 * @param position
	 *            目盛りの位置
	 */
	public void addDivision(double value, double position) {
		divisions.add(new Division(value, position));
	}

	// public double getMaximumValue() {
	//
	// }
	//

	/**
	 * @return つまみのある位置の目盛りの値
	 */
	public double getSeletedValue() {
		return divisions.get(currentThumbIndex).value;
	}

	/**
	 * コントロールを描画する
	 * 
	 * @param e
	 *            {@link PaintEvent}
	 */
	private void paint(PaintEvent e) {
		Rectangle b = getBounds();

		// 背景
		e.gc.setBackground(getDisplay().getSystemColor(SWT.COLOR_GRAY));
		e.gc.fillRectangle(0, 0, b.width, b.height);

		// 目盛り線
		Division max = divisions.get(divisions.size() - 1);
		for (Division d : divisions) {
			int x = (int) ((b.width - 1) * d.position / max.position);
			e.gc.drawLine(x, 0, x, b.height - 1);
		}

		// つまみ
		e.gc.setBackground(getDisplay().getSystemColor(SWT.COLOR_RED));
		int p = (int) ((b.width - 1) * divisions.get(currentThumbIndex).position / max.position);
		e.gc.fillRectangle(p - 1, 0, 3, b.height - 2);
	}

	/**
	 * 指定された値に最も近い位置につまみを移動させる。
	 * 
	 * @param value
	 *            値
	 */
	public void setSelectedValue(double value) {
		double diff1 = divisions.get(0).value - value;
		if (diff1 > 0) {
			currentThumbIndex = 0;
			return;
		}
		for (int i = 1; i < divisions.size(); i++) {
			double diff2 = divisions.get(i).value - value;
			if (diff2 > 0) {
				if (diff2 > -diff1) {
					currentThumbIndex = i - 1;
				} else {
					currentThumbIndex = i;
				}
				return;
			}
			diff1 = diff2;
		}
		currentThumbIndex = divisions.size() - 1;
	}
}
