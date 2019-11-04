package mywebbrowser;

import org.eclipse.swt.SWT;
import org.eclipse.swt.browser.Browser;
import org.eclipse.swt.events.SelectionEvent;
import org.eclipse.swt.events.SelectionListener;
import org.eclipse.swt.layout.GridData;
import org.eclipse.swt.layout.GridLayout;
import org.eclipse.swt.widgets.Button;
import org.eclipse.swt.widgets.Composite;
import org.eclipse.swt.widgets.Text;
import org.eclipse.ui.part.ViewPart;

/**
 * 
 */
public final class BrowserViewPart extends ViewPart {
	/** URLを入力するテキストボックス */
	private Text addressText;

	/** WEBブラウザー(WEBページビューア) */
	private Browser browser;

	@Override
	public void createPartControl(Composite parent) {
		Composite composite = new Composite(parent, SWT.NULL);
		composite.setLayout(new GridLayout(2, false));

		addressText = createAddressText(composite);
		createButton(composite, new SelectionListener() {

			@Override
			public void widgetSelected(SelectionEvent arg0) {
				String s = addressText.getText();
				browser.setUrl(s);
			}

			@Override
			public void widgetDefaultSelected(SelectionEvent arg0) {
			}
		});
		browser = createBrowser(composite);
	}

	@Override
	public void setFocus() {
	}

	/**
	 * URLを入力/表示するテキストボックスを生成する
	 * 
	 * @param composite
	 *            親コンポジット
	 * @return {@link Text}
	 */
	private static Text createAddressText(Composite composite) {
		Text addressText = new Text(composite, SWT.BORDER);
		addressText.setLayoutData(new GridData(GridData.FILL_HORIZONTAL));
		return addressText;
	}

	/**
	 * URLを入力するテキストボックスの右横の"GO"ボタンを生成する。
	 * 
	 * @param composite
	 *            親コンポジット
	 * @param selectionListener
	 *            ボタン押下時の処理
	 * @return {@link Button}
	 */
	private static Button createButton(Composite composite,
			SelectionListener selectionListener) {
		Button button = new Button(composite, SWT.NULL);
		button.setText("Go");
		button.addSelectionListener(selectionListener);
		return button;
	}

	/**
	 * WEBブラウザーコントロール(WEBページビューア)を生成する。
	 * 
	 * @param composite
	 *            親コンポジット
	 * @return {@link Browser}
	 */
	private static Browser createBrowser(Composite composite) {
		Browser browser = new Browser(composite, SWT.BORDER);
		browser.setLayoutData(new GridData(GridData.FILL, GridData.FILL, true,
				true, 2, 1));
		return browser;
	}
}
