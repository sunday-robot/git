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
	/** URL����͂���e�L�X�g�{�b�N�X */
	private Text addressText;

	/** WEB�u���E�U�[(WEB�y�[�W�r���[�A) */
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
	 * URL�����/�\������e�L�X�g�{�b�N�X�𐶐�����
	 * 
	 * @param composite
	 *            �e�R���|�W�b�g
	 * @return {@link Text}
	 */
	private static Text createAddressText(Composite composite) {
		Text addressText = new Text(composite, SWT.BORDER);
		addressText.setLayoutData(new GridData(GridData.FILL_HORIZONTAL));
		return addressText;
	}

	/**
	 * URL����͂���e�L�X�g�{�b�N�X�̉E����"GO"�{�^���𐶐�����B
	 * 
	 * @param composite
	 *            �e�R���|�W�b�g
	 * @param selectionListener
	 *            �{�^���������̏���
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
	 * WEB�u���E�U�[�R���g���[��(WEB�y�[�W�r���[�A)�𐶐�����B
	 * 
	 * @param composite
	 *            �e�R���|�W�b�g
	 * @return {@link Browser}
	 */
	private static Browser createBrowser(Composite composite) {
		Browser browser = new Browser(composite, SWT.BORDER);
		browser.setLayoutData(new GridData(GridData.FILL, GridData.FILL, true,
				true, 2, 1));
		return browser;
	}
}
