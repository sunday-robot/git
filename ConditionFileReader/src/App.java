import java.io.IOException;
import java.util.List;

import javax.xml.parsers.ParserConfigurationException;

import org.xml.sax.SAXException;

import ConditionFile.ConditionFileLoader;
import ConditionFile.ConfitionFileUtility;
import ConditionFile.TableGroupList;

public class App {

    /**
     * @param args
     * @throws ParserConfigurationException
     * @throws IOException
     * @throws SAXException
     */
    public static void main(String[] args) throws ParserConfigurationException,
	    SAXException, IOException {
	// String conditionFileName = "ConditionFiles/Simple.condition";
	// String conditionFileName = "ConditionFiles/LIVE_ANALYSIS.condition";
	String conditionFileName = "ConditionFiles/LSM_IMAGING_SETTINGS.condition";
	// String conditionFileName = "ConditionFiles/BI_CAMERA.condition";
	// String conditionFileName = "ConditionFiles/ROI.condition";

	// Document doc = XMLLoader.load(conditionFileName);
	// Viewer.view(doc);

	List<TableGroupList> conditionFile;
	try {
	    conditionFile = ConditionFileLoader.load(conditionFileName);
	} catch (Exception e) {
	    e.printStackTrace();
	    return;
	}
	System.out.println(conditionFile.toString());
	List<String> functionIDs = ConfitionFileUtility
		.getAllFunctionIDs(conditionFile);
	System.out.println(functionIDs);

	List<List<String>> stateIDGroups = ConfitionFileUtility
		.getStateIDGroups(conditionFile);
	System.out.println(stateIDGroups);

    }

}
