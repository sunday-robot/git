using System;
using System.Collections.Generic;
using System.Configuration;
using KomokubetsuBunsekiJoken;
using KomokumeiSettei;
using RpcKihonEnzanShiki;
using RpcKomokubetsuEnzanShiki;

namespace ODEditorDocument {
    public enum KentaiShubetsu {
        None = -1,   // 未選択
        RB,     // RB検体
        NotRB   // RB検体以外
    }

    // 本プログラムで編集するデータ(undo/redo機能のために1つのクラスにまとめた上、"Serializable()"指定をしている)
    [Serializable()]
    class EditData {
        public double wbHoseiParameter;        // WB補正用パラメータ
        public int komokuNo;             // 項目番号(1～120)、未選択時は0。
        public KentaiShubetsu kentaiShubetsu;  // 検体種別(RBかそれ以外)
        public int sampleShubetsu;       // サンプル種別
        public int[] rawOD;                    // 生OD値
        public bool[,] orderedCheckResult;     // ユーザーがOD値自動修正用に指示した演算式チェック結果
        public TelegramFile.TelegramFile denbunFile;    // 20h/21h電文ファイル
        public int TajuSokuteiNo;

        public EditData() {
            this.kentaiShubetsu = KentaiShubetsu.None;
            this.rawOD = new int[Constants.MaxSokkoPoint + 1];
            this.orderedCheckResult = new bool[Constants.MaxSokkoPoint + 1, 8];
            for (int i = 0; i < Constants.MaxSokkoPoint + 1; i++)
                for (int j = 0; j < 8; j++)
                    this.orderedCheckResult[i, j] = true;

            this.denbunFile = new TelegramFile.TelegramFile(-1);
        }

        public override string ToString() {
            string s = "";
            s += "wbHoseiParameter:\n" + this.wbHoseiParameter.ToString() + "\n";
            s += "komokuNo:\n" + this.komokuNo.ToString() + "\n";
            s += "kentaiShubetsu:\n" + this.kentaiShubetsu.ToString() + "\n";
            s += "sampleShubetsu:\n" + this.sampleShubetsu.ToString() + "\n";
            s += "rawOD:\n" + this.rawOD.ToString() + "\n";
            s += "orderedCheckResult:\n" + this.orderedCheckResult.ToString() + "\n";
            s += "denbunFile:\n" + this.denbunFile.ToString() + "\n";
            s += "TajuSokuteiNo:\n" + this.TajuSokuteiNo.ToString() + "\n";

            return s;
        }
    }

    public class ODEditorDocument {
        const int maxUndoDataCount = 100;    // Undoは100回

        #region MEMBER VARIABLES
        int pxIndex;

        // 以下は起動時にパラメータファイルなどから内容を取得するもの。(本プログラムでは取得後に変更しないので、undo/redoの対象としない)
        KomokumeiSetteiList komokumeiSetteiList;
        KomokubetsuBunsekiJokenList komokubetsuBunsekiJokenList;
        RpcKihonEnzanShikiList rpcKihonEnzanShikiList;
        RpcKomokubetsuEnzanShikiList rpcKomokubetsuEnzanShikiList;

        // 以下は画面からユーザに入力してもらうもの(undo/redoの対象)
        EditData editData;

        List<EditData> editDataHistory;
        int currentEditDataIndex;

        RpcKomokubetsuEnzanShiki.RpcKomokubetsuEnzanShiki[] activeRpcKomokubetsuEnzanShikiList;

        #endregion MEMBER VARIABLES

        #region CONSTRUCTOR

