package hello;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;

/***/
public final class Hello extends Application {
    @Override
    public void start(Stage primaryStage) {
	try {
	    ViewModel model = new ViewModel(new Model());
	    AnchorPane root;
	    FXMLLoader loader = new FXMLLoader(getClass().getResource("hello.fxml"));
	    root = (AnchorPane) loader.load();
	    HelloController controller = loader.<HelloController>getController();
	    controller.setViewModel(model);
	    Scene scene = new Scene(root, 400, 400);
	    scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
	    primaryStage.setScene(scene);
	    primaryStage.show();
	} catch (Exception e) {
	    e.printStackTrace();
	}
    }

    /**
     * @param args
     *            :
     */
    public static void main(String[] args) {
	launch(args);
    }
}
