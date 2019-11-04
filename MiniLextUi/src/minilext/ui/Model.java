package minilext.ui;

import javafx.beans.property.BooleanProperty;
import javafx.beans.property.Property;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

/**
 * MVCのM? それともMVVMのVM? <br>
 * ↑ラジオボタンのぐずぐずさを見る限りMVVMのVMかなあ。
 */
public final class Model {
    /** カラーライブ中かどうか */
    public Property<Boolean> colorLiveActive = new SimpleBooleanProperty();

    /** 多点測定でも貼り合わせ撮影でもない単発の撮影 */
    public final BooleanProperty singleAreaProperty = new SimpleBooleanProperty();

    /** 多点測定 */
    public final BooleanProperty multiAreaProperty = new SimpleBooleanProperty();

    /** 貼り合わせ撮影 */
    public final BooleanProperty stitchProperty = new SimpleBooleanProperty();

    /***/
    private final StringProperty nameProperty = new SimpleStringProperty();

    /***/
    public Model() {
    }

    /**
     * 
     * @return :
     */
    public StringProperty getNameProperty() {
	return nameProperty;
    }

    /**
     * @param value
     *            :
     */
    public void setName(String value) {
	nameProperty.set(value);
    }
}
