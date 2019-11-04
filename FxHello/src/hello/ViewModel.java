package hello;

import static hello.P.p;

import javafx.beans.property.StringProperty;
import javafx.beans.property.StringPropertyBase;

/**
 * 
 */
public class ViewModel {
    /***/
    static final class MyBean {
	/***/
	private String name;

	/**
	 * 
	 */
	MyBean() {
	}

	/**
	 * @return :
	 */
	public String getName() {
	    p("return [%s]", name);
	    return name;
	}

	/**
	 * @param value
	 *                  :
	 */
	public void setName(String value) {
	    p("[%s]", value);
	    name = value;
	}
    }

    /**  */
    private final MyBean myBean = new MyBean();

    /**  */
    private final StringProperty nameProperty = createStringProperty(myBean, "name");

    /***/
    private final StringProperty valueProperty = new StringPropertyBase() {

	// @Override
	// public void bind(ObservableValue<? extends String> observable) {
	// p();
	// super.bind(observable);
	// }
	//
	// @Override
	// public void unbind() {
	// p();
	// super.unbind();
	// }
	//
	// @Override
	// public boolean isBound() {
	// p();
	// return super.isBound();
	// }
	//
	@Override
	public Object getBean() {
	    p();
	    return myBean;
	}

	@Override
	public String getName() {
	    p();
	    return "name";
	}

	// @Override
	// public void addListener(ChangeListener<? super String> listener) {
	// p();
	// super.addListener(listener);
	// }
	//
	// @Override
	// public void removeListener(ChangeListener<? super String> listener) {
	// p();
	// super.removeListener(listener);
	// }
	//
	// @Override
	// public void addListener(InvalidationListener listener) {
	// p("listener:[%s]", listener);
	// super.addListener(listener);
	// }
	//
	// @Override
	// public void removeListener(InvalidationListener listener) {
	// p("listener:[%s]", listener);
	// super.removeListener(listener);
	// }
	//
	// @Override
	// public String get() {
	// p();
	// return super.get();
	// }
	//
	// @Override
	// public void set(String value) {
	// p("value=[%s]", value);
	// super.set(value);
	// }
    };

    /***/
    private final Model model;

    /**
     * @param model
     *                  :
     */
    public ViewModel(Model model) {
	this.model = model;
    }

    /**
     * @param bean
     *                         :
     * @param propertyName
     *                         :
     * @return :
     */
    private static StringProperty createStringProperty(MyBean bean, String propertyName) {
	var p = new StringPropertyBase() {

	    @Override
	    public Object getBean() {
		return bean;
	    }

	    @Override
	    public String getName() {
		return propertyName;
	    }

	};
	return p;
    }

    /**
     * @return :
     */
    public StringProperty getNameProperty() {
	return nameProperty;
	// return valueProperty;
    }

    /**
     * @param value
     *                  :
     */
    public void setName(String value) {
	// myBean.setName(value);
	nameProperty.set(value);
	// valueProperty.set(value);
    }
}