        public ODEditorDocument() {
            var pxIndexString = ConfigurationSettings.AppSettings["PxIndex"];
            var parameterFolder = ConfigurationSettings.AppSettings["ParameterFolder"];

            this.pxIndex = int.Parse(pxIndexString);

            this.komokumeiSetteiList
                = KomokumeiSetteiLoader.Load(parameterFolder + "\\AnalysisParameters\\TestName.PRM");
            this.komokubetsuBunsekiJokenList
                = KomokubetsuBunsekiJokenLoader.Load(parameterFolder + "\\AnalysisParameters\\TestMethod.PRM");
            this.rpcKihonEnzanShikiList
                = RpcKihonEnzanShikiLoader.Load(parameterFolder + "\\AnalysisParameters\\ReactionProfileCheckFormula.xml");
            this.rpcKomokubetsuEnzanShikiList
                = Loader.Load(parameterFolder + "\\AnalysisParameters\\ReactionProfileCheck.PRM");

            this.editData = new EditData();
            this.editDataHistory = new List<EditData>();
            this.currentEditDataIndex = -1;
            this.Commit();

            this.setActiveRpcEnzanShikiList();
        }

        #endregion CONSTRUCTOR

        #region PROPERTIES

        // 項目名設定パラメータに設定された項目名の配列を返す。
        public string[] KomokuNames {
            get {
                var s = new string[120];
                foreach (var e in this.komokumeiSetteiList) {
                    s[e.KomokuNo - 1] = e.BunsekiKomokumei;
                }
                return s;
            }
        }

        public int HachoIndex {
            // 現在選択されている分析項目の主波長のインデックス(340nmなら0)を返す。
            get {
                return this.komokubetsuBunsekiJokenList.Get(this.KomokuNo, this.SampleShubetsu).ShuHacho;
            }
        }

        public double WBHoseiParameter {
            get {
                return this.editData.wbHoseiParameter;
            }
            set {
                this.editData.wbHoseiParameter = value;
            }
        }

        public int KomokuNo {
            get {
                return this.editData.komokuNo;
            }
            set {
                this.editData.komokuNo = value;
                setActiveRpcEnzanShikiList();
            }
        }

        public KentaiShubetsu KentaiShubetsu {
            get {
                return this.editData.kentaiShubetsu;
            }
            set {
                this.editData.kentaiShubetsu = value;
                setActiveRpcEnzanShikiList();
            }
        }

        public int SampleShubetsu {
            get {
                return this.editData.sampleShubetsu;
            }
            set {
                this.editData.sampleShubetsu = value;
                setActiveRpcEnzanShikiList();
            }
        }

        public int[] RawOD {
            get {
                return this.editData.rawOD;
            }
            set {
                this.editData.rawOD = value;
            }
        }

        public bool[,] OrderedCheckResult {
            get {
                return this.editData.orderedCheckResult;
            }
            set {
                this.editData.orderedCheckResult = value;
            }
        }

        public string DenbunFileName {
            get {
                return this.editData.denbunFile.FileName;
            }
        }

        public DateTime DenbunFileLastWriteTime {
            get {
                return this.editData.denbunFile.LastWriteTime;
            }
        }

        public string DenbunFileContents {
            get {
                return this.editData.denbunFile.Contents;
            }
        }

        public int TajuSokuteiNo {
            get {
                return this.editData.TajuSokuteiNo;
            }
            set {
                this.editData.TajuSokuteiNo = value;
            }
        }

        // 現在選択されている分析項目のサンプル種別(ビットマップ。項目別分析条件に設定されたもの)を返す。
        public int AvailableSampleShubetsu {
            get {
                int s = 0;
                foreach (var e in this.komokubetsuBunsekiJokenList) {
                    if (e.KomokuNo == this.KomokuNo)
                        s |= e.SampleShubetsu;
                }
                return s;
            }
        }

        public int UndoableCount {
            get {
                return this.currentEditDataIndex;
            }
        }

        public int RedoableCount {
            get {
                return this.editDataHistory.Count - this.currentEditDataIndex - 1;
            }
        }

        public RpcKomokubetsuEnzanShiki.RpcKomokubetsuEnzanShiki[] ActiveRpcEnzanShikiList {
            get {
                return this.activeRpcKomokubetsuEnzanShikiList;
            }
        }

