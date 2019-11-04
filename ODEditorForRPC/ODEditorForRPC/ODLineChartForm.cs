using System;
using System.Drawing;
using System.Windows.Forms;

namespace ODEditorForRpc {
    public partial class ODLineChartForm : Form {
        // グラフの上下左右の余白(ドット数)(目盛りはこの余白に表示する)
        const int topMargin = 8;
        const int bottomMargin = 20;
        const int leftMargin = 40;
        const int rightMargin = 8;

        const int maxSokkoPoint = 27;   // 測光ポイントの最大値
        const int maxRawOD = 65535; // 生OD値の最大値

        bool doNotEventHandle;  // グラフ上でマウスホイールすることでズーム率を変更できるようにしているが、
        // この際ズーム率のコンボボックスの選択内容を変更すると、このコンボボックスのSelectedIndexChanged()が
        // 呼び出されてしまう。このフラグ変数は、SelectedIndexChanged()で処理を行うかどうかを判定するのに使用する。
        
        ODEditorForm parentForm;
        int[] rawOD;
        // グラフのOD値の表示域(グラフは縦方向のみ拡大出来る)
        int visibleChartRangeStart;
        int visibleChartRange;

        public ODLineChartForm(ODEditorForm parentForm) {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);    // フォームサイズ変更時にもPaintイベントを発生させる
            this.lineChartPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.lineChartPanel_MouseWheel);

            this.zoomRateComboBox.SelectedIndex = 0;

            this.lineChartVScrollBar.Minimum = 0;
            this.lineChartVScrollBar.Maximum = maxRawOD;
            this.lineChartVScrollBar.LargeChange = maxRawOD + 1;
            
