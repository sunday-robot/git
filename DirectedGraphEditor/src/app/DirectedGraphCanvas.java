package app;

import org.eclipse.swt.SWT;
import org.eclipse.swt.events.MouseEvent;
import org.eclipse.swt.events.MouseListener;
import org.eclipse.swt.events.MouseMoveListener;
import org.eclipse.swt.events.MouseTrackListener;
import org.eclipse.swt.events.MouseWheelListener;
import org.eclipse.swt.events.PaintEvent;
import org.eclipse.swt.events.PaintListener;
import org.eclipse.swt.graphics.Rectangle;
import org.eclipse.swt.widgets.Canvas;
import org.eclipse.swt.widgets.Composite;

import data.DirectedGraph;
import data.Edge;
import data.Node;

/**
 */
public final class DirectedGraphCanvas extends Canvas implements PaintListener {
	/**  */
	private DirectedGraph model;

	/**
	 * @param parent
	 *            親コンポジット
	 */
	DirectedGraphCanvas(Composite parent) {
		super(parent, SWT.NONE);

		MyMouseEventHandler meh = new MyMouseEventHandler();
		addMouseListener(meh);
		addMouseMoveListener(meh);
		addMouseTrackListener(meh);
		addMouseWheelListener(meh);
		addPaintListener(this);
	}

	class MyMouseEventHandler implements MouseListener, MouseMoveListener, MouseTrackListener, MouseWheelListener {
		@Override
		public void mouseUp(MouseEvent e) {
			System.out.println("mouseUp: " + e);
		}

		@Override
		public void mouseDown(MouseEvent e) {
			System.out.println("mouseDown: " + e);
		}

		@Override
		public void mouseDoubleClick(MouseEvent e) {
			System.out.println("mouseDoubleClick: " + e);
		}

		@Override
		public void mouseMove(MouseEvent e) {
			// ボタンを押し込んだ状態でのカーソル移動の場合は、コントロールの範囲から外れても、このイベントは発生する。
			System.out.println("mouseMove: " + e);
		}

		@Override
		public void mouseHover(MouseEvent e) {
			// カーソルが少し停止したら発生するものらしい
			// System.out.println("mouseHover: " + e);
		}

		@Override
		public void mouseExit(MouseEvent e) {
			// ドラッグ中の場合とそうでない場合で異なる。
			// ドラッグ中の場合、GUIコントロールの範囲から外れてもこのイベントは発生せず、mouseMoveイベントが発生し続ける。ドラッグ終了時にこのイベントが発生する。
			// ドラッグ中ではない場合、GUIコントロールの範囲から出た時に発生する。これ以降はmouveMoveイベントは発生しない。
			System.out.println("mouseExit: " + e);
		}

		@Override
		public void mouseEnter(MouseEvent e) {
			// GUIコントロールの範囲に入った時に発生する
			System.out.println("mouseEnter: " + e);
		}

		@Override
		public void mouseScrolled(MouseEvent e) {
			System.out.println("mouseScroll: " + e);
		}
	}

	@Override
	public void paintControl(PaintEvent e) {
		Rectangle b = getBounds();

		// 背景
		e.gc.setBackground(getDisplay().getSystemColor(SWT.COLOR_GRAY));
		e.gc.fillRectangle(0, 0, b.width, b.height);

		// ノード
		for (Node node : model.getNodes()) {
			MyNode myNode = (MyNode) node;
			e.gc.drawArc(myNode.getX() - 10, myNode.getY() - 10, 20, 20, 0, 360);
		}

		// エッジ
		for (Edge edge : model.getEdges()) {
			MyEdge myEdge = (MyEdge) edge;
			MyNode from = (MyNode) edge.getFrom();
			MyNode to = (MyNode) edge.getTo();
			int x0 = from.getX();
			int y0 = from.getY();
			int x1 = to.getX();
			int y1 = to.getY();
			e.gc.drawLine(x0, y0, x1, y1);
			e.gc.drawText(myEdge.getDescription(), (x0 + x1) / 2, (y0 + y1) / 2, true);
		}

		int x = 10;
		e.gc.drawLine(x, 0, x, b.height - 1);
		e.gc.setBackground(getDisplay().getSystemColor(SWT.COLOR_RED));
		int p = 4;
		e.gc.fillRectangle(p - 1, 0, 3, b.height - 2);
	}

	/**
	 * @param model
	 *            {@link DirectedGraph}
	 */
	public void setModel(DirectedGraph model) {
		this.model = model;
	}
}