import static org.junit.Assert.assertNotNull;

import org.junit.Test;

import battlecity.model.StageData;
import battlecity.model.util.StageDataLoader;

/**
 * テストクラス
 */
public final class StageLoaderTest {
	/** */
	private StageLoaderTest() {
	}

	/**
	 * 
	 */
	@Test
	public static void testLoad() {
		try {
			StageData[] stages = StageDataLoader.load(".");
			assertNotNull(stages);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