        #endregion PROPARTIES

        #region PUBLIC METHOD

        public RpcKihonEnzanShiki.RpcKihonEnzanShiki GetRpcKihonEnzanShiki(int shikiNo) {
            return this.rpcKihonEnzanShikiList.GetByNumber(shikiNo);
        }

        // 生OD値を初期化する
        public void InitializeRawOD() {
            for (int i = 0; i <= Constants.MaxSokkoPoint; i++) {
                this.RawOD[i] = i * 2000;
            }
        }

        public double CalcWBOD(int rawOD) {
            return rawOD / 10000.0 - this.WBHoseiParameter;
        }

        public double GetWBOD(int sokkoPoint) {
            return CalcWBOD(this.RawOD[sokkoPoint]);
        }

        // RPC項目別演算式の評価を行なう。
        // 左辺値の計算結果をvalue、不等式の評価結果はcheckResultにセットする。測光ポイントが範囲外の場合は、評価せず、falseを返す。
        public bool EvaluateRpcKomokubetsuEnzanShiki(int sokkoPoint, int jokenNo, out double value, out bool checkResult) {
            value = 0;
            checkResult = false;

            foreach (var e in this.ActiveRpcEnzanShikiList) {
                if (e.ConditionNo == jokenNo) {
                    var wbOD = new double[Constants.MaxSokkoPoint + 1];
                    for (int i = 0; i <= Constants.MaxSokkoPoint; i++) {
                        wbOD[i] = GetWBOD(i);
                    }
                    return this.evaluateRpcKomokubetsuEnzanShiki(sokkoPoint, wbOD, e, out value, out checkResult);
                }
            }
            return false;
        }

        // 指定された測光ポイントでの、指定された演算式の評価結果(左辺値ではなく、不等式全体の評価結果)が、
        // ユーザーに指定された通りかを返す
        public bool IsOrderSatisfied(int sokkoPoint, double[] wbOD) {
            foreach (var e in this.ActiveRpcEnzanShikiList) {
                double value;
                bool checkResult;

                if (!this.evaluateRpcKomokubetsuEnzanShiki(sokkoPoint, wbOD, e, out value, out checkResult))
                    continue;   // 評価不能(=測光ポイントが範囲外)なら問題ないので、次の演算式のチェックに移る

                // 演算式の評価結果がユーザー指定どおりか調べる
                if (checkResult != this.OrderedCheckResult[sokkoPoint, e.ConditionNo - 1]) {
                    // ユーザー指定どおりでない演算式があったら終了。
                    return false;
                }
            }

            return true;
        }

        public void LoadDenbunFile(string fileName, bool replaceRawOD) {
            var newDenbunFile = TelegramFile.Loader.Load(fileName, this.pxIndex);
            if (replaceRawOD) {
                this.editData.rawOD = newDenbunFile.GetODList(this.HachoIndex, this.pxIndex);
            }
            this.editData.TajuSokuteiNo = newDenbunFile.TajuSokuteiNo;

            this.editData.denbunFile = newDenbunFile;
        }

        public void SaveDenbunFile(string fileName) {
            TelegramFile.Saver.Save(this.editData.denbunFile, fileName, this.HachoIndex, this.pxIndex, this.editData.rawOD, this.editData.TajuSokuteiNo);
            LoadDenbunFile(fileName, false);
        }

        // Undo()/Redo()が出来るように、現状の編集データ状態をヒストリーに追加する。
        // 編集操作を行なうたびに、本メソッドを呼ぶこと。
        public void Commit() {
            if (this.currentEditDataIndex != this.editDataHistory.Count - 1) {
                this.editDataHistory.RemoveRange(this.currentEditDataIndex + 1,
                    this.editDataHistory.Count - 1 - this.currentEditDataIndex);
            }
            if (this.editDataHistory.Count >= maxUndoDataCount) {
                this.editDataHistory.RemoveAt(0);
            }
            this.editDataHistory.Add(DeepCloner.DeepClone(this.editData) as EditData);
            this.currentEditDataIndex = this.editDataHistory.Count - 1;
        }

