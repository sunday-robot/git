package swtfd;

import java.io.File;

import org.eclipse.core.databinding.DataBindingContext;
import org.eclipse.core.databinding.beans.PojoProperties;
import org.eclipse.core.databinding.observable.Realm;
import org.eclipse.core.databinding.observable.value.IObservableValue;
import org.eclipse.jface.databinding.swt.SWTObservables;
import org.eclipse.jface.databinding.swt.WidgetProperties;
import org.eclipse.swt.SWT;
import org.eclipse.swt.custom.CLabel;
import org.eclipse.swt.events.FocusAdapter;
import org.eclipse.swt.events.FocusEvent;
import org.eclipse.swt.events.ModifyEvent;
import org.eclipse.swt.events.ModifyListener;
import org.eclipse.swt.events.SelectionAdapter;
import org.eclipse.swt.events.SelectionEvent;
import org.eclipse.swt.layout.FormAttachment;
import org.eclipse.swt.layout.FormData;
import org.eclipse.swt.layout.FormLayout;
import org.eclipse.swt.layout.GridLayout;
import org.eclipse.swt.widgets.Button;
import org.eclipse.swt.widgets.Display;
import org.eclipse.swt.widgets.Group;
import org.eclipse.swt.widgets.Shell;
import org.eclipse.swt.widgets.Text;
import org.eclipse.swt.widgets.Tree;
import org.eclipse.swt.widgets.TreeItem;

public class SWTFD {
    private DataBindingContext m_bindingContext;

    protected Shell shell;
    private Tree folderTree;
    private SWTFDViewModel viewModel;
    private Button redRadioButton;
    private CLabel signalColorLabel;
    private Button greenRadioButton;
    private Button yellowRadioButton;
    private Text stringValueTextBox;
    private CLabel stringValueLabel;

    /**
     * Launch the application.
     * 
     * @param args
     */
    public static void main(String[] args) {
	Display display = Display.getDefault();
	Realm.runWithDefault(SWTObservables.getRealm(display), new Runnable() {
	    @Override
	    public void run() {
		try {
		    SWTFD window = new SWTFD();
		    window.setViewModel(new SWTFDViewModel());
		    window.open();
		} catch (Exception e) {
		    e.printStackTrace();
		}
	    }
	});
    }

