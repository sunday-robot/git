package sample.bmi;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

/**
 */
public final class Bmi extends Application {

    /** 身長テキストボックス */
    TextField heightTextField = new TextField();

    /** 体重テキストボックス */
    TextField weightTextField = new TextField();

    /** 体重テキストボックス */
    Label bmiLabel = new Label();

    @Override
    public void start(Stage primaryStage) throws Exception {
	primaryStage.setTitle("BMI");
	primaryStage.setWidth(200);
	primaryStage.setHeight(155);

	// 身長
	var heightLabel = new Label("身長:");
	heightTextField.setPrefWidth(80);
	var hBox1 = new HBox();
	hBox1.getChildren().addAll(heightLabel, heightTextField);

	// 体重
	var weightLabel = new Label("体重:");
	weightTextField.setPrefWidth(80);
	var hBox2 = new HBox();
	hBox2.getChildren().addAll(weightLabel, weightTextField);

	// BMI計算
	var calculateButton = new Button("計算");
	calculateButton.setOnAction(event -> updateValue());

	var root = new VBox();
	root.setAlignment(Pos.TOP_CENTER);
	root.setPadding(new Insets(5, 5, 5, 5));
	root.setSpacing(5.0);
	root.getChildren().addAll(hBox1, hBox2, calculateButton, bmiLabel);

	primaryStage.setScene(new Scene(root));
	primaryStage.show();
    }

    /**
     */
    private void updateValue() {
	var height = Double.parseDouble(heightTextField.getText());
	var weight = Double.parseDouble(weightTextField.getText());
	var bmi = 10000 * weight / (height * height);
	bmiLabel.setText(String.format("BMI=%5.2f", bmi));
    }

    /**
     * @param args
     *            :
     */
    public static void main(String[] args) {
	Application.launch(args);
    }
}
