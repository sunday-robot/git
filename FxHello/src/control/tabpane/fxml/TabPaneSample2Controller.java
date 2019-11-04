package control.tabpane.fxml;

import java.net.URL;
import java.util.ResourceBundle;

import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;

/***/
public class TabPaneSample2Controller implements Initializable {

    /** 丼物タブのメニュー */
    @FXML
    private ListView<String> donmonoListView;

    /** 麺類タブのメニュー */
    @FXML
    private ListView<String> noodleListView;

    /**
     * 
     */
    @FXML
    private Label statusBarLabel;

    @Override
    public void initialize(URL location, ResourceBundle resources) {
    }
}