    /**
     * 
     * @param viewModel
     *            ViewModel
     */
    private void setViewModel(SWTFDViewModel viewModel) {
	this.viewModel = viewModel;
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
     * Create contents of the window.
     */
    protected void createContents() {
	shell = new Shell();
	shell.setSize(450, 300);
	shell.setText("SWT Application");
	shell.setLayout(new FormLayout());

	folderTree = new Tree(shell, SWT.BORDER);
	FormData fd_folderTree = new FormData();
	fd_folderTree.bottom = new FormAttachment(0, 261);
	fd_folderTree.right = new FormAttachment(0, 108);
	fd_folderTree.top = new FormAttachment(0);
	fd_folderTree.left = new FormAttachment(0);
	folderTree.setLayoutData(fd_folderTree);

	Button refreshButton = new Button(shell, SWT.NONE);
	FormData fd_refreshButton = new FormData();
	fd_refreshButton.right = new FormAttachment(0, 195);
	fd_refreshButton.top = new FormAttachment(0, 10);
	fd_refreshButton.left = new FormAttachment(0, 114);
	refreshButton.setLayoutData(fd_refreshButton);
	refreshButton.addSelectionListener(new SelectionAdapter() {
	    @Override
	    public void widgetSelected(SelectionEvent e) {
		File[] roots = java.io.File.listRoots();
		for (File root : roots) {
		    TreeItem item = new TreeItem(folderTree, 0);
		    item.setText(root.toString());
		    // addChildren(root.listFiles(), item);
		}
	    }
	});
	refreshButton.setText("Refresh");

	Group signalColorRadioButtonGroup = new Group(shell, SWT.NONE);
	signalColorRadioButtonGroup.setText("Signal color");
	FormData fd_signalColorRadioButtonGroup = new FormData();
	fd_signalColorRadioButtonGroup.top = new FormAttachment(refreshButton,
		8);
	fd_signalColorRadioButtonGroup.left = new FormAttachment(folderTree, 6);
	fd_signalColorRadioButtonGroup.bottom = new FormAttachment(0, 150);
	fd_signalColorRadioButtonGroup.right = new FormAttachment(0, 252);
	signalColorRadioButtonGroup
		.setLayoutData(fd_signalColorRadioButtonGroup);
	signalColorRadioButtonGroup.setLayout(new GridLayout(1, false));

	redRadioButton = new Button(signalColorRadioButtonGroup, SWT.RADIO);
	redRadioButton.setText("Red");

	yellowRadioButton = new Button(signalColorRadioButtonGroup, SWT.RADIO);
	yellowRadioButton.setText("Yellow");

	greenRadioButton = new Button(signalColorRadioButtonGroup, SWT.RADIO);
	greenRadioButton.setText("Blue");

	signalColorLabel = new CLabel(shell, SWT.NONE);
	FormData fd_signalColorLabel = new FormData();
	fd_signalColorLabel.top = new FormAttachment(0, 43);
	fd_signalColorLabel.left = new FormAttachment(
		signalColorRadioButtonGroup, 6);
	signalColorLabel.setLayoutData(fd_signalColorLabel);
	signalColorLabel.setText("(Signal color)");

	stringValueTextBox = new Text(shell, SWT.BORDER);
	stringValueTextBox.addFocusListener(new FocusAdapter() {
	    @Override
	    public void focusLost(FocusEvent e) {
	    }
	});
	stringValueTextBox.addModifyListener(new ModifyListener() {
	    @Override
	    public void modifyText(ModifyEvent e) {
	    }
	});
	FormData fd_stringValueTextBox = new FormData();
	fd_stringValueTextBox.right = new FormAttachment(
		signalColorRadioButtonGroup, 0, SWT.RIGHT);
	fd_stringValueTextBox.top = new FormAttachment(
		signalColorRadioButtonGroup, 7);
	fd_stringValueTextBox.left = new FormAttachment(folderTree, 6);
	stringValueTextBox.setLayoutData(fd_stringValueTextBox);

	stringValueLabel = new CLabel(shell, SWT.NONE);
	FormData fd_stringValueLabel = new FormData();
	fd_stringValueLabel.bottom = new FormAttachment(100, -83);
	fd_stringValueLabel.width = 100;
	fd_stringValueLabel.left = new FormAttachment(signalColorLabel, 0,
		SWT.LEFT);
	stringValueLabel.setLayoutData(fd_stringValueLabel);
	stringValueLabel.setText("New Label");
	m_bindingContext = initDataBindings();
    }

    static void addChildren(File[] children, TreeItem parent) {
	if (children == null)
	    return;
	for (File child : children) {
	    System.out.println(String.format("%s", child));
	    TreeItem item = new TreeItem(parent, 0);
	    item.setText(child.toString());
	    if (child.isDirectory()) {
		addChildren(child.listFiles(), item);
	    }
	}
    }

    protected DataBindingContext initDataBindings() {
	DataBindingContext bindingContext = new DataBindingContext();
	//
	IObservableValue observeTextStringValueLabelObserveWidget = WidgetProperties
		.text().observe(stringValueLabel);
	IObservableValue stringValueViewModelObserveValue = PojoProperties
		.value("stringValue").observe(viewModel);
	bindingContext.bindValue(observeTextStringValueLabelObserveWidget,
		stringValueViewModelObserveValue, null, null);
	//
	IObservableValue observeTextStringValueTextBoxObserveWidget = WidgetProperties
		.text(SWT.FocusOut).observe(stringValueTextBox);
	bindingContext.bindValue(observeTextStringValueTextBoxObserveWidget,
		stringValueViewModelObserveValue, null, null);
	//
	IObservableValue observeTextSignalColorLabelObserveWidget = WidgetProperties
		.text().observe(signalColorLabel);
	IObservableValue signalColorViewModelObserveValue = PojoProperties
		.value("signalColor").observe(viewModel);
	bindingContext.bindValue(observeTextSignalColorLabelObserveWidget,
		signalColorViewModelObserveValue, null, null);
	//
	return bindingContext;
    }
}
