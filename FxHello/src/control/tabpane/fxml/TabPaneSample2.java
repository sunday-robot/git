package control.tabpane.fxml;

import java.util.ResourceBundle;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import minilext.log.Log;

/***/
public final class TabPaneSample2 extends Application {
    @Override
    public void start(Stage primaryStage) {
	try {
	    Scene scene;
	    {
		AnchorPane root;
		{
		    var fxmlUrl = getClass().getResource("TabPaneSample2.fxml");
		    var resourceBudle = ResourceBundle.getBundle("tabPaneSample2");
		    var loader = new FXMLLoader(fxmlUrl, resourceBudle);
		    root = (AnchorPane) loader.load();
		    {
			TabPaneSample2Controller controller = loader.<TabPaneSample2Controller>getController();
			Log.p(null, "%s", controller);
			// controller.setViewModel(model);
		    }
		}
		scene = new Scene(root, 400, 400);
		// ViewModel model = new ViewModel(new Model());
		// scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		primaryStage.setTitle("TabPane sample");
		// primaryStage.setWidth(230);
		// primaryStage.setHeight(220);

	    }
	    primaryStage.setScene(scene);
	    primaryStage.show();
	} catch (Exception e) {
	    e.printStackTrace();
	}
    }

    /**
     * @param args
     *                 :
     */
    public static void main(String[] args) {
	launch(args);
    }
}
