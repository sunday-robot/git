using System;
using System.Drawing;
using System.Windows.Forms;
using ODEditorDocument;

namespace ODEditorForRpc {
    public partial class ODEditorForm : Form {
        static string[] hachoString = new[]{
                " 0:340nm",
                " 1:380nm",
                " 2:410nm",
                " 3:450nm",
                " 4:480nm",
                " 5:520nm",
                " 6:540nm",
                " 7:570nm",
                " 8:600nm",
                " 9:660nm",
                "10:700nm",
                "11:750nm",
                "12:800nm"
            };

        #region MEMBER VARIABLES

        ODEditorDocument.ODEditorDocument doc;

        bool doNotEventHandling;                // undo,redo処理でテキストボックスなどの値を変更しても、それに付随する処理を行わせないようにするためのフラグ

        TelegramFileForm telegramFileForm;
        ODLineChartForm odLineChartForm;

        #endregion MEMBER VARIABLES

        public ODEditorForm() {
            try {
                InitializeComponent();

                this.telegramFileForm = new TelegramFileForm();
                this.odLineChartForm = new ODLineChartForm(this);

                this.doc = new ODEditorDocument.ODEditorDocument();

                // 画面上部の項目選択コンボボックスの選択肢の設定を行なう。
                var komokus = this.doc.KomokuNames;
                for (int i = 0; i < komokus.Length; i++) {
                    if (komokus[i] == null)
                        continue;
                    komokuComboBox.Items.Add(new MyComboBoxItem(i + 1, i + 1 + "." + komokus[i]));
                }

                initializeODDataGridView();             // 画面中央～下部のOD値データグリッドビューの設定を行なう(測光ポイント列に"P0"～"P27"をセットするだけ)

                showDocument();
            } catch (Exception exp) {
                MessageBox.Show("以下の原因で、初期化処理が失敗しました。\n" + exp.ToString());
                System.Environment.Exit(-1);
            }
        }

        #region EVENT HANDLER

        // WB補正パラメータが変更された場合の処理
        private void wbHoseiParameter_ValueChanged(object sender, EventArgs e) {
            if (this.doNotEventHandling)
                return;

            this.doc.WBHoseiParameter = (double) wbHoseiParameter.Value;
            commit();

            showWBODInODDataGridView();
            showEnzanShikiValueInODDataGridView();
        }

        // 分析項目選択コンボボックスで、分析項目が選択された場合の処理
        private void komokuComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.doNotEventHandling)
                return;

            MyComboBoxItem item = (MyComboBoxItem) komokuComboBox.SelectedItem;
            this.doc.KomokuNo = (int) item.Value;
            this.doc.KentaiShubetsu = KentaiShubetsu.None;
            this.doc.SampleShubetsu = 0;
            commit();

            // 検体種別選択コンボボックスを未選択状態にする。
            kentaiShubetsuComboBox.SelectedIndex = -1;
            
            // サンプル種別選択コンボボックスの選択肢を設定しなおす。
            resetSampleShubetsuComboBox();

            this.doNotEventHandling = false;

