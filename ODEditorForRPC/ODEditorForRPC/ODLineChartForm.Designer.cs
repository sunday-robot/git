namespace ODEditorForRpc {
    partial class ODLineChartForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.zoomRateComboBox = new System.Windows.Forms.ComboBox();
            this.lineChartPanel = new System.Windows.Forms.Panel();
            this.lineChartVScrollBar = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zoomRateComboBox
            // 
            this.zoomRateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomRateComboBox.DropDownHeight = 132;
            this.zoomRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zoomRateComboBox.FormattingEnabled = true;
            this.zoomRateComboBox.IntegralHeight = false;
            this.zoomRateComboBox.Items.AddRange(new object[] {
            "1.00",
            "2.00",
            "3.00",
            "4.00",
            "5.00",
            "6.00",
            "7.00",
            "8.00",
            "9.00",
            "10.00"});
            this.zoomRateComboBox.Location = new System.Drawing.Point(596, 12);
            this.zoomRateComboBox.Name = "zoomRateComboBox";
            this.zoomRateComboBox.Size = new System.Drawing.Size(54, 20);
            this.zoomRateComboBox.TabIndex = 1;
            this.zoomRateComboBox.SelectedIndexChanged += new System.EventHandler(this.zoomRateComboBox_SelectedIndexChanged);
            // 
            // lineChartPanel
            // 
            this.lineChartPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineChartPanel.Location = new System.Drawing.Point(12, 38);
            this.lineChartPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lineChartPanel.Name = "lineChartPanel";
            this.lineChartPanel.Size = new System.Drawing.Size(617, 441);
            this.lineChartPanel.TabIndex = 2;
            this.lineChartPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.lineChartPanel_Paint);
            this.lineChartPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lineChartPanel_MouseClick);
            // 
            // lineChartVScrollBar
            // 
            this.lineChartVScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineChartVScrollBar.Location = new System.Drawing.Point(629, 38);
            this.lineChartVScrollBar.Name = "lineChartVScrollBar";
            this.lineChartVScrollBar.Size = new System.Drawing.Size(21, 441);
            this.lineChartVScrollBar.TabIndex = 0;
            this.lineChartVScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.lineChartVScrollBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "拡大率";
            // 
            // ODLineChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lineChartVScrollBar);
            this.Controls.Add(this.lineChartPanel);
            this.Controls.Add(this.zoomRateComboBox);
            this.Name = "ODLineChartForm";
            this.Text = "ODGraph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ODLineChartForm_FormClosing);
            this.Resize += new System.EventHandler(this.ODLineChartForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox zoomRateComboBox;
        private System.Windows.Forms.Panel lineChartPanel;
        private System.Windows.Forms.VScrollBar lineChartVScrollBar;
        private System.Windows.Forms.Label label1;

    }
}