namespace ODEditorForRpc {
    partial class TelegramFileForm {
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
            this.telegramFileTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // telegramFileTextBox
            // 
            this.telegramFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.telegramFileTextBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (128)));
            this.telegramFileTextBox.Location = new System.Drawing.Point(12, 12);
            this.telegramFileTextBox.Multiline = true;
            this.telegramFileTextBox.Name = "telegramFileTextBox";
            this.telegramFileTextBox.ReadOnly = true;
            this.telegramFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.telegramFileTextBox.Size = new System.Drawing.Size(557, 481);
            this.telegramFileTextBox.TabIndex = 0;
            this.telegramFileTextBox.WordWrap = false;
            // 
            // TelegramFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 505);
            this.Controls.Add(this.telegramFileTextBox);
            this.Name = "TelegramFileForm";
            this.Text = "TelegramFileForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelegramFileForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox telegramFileTextBox;
    }
}