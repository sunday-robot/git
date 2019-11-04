using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ODEditorForRpc {
    public partial class TelegramFileForm : Form {
        public TelegramFileForm() {
            InitializeComponent();
        }

        private void TelegramFileForm_FormClosing(object sender, FormClosingEventArgs e) {
            // 呼び出し元の処理が面倒になるので、破棄せず、非表示にする。
            e.Cancel = true;
            this.Hide();
        }

        public void SetTelegramFile(string contents) {
            this.telegramFileTextBox.Text = contents;
        }
    }
}