            showEnzanShikiList();   // 演算式リストビューの内容を更新(サンプル種別選択コンボボックスが身選択状態になるので、クリアされる)
            setOpenAndSaveDenbunFileButtonState(); // "電文ファイル読み込み"、"電文ファイル書き込み"ボタンの状態をセットする
        }

        // 検体種別選択コンボボックスで、検体種別(RB検体か、それ以外の検体か)が選択された場合の処理
        private void kentaiShubetsuComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.doNotEventHandling)
                return;

            switch (kentaiShubetsuComboBox.SelectedIndex) {
            case 0:
                this.doc.KentaiShubetsu = KentaiShubetsu.RB;
                break;
            case 1:
                this.doc.KentaiShubetsu = KentaiShubetsu.NotRB;
                break;
            default:
                this.doc.KentaiShubetsu = KentaiShubetsu.None;
                break;
            }
            commit();

            showEnzanShikiList();                   // 演算式リストビューの内容を更新
            setOpenAndSaveDenbunFileButtonState(); // "電文ファイル読み込み"、"電文ファイル書き込み"ボタンの状態をセットする
        }

        // サンプル種別選択コンボボックスで、サンプル種別が選択された場合の処理
        private void sampleShubetsuComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.doNotEventHandling)
                return;

            MyComboBoxItem item = (MyComboBoxItem) sampleShubetsuComboBox.SelectedItem;
            this.doc.SampleShubetsu = (int) item.Value;
            commit();

            hachoLabel.Text = hachoString[this.doc.HachoIndex];
            showEnzanShikiList();                   // 演算式リストビューの内容を更新
            setOpenAndSaveDenbunFileButtonState(); // "電文ファイル読み込み"、"電文ファイル書き込み"ボタンの状態をセットする
        }

        // ODデータグリッドビューのセルがクリックされた場合の処理
        private void odDataGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
            odDataGridView.BeginEdit(false);    // 1クリックで編集モードに入るようにする
        }

        // ODデータグリッドビューのセル内容の変更が確定(*)された場合の処理
        // (*) データグリッドビューの場合、セル内容の編集をしただけでは変更内容が確定されず、他のセルをクリックした場合などに確定され、本イベントが発生する。
        private void odDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (this.doNotEventHandling)
                return;

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 1) {
                // 生OD値列の場合
                this.doc.RawOD[e.RowIndex] = int.Parse(odDataGridView[1, e.RowIndex].Value.ToString());
                commit();
                showWBODInODDataGridView(e.RowIndex);

                if (e.RowIndex >= 2)
                    showEnzanShikiValueInODDataGridView(e.RowIndex - 2);
                if (e.RowIndex >= 1)
                    showEnzanShikiValueInODDataGridView(e.RowIndex - 1);
                showEnzanShikiValueInODDataGridView(e.RowIndex);
                odLineChartForm.DrawChart(this.doc.RawOD);
            } else if ((e.ColumnIndex >= 4) && (e.ColumnIndex % 2 == 0)) {
                // 各演算式の左辺の値の右隣のチェックボックス
                int enzan_shiki_no = (e.ColumnIndex - 4) / 2 + 1;
                this.doc.OrderedCheckResult[e.RowIndex, enzan_shiki_no - 1]
                    = !((bool) odDataGridView[e.ColumnIndex, e.RowIndex].Value);
                // ↑チェックボックスがチェックされている(true)の、演算式の評価結果をNG(false)にしろという意味なので、真偽を反転させる必要がある。
                commit();
            }
        }

        // "OD値初期化"ボタン押下時の処理
        private void initializeODListButton_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("生OD値を初期値に戻します。", this.Name, MessageBoxButtons.OKCancel);
            if (result != System.Windows.Forms.DialogResult.OK)
                return;
            this.doc.InitializeRawOD();
            commit();

            showRawODInODDataGridView();
            odLineChartForm.DrawChart(this.doc.RawOD);
        }

        // "OD値自動修正"ボタン押下時の処理
        private void adjustODListButton_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("生OD値を自動修正します。", this.Name, MessageBoxButtons.OKCancel);
            if (result != System.Windows.Forms.DialogResult.OK)
                return;
            if (!ODListAdjuster.Method4.Adjust(this.doc)) {
                MessageBox.Show("OD値修正が失敗しました。");
                return;
            }
            commit();

            showRawODInODDataGridView();
            odLineChartForm.DrawChart(this.doc.RawOD);
        }

        // 電文ファイルを開く(ロードする)
        // (openDenbunFileButton_Click()、openDenbunFile2Button_Click()の下請け)
        private bool openDenbunFile(bool replaceRawOD) {
            try {
                var ofd = new System.Windows.Forms.OpenFileDialog();
                ofd.Filter = "電文ファイル(*.D1h, *.20h, *.21h)|*.D1h;*.20h;*.21h|全てのファイル(*.*)|*.*";
                if (ofd.ShowDialog() != DialogResult.OK)
                    return false;

                this.doc.LoadDenbunFile(ofd.FileName, replaceRawOD);
                return true;
            } catch (Exception exp) {
                MessageBox.Show(exp.Message);
                return false;
            }
        }

        // "電文ファイルを開く"ボタン押下時の処理
        // 電文ファイルロードの後、生OD値を電文ファイルの内容で置き換える
        private void openDenbunFileButton_Click(object sender, EventArgs e) {
            if (!openDenbunFile(true))
                return;
            commit();

            // 画面にも反映する
            showDenbunFileName();
            setOpenAndSaveDenbunFileButtonState(); // "電文ファイル読み込み"、"電文ファイル書き込み"ボタンの状態をセットする
            showRawODInODDataGridView();
            showTajuSokuteiNo();
            this.telegramFileForm.SetTelegramFile(this.doc.DenbunFileContents);
            odLineChartForm.DrawChart(this.doc.RawOD);
        }

        // "電文ファイルを開く(2)"ボタン押下時の処理
        // 編集中の生OD値を変更せずに電文ファイルを開く。
        private void openDenbunFile2Button_Click(object sender, EventArgs e) {
            if (!openDenbunFile(false))
                return;
            commit();

            // 画面にも反映する
            showDenbunFileName();
            setOpenAndSaveDenbunFileButtonState(); // "電文ファイル読み込み"、"電文ファイル書き込み"ボタンの状態をセットする
            showTajuSokuteiNo();
            this.telegramFileForm.SetTelegramFile(this.doc.DenbunFileContents);
        }

        // "電文ファイルを保存"ボタン押下時の処理
        // タイムスタンプで、他のアプリケーションで変更されていないことを確認してから上書き保存を行なう。
        private void SaveDenbunFileButton_Click(object sender, EventArgs e) {
            var dt = System.IO.File.GetLastWriteTime(this.doc.DenbunFileName);
            if (!dt.Equals(this.doc.DenbunFileLastWriteTime)) {
                var ans = MessageBox.Show("他のプログラムで書き換えられています。上書きしますか?" + System.Environment.NewLine
                    + "更新日時:" + dt.ToString() + System.Environment.NewLine, saveDenbunFileButton.Text,
                    MessageBoxButtons.YesNo);
                if (ans != System.Windows.Forms.DialogResult.Yes) {
                    return;
                }
            }

            saveDenbunFile(this.doc.DenbunFileName);
        }

        // "電文ファイルを名前をつけて保存"ボタン押下時の処理
        private void saveAsDenbunFileButton_Click(object sender, EventArgs e) {
            var sfd = new System.Windows.Forms.SaveFileDialog();
            sfd.Filter = "電文ファイル(*.D1h, *.20h, *.21h)|*.D1h;*.20h;*.21h|全てのファイル(*.*)|*.*";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            saveDenbunFile(sfd.FileName);
        }

        // "電文ファイル表示"ボタン押下時の処理
        private void showTelegramFileButton_Click(object sender, EventArgs e) {
            if (!this.telegramFileForm.Visible)
                this.telegramFileForm.Show();
            else
                this.telegramFileForm.Focus();
        }

        // "グラフ表示"ボタン押下時の処理
        private void showODGraphFormButton_Click(object sender, EventArgs e) {
            if (!this.odLineChartForm.Visible)
                this.odLineChartForm.Show();
            else
                this.odLineChartForm.Focus();
        }

        private void undoButton_Click(object sender, EventArgs e) {
            undo();
        }

        private void redoButton_Click(object sender, EventArgs e) {
            redo();
        }

        private void tajuSokuteiNoComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.doNotEventHandling)
                return;
            this.doc.TajuSokuteiNo = this.tajuSokuteiNoComboBox.SelectedIndex + 1;
            commit();
        }

        #endregion イベントハンドラー

        ///////////////////////////////////////////////////////////////////////

        #region PUBLIC METHOD

        public void SetRawOD(int sokkoPoint, int rawOD) {
            this.doc.RawOD[sokkoPoint] = rawOD;
            commit();
            showRawODInODDataGridView();
        }

        #endregion PUBLIC METHOD

        #region PRIVATE METHOD

        private void commit() {
            this.doc.Commit();
            this.showUndoRedoCount();
        }

        private void undo() {
            if (!this.doc.Undo())
                return;
            // ドキュメントの内容を画面の各コントロールに反映する
            this.showDocument();
        }

        private void redo() {
            if (!this.doc.Redo())
                return;
            // ドキュメントの内容を画面の各コントロールに反映する
            this.showDocument();
        }

        // タイトルバーに、電文ファイル名を表示する。
        private void showDenbunFileName() {
            var s = this.doc.DenbunFileName;
            if (s == "") {
                this.Text = Application.ProductName;
            } else {
                this.Text = s + "(" + this.doc.DenbunFileLastWriteTime.ToString() + ") - " + Application.ProductName;
            }
        }
        
        // 現在選択されている分析項目に応じて、サンプル種別コンボボックスの選択肢を変更する。
        private void resetSampleShubetsuComboBox() {
            int s = this.doc.AvailableSampleShubetsu;

            sampleShubetsuComboBox.Items.Clear();
            if ((s & 1) != 0)
                sampleShubetsuComboBox.Items.Add(new MyComboBoxItem(1, "血清"));
            if ((s & 2) != 0)
                sampleShubetsuComboBox.Items.Add(new MyComboBoxItem(2, "尿"));
            if ((s & 4) != 0)
                sampleShubetsuComboBox.Items.Add(new MyComboBoxItem(4, "その他"));
            if ((s & 8) != 0)
                sampleShubetsuComboBox.Items.Add(new MyComboBoxItem(8, "その他1"));
            if ((s & 16) != 0)
                sampleShubetsuComboBox.Items.Add(new MyComboBoxItem(16, "全血"));
        }

        // 現在のドキュメントの内容を表示する。(undo、redoの後に呼ぶメソッド)
        private void showDocument() {
            this.doNotEventHandling = true;

            showDenbunFileName();

            resetSampleShubetsuComboBox();

            this.wbHoseiParameter.Value = (decimal) this.doc.WBHoseiParameter;
            this.komokuComboBox.SelectedIndex = this.doc.KomokuNo - 1;
            this.kentaiShubetsuComboBox.SelectedIndex = (int) this.doc.KentaiShubetsu;
            if (this.doc.SampleShubetsu == 0) {
                this.sampleShubetsuComboBox.SelectedIndex = -1;
            } else {
                foreach (var e in this.sampleShubetsuComboBox.Items) {
                    if ((int) ((MyComboBoxItem) e).Value == this.doc.SampleShubetsu)
                        this.sampleShubetsuComboBox.SelectedItem = e;
                }
            }
            showEnzanShikiList();
            for (int i = 0; i < 28; i++) {
                for (int j = 0; j < 8; j++) {
                    this.odDataGridView[4 + j * 2, i].Value = !this.doc.OrderedCheckResult[i, j];
                }
            }
            this.showRawODInODDataGridView();
            this.setOpenAndSaveDenbunFileButtonState(); // "電文ファイル読み込み"、"電文ファイル書き込み"ボタンの状態をセットする
            this.showUndoRedoCount();
            this.showTajuSokuteiNo();
            this.doNotEventHandling = false;

            this.odLineChartForm.DrawChart(this.doc.RawOD);

            this.telegramFileForm.SetTelegramFile(this.doc.DenbunFileContents);
        }

        // 演算式リストビューの内容を表示する。(分析項目、検体種別、サンプル種別に対応する演算式のリストを表示する。)
        private void showEnzanShikiList() {
            enzanShikiListView.Items.Clear();
            foreach (var e in this.doc.ActiveRpcEnzanShikiList) {
                var s = new string[4];
                s[0] = e.ConditionNo.ToString();
                s[1] = string.Format("{0,2} ～ {1,2}", e.CheckStartPoint, e.CheckEndPoint);
                s[2] = RpcKihonEnzanShiki.Formatter.Format(this.doc.GetRpcKihonEnzanShiki(e.KihonEnzanShikiNo));
                s[3] = string.Format("{0,7:F4} ～ {1,7:F4}", e.KagenChi, e.JogenChi);
                enzanShikiListView.Items.Add(new ListViewItem(s));
            }

            // ODデータグリッドビュー内の各演算式の左辺値を更新する。
            showEnzanShikiValueInODDataGridView();
        }

        // アプリケーション起動時に、ODデータグリッドビューを初期化する。(第1列の測光ポイントをセットするだけ)
        private void initializeODDataGridView() {
            var rows = this.odDataGridView.Rows;
            for (int i = 0; i <= Constants.MaxSokkoPoint; i++) {
                var row = new string[1];
                row[0] = string.Format("P{0}", i);          // 測光ポイント
                rows.Add(row);
            }
        }

        // ODデータグリッドビューの第2列に生OD値列の内容を表示する。
        private void showRawODInODDataGridView() {
            this.doNotEventHandling = true;
            var rows = this.odDataGridView.Rows;
            for (int i = 0; i <= Constants.MaxSokkoPoint; i++) {
                rows[i].Cells[1].Value = this.doc.RawOD[i];
            }
            this.doNotEventHandling = false;
            showWBODInODDataGridView();
        }

        // ODデータグリッドビューの第3列のWB補正値の内容を表示する。(指定行のみ)
        private void showWBODInODDataGridView(int rowIndex) {
            var row = this.odDataGridView.Rows[rowIndex];
            row.Cells[2].Value = this.doc.GetWBOD(rowIndex);
        }

        // ODデータグリッドビューの第3列のWB補正値の内容を表示する。(全行)
        private void showWBODInODDataGridView() {
            int i;
            for (i = 0; i <= Constants.MaxSokkoPoint; i++) {
                this.showWBODInODDataGridView(i);
            }
            showEnzanShikiValueInODDataGridView();
        }

        // ODデータグリッドビューの第4列以降の各演算式の左辺値の列の内容を表示する。(指定行のみ)
        private void showEnzanShikiValueInODDataGridView(int sokkoPoint) {
            int i;
            var row = this.odDataGridView.Rows[sokkoPoint];
            for (i = 0; i < 8; i++) {
                double value;
                bool checkResult;
                var valueCell = row.Cells[3 + i * 2];
                var check_cell = row.Cells[3 + i * 2 + 1];
                if (!this.doc.EvaluateRpcKomokubetsuEnzanShiki(sokkoPoint, i + 1, out value, out checkResult)) {
                    valueCell.Value = "";
                    valueCell.Style.BackColor = Color.DarkGray;
                    check_cell.ReadOnly = true;
                    check_cell.Style.BackColor = Color.DarkGray;
                } else {
                    valueCell.Value = value;
                    valueCell.Style.BackColor = checkResult ? Color.White : Color.Red;
                    check_cell.ReadOnly = false;
                    check_cell.Style.BackColor = Color.White;
                }
            }
        }

        // ODデータグリッドビューの第4列以降の各演算式の左辺値の列の内容を表示する。(全行)
        private void showEnzanShikiValueInODDataGridView() {
            int i;
            for (i = 0; i <= Constants.MaxSokkoPoint; i++) {
                showEnzanShikiValueInODDataGridView(i);
            }
        }

        // OD値リストの全チェックボックスのチェックをはずす
        private void uncheckAllODLCheckBox() {
            var rows = this.odDataGridView.Rows;
            for (int i = 0; i <= Constants.MaxSokkoPoint; i++) {
                for (int j = 0; j < 8; j++) {
                    rows[i].Cells[4 + j * 2].Value = false;
                }
            }
        }

        // "電文ファイル読み込み"、"電文ファイル書き込み"ボタンの有効/無効を設定する。
        private void setOpenAndSaveDenbunFileButtonState() {
            if ((this.doc.KomokuNo <= 0)
                || (this.doc.KentaiShubetsu == KentaiShubetsu.None)
                || (this.doc.SampleShubetsu == 0)) {
                openDenbunFileButton.Enabled = false;
                openDenbunFile2Button.Enabled = false;
                saveDenbunFileButton.Enabled = false;
                saveAsDenbunFileButton.Enabled = false;
                return;
            }
            openDenbunFileButton.Enabled = true;
            openDenbunFile2Button.Enabled = true;
            saveDenbunFileButton.Enabled = this.doc.DenbunFileName != "";
            saveAsDenbunFileButton.Enabled = this.doc.DenbunFileName != "";
        }

        // "Undo"/"Redo"ボタンにundo/redo可能な回数を表示する。
        private void showUndoRedoCount() {
            this.undoButton.Text = "Undo(" + this.doc.UndoableCount.ToString() + ")";
            this.redoButton.Text = "Redo(" + this.doc.RedoableCount.ToString() + ")";
        }

        void saveDenbunFile(string fileName) {
            this.doc.SaveDenbunFile(fileName);
            commit();

            // 画面にも反映する
            showDenbunFileName();
            this.telegramFileForm.SetTelegramFile(this.doc.DenbunFileContents);
        }

        private void showTajuSokuteiNo() {
            this.doNotEventHandling = true;
            this.tajuSokuteiNoComboBox.SelectedIndex = this.doc.TajuSokuteiNo - 1;
            this.doNotEventHandling = false;
        }

        #endregion PRIVATE METHOD

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show(this.doc.ToString());
        }

    }
}
