using System;
using System.Windows.Forms;

namespace NumericUpDownColumn {
    public class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public NumericUpDownEditingControl() {
            this.Maximum = 65535;
        }

        public object EditingControlFormattedValue {
            get {
                return this.Value.ToString();
            }
            set {
                String newValue = value as String;
                if (newValue != null) {
                    this.Value = decimal.Parse(newValue);
                }
            }
        }

        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context) {
            return EditingControlFormattedValue;
        }

        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle) {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex {
            get {
                return rowIndex;
            }
            set {
                rowIndex = value;
            }
        }

        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey) {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode) {
            case Keys.Left:
            case Keys.Up:
            case Keys.Down:
            case Keys.Right:
            case Keys.Home:
            case Keys.End:
            case Keys.PageDown:
            case Keys.PageUp:
                return true;
            default:
                return false;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll) {
            // No preparation needs to be done.
        }

        public bool RepositionEditingControlOnValueChange {
            get {
                return false;
            }
        }

        public DataGridView EditingControlDataGridView {
            get {
                return dataGridView;
            }
            set {
                dataGridView = value;
            }
        }

        public bool EditingControlValueChanged {
            get {
                return valueChanged;
            }
            set {
                valueChanged = value;
            }
        }

        public Cursor EditingPanelCursor {
            get {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs) {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}
