package minilext.ui;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.ButtonType;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.control.Toggle;
import javafx.scene.control.ToggleButton;
import javafx.scene.control.ToggleGroup;

/** */
public final class HelloController implements Initializable {
    /** */
    @FXML
    private TextField nameTextField;

    /** */
    @FXML
    private Label answerLabel;

    /**  */
    @FXML
    private Toggle colorLiveToggleButton;

    /**  */
    @FXML
    private Toggle lsmLiveToggleButton;

    /**  */
    @FXML
    private ToggleGroup autoExtendOrManualExtend;

    /** (こんなものに名前などいらないかも)単発の撮影、移動撮影、貼り合わせ撮影のラジオボタングループ */
    @FXML
    private ToggleGroup singleOrMultipleOrStitch;

    /** MATLモードラジオボタン1(MATLではなく単発) */
    @FXML
    private ToggleButton singleRadioButton;

    /** MATLモードラジオボタン2(多点測定) */
    @FXML
    private ToggleButton multiRadioButton;

    /** MATLモードラジオボタン3(貼り合わせ撮影) */
    @FXML
    private ToggleButton stitchRadioButton;

    /**  */
    private Model model;

    /**
     * 
     * @param model
     *            :
     */
    public void setModel(Model model) {
	this.model = model;
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
	model = new Model();

	colorLiveToggleButton.selectedProperty().bindBidirectional(model.colorLiveActive);
	singleRadioButton.selectedProperty().bindBidirectional(model.singleAreaProperty);
	multiRadioButton.selectedProperty().bindBidirectional(model.multiAreaProperty);
	stitchRadioButton.selectedProperty().bindBidirectional(model.stitchProperty);
	// autoExtendOrManualExtend.selectedToggleProperty().
    }

    /**
     * @param event
     *            :
     */
    @FXML
    private void colorLiveToggleButtonOnAction(ActionEvent event) {
	System.out.println("color live button pressed.");
    }

    /**
     * @param event
     *            :
     */
    @FXML
    private void okButtonOnAction(ActionEvent event) {
	System.out.println("click");
	String name = nameTextField.getText();
	if (name.isEmpty()) {
	    Alert alert = new Alert(AlertType.ERROR, "名前を入力してください。", ButtonType.OK);
	    alert.setHeaderText(null);
	    alert.show();
	    return;
	}
	nameTextField.clear();
	answerLabel.setText(name + " さん、こんにちは");
    }

    /**
     * @param event
     *            :
     */
    @FXML
    private void closeMenuOnAction(ActionEvent event) {
	System.out.println("menu->File->Close");
	Platform.exit();
    }

    /**
     * @param event
     *            :
     */
    @FXML
    private void clearButtonOnAction(ActionEvent event) {
	System.out.println("click");
	answerLabel.setText(null);
    }

    /**
     * @param event
     *            :
     */
    @FXML
    private void startButtonOnAction(ActionEvent event) {
	System.out.println("撮影スタート");
    }
}
