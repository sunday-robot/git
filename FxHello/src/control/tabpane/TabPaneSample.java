package control.tabpane;

import javafx.application.Application;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

/**
 */
public final class TabPaneSample extends Application {
    /** */
    private Label statusBarLabel = new Label();

    @Override
    public void start(Stage primaryStage) throws Exception {
	primaryStage.setTitle("TabPane sample");
	primaryStage.setWidth(230);
	primaryStage.setHeight(220);

	var menuTabPane = createMenuTabPane();

	var vBox = new VBox();
	vBox.getChildren().addAll(menuTabPane, statusBarLabel);

	primaryStage.setScene(new Scene(vBox));
	primaryStage.show();
    }

    /**
     * @return :
     */
    private TabPane createMenuTabPane() {
	var tabPane = new TabPane();
	tabPane.getTabs().add(createDonburisTab());
	tabPane.getTabs().add(createNoodlesTab());
	return tabPane;
    }

    /**
     * @return :
     */
    private Tab createDonburisTab() {
	var listView = new ListView<String>();

	listView.setItems(FXCollections.observableArrayList("かつ丼", "親子丼", "天丼", "牛丼", "玉丼"));
	listView.getSelectionModel().selectedItemProperty().addListener(new ChangeListener<String>() {

	    @Override
	    public void changed(ObservableValue<? extends String> observable, String oldValue, String newValue) {
		statusBarLabel.setText(newValue + " was selected.");
	    }

	});
	var tab = new Tab("丼もの");
	tab.setContent(listView);

	return tab;
    }

    /**
     * @return :
     */
    private Tab createNoodlesTab() {
	var listView = new ListView<String>();
	listView.setItems(FXCollections.observableArrayList("そば", "うどん", "スパゲッティ", "山菜そば", "鍋焼きうどん"));
	listView.getSelectionModel().selectedItemProperty().addListener(new ChangeListener<String>() {

	    @Override
	    public void changed(ObservableValue<? extends String> observable, String oldValue, String newValue) {
		statusBarLabel.setText(newValue + " was selected.");
	    }
	});
	var tab = new Tab("麺類");
	tab.setContent(listView);

	return tab;
    }

    /**
     * @param args
     *            :
     */
    public static void main(String[] args) {
	Application.launch(args);
    }
}