            this.parentForm = parentForm;
            this.rawOD = new int[maxSokkoPoint + 1];
            this.visibleChartRangeStart = 0;
            this.visibleChartRange = 65536;
        }

        // OD値のグラフを描く
        public void DrawChart(int[] rawOD) {
            int i;

            if (rawOD != null) {
                System.Array.Copy(rawOD, this.rawOD, rawOD.Length);
            }

            var c = this.lineChartPanel.ClientRectangle;
            var g = this.lineChartPanel.CreateGraphics();
            var pen = new Pen(Color.Black);
            var light_gray_pen = new Pen(Color.LightGray);
            var font = new Font(FontFamily.GenericMonospace, 8);
            var brush = new SolidBrush(Color.Black);

            g.Clear(Color.White);

            // 目盛り線を描く
            for (i = 0; i < maxSokkoPoint; i++) {
                int w = this.chartWidth;
                int x = leftMargin + (w / 2 + i * w) / maxSokkoPoint;
                g.DrawLine(light_gray_pen, x, topMargin, x, c.Bottom - bottomMargin);
            }

            // X、Y軸を描く
            if (this.visibleChartRangeStart == 0) {
                g.DrawLine(pen, leftMargin, c.Bottom - bottomMargin, c.Right - rightMargin, c.Bottom - bottomMargin);
            }
            g.DrawLine(pen, leftMargin, topMargin, leftMargin, c.Bottom - bottomMargin);

            // X軸の目盛り("0"～"27")を書く
            {
                var stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                for (i = 0; i < this.rawOD.Length; i++) {
                    int w = this.chartWidth / maxSokkoPoint;
                    int x = leftMargin + i * this.chartWidth / maxSokkoPoint - w / 2;
                    int y = c.Bottom - bottomMargin;
                    var rectangle = new Rectangle(x, y, w, bottomMargin);
                    g.DrawString(i.ToString(), font, brush, rectangle, stringFormat);
                }
            }

            // Y軸の目盛り(最小値と最大値のみ)を書く
            {
                var stringFormat = new StringFormat();
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Far;   // 右寄せ
                int x = 0;
                int w = leftMargin;
                g.DrawString((this.visibleChartRangeStart + this.visibleChartRange - 1).ToString(), font, brush, new Rectangle(x, topMargin - 4, w, 8), stringFormat);
                g.DrawString(this.visibleChartRangeStart.ToString(), font, brush, new Rectangle(x, c.Bottom - bottomMargin - 4, w, 8), stringFormat);
            }

            // 生OD値については、グラフの範囲外の描画を行なわないように、クリッピング領域を設定する。
            g.Clip = new Region(new Rectangle(leftMargin - 1, topMargin - 1, this.chartWidth + 2, this.chartHeight + 2));

            // 生OD値をプロットする
            for (i = 0; i < this.rawOD.Length; i++) {
                var p = getPoint(i, this.rawOD[i]);
                p.X--;
                p.Y--;
                g.DrawRectangle(pen, new Rectangle(p, new Size(2, 2)));
            }

            // 生OD値を結ぶ線を描く
            var p1 = getPoint(0, this.rawOD[0]);
            for (i = 0; i < this.rawOD.Length; i++) {
                var p2 = getPoint(i, this.rawOD[i]);
                g.DrawLine(pen, p1, p2);
                p1 = p2;
            }
        }

        #region イベントハンドラー

        private void ODLineChartForm_FormClosing(object sender, FormClosingEventArgs e) {
            // 呼び出し元の処理が面倒になるので、破棄せず、非表示にする。
            e.Cancel = true;
            this.Hide();
        }

        private void ODLineChartForm_Resize(object sender, EventArgs e) {
            this.lineChartPanel.Invalidate();
        }

        private void zoomRateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.doNotEventHandle)
                return;

            changeChartZoomRate(this.visibleChartRangeStart + this.visibleChartRange / 2);
        }

        private void lineChartPanel_Paint(object sender, PaintEventArgs e) {
            DrawChart(null);
        }

        private void lineChartPanel_MouseClick(object sender, MouseEventArgs e) {
            if (!lineChartPanel.Focused) {
                lineChartPanel.Focus(); // マウスホイールイベントを発生させるため、フォーカスを取得する
            }

            int sokkoPoint;
            int rawOD;

            sokkoPoint = mouseXToSokkoPoint(e.X);
            rawOD = mouseYToRawOD(e.Y);
            if ((sokkoPoint < 0) || (rawOD < 0))
                return;
            this.rawOD[sokkoPoint] = rawOD;
            this.lineChartPanel.Invalidate();

            this.parentForm.SetRawOD(sokkoPoint, rawOD);
        }

        private void lineChartPanel_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e) {
            int centerOD = mouseYToRawOD(e.Y);
            if (centerOD < 0)
                return;

            int si = this.zoomRateComboBox.SelectedIndex;
            if (e.Delta < 0) {  // ホイールダウン時は縮小
                if (si == 0)
                    return;
                si--;
            } else {            // ホイールアップ時は拡大
                if (si == this.zoomRateComboBox.Items.Count - 1)
                    return;
                si++;
            }

            this.doNotEventHandle = true;
            this.zoomRateComboBox.SelectedIndex = si;
            this.doNotEventHandle = false;

            changeChartZoomRate(centerOD);
        }

        private void lineChartVScrollBar_Scroll(object sender, ScrollEventArgs e) {
            this.visibleChartRangeStart = maxRawOD - this.visibleChartRange + 1 - this.lineChartVScrollBar.Value;
            this.lineChartPanel.Invalidate();
            //            var x = this.lineChartVScrollBar;
            //            this.Text = x.Value + "(" + x.Minimum + " ～ " + x.Maximum + "," + x.LargeChange + ")";
        }

        #endregion イベントハンドラー

        ///////////////////////////////////////////////////////////////////////

        int chartWidth {
            get {
                return this.lineChartPanel.ClientRectangle.Width - leftMargin - rightMargin;
            }
        }

        int chartHeight {
            get {
                return this.lineChartPanel.ClientRectangle.Height - topMargin - bottomMargin;
            }
        }

        // 測光ポイントと生OD値に対応する画面座標を返す
        Point getPoint(int sokkoPoint, int rawOD) {
            int x = this.lineChartPanel.ClientRectangle.Left + leftMargin + sokkoPoint * this.chartWidth / maxSokkoPoint;
            int y = this.lineChartPanel.ClientRectangle.Bottom - bottomMargin - (rawOD - this.visibleChartRangeStart) * this.chartHeight / this.visibleChartRange;
            return new Point(x, y);
        }

        int mouseXToSokkoPoint(int mouseX) {
            int x = mouseX - this.lineChartPanel.ClientRectangle.X - leftMargin;

            if ((x < 0) || (x > this.chartWidth))
                return -1;
            return (x * maxSokkoPoint + this.chartWidth / 2) / this.chartWidth;
        }

        int mouseYToRawOD(int mouseY) {
            int y = this.chartHeight - (mouseY - this.lineChartPanel.ClientRectangle.Y - topMargin);

            if ((y < 0) || (y > this.chartHeight))
                return -1;
            return this.visibleChartRangeStart + y * this.visibleChartRange / this.chartHeight;
        }

        void changeChartZoomRate(int centerOD) {
            double zoomRate = double.Parse(this.zoomRateComboBox.Text);
            int newRange = (int) (65536 / zoomRate);
            int newRangeStart = (int) (centerOD - (double) (centerOD - this.visibleChartRangeStart) * newRange / this.visibleChartRange);

            if (newRangeStart < 0)
                newRangeStart = 0;
            else if (newRangeStart + newRange > maxRawOD)
                newRangeStart = maxRawOD - newRange + 1;

            this.visibleChartRangeStart = newRangeStart;
            this.visibleChartRange = newRange;

            this.lineChartVScrollBar.Value = maxRawOD - this.visibleChartRange + 1 - this.visibleChartRangeStart;
            this.lineChartVScrollBar.LargeChange = this.visibleChartRange;
            this.lineChartPanel.Invalidate();
        }

    }
}
