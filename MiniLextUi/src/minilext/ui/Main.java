package minilext.ui;

import java.io.IOException;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/***/
public final class Main extends Application {
    @Override
    public void start(Stage primaryStage) {
	Parent root;
	try {
	    root = FXMLLoader.load(getClass().getResource("Hello.fxml"));
	    Scene scene = new Scene(root, 1024, 800);
	    scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
	    primaryStage.setScene(scene);
	    primaryStage.show();
	} catch (IOException e) {
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
