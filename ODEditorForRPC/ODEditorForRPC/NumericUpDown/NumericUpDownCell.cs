using System;
using System.Windows.Forms;

namespace NumericUpDownColumn {
    public class NumericUpDownCell : DataGridViewTextBoxCell {
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle) {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            var ctl = DataGridView.EditingControl as NumericUpDownEditingControl;
            ctl.Value = decimal.Parse(this.Value.ToString());
        }

        public override Type EditType {
            get {
                return typeof(NumericUpDownEditingControl);
            }
        }

        public override Type ValueType {
            get {
                return typeof(decimal);
            }
        }

        public override object DefaultNewRowValue {
            get {
                return decimal.Zero;
            }
        }
    }

}
