package battlecity.model.util;

import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.List;

import battlecity.model.ComputerTankSpecification;
import battlecity.model.ComputerTankTypes;
import battlecity.model.StageData;

/**
 * ステージデータローダー
 */
public final class StageDataLoader {
	/***/
	private StageDataLoader() {
	}

	/**
	 * ステージデータをロードする
	 * 
	 * @param stageFilePath
	 *            ステージデータファイルのパス名
	 * @return ステージデータの配列
	 * @throws Exception
	 *             何らかのエラー
	 */
	public static StageData[] load(String stageFilePath) throws Exception {
		BufferedReader br = new BufferedReader(new FileReader(stageFilePath));
		List<StageData> stages = new ArrayList<StageData>();
		for (;;) {
			StageData s = createStageData(br);
			if (s == null)
				break;
			stages.add(s);
		}
		br.close();
		return stages.toArray(new StageData[0]);
	}

	/**
	 * ステージデータを生成する
	 * 
	 * @param br
	 *            BufferedReader
	 * @return Stage
	 * @throws Exception
	 *             何らかのエラー
	 */
	private static StageData createStageData(BufferedReader br) throws Exception {
		String s = br.readLine();
		if (s == null)
			return null;
		StageData stage = new StageData();
		for (int i = 0; i < 26; i++) {
			for (int j = 0; j < 26; j++) {
				stage.bg[i][j] = s.charAt(j);
			}
			s = br.readLine();
		}
		for (int i = 0; i < 20; i++) {
			char c = s.charAt(i);

			ComputerTankSpecification ctt;
			switch (Character.toUpperCase(c)) {
			case 'A':
				ctt = ComputerTankTypes.A;
				break;
			case 'B':
				ctt = ComputerTankTypes.B;
				break;
			case 'C':
				ctt = ComputerTankTypes.C;
				break;
			case 'D':
				ctt = ComputerTankTypes.D;
				break;
			default:
				throw new Exception("Wrong Enemy Tank Type");
			}
			stage.enemyTankSequence[i] = ctt;

			stage.enemyTankHasItemSequence[i] = Character.isUpperCase(c);
		}
		return stage;
	}
}
