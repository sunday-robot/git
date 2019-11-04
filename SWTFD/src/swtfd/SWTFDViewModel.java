package swtfd;

public class SWTFDViewModel {
    private int integerValue = 0;
    private String stringValue = "";

    public int getIntegerValue() {
	return integerValue;
    }

    public void setIntegerValue(int v) {
	integerValue = v;
    }

    public String getStringValue() {
	return stringValue;
    }

    public void setStringValue(String v) {
	stringValue = v;
    }

    private SignalColor signalColor = SignalColor.Red;

    public String getSignalColorString() {
	return signalColor.toString();
    }

    public void setSignalColor(SignalColor newSignalColor) {
	signalColor = newSignalColor;
    }

    public boolean getIsSignalColorRed() {
	return signalColor == SignalColor.Red;
    }

    public void setIsSignalColorRed(boolean b) {
	signalColor = SignalColor.Red;
    }

    public boolean getIsSignalColorYellow() {
	return signalColor == SignalColor.Yellow;
    }

    public void setIsSignalColorYellow(boolean b) {
	signalColor = SignalColor.Yellow;
    }

    public boolean getIsSignalColorGreen() {
	return signalColor == SignalColor.Green;
    }

    public void setIsSignalColorGreen(boolean b) {
	signalColor = SignalColor.Green;
    }

}
