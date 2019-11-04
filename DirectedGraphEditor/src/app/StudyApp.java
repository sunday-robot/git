package app;

import org.eclipse.swt.SWT;
import org.eclipse.swt.events.SelectionAdapter;
import org.eclipse.swt.events.SelectionEvent;
import org.eclipse.swt.layout.GridData;
import org.eclipse.swt.layout.GridLayout;
import org.eclipse.swt.widgets.Button;
import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Shell;

import data.DirectedGraph;

/**
 */
public final class StudyApp {
	/**
	 */
	private StudyApp() {
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
	 * @return {@link Shell}
	 */
	private static Shell createShell() {
		Shell shell = new Shell();
		// shell.setSize(450, 300);
		shell.setText("SWT Application");
		shell.setLayout(new GridLayout(1, false));

		DirectedGraphCanvas canvas = new DirectedGraphCanvas(shell);
		canvas.setLayoutData(new GridData(450, 300));
		canvas.setModel(createDirectedGraph());

		Button button = new Button(shell, SWT.NONE);
		button.setText("OK");
		button.setLayoutData(new GridData(100, 40));
		button.addSelectionListener(new SelectionAdapter() {
			@Override
			public void widgetSelected(SelectionEvent e) {
				super.widgetSelected(e);
				shell.close();
			}
		});

		shell.pack();

		return shell;
	}

	/**
	 * @return 有向グラフ
	 */
	private static DirectedGraph createDirectedGraph() {
		DirectedGraph directedGraph = new DirectedGraph() {
		};
		MyNode a = new MyNode(100, 100);
		MyNode b = new MyNode(200, 100);
		MyNode c = new MyNode(50, 50);
		MyEdge e1 = new MyEdge(a, b, "a -> b");
		MyEdge e2 = new MyEdge(a, c, "a -> c");
		directedGraph.addNode(a);
		directedGraph.addNode(b);
		directedGraph.addNode(c);
		directedGraph.addEdge(e1);
		directedGraph.addEdge(e2);
		return directedGraph;
	}
}
