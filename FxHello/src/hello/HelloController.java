package hello;

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

/** */
public class HelloController implements Initializable {
    /** */
    @FXML
    private TextField nameTextField;

    /** */
    @FXML
    private Label answerLabel;

    /** */
    private ViewModel viewModel;

    /**
     * @param viewModel
     *                      :
     */
    public void setViewModel(ViewModel viewModel) {
	this.viewModel = viewModel;
	answerLabel.textProperty().bind(viewModel.getNameProperty());
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
    }

    /**
     * @param event
     *                  :
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
	viewModel.setName(name);
	nameTextField.clear();
    }

    /**
     * @param event
     *                  :
     */
    @FXML
    private void closeMenuOnAction(ActionEvent event) {
	System.out.println("menu->File->Close");
	Platform.exit();
    }

    /**
     * @param event
     *                  :
     */
    @FXML
    private void clearButtonOnAction(ActionEvent event) {
	System.out.println("clear");
	viewModel.setName(null);
    }
}