        public bool Undo() {
            if (this.currentEditDataIndex == 0) {
                return false;
            }
            this.currentEditDataIndex--;
            this.editData = DeepCloner.DeepClone(this.editDataHistory[this.currentEditDataIndex]) as EditData;
            return true;
        }

        public bool Redo() {
            if (this.currentEditDataIndex == this.editDataHistory.Count - 1) {
                return false;
            }
            this.currentEditDataIndex++;
            this.editData = DeepCloner.DeepClone(this.editDataHistory[this.currentEditDataIndex]) as EditData;
            return true;
        }

        public override string ToString() {
            string s = "";
            s += "pxIndex:\n" + this.pxIndex.ToString() + "\n\n";
            s += "komokumeiSetteiList:\n" + this.komokumeiSetteiList.ToString() + "\n\n";
            s += "komokubetsuBunsekiJoken:\n" + this.komokubetsuBunsekiJokenList.ToString() + "\n\n";
            s += "rpcKihonEnzanShikiList:\n" + this.rpcKihonEnzanShikiList.ToString() + "\n\n";
            s += "rpcKomokubetsuEnzanShikiList:\n" + this.rpcKomokubetsuEnzanShikiList.ToString() + "\n\n";
            s += "editData:\n" + this.editData.ToString();
            return s;
        }

        #endregion PUBLIC METHOD

        #region PRIVATE METHOD

        void setActiveRpcEnzanShikiList() {
            var r = new List<RpcKomokubetsuEnzanShiki.RpcKomokubetsuEnzanShiki>();

            if ((this.KomokuNo == 0)
                || (this.KentaiShubetsu == KentaiShubetsu.None)
                || (this.SampleShubetsu == 0)) {
                this.activeRpcKomokubetsuEnzanShikiList = r.ToArray();
                return;
            }

            foreach (var e in this.rpcKomokubetsuEnzanShikiList) {
                if (e.KomokuNo != this.KomokuNo)
                    continue;
                if (e.IsRBKentai != (this.KentaiShubetsu == KentaiShubetsu.RB))
                    continue;
                if (e.SampleShubetsu != this.SampleShubetsu)
                    continue;
                r.Add(e);
            }
            this.activeRpcKomokubetsuEnzanShikiList = r.ToArray();
        }

        bool evaluateRpcKomokubetsuEnzanShiki(int sokkoPoint, double[] wbOD, RpcKomokubetsuEnzanShiki.RpcKomokubetsuEnzanShiki shiki, out double value, out bool checkResult) {
            value = 0;
            checkResult = false;

            if (sokkoPoint < shiki.CheckStartPoint)
                return false;

            var k = this.rpcKihonEnzanShikiList.GetByNumber(shiki.KihonEnzanShikiNo);

            var h = k.GetVariables();
            if (h.ContainsKey('C')) {
                if (sokkoPoint > shiki.CheckEndPoint - 2)
                    return false;
                value = k.Evaluate(wbOD[sokkoPoint], wbOD[sokkoPoint + 1], wbOD[sokkoPoint + 2]);
            } else if (h.ContainsKey('B')) {
                if (sokkoPoint > shiki.CheckEndPoint - 1)
                    return false;
                value = k.Evaluate(wbOD[sokkoPoint], wbOD[sokkoPoint + 1], 0);
            } else if (h.ContainsKey('A')) {
                if (sokkoPoint > shiki.CheckEndPoint)
                    return false;
                value = k.Evaluate(wbOD[sokkoPoint], 0, 0);
            } else {
                value = k.Evaluate(0, 0, 0);
            }

            checkResult = (shiki.KagenChi <= value) && (value <= shiki.JogenChi);

            return true;
        }

        #endregion PRIVATE METHOD
    }
}
